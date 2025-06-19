namespace WackyRaceProject
{
    partial class FormGame
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
            this.components = new System.ComponentModel.Container();
            this.labelPlayerInfo = new System.Windows.Forms.Label();
            this.labelTimeInfo = new System.Windows.Forms.Label();
            this.buttonRestart = new System.Windows.Forms.Button();
            this.labelGameOver = new System.Windows.Forms.Label();
            this.labelBestTime = new System.Windows.Forms.Label();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuStripGame = new System.Windows.Forms.ToolStripMenuItem();
            this.timerBackground = new System.Windows.Forms.Timer(this.components);
            this.timerSurviveTime = new System.Windows.Forms.Timer(this.components);
            this.timerPlayerAnimation = new System.Windows.Forms.Timer(this.components);
            this.timerMoveCooldown = new System.Windows.Forms.Timer(this.components);
            this.timerObstacleSpawner = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelPlayerInfo
            // 
            this.labelPlayerInfo.AutoSize = true;
            this.labelPlayerInfo.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelPlayerInfo.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelPlayerInfo.Location = new System.Drawing.Point(15, 40);
            this.labelPlayerInfo.Name = "labelPlayerInfo";
            this.labelPlayerInfo.Size = new System.Drawing.Size(57, 13);
            this.labelPlayerInfo.TabIndex = 1;
            this.labelPlayerInfo.Text = "Player Info";
            // 
            // labelTimeInfo
            // 
            this.labelTimeInfo.AutoSize = true;
            this.labelTimeInfo.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelTimeInfo.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelTimeInfo.Location = new System.Drawing.Point(297, 40);
            this.labelTimeInfo.Name = "labelTimeInfo";
            this.labelTimeInfo.Size = new System.Drawing.Size(51, 13);
            this.labelTimeInfo.TabIndex = 2;
            this.labelTimeInfo.Text = "Time Info";
            // 
            // buttonRestart
            // 
            this.buttonRestart.BackColor = System.Drawing.Color.Lime;
            this.buttonRestart.Location = new System.Drawing.Point(179, 247);
            this.buttonRestart.Name = "buttonRestart";
            this.buttonRestart.Size = new System.Drawing.Size(75, 23);
            this.buttonRestart.TabIndex = 3;
            this.buttonRestart.Text = "Restart";
            this.buttonRestart.UseVisualStyleBackColor = false;
            this.buttonRestart.Click += new System.EventHandler(this.button1_Click);
            // 
            // labelGameOver
            // 
            this.labelGameOver.AutoSize = true;
            this.labelGameOver.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelGameOver.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelGameOver.Location = new System.Drawing.Point(267, 183);
            this.labelGameOver.Name = "labelGameOver";
            this.labelGameOver.Size = new System.Drawing.Size(61, 13);
            this.labelGameOver.TabIndex = 4;
            this.labelGameOver.Text = "Game Over";
            // 
            // labelBestTime
            // 
            this.labelBestTime.AutoSize = true;
            this.labelBestTime.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelBestTime.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelBestTime.Location = new System.Drawing.Point(297, 82);
            this.labelBestTime.Name = "labelBestTime";
            this.labelBestTime.Size = new System.Drawing.Size(54, 13);
            this.labelBestTime.TabIndex = 5;
            this.labelBestTime.Text = "Best Time";
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxLogo.BackgroundImage = global::WackyRaceProject.Properties.Resources.logo;
            this.pictureBoxLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxLogo.Location = new System.Drawing.Point(87, 35);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(193, 145);
            this.pictureBoxLogo.TabIndex = 0;
            this.pictureBoxLogo.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuStripGame});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(397, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuStripGame
            // 
            this.menuStripGame.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.menuStripGame.Name = "menuStripGame";
            this.menuStripGame.Size = new System.Drawing.Size(75, 20);
            this.menuStripGame.Text = "Play Game";
            this.menuStripGame.Click += new System.EventHandler(this.playGameToolStripMenuItem_Click);
            // 
            // timerBackground
            // 
            this.timerBackground.Interval = 30;
            this.timerBackground.Tick += new System.EventHandler(this.timerBackground_Tick);
            // 
            // timerSurviveTime
            // 
            this.timerSurviveTime.Interval = 1000;
            this.timerSurviveTime.Tick += new System.EventHandler(this.timerSurviveTime_Tick);
            // 
            // timerPlayerAnimation
            // 
            this.timerPlayerAnimation.Tick += new System.EventHandler(this.timerPlayerAnimation_Tick);
            // 
            // timerMoveCooldown
            // 
            this.timerMoveCooldown.Interval = 500;
            this.timerMoveCooldown.Tick += new System.EventHandler(this.timerMoveCooldown_Tick);
            // 
            // timerObstacleSpawner
            // 
            this.timerObstacleSpawner.Interval = 1000;
            this.timerObstacleSpawner.Tick += new System.EventHandler(this.timerObstacleSpawner_Tick);
            // 
            // FormGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BackgroundImage = global::WackyRaceProject.Properties.Resources.bg1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(397, 338);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.labelBestTime);
            this.Controls.Add(this.labelGameOver);
            this.Controls.Add(this.buttonRestart);
            this.Controls.Add(this.labelTimeInfo);
            this.Controls.Add(this.labelPlayerInfo);
            this.Controls.Add(this.pictureBoxLogo);
            this.DoubleBuffered = true;
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormGame";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormGame_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.Label labelPlayerInfo;
        private System.Windows.Forms.Label labelTimeInfo;
        private System.Windows.Forms.Button buttonRestart;
        private System.Windows.Forms.Label labelGameOver;
        private System.Windows.Forms.Label labelBestTime;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuStripGame;
        private System.Windows.Forms.Timer timerBackground;
        private System.Windows.Forms.Timer timerSurviveTime;
        private System.Windows.Forms.Timer timerPlayerAnimation;
        private System.Windows.Forms.Timer timerMoveCooldown;
        private System.Windows.Forms.Timer timerObstacleSpawner;
    }
}

