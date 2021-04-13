
namespace ImageSorter
{
    partial class Main
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
            this.textBoxSrc = new System.Windows.Forms.TextBox();
            this.sourceDirBtn = new System.Windows.Forms.Button();
            this.textBoxTarget = new System.Windows.Forms.TextBox();
            this.buttonTarget = new System.Windows.Forms.Button();
            this.buttonLaunch = new System.Windows.Forms.Button();
            this.textBoxLogs = new System.Windows.Forms.TextBox();
            this.folderBrowserDialogSrc = new System.Windows.Forms.FolderBrowserDialog();
            this.folderBrowserDialogTarget = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // textBoxSrc
            // 
            this.textBoxSrc.AccessibleDescription = "Répertoire source";
            this.textBoxSrc.Location = new System.Drawing.Point(23, 36);
            this.textBoxSrc.Name = "textBoxSrc";
            this.textBoxSrc.Size = new System.Drawing.Size(555, 27);
            this.textBoxSrc.TabIndex = 0;
            this.textBoxSrc.TextChanged += new System.EventHandler(this.textBoxSrc_TextChanged);
            // 
            // sourceDirBtn
            // 
            this.sourceDirBtn.Image = global::ImageSorter.Properties.Resources.FolderBrowserDialogControl_16x;
            this.sourceDirBtn.Location = new System.Drawing.Point(595, 36);
            this.sourceDirBtn.Name = "sourceDirBtn";
            this.sourceDirBtn.Size = new System.Drawing.Size(30, 26);
            this.sourceDirBtn.TabIndex = 1;
            this.sourceDirBtn.UseVisualStyleBackColor = true;
            this.sourceDirBtn.Click += new System.EventHandler(this.sourceDirBtn_Click);
            // 
            // textBoxTarget
            // 
            this.textBoxTarget.Location = new System.Drawing.Point(23, 94);
            this.textBoxTarget.Name = "textBoxTarget";
            this.textBoxTarget.Size = new System.Drawing.Size(555, 27);
            this.textBoxTarget.TabIndex = 2;
            this.textBoxTarget.TextChanged += new System.EventHandler(this.textBoxTarget_TextChanged);
            // 
            // buttonTarget
            // 
            this.buttonTarget.Image = global::ImageSorter.Properties.Resources.FolderBrowserDialogControl_16x;
            this.buttonTarget.Location = new System.Drawing.Point(595, 94);
            this.buttonTarget.Name = "buttonTarget";
            this.buttonTarget.Size = new System.Drawing.Size(30, 29);
            this.buttonTarget.TabIndex = 3;
            this.buttonTarget.UseVisualStyleBackColor = true;
            this.buttonTarget.Click += new System.EventHandler(this.buttonDirTarget_Click);
            // 
            // buttonLaunch
            // 
            this.buttonLaunch.Location = new System.Drawing.Point(595, 158);
            this.buttonLaunch.Name = "buttonLaunch";
            this.buttonLaunch.Size = new System.Drawing.Size(94, 29);
            this.buttonLaunch.TabIndex = 4;
            this.buttonLaunch.Text = "Lancer";
            this.buttonLaunch.UseVisualStyleBackColor = true;
            this.buttonLaunch.Click += new System.EventHandler(this.buttonLaunch_Click);
            // 
            // textBoxLogs
            // 
            this.textBoxLogs.Location = new System.Drawing.Point(23, 159);
            this.textBoxLogs.Multiline = true;
            this.textBoxLogs.Name = "textBoxLogs";
            this.textBoxLogs.Size = new System.Drawing.Size(555, 122);
            this.textBoxLogs.TabIndex = 5;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 309);
            this.Controls.Add(this.textBoxLogs);
            this.Controls.Add(this.buttonLaunch);
            this.Controls.Add(this.buttonTarget);
            this.Controls.Add(this.textBoxTarget);
            this.Controls.Add(this.sourceDirBtn);
            this.Controls.Add(this.textBoxSrc);
            this.Name = "Main";
            this.Text = "Image Sorter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxSrc;
        private System.Windows.Forms.Button sourceDirBtn;
        private System.Windows.Forms.TextBox textBoxTarget;
        private System.Windows.Forms.Button buttonTarget;
        private System.Windows.Forms.Button buttonLaunch;
        private System.Windows.Forms.TextBox textBoxLogs;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogSrc;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogTarget;
    }
}

