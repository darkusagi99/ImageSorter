
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxSrc
            // 
            this.textBoxSrc.AccessibleDescription = "Répertoire source";
            this.textBoxSrc.Location = new System.Drawing.Point(20, 27);
            this.textBoxSrc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxSrc.Name = "textBoxSrc";
            this.textBoxSrc.Size = new System.Drawing.Size(486, 23);
            this.textBoxSrc.TabIndex = 0;
            this.textBoxSrc.TextChanged += new System.EventHandler(this.textBoxSrc_TextChanged);
            // 
            // sourceDirBtn
            // 
            this.sourceDirBtn.Image = global::ImageSorter.Properties.Resources.FolderBrowserDialogControl_16x;
            this.sourceDirBtn.Location = new System.Drawing.Point(521, 27);
            this.sourceDirBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.sourceDirBtn.Name = "sourceDirBtn";
            this.sourceDirBtn.Size = new System.Drawing.Size(26, 20);
            this.sourceDirBtn.TabIndex = 1;
            this.sourceDirBtn.UseVisualStyleBackColor = true;
            this.sourceDirBtn.Click += new System.EventHandler(this.sourceDirBtn_Click);
            // 
            // textBoxTarget
            // 
            this.textBoxTarget.Location = new System.Drawing.Point(20, 70);
            this.textBoxTarget.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxTarget.Name = "textBoxTarget";
            this.textBoxTarget.Size = new System.Drawing.Size(486, 23);
            this.textBoxTarget.TabIndex = 2;
            this.textBoxTarget.TextChanged += new System.EventHandler(this.textBoxTarget_TextChanged);
            // 
            // buttonTarget
            // 
            this.buttonTarget.Image = global::ImageSorter.Properties.Resources.FolderBrowserDialogControl_16x;
            this.buttonTarget.Location = new System.Drawing.Point(521, 70);
            this.buttonTarget.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonTarget.Name = "buttonTarget";
            this.buttonTarget.Size = new System.Drawing.Size(26, 22);
            this.buttonTarget.TabIndex = 3;
            this.buttonTarget.UseVisualStyleBackColor = true;
            this.buttonTarget.Click += new System.EventHandler(this.buttonDirTarget_Click);
            // 
            // buttonLaunch
            // 
            this.buttonLaunch.Location = new System.Drawing.Point(521, 118);
            this.buttonLaunch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonLaunch.Name = "buttonLaunch";
            this.buttonLaunch.Size = new System.Drawing.Size(82, 22);
            this.buttonLaunch.TabIndex = 4;
            this.buttonLaunch.Text = "Lancer";
            this.buttonLaunch.UseVisualStyleBackColor = true;
            this.buttonLaunch.Click += new System.EventHandler(this.buttonLaunch_Click);
            // 
            // textBoxLogs
            // 
            this.textBoxLogs.Location = new System.Drawing.Point(20, 119);
            this.textBoxLogs.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxLogs.Multiline = true;
            this.textBoxLogs.Name = "textBoxLogs";
            this.textBoxLogs.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxLogs.Size = new System.Drawing.Size(486, 92);
            this.textBoxLogs.TabIndex = 5;
            this.textBoxLogs.TextChanged += new System.EventHandler(this.textBoxLogs_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "Dossier source";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "Dossier cible";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 232);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxLogs);
            this.Controls.Add(this.buttonLaunch);
            this.Controls.Add(this.buttonTarget);
            this.Controls.Add(this.textBoxTarget);
            this.Controls.Add(this.sourceDirBtn);
            this.Controls.Add(this.textBoxSrc);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

