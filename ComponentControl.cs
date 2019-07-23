using System;
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
        public event SelectedEventHandler Selected;
        public delegate void SelectedEventHandler(object sender, EventArgs e);

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
                case TextBox _:
                case Label _:
                    activeControl = (sender as Control).Parent;
                    break;
            }

            if (activeControl.GetType() != typeof(ComponentControl)) {
                Debugger.Break();
                ;
            }

            previousLocation = e.Location;
            Cursor = Cursors.Hand;
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
            Cursor = Cursors.Default;
        }

        private void ComponentControl_LocationChanged(object sender, EventArgs e)
        {
            ((ComponentBase)Tag).Location = Location;
        }

        private void ContextMenu_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // determine allowed connection types and populate the Connect To menu
            ConnectToMenuItem.DropDownItems.Clear();

            foreach (ComponentBase component in Form1.design.Components.Where(c => c != Tag)) {
                if (!AllowedConnections.Allowed.Any(a => a.Item1 == Tag.GetType() && a.Item2 == component.GetType() || a.Item1 == component.GetType() && a.Item2 == Tag.GetType())) {
                    continue;
                }

                ToolStripButton toolStripButton = new ToolStripButton {
                    Text = component.Name,
                    Tag = new Tuple<ComponentBase, ComponentBase>(component, Tag as ComponentBase)
                };

                toolStripButton.Click += ComponentControl_Click;
                ConnectToMenuItem.DropDownItems.Add(toolStripButton);
            }
        }

        private void ComponentControl_Click(object sender, EventArgs e)
        {
            Tuple<ComponentBase, ComponentBase> items = (sender as ToolStripItem).Tag as Tuple<ComponentBase, ComponentBase>;
            Form1.design.Connections.Add(new MsiSqlDatabaseConnection { Item1Id = items.Item1.Id, Item2Id = items.Item2.Id });
            Parent.Invalidate();
        }
    }
}
