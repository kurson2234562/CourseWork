namespace _6
{
    partial class Queries
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
            this.MinimizeButton = new System.Windows.Forms.Button();
            this.MaximizeButton = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.audio_libDataSet = new _6.Audio_libDataSet();
            this.audiolibDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.audio_libDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.audiolibDataSetBindingSource)).BeginInit();
            this.SuspendLayout();
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
            this.MinimizeButton.Location = new System.Drawing.Point(602, 0);
            this.MinimizeButton.Margin = new System.Windows.Forms.Padding(0);
            this.MinimizeButton.Name = "MinimizeButton";
            this.MinimizeButton.Size = new System.Drawing.Size(36, 23);
            this.MinimizeButton.TabIndex = 32;
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
            this.MaximizeButton.Location = new System.Drawing.Point(638, 0);
            this.MaximizeButton.Margin = new System.Windows.Forms.Padding(0);
            this.MaximizeButton.Name = "MaximizeButton";
            this.MaximizeButton.Size = new System.Drawing.Size(36, 23);
            this.MaximizeButton.TabIndex = 31;
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
            this.CloseButton.Location = new System.Drawing.Point(674, 0);
            this.CloseButton.Margin = new System.Windows.Forms.Padding(0);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(36, 23);
            this.CloseButton.TabIndex = 30;
            this.CloseButton.Text = "Х";
            this.CloseButton.UseVisualStyleBackColor = false;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Информация о прослушанных треках",
            "Последний прослушанный трек",
            "Топ-10 любимых исполнителей",
            "Топ-10 любимых треков"});
            this.comboBox1.Location = new System.Drawing.Point(12, 68);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(686, 21);
            this.comboBox1.TabIndex = 33;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 124);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(686, 276);
            this.dataGridView1.TabIndex = 34;
            this.dataGridView1.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dataGridView1_EditingControlShowing);
            // 
            // audio_libDataSet
            // 
            this.audio_libDataSet.DataSetName = "Audio_libDataSet";
            this.audio_libDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // audiolibDataSetBindingSource
            // 
            this.audiolibDataSetBindingSource.DataSource = this.audio_libDataSet;
            this.audiolibDataSetBindingSource.Position = 0;
            // 
            // Queries
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(37)))), ((int)(((byte)(61)))));
            this.ClientSize = new System.Drawing.Size(710, 412);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.MinimizeButton);
            this.Controls.Add(this.MaximizeButton);
            this.Controls.Add(this.CloseButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Queries";
            this.Text = "Queries";
            this.Load += new System.EventHandler(this.Queries_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Queries_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Queries_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.audio_libDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.audiolibDataSetBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button MinimizeButton;
        private System.Windows.Forms.Button MaximizeButton;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private Audio_libDataSet audio_libDataSet;
        private System.Windows.Forms.BindingSource audiolibDataSetBindingSource;
    }
}