namespace MapViewer
{
    partial class GLMapViewForm
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
            if (disposing && (components != null))
            {
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
            this.glMapControl = new MapViewer.View.OpenGL.GLMapControl();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.ファイルToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.開くToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.地図ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.他の地図を開くToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.direct3Dの地図を開くToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.button = new System.Windows.Forms.Button();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // glMapControl
            // 
            this.glMapControl.BackColor = System.Drawing.Color.Black;
            this.glMapControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.glMapControl.Location = new System.Drawing.Point(0, 24);
            this.glMapControl.Name = "glMapControl";
            this.glMapControl.Size = new System.Drawing.Size(984, 841);
            this.glMapControl.TabIndex = 0;
            this.glMapControl.VSync = false;
            this.glMapControl.Paint += new System.Windows.Forms.PaintEventHandler(this.OnPaintMap);
            this.glMapControl.Resize += new System.EventHandler(this.OnResize);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ファイルToolStripMenuItem,
            this.地図ToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(984, 24);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
            // 
            // ファイルToolStripMenuItem
            // 
            this.ファイルToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.開くToolStripMenuItem});
            this.ファイルToolStripMenuItem.Name = "ファイルToolStripMenuItem";
            this.ファイルToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.ファイルToolStripMenuItem.Text = "ファイル";
            // 
            // 開くToolStripMenuItem
            // 
            this.開くToolStripMenuItem.Name = "開くToolStripMenuItem";
            this.開くToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.開くToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.開くToolStripMenuItem.Text = "開く";
            this.開くToolStripMenuItem.Click += new System.EventHandler(this.OnClickFileOpen);
            // 
            // 地図ToolStripMenuItem
            // 
            this.地図ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.他の地図を開くToolStripMenuItem,
            this.direct3Dの地図を開くToolStripMenuItem});
            this.地図ToolStripMenuItem.Name = "地図ToolStripMenuItem";
            this.地図ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.地図ToolStripMenuItem.Text = "地図";
            // 
            // 他の地図を開くToolStripMenuItem
            // 
            this.他の地図を開くToolStripMenuItem.Name = "他の地図を開くToolStripMenuItem";
            this.他の地図を開くToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.他の地図を開くToolStripMenuItem.Text = "標準の地図を開く";
            this.他の地図を開くToolStripMenuItem.Click += new System.EventHandler(this.OnOpenOtherMap);
            // 
            // direct3Dの地図を開くToolStripMenuItem
            // 
            this.direct3Dの地図を開くToolStripMenuItem.Name = "direct3Dの地図を開くToolStripMenuItem";
            this.direct3Dの地図を開くToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.direct3Dの地図を開くToolStripMenuItem.Text = "Direct3Dの地図を開く";
            this.direct3Dの地図を開くToolStripMenuItem.Click += new System.EventHandler(this.OnOpenDirect3DMap);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // button
            // 
            this.button.Location = new System.Drawing.Point(897, 27);
            this.button.Name = "button";
            this.button.Size = new System.Drawing.Size(75, 23);
            this.button.TabIndex = 2;
            this.button.Text = "更新";
            this.button.UseVisualStyleBackColor = true;
            this.button.Click += new System.EventHandler(this.OnClickReflesh);
            // 
            // GLMapViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 865);
            this.Controls.Add(this.button);
            this.Controls.Add(this.glMapControl);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "GLMapViewForm";
            this.Text = "OpenGL Map Viewer";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OnFormClosed);
            this.Load += new System.EventHandler(this.OnLoad);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private View.OpenGL.GLMapControl glMapControl;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem ファイルToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 開くToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ToolStripMenuItem 地図ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 他の地図を開くToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem direct3Dの地図を開くToolStripMenuItem;
        private System.Windows.Forms.Button button;
    }
}