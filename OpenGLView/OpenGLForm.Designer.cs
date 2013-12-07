namespace OpenGLView
{
    partial class OpenGLForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.glUserControl11 = new OpenGLView.GLUserControl1();
            this.SuspendLayout();
            // 
            // glUserControl11
            // 
            this.glUserControl11.BackColor = System.Drawing.Color.Black;
            this.glUserControl11.Location = new System.Drawing.Point(12, 12);
            this.glUserControl11.Name = "glUserControl11";
            this.glUserControl11.Size = new System.Drawing.Size(402, 401);
            this.glUserControl11.TabIndex = 0;
            this.glUserControl11.VSync = false;
            this.glUserControl11.Load += new System.EventHandler(this.glUserControl11_Load);
            this.glUserControl11.Paint += new System.Windows.Forms.PaintEventHandler(this.glUserControl11_Paint);
            this.glUserControl11.Resize += new System.EventHandler(this.glUserControl11_Resize);
            // 
            // OpenGLForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 425);
            this.Controls.Add(this.glUserControl11);
            this.Name = "OpenGLForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.OpenGLForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private GLUserControl1 glUserControl11;


    }
}

