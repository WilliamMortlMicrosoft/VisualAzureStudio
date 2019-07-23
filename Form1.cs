using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json;
using VisualAzureStudio.Models;
using VisualAzureStudio.Models.Components;
using VisualAzureStudio.Models.Connections;

namespace VisualAzureStudio
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView1_ItemActivate(object sender, EventArgs e)
        {
            switch (ToolBoxListView.SelectedItems[0].Text) {
                case "App Service":
                    NewComponentControl(
                        new AppService {
                            Name = GetFreeName("App Service", design),
                            Location = GetFreeLocation(design)
                        },
                        false);
                    break;

                case "Key Vault":
                    NewComponentControl(
                        new KeyVault {
                            Name = GetFreeName("Key Vault", design),
                            Location = GetFreeLocation(design)
                        },
                        false);
                    break;

                case "SQL Database":
                    NewComponentControl(
                        new SqlDatabase {
                            Name = GetFreeName("SQL Server", design),
                            Location = GetFreeLocation(design)
                        },
                        false);
                    break;

                case "MSI":
                    NewComponentControl(
                        new Msi {
                            Name = GetFreeName("MSI", design),
                            Location = GetFreeLocation(design)
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
                return typeDescription + " 1";
            }

            int resultIndex = 0;
            bool nameUnique = false;

            string testName = string.Empty;

            while (!nameUnique) {
                resultIndex++;
                testName = typeDescription + " " + resultIndex;
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
                BackColor = newComponent.BackColor
            };

            newComponentControl.Selected += component_Selected;

            if (!existing) {
                design.Components.Add(newComponent);
            }

            Canvas.Controls.Add(newComponentControl);
            PropertyGrid.SelectedObject = newComponent;
        }

        private void component_Selected(object sender, EventArgs e)
        {
            PropertyGrid.SelectedObject = (sender as Control).Tag;
        }

        private void PropertyGrid_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            if (e.ChangedItem.Label == "Name") {
                ((ComponentBase)PropertyGrid.SelectedObject).Name = (string)e.ChangedItem.Value;
            }
        }

        private void FileSaveAsMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dialog = new SaveFileDialog()) {
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

                File.WriteAllText(dialog.FileName, JsonConvert.SerializeObject(design, settings));
                design.Path = dialog.FileName;
            }
        }

        internal static Design design { get; private set; } = new Design();

        private void Canvas_MouseDown(object sender, MouseEventArgs e)
        {
            // check if mouse clicked on line

            // if not on line, then select whole design

            PropertyGrid.SelectedObject = design;
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
            CalculateLines(design);
            DrawLines(design, e.Graphics);
        }

        private void DrawLines(Design design1, Graphics graphics)
        {
            Pen pen = new Pen(Color.Silver, 5);

            foreach (ConnectionBase connection in design.Connections) {
                graphics.DrawLines(pen, new[] { connection.Start, new Point(connection.End.X, connection.Start.Y), connection.End });
            }
        }

        private void CalculateLines(Design design1)
        {
            foreach (ConnectionBase connection in design.Connections) {
                connection.Start = design.Components.First(c => c.Id == connection.Item1Id).Location.OffsetPoint(75, 34);
                connection.End = design.Components.First(c => c.Id == connection.Item2Id).Location.OffsetPoint(75, 34);
            }
        }

        private void FileNewMenuItem_Click(object sender, EventArgs e)
        {
            Canvas.Controls.Clear();
            design = new Design();
            Canvas.Invalidate();
        }

        private void GenerateButton_Click(object sender, EventArgs e)
        {
            if (design.Path == null) {
                // design must be saved first to establish the path
                FileSaveAsMenuItem_Click(this, new EventArgs());
            }

            if (design.Path == null) {
                return;
            }

            string outputFolder = Path.Combine(Path.GetDirectoryName(design.Path), Path.GetFileNameWithoutExtension(design.Path)) + "_output";

            // call generate method here

            throw new NotImplementedException();
        }
    }
}
