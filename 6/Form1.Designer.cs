namespace _6
{
    partial class Application
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Application));
            this.ResizePanel = new System.Windows.Forms.Panel();
            this.MinimizeButton = new System.Windows.Forms.Button();
            this.MenuPanel = new System.Windows.Forms.Panel();
            this.MenuCloseButton = new System.Windows.Forms.Button();
            this.AboutButton = new System.Windows.Forms.Button();
            this.DataBaseButton = new System.Windows.Forms.Button();
            this.MaximizeButton = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.Button();
            this.MenuButton = new System.Windows.Forms.Button();
            this.NextButton = new System.Windows.Forms.Button();
            this.PreviousButton = new System.Windows.Forms.Button();
            this.PlayListComponent = new System.Windows.Forms.ListBox();
            this.InformationAboutSong = new System.Windows.Forms.Label();
            this.PlayPauseButton = new System.Windows.Forms.Button();
            this.OpenButton = new System.Windows.Forms.Button();
            this.MovePanel = new System.Windows.Forms.Panel();
            this.OpenFile = new System.Windows.Forms.OpenFileDialog();
            this.TIMER = new System.Windows.Forms.Timer(this.components);
            this.FolderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.ResizePanel.SuspendLayout();
            this.MenuPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ResizePanel
            // 
            this.ResizePanel.Controls.Add(this.MinimizeButton);
            this.ResizePanel.Controls.Add(this.MenuPanel);
            this.ResizePanel.Controls.Add(this.MaximizeButton);
            this.ResizePanel.Controls.Add(this.CloseButton);
            this.ResizePanel.Controls.Add(this.MenuButton);
            this.ResizePanel.Controls.Add(this.NextButton);
            this.ResizePanel.Controls.Add(this.PreviousButton);
            this.ResizePanel.Controls.Add(this.PlayListComponent);
            this.ResizePanel.Controls.Add(this.InformationAboutSong);
            this.ResizePanel.Controls.Add(this.PlayPauseButton);
            this.ResizePanel.Controls.Add(this.OpenButton);
            this.ResizePanel.Controls.Add(this.MovePanel);
            this.ResizePanel.Cursor = System.Windows.Forms.Cursors.Default;
            this.ResizePanel.Location = new System.Drawing.Point(0, 0);
            this.ResizePanel.Name = "ResizePanel";
            this.ResizePanel.Size = new System.Drawing.Size(332, 567);
            this.ResizePanel.TabIndex = 0;
            // 
            // MinimizeButton
            // 
            this.MinimizeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(66)))), ((int)(((byte)(98)))));
            this.MinimizeButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MinimizeButton.FlatAppearance.BorderSize = 0;
            this.MinimizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MinimizeButton.ForeColor = System.Drawing.Color.White;
            this.MinimizeButton.Location = new System.Drawing.Point(224, 0);
            this.MinimizeButton.Margin = new System.Windows.Forms.Padding(0);
            this.MinimizeButton.Name = "MinimizeButton";
            this.MinimizeButton.Size = new System.Drawing.Size(36, 23);
            this.MinimizeButton.TabIndex = 23;
            this.MinimizeButton.Text = "_";
            this.MinimizeButton.UseVisualStyleBackColor = false;
            this.MinimizeButton.Click += new System.EventHandler(this.MinimizeButton_Click);
            // 
            // MenuPanel
            // 
            this.MenuPanel.Controls.Add(this.MenuCloseButton);
            this.MenuPanel.Controls.Add(this.AboutButton);
            this.MenuPanel.Controls.Add(this.DataBaseButton);
            this.MenuPanel.Location = new System.Drawing.Point(0, 25);
            this.MenuPanel.Name = "MenuPanel";
            this.MenuPanel.Size = new System.Drawing.Size(115, 100);
            this.MenuPanel.TabIndex = 0;
            this.MenuPanel.Visible = false;
            // 
            // MenuCloseButton
            // 
            this.MenuCloseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(66)))), ((int)(((byte)(98)))));
            this.MenuCloseButton.FlatAppearance.BorderSize = 0;
            this.MenuCloseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MenuCloseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MenuCloseButton.ForeColor = System.Drawing.Color.White;
            this.MenuCloseButton.Location = new System.Drawing.Point(0, 42);
            this.MenuCloseButton.Name = "MenuCloseButton";
            this.MenuCloseButton.Size = new System.Drawing.Size(115, 23);
            this.MenuCloseButton.TabIndex = 2;
            this.MenuCloseButton.Text = "Выход";
            this.MenuCloseButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.MenuCloseButton.UseVisualStyleBackColor = false;
            this.MenuCloseButton.Click += new System.EventHandler(this.MenuCloseButton_Click);
            // 
            // AboutButton
            // 
            this.AboutButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(66)))), ((int)(((byte)(98)))));
            this.AboutButton.FlatAppearance.BorderSize = 0;
            this.AboutButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AboutButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AboutButton.ForeColor = System.Drawing.Color.White;
            this.AboutButton.Location = new System.Drawing.Point(0, 21);
            this.AboutButton.Name = "AboutButton";
            this.AboutButton.Size = new System.Drawing.Size(115, 23);
            this.AboutButton.TabIndex = 1;
            this.AboutButton.Text = "О программе";
            this.AboutButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.AboutButton.UseVisualStyleBackColor = false;
            this.AboutButton.Click += new System.EventHandler(this.AboutButton_Click);
            // 
            // DataBaseButton
            // 
            this.DataBaseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(66)))), ((int)(((byte)(98)))));
            this.DataBaseButton.FlatAppearance.BorderSize = 0;
            this.DataBaseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DataBaseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DataBaseButton.ForeColor = System.Drawing.Color.White;
            this.DataBaseButton.Location = new System.Drawing.Point(0, 0);
            this.DataBaseButton.Name = "DataBaseButton";
            this.DataBaseButton.Size = new System.Drawing.Size(115, 21);
            this.DataBaseButton.TabIndex = 0;
            this.DataBaseButton.Text = "Работа с БД";
            this.DataBaseButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DataBaseButton.UseVisualStyleBackColor = false;
            // 
            // MaximizeButton
            // 
            this.MaximizeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(66)))), ((int)(((byte)(98)))));
            this.MaximizeButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MaximizeButton.FlatAppearance.BorderSize = 0;
            this.MaximizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MaximizeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MaximizeButton.ForeColor = System.Drawing.Color.White;
            this.MaximizeButton.Location = new System.Drawing.Point(260, 0);
            this.MaximizeButton.Margin = new System.Windows.Forms.Padding(0);
            this.MaximizeButton.Name = "MaximizeButton";
            this.MaximizeButton.Size = new System.Drawing.Size(36, 23);
            this.MaximizeButton.TabIndex = 22;
            this.MaximizeButton.Text = "☐";
            this.MaximizeButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.MaximizeButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.MaximizeButton.UseVisualStyleBackColor = false;
            this.MaximizeButton.Click += new System.EventHandler(this.MaximizeButton_Click);
            // 
            // CloseButton
            // 
            this.CloseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(66)))), ((int)(((byte)(98)))));
            this.CloseButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CloseButton.FlatAppearance.BorderSize = 0;
            this.CloseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseButton.ForeColor = System.Drawing.Color.White;
            this.CloseButton.Location = new System.Drawing.Point(296, 0);
            this.CloseButton.Margin = new System.Windows.Forms.Padding(0);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(36, 23);
            this.CloseButton.TabIndex = 21;
            this.CloseButton.Text = "Х";
            this.CloseButton.UseVisualStyleBackColor = false;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // MenuButton
            // 
            this.MenuButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(66)))), ((int)(((byte)(98)))));
            this.MenuButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MenuButton.FlatAppearance.BorderSize = 0;
            this.MenuButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MenuButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.MenuButton.Location = new System.Drawing.Point(0, 0);
            this.MenuButton.Name = "MenuButton";
            this.MenuButton.Size = new System.Drawing.Size(75, 23);
            this.MenuButton.TabIndex = 20;
            this.MenuButton.Text = "Меню";
            this.MenuButton.UseVisualStyleBackColor = false;
            this.MenuButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // NextButton
            // 
            this.NextButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(66)))), ((int)(((byte)(98)))));
            this.NextButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.NextButton.Enabled = false;
            this.NextButton.FlatAppearance.BorderSize = 0;
            this.NextButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NextButton.ForeColor = System.Drawing.Color.White;
            this.NextButton.Location = new System.Drawing.Point(220, 94);
            this.NextButton.Name = "NextButton";
            this.NextButton.Size = new System.Drawing.Size(100, 23);
            this.NextButton.TabIndex = 16;
            this.NextButton.Text = ">>";
            this.NextButton.UseVisualStyleBackColor = false;
            this.NextButton.Click += new System.EventHandler(this.Next_Click);
            // 
            // PreviousButton
            // 
            this.PreviousButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(66)))), ((int)(((byte)(98)))));
            this.PreviousButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PreviousButton.Enabled = false;
            this.PreviousButton.FlatAppearance.BorderSize = 0;
            this.PreviousButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PreviousButton.ForeColor = System.Drawing.Color.White;
            this.PreviousButton.Location = new System.Drawing.Point(12, 94);
            this.PreviousButton.Name = "PreviousButton";
            this.PreviousButton.Size = new System.Drawing.Size(100, 23);
            this.PreviousButton.TabIndex = 14;
            this.PreviousButton.Text = "<<";
            this.PreviousButton.UseVisualStyleBackColor = false;
            this.PreviousButton.Click += new System.EventHandler(this.Previous_Click);
            // 
            // PlayListComponent
            // 
            this.PlayListComponent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(66)))), ((int)(((byte)(98)))));
            this.PlayListComponent.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PlayListComponent.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PlayListComponent.ForeColor = System.Drawing.SystemColors.Info;
            this.PlayListComponent.FormattingEnabled = true;
            this.PlayListComponent.ItemHeight = 15;
            this.PlayListComponent.Location = new System.Drawing.Point(12, 123);
            this.PlayListComponent.Name = "PlayListComponent";
            this.PlayListComponent.Size = new System.Drawing.Size(308, 435);
            this.PlayListComponent.TabIndex = 17;
            this.PlayListComponent.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox1_MouseDoubleClick);
            // 
            // InformationAboutSong
            // 
            this.InformationAboutSong.AutoSize = true;
            this.InformationAboutSong.ForeColor = System.Drawing.Color.White;
            this.InformationAboutSong.Location = new System.Drawing.Point(13, 33);
            this.InformationAboutSong.Name = "InformationAboutSong";
            this.InformationAboutSong.Size = new System.Drawing.Size(0, 13);
            this.InformationAboutSong.TabIndex = 18;
            // 
            // PlayPauseButton
            // 
            this.PlayPauseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(66)))), ((int)(((byte)(98)))));
            this.PlayPauseButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PlayPauseButton.Enabled = false;
            this.PlayPauseButton.FlatAppearance.BorderSize = 0;
            this.PlayPauseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PlayPauseButton.ForeColor = System.Drawing.Color.White;
            this.PlayPauseButton.Location = new System.Drawing.Point(116, 94);
            this.PlayPauseButton.Name = "PlayPauseButton";
            this.PlayPauseButton.Size = new System.Drawing.Size(100, 23);
            this.PlayPauseButton.TabIndex = 15;
            this.PlayPauseButton.Text = "|>| |";
            this.PlayPauseButton.UseVisualStyleBackColor = false;
            this.PlayPauseButton.Click += new System.EventHandler(this.PlayPause_Click);
            // 
            // OpenButton
            // 
            this.OpenButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(66)))), ((int)(((byte)(98)))));
            this.OpenButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.OpenButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.OpenButton.FlatAppearance.BorderSize = 0;
            this.OpenButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OpenButton.ForeColor = System.Drawing.Color.White;
            this.OpenButton.Location = new System.Drawing.Point(12, 65);
            this.OpenButton.Name = "OpenButton";
            this.OpenButton.Size = new System.Drawing.Size(308, 23);
            this.OpenButton.TabIndex = 13;
            this.OpenButton.Text = "Открыть файл(-ы)";
            this.OpenButton.UseVisualStyleBackColor = false;
            this.OpenButton.Click += new System.EventHandler(this.Open_Click);
            // 
            // MovePanel
            // 
            this.MovePanel.AccessibleRole = System.Windows.Forms.AccessibleRole.Border;
            this.MovePanel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.MovePanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.MovePanel.Location = new System.Drawing.Point(12, 0);
            this.MovePanel.Name = "MovePanel";
            this.MovePanel.Size = new System.Drawing.Size(308, 119);
            this.MovePanel.TabIndex = 19;
            this.MovePanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.MovePanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            // 
            // OpenFile
            // 
            this.OpenFile.Multiselect = true;
            // 
            // TIMER
            // 
            this.TIMER.Interval = 1000000000;
            // 
            // FolderBrowser
            // 
            this.FolderBrowser.Description = "Выбор папки";
            this.FolderBrowser.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // Application
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(37)))), ((int)(((byte)(61)))));
            this.ClientSize = new System.Drawing.Size(332, 567);
            this.Controls.Add(this.ResizePanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Location = new System.Drawing.Point(200, 20);
            this.MinimumSize = new System.Drawing.Size(280, 182);
            this.Name = "Application";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Audio Player";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.ResizePanel.ResumeLayout(false);
            this.ResizePanel.PerformLayout();
            this.MenuPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel ResizePanel;
        private System.Windows.Forms.Button NextButton;
        private System.Windows.Forms.Button PreviousButton;
        private System.Windows.Forms.ListBox PlayListComponent;
        private System.Windows.Forms.Label InformationAboutSong;
        private System.Windows.Forms.Button PlayPauseButton;
        private System.Windows.Forms.Button OpenButton;
        private System.Windows.Forms.Panel MovePanel;
        private System.Windows.Forms.OpenFileDialog OpenFile;
        public System.Windows.Forms.Timer TIMER;
        private System.Windows.Forms.FolderBrowserDialog FolderBrowser;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Button MenuButton;
        private System.Windows.Forms.Panel MenuPanel;
        private System.Windows.Forms.Button MenuCloseButton;
        private System.Windows.Forms.Button AboutButton;
        private System.Windows.Forms.Button DataBaseButton;
        private System.Windows.Forms.Button MinimizeButton;
        private System.Windows.Forms.Button MaximizeButton;
    }
}

