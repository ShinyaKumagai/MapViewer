namespace ViewTest
{
    partial class D3DForm
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
            this.d3DUserControl1 = new ViewTest.D3DUserControl();
            this.SuspendLayout();
            // 
            // d3DUserControl1
            // 
            this.d3DUserControl1.Location = new System.Drawing.Point(133, 87);
            this.d3DUserControl1.Name = "d3DUserControl1";
            this.d3DUserControl1.Size = new System.Drawing.Size(276, 267);
            this.d3DUserControl1.TabIndex = 0;
            // 
            // D3DForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 457);
            this.Controls.Add(this.d3DUserControl1);
            this.Name = "D3DForm";
            this.Text = "D3DForm";
            this.Load += new System.EventHandler(this.D3DForm_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.D3DForm_Paint);
            this.ResumeLayout(false);

        }

        #endregion

        private D3DUserControl d3DUserControl1;
    }
}