namespace WinFrmThreadDemo
{
    partial class MainFrm
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
            this.btnLoop = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnLoop
            // 
            this.btnLoop.Location = new System.Drawing.Point(259, 162);
            this.btnLoop.Name = "btnLoop";
            this.btnLoop.Size = new System.Drawing.Size(195, 23);
            this.btnLoop.TabIndex = 0;
            this.btnLoop.Text = "btnLoop";
            this.btnLoop.UseVisualStyleBackColor = true;
            this.btnLoop.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 449);
            this.Controls.Add(this.btnLoop);
            this.Name = "MainFrm";
            this.Text = "MainFrm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLoop;
    }
}