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
            this.Next = new System.Windows.Forms.Button();
            this.Previous = new System.Windows.Forms.Button();
            this.PlayListComponent = new System.Windows.Forms.ListBox();
            this.InformationAboutSong = new System.Windows.Forms.Label();
            this.PlayPause = new System.Windows.Forms.Button();
            this.Open = new System.Windows.Forms.Button();
            this.MovePanel = new System.Windows.Forms.Panel();
            this.OpenFile = new System.Windows.Forms.OpenFileDialog();
            this.TIMER = new System.Windows.Forms.Timer(this.components);
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.MenuButton = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.Button();
            this.MenuPanel = new System.Windows.Forms.Panel();
            this.DataBaseButton = new System.Windows.Forms.Button();
            this.AboutButton = new System.Windows.Forms.Button();
            this.MenuCloseButton = new System.Windows.Forms.Button();
            this.MaximizeButton = new System.Windows.Forms.Button();
            this.MinimizeButton = new System.Windows.Forms.Button();
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
            this.ResizePanel.Controls.Add(this.Next);
            this.ResizePanel.Controls.Add(this.Previous);
            this.ResizePanel.Controls.Add(this.PlayListComponent);
            this.ResizePanel.Controls.Add(this.InformationAboutSong);
            this.ResizePanel.Controls.Add(this.PlayPause);
            this.ResizePanel.Controls.Add(this.Open);
            this.ResizePanel.Controls.Add(this.MovePanel);
            this.ResizePanel.Cursor = System.Windows.Forms.Cursors.Default;
            this.ResizePanel.Location = new System.Drawing.Point(0, 0);
            this.ResizePanel.Name = "ResizePanel";
            this.ResizePanel.Size = new System.Drawing.Size(332, 567);
            this.ResizePanel.TabIndex = 0;
            // 
            // Next
            // 
            this.Next.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(66)))), ((int)(((byte)(98)))));
            this.Next.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Next.Enabled = false;
            this.Next.FlatAppearance.BorderSize = 0;
            this.Next.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Next.ForeColor = System.Drawing.Color.White;
            this.Next.Location = new System.Drawing.Point(220, 94);
            this.Next.Name = "Next";
            this.Next.Size = new System.Drawing.Size(100, 23);
            this.Next.TabIndex = 16;
            this.Next.Text = ">>";
            this.Next.UseVisualStyleBackColor = false;
            this.Next.Click += new System.EventHandler(this.Next_Click);
            // 
            // Previous
            // 
            this.Previous.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(66)))), ((int)(((byte)(98)))));
            this.Previous.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Previous.Enabled = false;
            this.Previous.FlatAppearance.BorderSize = 0;
            this.Previous.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Previous.ForeColor = System.Drawing.Color.White;
            this.Previous.Location = new System.Drawing.Point(12, 94);
            this.Previous.Name = "Previous";
            this.Previous.Size = new System.Drawing.Size(100, 23);
            this.Previous.TabIndex = 14;
            this.Previous.Text = "<<";
            this.Previous.UseVisualStyleBackColor = false;
            this.Previous.Click += new System.EventHandler(this.Previous_Click);
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
            // PlayPause
            // 
            this.PlayPause.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(66)))), ((int)(((byte)(98)))));
            this.PlayPause.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PlayPause.Enabled = false;
            this.PlayPause.FlatAppearance.BorderSize = 0;
            this.PlayPause.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PlayPause.ForeColor = System.Drawing.Color.White;
            this.PlayPause.Location = new System.Drawing.Point(116, 94);
            this.PlayPause.Name = "PlayPause";
            this.PlayPause.Size = new System.Drawing.Size(100, 23);
            this.PlayPause.TabIndex = 15;
            this.PlayPause.Text = "|>| |";
            this.PlayPause.UseVisualStyleBackColor = false;
            this.PlayPause.Click += new System.EventHandler(this.PlayPause_Click);
            // 
            // Open
            // 
            this.Open.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(66)))), ((int)(((byte)(98)))));
            this.Open.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Open.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Open.FlatAppearance.BorderSize = 0;
            this.Open.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Open.ForeColor = System.Drawing.Color.White;
            this.Open.Location = new System.Drawing.Point(12, 65);
            this.Open.Name = "Open";
            this.Open.Size = new System.Drawing.Size(308, 23);
            this.Open.TabIndex = 13;
            this.Open.Text = "Открыть файл(-ы)";
            this.Open.UseVisualStyleBackColor = false;
            this.Open.Click += new System.EventHandler(this.Open_Click);
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
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.Description = "Выбор папки";
            this.folderBrowserDialog1.RootFolder = System.Environment.SpecialFolder.MyComputer;
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
            // MaximizeButton
            // 
            this.MaximizeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(66)))), ((int)(((byte)(98)))));
            this.MaximizeButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MaximizeButton.FlatAppearance.BorderSize = 0;
            this.MaximizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MaximizeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MaximizeButton.ForeColor = System.Drawing.Color.White;
            this.MaximizeButton.Location = new System.Drawing.Point(260, 0);
            this.MaximizeButton.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.MaximizeButton.Name = "MaximizeButton";
            this.MaximizeButton.Size = new System.Drawing.Size(36, 23);
            this.MaximizeButton.TabIndex = 22;
            this.MaximizeButton.Text = "☐";
            this.MaximizeButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.MaximizeButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.MaximizeButton.UseVisualStyleBackColor = false;
            this.MaximizeButton.Click += new System.EventHandler(this.MaximizeButton_Click);
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
            this.MinimizeButton.Click += new System.EventHandler(this.button3_Click);
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
        private System.Windows.Forms.Button Next;
        private System.Windows.Forms.Button Previous;
        private System.Windows.Forms.ListBox PlayListComponent;
        private System.Windows.Forms.Label InformationAboutSong;
        private System.Windows.Forms.Button PlayPause;
        private System.Windows.Forms.Button Open;
        private System.Windows.Forms.Panel MovePanel;
        private System.Windows.Forms.OpenFileDialog OpenFile;
        public System.Windows.Forms.Timer TIMER;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
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

