namespace ViewTest
{
    partial class GLPolygonForm
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
            this.glPolygonControl1 = new ViewTest.GLPolygonControl();
            this.SuspendLayout();
            // 
            // glPolygonControl1
            // 
            this.glPolygonControl1.BackColor = System.Drawing.Color.Black;
            this.glPolygonControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.glPolygonControl1.Location = new System.Drawing.Point(0, 0);
            this.glPolygonControl1.Name = "glPolygonControl1";
            this.glPolygonControl1.Size = new System.Drawing.Size(797, 444);
            this.glPolygonControl1.TabIndex = 0;
            this.glPolygonControl1.VSync = false;
            // 
            // GLPolygonForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(797, 444);
            this.Controls.Add(this.glPolygonControl1);
            this.Name = "GLPolygonForm";
            this.Text = "GLPolygonForm";
            this.ResumeLayout(false);

        }

        #endregion

        private GLPolygonControl glPolygonControl1;
    }
}