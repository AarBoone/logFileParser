namespace logFileParser
{
    partial class Form1
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
            openFileDialog_FileName = new OpenFileDialog();
            button_SelectFile = new Button();
            label_FileName = new Label();
            dataGridView_EventTypeCount = new DataGridView();
            comboBox_AllEventTypes = new ComboBox();
            dataGridView_MoreInfoAboutEventTypes = new DataGridView();
            label_GetMoreInfo = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView_EventTypeCount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView_MoreInfoAboutEventTypes).BeginInit();
            SuspendLayout();
            // 
            // openFileDialog_FileName
            // 
            openFileDialog_FileName.FileName = "openFileDialog_FileName";
            openFileDialog_FileName.FileOk += openFileDialog_FileName_FileOk;
            // 
            // button_SelectFile
            // 
            button_SelectFile.Location = new Point(713, 415);
            button_SelectFile.Name = "button_SelectFile";
            button_SelectFile.Size = new Size(75, 23);
            button_SelectFile.TabIndex = 0;
            button_SelectFile.Text = "Select File";
            button_SelectFile.UseVisualStyleBackColor = true;
            button_SelectFile.Click += button_SelectFile_Click;
            // 
            // label_FileName
            // 
            label_FileName.AutoSize = true;
            label_FileName.Location = new Point(26, 32);
            label_FileName.Name = "label_FileName";
            label_FileName.Size = new Size(38, 15);
            label_FileName.TabIndex = 1;
            label_FileName.Text = "label1";
            label_FileName.Visible = false;
            // 
            // dataGridView_EventTypeCount
            // 
            dataGridView_EventTypeCount.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView_EventTypeCount.BackgroundColor = SystemColors.Control;
            dataGridView_EventTypeCount.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView_EventTypeCount.Location = new Point(26, 50);
            dataGridView_EventTypeCount.Name = "dataGridView_EventTypeCount";
            dataGridView_EventTypeCount.Size = new Size(240, 207);
            dataGridView_EventTypeCount.TabIndex = 2;
            dataGridView_EventTypeCount.Visible = false;
            // 
            // comboBox_AllEventTypes
            // 
            comboBox_AllEventTypes.FormattingEnabled = true;
            comboBox_AllEventTypes.Location = new Point(26, 263);
            comboBox_AllEventTypes.Name = "comboBox_AllEventTypes";
            comboBox_AllEventTypes.Size = new Size(121, 23);
            comboBox_AllEventTypes.TabIndex = 3;
            comboBox_AllEventTypes.Visible = false;
            comboBox_AllEventTypes.SelectedIndexChanged += comboBox_AllEventTypes_SelectedIndexChanged;
            // 
            // dataGridView_MoreInfoAboutEventTypes
            // 
            dataGridView_MoreInfoAboutEventTypes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView_MoreInfoAboutEventTypes.BackgroundColor = SystemColors.Control;
            dataGridView_MoreInfoAboutEventTypes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView_MoreInfoAboutEventTypes.Location = new Point(26, 292);
            dataGridView_MoreInfoAboutEventTypes.Name = "dataGridView_MoreInfoAboutEventTypes";
            dataGridView_MoreInfoAboutEventTypes.Size = new Size(762, 117);
            dataGridView_MoreInfoAboutEventTypes.TabIndex = 4;
            dataGridView_MoreInfoAboutEventTypes.Visible = false;
            // 
            // label_GetMoreInfo
            // 
            label_GetMoreInfo.AutoSize = true;
            label_GetMoreInfo.Location = new Point(153, 266);
            label_GetMoreInfo.Name = "label_GetMoreInfo";
            label_GetMoreInfo.Size = new Size(222, 15);
            label_GetMoreInfo.TabIndex = 5;
            label_GetMoreInfo.Text = "Get More Info About Selected Event Type";
            label_GetMoreInfo.Visible = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label_GetMoreInfo);
            Controls.Add(dataGridView_MoreInfoAboutEventTypes);
            Controls.Add(comboBox_AllEventTypes);
            Controls.Add(dataGridView_EventTypeCount);
            Controls.Add(label_FileName);
            Controls.Add(button_SelectFile);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView_EventTypeCount).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView_MoreInfoAboutEventTypes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private OpenFileDialog openFileDialog_FileName;
        private Button button_SelectFile;
        private Label label_FileName;
        private DataGridView dataGridView_EventTypeCount;
        private ComboBox comboBox_AllEventTypes;
        private DataGridView dataGridView_MoreInfoAboutEventTypes;
        private Label label_GetMoreInfo;
    }
}
