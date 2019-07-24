using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using VisualAzureStudio.Models.Components;
using VisualAzureStudio.Models.Connections;

namespace VisualAzureStudio
{
    public partial class ComponentControl : UserControl
    {
        public event EventHandler Selected;
        public event EventHandler Deleted;
      
        public ComponentControl()
        {
            InitializeComponent();
        }

        private Control activeControl;
        private Point previousLocation;

        private void componentControl_MouseDown(object sender, MouseEventArgs e)
        {
            Selected?.Invoke(this, new EventArgs());

            if (e.Button != MouseButtons.Left) {
                return;
            }

            switch (sender) {
                case ComponentControl _:
                    activeControl = sender as Control;
                    break;
                case PictureBox _:
                case TextBox _:
                case Label _:
                    activeControl = (sender as Control).Parent;
                    break;
            }

            if (activeControl.GetType() != typeof(ComponentControl)) {
                Debugger.Break();
            }

            previousLocation = e.Location;
        }

        private void componentControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (activeControl == null || activeControl != sender) {
                return;
            }

            Point location = activeControl.Location;
            location.Offset(e.Location.X - previousLocation.X, e.Location.Y - previousLocation.Y);
            activeControl.Location = location;
            Parent.Invalidate();
        }

        private void componentControl_MouseUp(object sender, MouseEventArgs e)
        {
            activeControl = null;
        }

        private void ComponentControl_LocationChanged(object sender, EventArgs e)
        {
            ((ComponentBase)Tag).Location = Location;
        }

        private void ContextMenu_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // determine allowed connection types and populate the Connect To menu
            ConnectToMenuItem.DropDownItems.Clear();

            ComponentBase tagComponent = (ComponentBase)Tag;

            foreach (ComponentBase component in Form1.design.Components.Where(c => c != Tag)) {
                // skip if connection is not allowed
                List<AllowedConnection> allowedConnections = AllowedConnections.Allowed.Where(a => a.Item1 == tagComponent.GetType() && a.Item2 == component.GetType() || a.Item1 == component.GetType() && a.Item2 == tagComponent.GetType()).ToList();

                if (allowedConnections.Count == 0) {
                    continue;
                }

                // skip if connection already exists
                if (Form1.design.Connections.Any(c => c.Item1Id == component.Id && c.Item2Id == tagComponent.Id || c.Item1Id == tagComponent.Id && c.Item2Id == component.Id)) {
                    continue;
                }

                ToolStripButton toolStripButton = new ToolStripButton {
                    Text = component.Name,
                    Tag = new Tuple<ComponentBase, ComponentBase, Type>(component, tagComponent, allowedConnections.First().Item3),
                    Width = 128
                };

                toolStripButton.Click += ComponentControl_Click;
                ConnectToMenuItem.DropDownItems.Add(toolStripButton);
            }
        }

        private void ComponentControl_Click(object sender, EventArgs e)
        {
            Tuple<ComponentBase, ComponentBase, Type> items = (sender as ToolStripItem).Tag as Tuple<ComponentBase, ComponentBase, Type>;

            ConnectionBase newConnection = (ConnectionBase)Activator.CreateInstance(items.Item3);
            newConnection.Item1Id = items.Item1.Id;
            newConnection.Item2Id = items.Item2.Id;

            Form1.design.Connections.Add(newConnection);
            Form1.design.IsDirty = true;

            Parent.Invalidate();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ComponentBase component = Tag as ComponentBase;

            if (MessageBox.Show($"Delete {component.TypeDescription} \"{component.Name}\"?", "Visual Azure Studio", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                Deleted?.Invoke(this, new EventArgs());
            }
        }
    }
}
