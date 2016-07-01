namespace LauncherLesAuDacieuX
{
    partial class App
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
            this.buttonGo = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.labelLog = new System.Windows.Forms.Label();
            this.buttonTest = new System.Windows.Forms.Button();
            this.labelDownloadSpeed = new System.Windows.Forms.Label();
            this.progressBarEx1 = new ProgressBarEx.ProgressBarEx();
            this.SuspendLayout();
            // 
            // buttonGo
            // 
            this.buttonGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonGo.BackColor = System.Drawing.SystemColors.ControlText;
            this.buttonGo.FlatAppearance.BorderColor = System.Drawing.Color.DarkOrange;
            this.buttonGo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.buttonGo.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.WindowFrame;
            this.buttonGo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonGo.ForeColor = System.Drawing.Color.DarkOrange;
            this.buttonGo.Location = new System.Drawing.Point(354, 67);
            this.buttonGo.Name = "buttonGo";
            this.buttonGo.Size = new System.Drawing.Size(75, 23);
            this.buttonGo.TabIndex = 0;
            this.buttonGo.TabStop = false;
            this.buttonGo.Text = "Jouer";
            this.buttonGo.UseVisualStyleBackColor = false;
            this.buttonGo.Click += new System.EventHandler(this.buttonGo_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.SystemColors.ControlText;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.DarkOrange;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.WindowFrame;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.DarkOrange;
            this.button1.Location = new System.Drawing.Point(412, 9);
            this.button1.Margin = new System.Windows.Forms.Padding(0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(20, 20);
            this.button1.TabIndex = 2;
            this.button1.TabStop = false;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.BackColor = System.Drawing.SystemColors.ControlText;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.DarkOrange;
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.WindowFrame;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.DarkOrange;
            this.button2.Location = new System.Drawing.Point(383, 9);
            this.button2.Margin = new System.Windows.Forms.Padding(0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(20, 20);
            this.button2.TabIndex = 3;
            this.button2.TabStop = false;
            this.button2.Text = "-";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // labelLog
            // 
            this.labelLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelLog.BackColor = System.Drawing.Color.Transparent;
            this.labelLog.ForeColor = System.Drawing.Color.Orange;
            this.labelLog.Location = new System.Drawing.Point(12, 81);
            this.labelLog.Name = "labelLog";
            this.labelLog.Size = new System.Drawing.Size(196, 13);
            this.labelLog.TabIndex = 4;
            this.labelLog.Text = "...";
            // 
            // buttonTest
            // 
            this.buttonTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonTest.BackColor = System.Drawing.SystemColors.ControlText;
            this.buttonTest.FlatAppearance.BorderColor = System.Drawing.Color.DarkOrange;
            this.buttonTest.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.buttonTest.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.WindowFrame;
            this.buttonTest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTest.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTest.ForeColor = System.Drawing.Color.DarkOrange;
            this.buttonTest.Location = new System.Drawing.Point(354, 38);
            this.buttonTest.Name = "buttonTest";
            this.buttonTest.Size = new System.Drawing.Size(75, 23);
            this.buttonTest.TabIndex = 6;
            this.buttonTest.TabStop = false;
            this.buttonTest.Text = "Test";
            this.buttonTest.UseVisualStyleBackColor = false;
            this.buttonTest.Click += new System.EventHandler(this.buttonTest_Click);
            // 
            // labelDownloadSpeed
            // 
            this.labelDownloadSpeed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelDownloadSpeed.BackColor = System.Drawing.Color.Transparent;
            this.labelDownloadSpeed.ForeColor = System.Drawing.Color.Orange;
            this.labelDownloadSpeed.Location = new System.Drawing.Point(214, 81);
            this.labelDownloadSpeed.Name = "labelDownloadSpeed";
            this.labelDownloadSpeed.Size = new System.Drawing.Size(134, 13);
            this.labelDownloadSpeed.TabIndex = 7;
            this.labelDownloadSpeed.Text = ".......";
            this.labelDownloadSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // progressBarEx1
            // 
            this.progressBarEx1.BackColor = System.Drawing.Color.Transparent;
            this.progressBarEx1.BackgroundColor = System.Drawing.Color.Black;
            this.progressBarEx1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBarEx1.GradiantColor = System.Drawing.Color.Black;
            this.progressBarEx1.GradiantPosition = ProgressBarEx.ProgressBarEx.GradiantArea.None;
            this.progressBarEx1.Image = null;
            this.progressBarEx1.Location = new System.Drawing.Point(0, 97);
            this.progressBarEx1.Name = "progressBarEx1";
            this.progressBarEx1.ProgressColor = System.Drawing.Color.White;
            this.progressBarEx1.Size = new System.Drawing.Size(441, 5);
            this.progressBarEx1.Text = "progressBarEx1";
            // 
            // App
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(441, 102);
            this.Controls.Add(this.progressBarEx1);
            this.Controls.Add(this.labelDownloadSpeed);
            this.Controls.Add(this.labelLog);
            this.Controls.Add(this.buttonTest);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonGo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "App";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Launcher";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.StartDragWindow);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonGo;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label labelLog;
        private System.Windows.Forms.Button buttonTest;
        private System.Windows.Forms.Label labelDownloadSpeed;
        private ProgressBarEx.ProgressBarEx progressBarEx1;
    }
}

