namespace FileLocker
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox FilePath;
        private System.Windows.Forms.Button BrowseFile;
        private System.Windows.Forms.Button LockFile;
        private System.Windows.Forms.Button UnlockFile;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.FilePath = new System.Windows.Forms.TextBox();
            this.BrowseFile = new System.Windows.Forms.Button();
            this.LockFile = new System.Windows.Forms.Button();
            this.UnlockFile = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // FilePath
            // 
            this.FilePath.Location = new System.Drawing.Point(12, 12);
            this.FilePath.Name = "FilePath";
            this.FilePath.Size = new System.Drawing.Size(360, 22);
            this.FilePath.TabIndex = 0;
            this.FilePath.TextChanged += new System.EventHandler(this.FilePath_TextChanged);
            // 
            // BrowseFile
            // 
            this.BrowseFile.Location = new System.Drawing.Point(378, 12);
            this.BrowseFile.Name = "BrowseFile";
            this.BrowseFile.Size = new System.Drawing.Size(30, 23);
            this.BrowseFile.TabIndex = 1;
            this.BrowseFile.Text = "...";
            this.BrowseFile.UseVisualStyleBackColor = true;
            this.BrowseFile.Click += new System.EventHandler(this.BrowseFile_Click);
            // 
            // LockFile
            // 
            this.LockFile.Location = new System.Drawing.Point(12, 40);
            this.LockFile.Name = "LockFile";
            this.LockFile.Size = new System.Drawing.Size(75, 23);
            this.LockFile.TabIndex = 2;
            this.LockFile.Text = "Lock";
            this.LockFile.UseVisualStyleBackColor = true;
            this.LockFile.Click += new System.EventHandler(this.LockFile_Click);
            // 
            // UnlockFile
            // 
            this.UnlockFile.Location = new System.Drawing.Point(93, 40);
            this.UnlockFile.Name = "UnlockFile";
            this.UnlockFile.Size = new System.Drawing.Size(75, 23);
            this.UnlockFile.TabIndex = 3;
            this.UnlockFile.Text = "Unlock";
            this.UnlockFile.UseVisualStyleBackColor = true;
            this.UnlockFile.Click += new System.EventHandler(this.UnlockFile_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 75);
            this.Controls.Add(this.UnlockFile);
            this.Controls.Add(this.LockFile);
            this.Controls.Add(this.BrowseFile);
            this.Controls.Add(this.FilePath);
            this.Name = "Form1";
            this.Text = "File Locker";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
