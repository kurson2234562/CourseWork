namespace _6
{
    partial class DataBase
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.audiolibDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.audio_libDataSet = new _6.Audio_libDataSet();
            this.button1 = new System.Windows.Forms.Button();
            this.songerTableAdapter = new _6.Audio_libDataSetTableAdapters.SongerTableAdapter();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.fKGroupofIDSo21B6055DBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.group_of_songerTableAdapter = new _6.Audio_libDataSetTableAdapters.Group_of_songerTableAdapter();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.MinimizeButton = new System.Windows.Forms.Button();
            this.MaximizeButton = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.audiolibDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.audio_libDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fKGroupofIDSo21B6055DBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(14, 37);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(493, 224);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dataGridView1_EditingControlShowing);
            // 
            // audiolibDataSetBindingSource
            // 
            this.audiolibDataSetBindingSource.DataSource = this.audio_libDataSet;
            this.audiolibDataSetBindingSource.Position = 0;
            // 
            // audio_libDataSet
            // 
            this.audio_libDataSet.DataSetName = "Audio_libDataSet";
            this.audio_libDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(66)))), ((int)(((byte)(98)))));
            this.button1.Enabled = false;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(14, 267);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Показать таблицу";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // songerTableAdapter
            // 
            this.songerTableAdapter.ClearBeforeFill = true;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(66)))), ((int)(((byte)(98)))));
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(431, 267);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Закрыть";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(66)))), ((int)(((byte)(98)))));
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(15, 9);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(118, 23);
            this.button3.TabIndex = 4;
            this.button3.Text = "Работа с таблицами";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // group_of_songerTableAdapter
            // 
            this.group_of_songerTableAdapter.ClearBeforeFill = true;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Album_Info",
            "Composition_Album",
            "Genre",
            "Groups",
            "Listening",
            "Participation",
            "Song",
            "Songer"});
            this.comboBox1.Location = new System.Drawing.Point(141, 269);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(159, 21);
            this.comboBox1.TabIndex = 6;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // MinimizeButton
            // 
            this.MinimizeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MinimizeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(66)))), ((int)(((byte)(98)))));
            this.MinimizeButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MinimizeButton.Enabled = false;
            this.MinimizeButton.FlatAppearance.BorderSize = 0;
            this.MinimizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MinimizeButton.ForeColor = System.Drawing.Color.White;
            this.MinimizeButton.Location = new System.Drawing.Point(417, 0);
            this.MinimizeButton.Margin = new System.Windows.Forms.Padding(0);
            this.MinimizeButton.Name = "MinimizeButton";
            this.MinimizeButton.Size = new System.Drawing.Size(36, 23);
            this.MinimizeButton.TabIndex = 29;
            this.MinimizeButton.Text = "_";
            this.MinimizeButton.UseVisualStyleBackColor = false;
            this.MinimizeButton.Click += new System.EventHandler(this.MinimizeButton_Click);
            // 
            // MaximizeButton
            // 
            this.MaximizeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MaximizeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(66)))), ((int)(((byte)(98)))));
            this.MaximizeButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MaximizeButton.Enabled = false;
            this.MaximizeButton.FlatAppearance.BorderSize = 0;
            this.MaximizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MaximizeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MaximizeButton.ForeColor = System.Drawing.Color.White;
            this.MaximizeButton.Location = new System.Drawing.Point(453, 0);
            this.MaximizeButton.Margin = new System.Windows.Forms.Padding(0);
            this.MaximizeButton.Name = "MaximizeButton";
            this.MaximizeButton.Size = new System.Drawing.Size(36, 23);
            this.MaximizeButton.TabIndex = 28;
            this.MaximizeButton.Text = "☐";
            this.MaximizeButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.MaximizeButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.MaximizeButton.UseVisualStyleBackColor = false;
            // 
            // CloseButton
            // 
            this.CloseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(66)))), ((int)(((byte)(98)))));
            this.CloseButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CloseButton.FlatAppearance.BorderSize = 0;
            this.CloseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseButton.ForeColor = System.Drawing.Color.White;
            this.CloseButton.Location = new System.Drawing.Point(489, 0);
            this.CloseButton.Margin = new System.Windows.Forms.Padding(0);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(36, 23);
            this.CloseButton.TabIndex = 27;
            this.CloseButton.Text = "Х";
            this.CloseButton.UseVisualStyleBackColor = false;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(66)))), ((int)(((byte)(98)))));
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.ForeColor = System.Drawing.SystemColors.Control;
            this.button4.Location = new System.Drawing.Point(306, 267);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(119, 23);
            this.button4.TabIndex = 30;
            this.button4.Text = "Статистика";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // DataBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(37)))), ((int)(((byte)(61)))));
            this.ClientSize = new System.Drawing.Size(523, 302);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.MinimizeButton);
            this.Controls.Add(this.MaximizeButton);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(100, 100);
            this.MinimumSize = new System.Drawing.Size(523, 0);
            this.Name = "DataBase";
            this.Text = "DataBase";
            this.Load += new System.EventHandler(this.DataBase_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DataBase_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.DataBase_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.audiolibDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.audio_libDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fKGroupofIDSo21B6055DBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource audiolibDataSetBindingSource;
        private Audio_libDataSet audio_libDataSet;
        private System.Windows.Forms.Button button1;
        private Audio_libDataSetTableAdapters.SongerTableAdapter songerTableAdapter;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.BindingSource fKGroupofIDSo21B6055DBindingSource;
        private Audio_libDataSetTableAdapters.Group_of_songerTableAdapter group_of_songerTableAdapter;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button MinimizeButton;
        private System.Windows.Forms.Button MaximizeButton;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Button button4;
    }
}