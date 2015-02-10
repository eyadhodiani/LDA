namespace Viewer
{
    partial class Viewer
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
            this.modelFolderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.buttonLoadModel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBoxOutput_Model_Path = new System.Windows.Forms.TextBox();
            this.textBoxTotal_Iteration_Steps = new System.Windows.Forms.TextBox();
            this.textBoxTotal_words_in_Topic = new System.Windows.Forms.TextBox();
            this.textBoxTopicCount = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.topicGridView = new System.Windows.Forms.DataGridView();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnSave_Result = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.topicGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonLoadModel
            // 
            this.buttonLoadModel.Location = new System.Drawing.Point(175, 460);
            this.buttonLoadModel.Name = "buttonLoadModel";
            this.buttonLoadModel.Size = new System.Drawing.Size(185, 69);
            this.buttonLoadModel.TabIndex = 0;
            this.buttonLoadModel.Text = "&Load Model";
            this.buttonLoadModel.UseVisualStyleBackColor = true;
            this.buttonLoadModel.Click += new System.EventHandler(this.buttonLoadModel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSave_Result);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.textBoxOutput_Model_Path);
            this.groupBox1.Controls.Add(this.textBoxTotal_Iteration_Steps);
            this.groupBox1.Controls.Add(this.textBoxTotal_words_in_Topic);
            this.groupBox1.Controls.Add(this.buttonLoadModel);
            this.groupBox1.Controls.Add(this.textBoxTopicCount);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 13);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(0);
            this.groupBox1.Size = new System.Drawing.Size(372, 665);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "LDA Param";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 460);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(156, 66);
            this.button1.TabIndex = 3;
            this.button1.Text = "Run";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBoxOutput_Model_Path
            // 
            this.textBoxOutput_Model_Path.Location = new System.Drawing.Point(32, 413);
            this.textBoxOutput_Model_Path.Name = "textBoxOutput_Model_Path";
            this.textBoxOutput_Model_Path.Size = new System.Drawing.Size(298, 38);
            this.textBoxOutput_Model_Path.TabIndex = 13;
            this.textBoxOutput_Model_Path.Text = "C:\\Model";
            // 
            // textBoxTotal_Iteration_Steps
            // 
            this.textBoxTotal_Iteration_Steps.Location = new System.Drawing.Point(32, 335);
            this.textBoxTotal_Iteration_Steps.Name = "textBoxTotal_Iteration_Steps";
            this.textBoxTotal_Iteration_Steps.Size = new System.Drawing.Size(298, 38);
            this.textBoxTotal_Iteration_Steps.TabIndex = 12;
            this.textBoxTotal_Iteration_Steps.Text = "100";
            // 
            // textBoxTotal_words_in_Topic
            // 
            this.textBoxTotal_words_in_Topic.Location = new System.Drawing.Point(32, 257);
            this.textBoxTotal_words_in_Topic.Name = "textBoxTotal_words_in_Topic";
            this.textBoxTotal_words_in_Topic.Size = new System.Drawing.Size(298, 38);
            this.textBoxTotal_words_in_Topic.TabIndex = 11;
            this.textBoxTotal_words_in_Topic.Text = "5";
            // 
            // textBoxTopicCount
            // 
            this.textBoxTopicCount.Location = new System.Drawing.Point(32, 179);
            this.textBoxTopicCount.Name = "textBoxTopicCount";
            this.textBoxTopicCount.Size = new System.Drawing.Size(298, 38);
            this.textBoxTopicCount.TabIndex = 10;
            this.textBoxTopicCount.Text = "1";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(29, 221);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(210, 31);
            this.label7.TabIndex = 7;
            this.label7.Text = "Total words in Topic";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(29, 377);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(201, 31);
            this.label6.TabIndex = 6;
            this.label6.Text = "Output Model Path:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 299);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(209, 31);
            this.label5.TabIndex = 5;
            this.label5.Text = "Total Iteration Steps";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 143);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(138, 31);
            this.label4.TabIndex = 4;
            this.label4.Text = "Topic Count:";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Single file",
            "Directory files"});
            this.comboBox1.Location = new System.Drawing.Point(25, 84);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(0);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(219, 39);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Corpus Type:";
            // 
            // topicGridView
            // 
            this.topicGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.topicGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.topicGridView.Location = new System.Drawing.Point(402, 30);
            this.topicGridView.Name = "topicGridView";
            this.topicGridView.RowTemplate.Height = 23;
            this.topicGridView.Size = new System.Drawing.Size(1349, 740);
            this.topicGridView.TabIndex = 3;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnSave_Result
            // 
            this.btnSave_Result.Location = new System.Drawing.Point(13, 549);
            this.btnSave_Result.Name = "btnSave_Result";
            this.btnSave_Result.Size = new System.Drawing.Size(347, 69);
            this.btnSave_Result.TabIndex = 4;
            this.btnSave_Result.Text = "Save Result (csv)";
            this.btnSave_Result.UseVisualStyleBackColor = true;
            this.btnSave_Result.Click += new System.EventHandler(this.btnSave_Result_Click);
            // 
            // Viewer
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1782, 765);
            this.Controls.Add(this.topicGridView);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "Viewer";
            this.Text = "LDA Visualization";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.topicGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog modelFolderDialog;
        private System.Windows.Forms.Button buttonLoadModel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxOutput_Model_Path;
        private System.Windows.Forms.TextBox textBoxTotal_Iteration_Steps;
        private System.Windows.Forms.TextBox textBoxTotal_words_in_Topic;
        private System.Windows.Forms.TextBox textBoxTopicCount;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView topicGridView;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnSave_Result;
    }
}

