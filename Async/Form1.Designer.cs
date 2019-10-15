namespace Async
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.GetSync = new System.Windows.Forms.Button();
            this.GetAsyncAwait = new System.Windows.Forms.Button();
            this.GetAsyncParralel = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            // 
            // GetSync
            // 
            this.GetSync.Location = new System.Drawing.Point(291, 17);
            this.GetSync.Name = "GetSync";
            this.GetSync.Size = new System.Drawing.Size(541, 47);
            this.GetSync.TabIndex = 0;
            this.GetSync.Text = "GetSync";
            this.GetSync.UseVisualStyleBackColor = true;
            this.GetSync.Click += new System.EventHandler(this.GetSync_Click);
            // 
            // GetAsyncAwait
            // 
            this.GetAsyncAwait.Location = new System.Drawing.Point(291, 83);
            this.GetAsyncAwait.Name = "GetAsyncAwait";
            this.GetAsyncAwait.Size = new System.Drawing.Size(541, 47);
            this.GetAsyncAwait.TabIndex = 0;
            this.GetAsyncAwait.Text = "GetAsyncAwait";
            this.GetAsyncAwait.UseVisualStyleBackColor = true;
            this.GetAsyncAwait.Click += new System.EventHandler(this.GetAsyncAwait_Click);
            // 
            // GetAsyncParralel
            // 
            this.GetAsyncParralel.Location = new System.Drawing.Point(291, 152);
            this.GetAsyncParralel.Name = "GetAsyncParralel";
            this.GetAsyncParralel.Size = new System.Drawing.Size(541, 47);
            this.GetAsyncParralel.TabIndex = 0;
            this.GetAsyncParralel.Text = "GetAsync in Parallel";
            this.GetAsyncParralel.UseVisualStyleBackColor = true;
            this.GetAsyncParralel.Click += new System.EventHandler(this.GetAsyncParralel_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(291, 242);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(541, 247);
            this.textBox1.TabIndex = 1;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(291, 206);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(541, 23);
            this.progressBar1.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1139, 537);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.GetSync);
            this.Controls.Add(this.GetAsyncAwait);
            this.Controls.Add(this.GetAsyncParralel);
            this.Name = "Form1";
            this.Text = "Form1";

        }

        #endregion

        private System.Windows.Forms.Button GetSync;
        private System.Windows.Forms.Button GetAsyncAwait;
        private System.Windows.Forms.Button GetAsyncParralel;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}

