namespace VisualAzureStudio
{
    partial class ComponentControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ComponentTypeImage = new System.Windows.Forms.PictureBox();
            this.ComponnentTypeLabel = new System.Windows.Forms.Label();
            this.ResourceGroupLabel = new System.Windows.Forms.Label();
            this.NameLabel = new System.Windows.Forms.Label();
            this.ContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ConnectToMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.ComponentTypeImage)).BeginInit();
            this.ContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // ComponentTypeImage
            // 
            this.ComponentTypeImage.Location = new System.Drawing.Point(0, 0);
            this.ComponentTypeImage.Name = "ComponentTypeImage";
            this.ComponentTypeImage.Size = new System.Drawing.Size(32, 32);
            this.ComponentTypeImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ComponentTypeImage.TabIndex = 0;
            this.ComponentTypeImage.TabStop = false;
            // 
            // ComponnentTypeLabel
            // 
            this.ComponnentTypeLabel.AutoSize = true;
            this.ComponnentTypeLabel.Location = new System.Drawing.Point(0, 36);
            this.ComponnentTypeLabel.Name = "ComponnentTypeLabel";
            this.ComponnentTypeLabel.Size = new System.Drawing.Size(92, 13);
            this.ComponnentTypeLabel.TabIndex = 1;
            this.ComponnentTypeLabel.Text = "Component Name";
            this.ComponnentTypeLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.componentControl_MouseDown);
            this.ComponnentTypeLabel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.componentControl_MouseMove);
            this.ComponnentTypeLabel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.componentControl_MouseUp);
            // 
            // ResourceGroupLabel
            // 
            this.ResourceGroupLabel.AutoSize = true;
            this.ResourceGroupLabel.Location = new System.Drawing.Point(0, 53);
            this.ResourceGroupLabel.Name = "ResourceGroupLabel";
            this.ResourceGroupLabel.Size = new System.Drawing.Size(29, 13);
            this.ResourceGroupLabel.TabIndex = 2;
            this.ResourceGroupLabel.Text = "RG: ";
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(38, 10);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(17, 13);
            this.NameLabel.TabIndex = 3;
            this.NameLabel.Text = "\"\"";
            // 
            // ContextMenu
            // 
            this.ContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ConnectToMenuItem});
            this.ContextMenu.Name = "ContextMenu";
            this.ContextMenu.ShowImageMargin = false;
            this.ContextMenu.Size = new System.Drawing.Size(156, 48);
            this.ContextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.ContextMenu_Opening);
            // 
            // ConnectToMenuItem
            // 
            this.ConnectToMenuItem.Name = "ConnectToMenuItem";
            this.ConnectToMenuItem.Size = new System.Drawing.Size(110, 22);
            this.ConnectToMenuItem.Text = "Connect To";
            // 
            // ComponentControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ContextMenuStrip = this.ContextMenu;
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.ResourceGroupLabel);
            this.Controls.Add(this.ComponnentTypeLabel);
            this.Controls.Add(this.ComponentTypeImage);
            this.Name = "ComponentControl";
            this.Size = new System.Drawing.Size(150, 68);
            this.LocationChanged += new System.EventHandler(this.ComponentControl_LocationChanged);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.componentControl_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.componentControl_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.componentControl_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.ComponentTypeImage)).EndInit();
            this.ContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.PictureBox ComponentTypeImage;
        public System.Windows.Forms.Label ComponnentTypeLabel;
        public System.Windows.Forms.Label ResourceGroupLabel;
        public System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.ContextMenuStrip ContextMenu;
        private System.Windows.Forms.ToolStripMenuItem ConnectToMenuItem;
    }
}
