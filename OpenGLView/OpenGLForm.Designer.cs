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
            this.openGLControl1 = new OpenGLView.OpenGLControl();
            this.SuspendLayout();
            // 
            // openGLControl1
            // 
            this.openGLControl1.BackColor = System.Drawing.Color.Black;
            this.openGLControl1.Location = new System.Drawing.Point(12, 12);
            this.openGLControl1.Name = "openGLControl1";
            this.openGLControl1.Size = new System.Drawing.Size(400, 400);
            this.openGLControl1.TabIndex = 0;
            this.openGLControl1.VSync = false;
            // 
            // OpenGLForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 425);
            this.Controls.Add(this.openGLControl1);
            this.Name = "OpenGLForm";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private OpenGLControl openGLControl1;
    }
}

