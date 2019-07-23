namespace VisualAzureStudio
{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("App Service", 0);
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("Key Vault", 1);
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("SQL Database", 2);
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem("MSI", 3);
            this.Canvas = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.TerraformTextBox = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.ArmTemplateTextBox = new System.Windows.Forms.TextBox();
            this.ImageList16 = new System.Windows.Forms.ImageList(this.components);
            this.ToolBoxListView = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.ImageList32 = new System.Windows.Forms.ImageList(this.components);
            this.PropertyGrid = new System.Windows.Forms.PropertyGrid();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FileOpenMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FileSaveAsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.FileExitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.FileNewMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Canvas
            // 
            this.Canvas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Canvas.BackColor = System.Drawing.SystemColors.Window;
            this.Canvas.Location = new System.Drawing.Point(127, 44);
            this.Canvas.Name = "Canvas";
            this.Canvas.Size = new System.Drawing.Size(725, 401);
            this.Canvas.TabIndex = 0;
            this.Canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.Canvas_Paint);
            this.Canvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Canvas_MouseDown);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(13, 452);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1146, 131);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.TerraformTextBox);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1138, 105);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Terraform";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // TerraformTextBox
            // 
            this.TerraformTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TerraformTextBox.Location = new System.Drawing.Point(3, 3);
            this.TerraformTextBox.Multiline = true;
            this.TerraformTextBox.Name = "TerraformTextBox";
            this.TerraformTextBox.Size = new System.Drawing.Size(1132, 99);
            this.TerraformTextBox.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.ArmTemplateTextBox);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(767, 105);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "ARM Template";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // ArmTemplateTextBox
            // 
            this.ArmTemplateTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ArmTemplateTextBox.Location = new System.Drawing.Point(3, 3);
            this.ArmTemplateTextBox.Multiline = true;
            this.ArmTemplateTextBox.Name = "ArmTemplateTextBox";
            this.ArmTemplateTextBox.Size = new System.Drawing.Size(761, 99);
            this.ArmTemplateTextBox.TabIndex = 1;
            // 
            // ImageList16
            // 
            this.ImageList16.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList16.ImageStream")));
            this.ImageList16.TransparentColor = System.Drawing.Color.Transparent;
            this.ImageList16.Images.SetKeyName(0, "App Service 16.png");
            this.ImageList16.Images.SetKeyName(1, "Key Vault 16a.png");
            this.ImageList16.Images.SetKeyName(2, "SQL 16.png");
            this.ImageList16.Images.SetKeyName(3, "MSI 16.png");
            // 
            // ToolBoxListView
            // 
            this.ToolBoxListView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ToolBoxListView.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4});
            this.ToolBoxListView.Location = new System.Drawing.Point(13, 44);
            this.ToolBoxListView.Name = "ToolBoxListView";
            this.ToolBoxListView.Size = new System.Drawing.Size(108, 401);
            this.ToolBoxListView.SmallImageList = this.ImageList16;
            this.ToolBoxListView.TabIndex = 4;
            this.ToolBoxListView.UseCompatibleStateImageBehavior = false;
            this.ToolBoxListView.View = System.Windows.Forms.View.SmallIcon;
            this.ToolBoxListView.ItemActivate += new System.EventHandler(this.listView1_ItemActivate);
            this.ToolBoxListView.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Toolbox";
            // 
            // ImageList32
            // 
            this.ImageList32.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList32.ImageStream")));
            this.ImageList32.TransparentColor = System.Drawing.Color.Transparent;
            this.ImageList32.Images.SetKeyName(0, "App Service 32.png");
            this.ImageList32.Images.SetKeyName(1, "Key Vault 32a.png");
            this.ImageList32.Images.SetKeyName(2, "SQL 32.png");
            this.ImageList32.Images.SetKeyName(3, "MSI 32.png");
            // 
            // PropertyGrid
            // 
            this.PropertyGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PropertyGrid.Location = new System.Drawing.Point(858, 44);
            this.PropertyGrid.Name = "PropertyGrid";
            this.PropertyGrid.Size = new System.Drawing.Size(301, 402);
            this.PropertyGrid.TabIndex = 7;
            this.PropertyGrid.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.PropertyGrid_PropertyValueChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1171, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileNewMenuItem,
            this.toolStripSeparator1,
            this.FileOpenMenuItem,
            this.FileSaveAsMenuItem,
            this.toolStripMenuItem1,
            this.FileExitMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // FileOpenMenuItem
            // 
            this.FileOpenMenuItem.Name = "FileOpenMenuItem";
            this.FileOpenMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.FileOpenMenuItem.Size = new System.Drawing.Size(180, 22);
            this.FileOpenMenuItem.Text = "Open...";
            this.FileOpenMenuItem.Click += new System.EventHandler(this.FileOpenMenuItem_Click);
            // 
            // FileSaveAsMenuItem
            // 
            this.FileSaveAsMenuItem.Name = "FileSaveAsMenuItem";
            this.FileSaveAsMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.FileSaveAsMenuItem.Size = new System.Drawing.Size(180, 22);
            this.FileSaveAsMenuItem.Text = "Save As...";
            this.FileSaveAsMenuItem.Click += new System.EventHandler(this.FileSaveAsMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(177, 6);
            // 
            // FileExitMenuItem
            // 
            this.FileExitMenuItem.Name = "FileExitMenuItem";
            this.FileExitMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.FileExitMenuItem.Size = new System.Drawing.Size(180, 22);
            this.FileExitMenuItem.Text = "Exit";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(130, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Canvas";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(855, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Properties";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // FileNewMenuItem
            // 
            this.FileNewMenuItem.Name = "FileNewMenuItem";
            this.FileNewMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.FileNewMenuItem.Size = new System.Drawing.Size(180, 22);
            this.FileNewMenuItem.Text = "New";
            this.FileNewMenuItem.Click += new System.EventHandler(this.FileNewMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1171, 595);
            this.Controls.Add(this.PropertyGrid);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ToolBoxListView);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.Canvas);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Visual Azure Studio";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel Canvas;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox TerraformTextBox;
        private System.Windows.Forms.TextBox ArmTemplateTextBox;
        private System.Windows.Forms.ImageList ImageList16;
        private System.Windows.Forms.ListView ToolBoxListView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ImageList ImageList32;
        private System.Windows.Forms.PropertyGrid PropertyGrid;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FileOpenMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FileSaveAsMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem FileExitMenuItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripMenuItem FileNewMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}

