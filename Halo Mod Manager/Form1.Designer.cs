namespace Halo_Mod_Manager
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnRemoveMods = new System.Windows.Forms.Button();
            this.btnSetGamePath = new System.Windows.Forms.Button();
            this.directoryEntry1 = new System.DirectoryServices.DirectoryEntry();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.lblPath = new System.Windows.Forms.Label();
            this.lblResult = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(244, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Drop Mod Files Here";
            // 
            // btnRemoveMods
            // 
            this.btnRemoveMods.Location = new System.Drawing.Point(22, 41);
            this.btnRemoveMods.Name = "btnRemoveMods";
            this.btnRemoveMods.Size = new System.Drawing.Size(146, 34);
            this.btnRemoveMods.TabIndex = 1;
            this.btnRemoveMods.Text = "Remove Mods";
            this.btnRemoveMods.UseVisualStyleBackColor = true;
            this.btnRemoveMods.Click += new System.EventHandler(this.btnRemoveMods_Click);
            // 
            // btnSetGamePath
            // 
            this.btnSetGamePath.Location = new System.Drawing.Point(22, 98);
            this.btnSetGamePath.Name = "btnSetGamePath";
            this.btnSetGamePath.Size = new System.Drawing.Size(146, 34);
            this.btnSetGamePath.TabIndex = 2;
            this.btnSetGamePath.Text = "Set Game Path";
            this.btnSetGamePath.UseVisualStyleBackColor = true;
            this.btnSetGamePath.Click += new System.EventHandler(this.btnSetGamePath_Click);
            // 
            // lblPath
            // 
            this.lblPath.AutoSize = true;
            this.lblPath.Location = new System.Drawing.Point(22, 15);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(0, 20);
            this.lblPath.TabIndex = 3;
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(22, 154);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(0, 20);
            this.lblResult.TabIndex = 4;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(235, 98);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(517, 34);
            this.progressBar1.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.lblPath);
            this.Controls.Add(this.btnSetGamePath);
            this.Controls.Add(this.btnRemoveMods);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Halo Mod Manager";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRemoveMods;
        private System.Windows.Forms.Button btnSetGamePath;
        private System.DirectoryServices.DirectoryEntry directoryEntry1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label lblPath;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}

