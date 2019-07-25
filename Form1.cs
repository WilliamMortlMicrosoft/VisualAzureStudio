using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using VisualAzureStudio.Models;
using VisualAzureStudio.Models.Components;
using VisualAzureStudio.Models.Connections;
using VisualAzureStudio.Properties;
using VisualAzureStudio.Rules;

namespace VisualAzureStudio
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ToolBoxListView_ItemActivate(object sender, EventArgs e)
        {
            switch (ToolBoxListView.SelectedItems[0].Text) {
                case "App Service":
                    NewComponentControl(
                        new AppService {
                            Name = GetFreeName("AppService", design),
                            Location = GetFreeLocation(design),
                            ResourceGroup = design.GetCommonResourceGroup()
                        },
                        false);
                    break;

                case "Key Vault":
                    NewComponentControl(
                        new KeyVault {
                            Name = GetFreeName("KeyVault", design),
                            Location = GetFreeLocation(design),
                            ResourceGroup = design.GetCommonResourceGroup()
                        },
                        false);
                    break;

                case "SQL Server":
                    NewComponentControl(
                        new SqlServer {
                            Name = GetFreeName("SQLServer", design),
                            Location = GetFreeLocation(design),
                            ResourceGroup = design.GetCommonResourceGroup()
                        },
                        false);
                    break;

                case "SQL Database":
                    NewComponentControl(
                        new SqlDatabase {
                            Name = GetFreeName("SQLDatabase", design),
                            Location = GetFreeLocation(design),
                            ResourceGroup = design.GetCommonResourceGroup()
                        },
                        false);
                    break;

                case "Managed Identity":
                    NewComponentControl(
                        new Msi {
                            Name = GetFreeName("ManagedIdentity", design),
                            Location = GetFreeLocation(design),
                            ResourceGroup = design.GetCommonResourceGroup()
                        },
                        false);
                    break;
                case "Kubernetes Service":
                    NewComponentControl(
                        new Aks {
                            Name = GetFreeName("AKS", design),
                            Location = GetFreeLocation(design),
                            ResourceGroup = design.GetCommonResourceGroup()
                        },
                        false);
                    break;
            }
        }

        private Point GetFreeLocation(Design design)
        {
            if ((design?.Components?.Count ?? 0) == 0) {
                return new Point(0, 0);
            }

            return new Point(design.Components.Max(c => c.Location.X) + 158, 0);
        }

        private string GetFreeName(string typeDescription, Design design)
        {
            if (typeDescription == null) {
                throw new ArgumentNullException(nameof(typeDescription));
            }

            if (design == null) {
                throw new ArgumentNullException(nameof(design));
            }

            if ((design.Components?.Count ?? 0) == 0) {
                return typeDescription + "1";
            }

            int resultIndex = 0;
            bool nameUnique = false;

            string testName = string.Empty;

            while (!nameUnique) {
                resultIndex++;
                testName = typeDescription + resultIndex;
                nameUnique = !design.Components?.Any(c => c.Name.Equals(testName, StringComparison.InvariantCultureIgnoreCase)) ?? false;
            }

            return testName;
        }

        private void NewComponentControl(ComponentBase newComponent, bool existing)
        {
            ComponentControl newComponentControl = new ComponentControl {
                Tag = newComponent,
                Location = newComponent.Location,
                ComponentTypeImage = { Image = ImageList32.Images[newComponent.ImageIndex] },
                ComponnentTypeLabel = { Text = newComponent.TypeDescription },
                NameLabel = { Text = newComponent.Name },
                ResourceGroupLabel = { Text = "RG: " + newComponent.ResourceGroup },
                BackColor = newComponent.BackColor
            };

            newComponentControl.Selected += component_Selected;
            newComponentControl.Deleted += component_Deleted;

            if (!existing) {
                design.Components.Add(newComponent);
                design.IsDirty = true;
            }

            Canvas.Controls.Add(newComponentControl);
            SwitchObjectSelection(newComponent);
        }

        private void component_Deleted(object sender, EventArgs eventArgs)
        {
            ComponentBase componentBeingDeleted = (sender as Control).Tag as ComponentBase;

            // delete any related connections

            design.Connections.RemoveAll(c => c.Item1Id == componentBeingDeleted.Id || c.Item2Id == componentBeingDeleted.Id);

            // delete object

            design.Components.Remove(componentBeingDeleted);

            design.IsDirty = true;

            // delete control

            Canvas.Controls.Remove(sender as Control);
            Canvas.Invalidate();
        }

        private void SwitchObjectSelection(object component)
        {
            PropertyGrid.SelectedObject = component;

            switch (component) {
                case Design design:
                    PropertiesLabel.Text = "Properties for Design";
                    break;
                case ConnectionBase connectionBase:
                    PropertiesLabel.Text = "Properties for Connection";
                    break;
                case ComponentBase componentBase:
                    PropertiesLabel.Text = "Properties for " + componentBase.Name;
                    break;
            }
        }

        private void component_Selected(object sender, EventArgs e)
        {
            SwitchObjectSelection((sender as Control)?.Tag as ComponentBase);
        }

        private void PropertyGrid_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            switch (e.ChangedItem.Label) {
                case "Name":
                    ((ComponentBase)PropertyGrid.SelectedObject).Name = (string)e.ChangedItem.Value;

                    // update UI

                    foreach (ComponentControl control in Canvas.Controls.OfType<ComponentControl>()) {
                        if (control.Tag == PropertyGrid.SelectedObject) {
                            control.NameLabel.Text = (string)e.ChangedItem.Value;
                        }
                    }

                    break;
                case "ResourceGroup":
                    ((ComponentBase)PropertyGrid.SelectedObject).ResourceGroup = (string)e.ChangedItem.Value;

                    // update UI

                    foreach (ComponentControl control in Canvas.Controls.OfType<ComponentControl>()) {
                        if (control.Tag == PropertyGrid.SelectedObject) {
                            control.ResourceGroupLabel.Text = "RG: " + (string)e.ChangedItem.Value;
                        }
                    }

                    break;
            }
        }

        private void FileSaveAsMenuItem_Click(object sender, EventArgs e)
        {
            SaveDesign();
        }

        private static void SaveDesign()
        {
            if (design.Path != null) {
                WriteDesignFile(design, design.Path);
                return;
            }

            using (SaveFileDialog dialog = new SaveFileDialog()) {
                dialog.AddExtension = true;
                dialog.DefaultExt = "*.vas";
                dialog.Filter = "Visual Azure Studio files (*.vas)|*.vas";

                if (dialog.ShowDialog() != DialogResult.OK) {
                    return;
                }

                WriteDesignFile(design, dialog.FileName);
                design.Path = dialog.FileName;
            }
        }

        private static void WriteDesignFile(Design design, string fileName)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings {
                TypeNameHandling = TypeNameHandling.Auto,
                Formatting = Formatting.Indented
            };

            File.WriteAllText(fileName, JsonConvert.SerializeObject(design, settings));
            design.IsDirty = false;
        }

        internal static Design design { get; private set; } = new Design();

        private void Canvas_MouseDown(object sender, MouseEventArgs e)
        {
            // check if mouse clicked on line

            ConnectionBase connection = design.FindByPoint(e.Location, 5);

            if (connection != null) {
                SwitchObjectSelection(connection);
                return;
            }

            // if not on line, then select whole design

            SwitchObjectSelection(design);
        }

        private void FileOpenMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog()) {
                dialog.AddExtension = true;
                dialog.DefaultExt = "*.vas";
                dialog.Filter = "Visual Azure Studio files (*.vas)|*.vas";

                if (dialog.ShowDialog() != DialogResult.OK) {
                    return;
                }

                JsonSerializerSettings settings = new JsonSerializerSettings {
                    TypeNameHandling = TypeNameHandling.Auto,
                    Formatting = Formatting.Indented
                };

                ResetCanvas(JsonConvert.DeserializeObject<Design>(File.ReadAllText(dialog.FileName), settings));

                design.Path = dialog.FileName;
            }

            Canvas.Invalidate();
        }

        private void ResetCanvas(Design newDesign)
        {
            Canvas.Controls.Clear();
            design = newDesign;

            if (design.Components == null) {
                return;
            }

            foreach (ComponentBase component in design.Components) {
                NewComponentControl(component, true);
            }
        }

        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            design.CalculateLines();
            design.DrawLines(e.Graphics);
        }

        private void FileNewMenuItem_Click(object sender, EventArgs e)
        {
            Canvas.Controls.Clear();
            design = new Design();
            Canvas.Invalidate();
        }

        private void GenerateButton_Click(object sender, EventArgs e)
        {
            // check for violations

            List<Violation> violations = design.GetViolations();

            if (violations != null && violations.Count > 0) {
                MessageBox.Show(violations.Select(v => v.Description).Aggregate((a, b) => a + "\r\n" + b), Resources.ProgramName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (design.Path == null) {
                // design must be saved first to establish the path
                FileSaveAsMenuItem_Click(this, new EventArgs());
            }

            if (design.Path == null) {
                return;
            }

            string outputFolder = Path.Combine(Path.GetDirectoryName(design.Path), Path.GetFileNameWithoutExtension(design.Path)) + "_output";

            if (!Helper.GenerateAZ(design, outputFolder)) {
                return;
            }

            Process process = new Process {
                StartInfo = {
                    FileName = "notepad.exe",
                    Arguments = Path.Combine(Path.GetDirectoryName(design.Path), Path.GetFileNameWithoutExtension(design.Path)+"_output","azcommands.txt"),
                    WindowStyle = ProcessWindowStyle.Normal
                }
            };

            process.Start();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (design.IsDirty) {
                DialogResult result = MessageBox.Show("Save design before exiting?", Resources.ProgramName, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (result == DialogResult.Cancel) {
                    e.Cancel = true;
                    return;
                }

                if (result == DialogResult.Yes) {

                }

                e.Cancel = false;
            }
        }
    }
}
