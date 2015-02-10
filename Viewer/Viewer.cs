using Core.Data;
using Core.Helper;
using Core.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Viewer
{
    public partial class Viewer : Form
    {
        private Parameter Parameter;
        private LDAModel LDAModel;

        public Viewer()
        {
            InitializeComponent();
        }

        private void buttonLoadModel_Click(object sender, EventArgs e)
        {
            //if (modelFolderDialog.ShowDialog() == DialogResult.OK)
            //{
            //    var path = modelFolderDialog.SelectedPath;
            //    Parameter = path.Import<Parameter>();
            //    LDAModel = path.Import<LDAModel>();
            //    ModelHelper.ImportVoca(path);

            //    UpdateTopicGridView();
            //}

            var path = textBoxOutput_Model_Path.Text;
            Parameter = path.Import<Parameter>();
            LDAModel = path.Import<LDAModel>();
            ModelHelper.ImportVoca(path);

            UpdateTopicGridView();
        }

        private DataTable topicTable;
        private void UpdateTopicGridView()
        {
            topicTable = new DataTable();
            foreach (var topicId in Enumerable.Range(0, Parameter.TopicCount))
            {
                topicTable.Columns.Add(string.Format("Topic {0}", topicId));
                topicTable.Columns.Add(string.Format("Prob {0}", topicId));
            }

            foreach (var top in Enumerable.Range(0, Convert.ToInt32(textBoxTotal_words_in_Topic.Text) + 1))
            {
                var row = topicTable.NewRow();
                topicTable.Rows.Add(row);
            }

            foreach (var topicId in Enumerable.Range(0, Parameter.TopicCount))
            {
                var topicCol = string.Format("Topic {0}", topicId);
                var probCol = string.Format("Prob {0}", topicId);

                var wordDist = LDAModel.Phi[topicId]
                    .Select((e, wordId) => new { WordId = wordId, Prob = e })
                    .OrderByDescending(e => e.Prob)
                    .ToList();

                topicTable.Rows[0][topicCol] = topicCol;
                topicTable.Rows[0][topicCol] = wordDist.Sum(e => e.Prob);
                foreach (var top in Enumerable.Range(1, Convert.ToInt32(textBoxTotal_words_in_Topic.Text)))
                {
                    var word = WordManager.ToWord(wordDist[top].WordId);
                    var prob = wordDist[top].Prob;
                    topicTable.Rows[top][topicCol] = word;
                    topicTable.Rows[top][probCol] = prob;
                }
            }

            topicGridView.DataSource = topicTable;
        }

        private string path = @"C:\docs1\";
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 1)
            {
                if (modelFolderDialog.ShowDialog() == DialogResult.OK)
                {
                     path = modelFolderDialog.SelectedPath;
                }

            }
            else
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    path = openFileDialog1.FileName;
                }
            }

           // MessageBox.Show(path);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            // Use ProcessStartInfo class
            ProcessStartInfo startInfo = new ProcessStartInfo();
            //startInfo.CreateNoWindow = false;
            //startInfo.UseShellExecute = false;
            startInfo.FileName = @"C:\eyad\Special Topics in Computer Science(1)\LDA\Tools\LatentDirichletAllocation\LatentDirichletAllocation-master\Core\Core\bin\x64\Debug\Core.exe";
            //startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.Arguments = path + " 0.5 0.1 " + textBoxTopicCount.Text + " " + textBoxTotal_Iteration_Steps.Text + " " + textBoxOutput_Model_Path.Text + "";

            //Dataset\newsdata.csv 0.5 0.1 1 1000 C:\Model
            try
            {
                // Start the process with the info we specified.
                // Call WaitForExit and then the using statement will close.
                using (Process exeProcess = Process.Start(startInfo))
                {
                    exeProcess.WaitForExit();
                }
            }
            catch
            {
                // Log error.
            }

        }

        private void btnSave_Result_Click(object sender, EventArgs e)
        {
            var csv = new StringBuilder();

            //var newLine = string.Format("{0},{1}{2}", first, second, Environment.NewLine);
            var newLine = "";
            for (int i = 0; i < topicTable.Columns.Count; i++)
            {
                newLine += topicTable.Columns[i].ColumnName + ",";
            }
            newLine += Environment.NewLine;
           

            //-----------------------------------------------------------
            for (int i = 0; i < topicTable.Rows.Count; i++)
            {
                for (int j = 0; j < topicTable.Columns.Count; j++)
                {
                    newLine += topicTable.Rows[i][j].ToString() + ",";
                }
                newLine += Environment.NewLine;
                
            }
            csv.Append(newLine);
            var filePath = path.Replace(".txt", ".csv");
            File.WriteAllText(filePath, csv.ToString(), Encoding.UTF8);

            ProcessStartInfo startInfo = new ProcessStartInfo();
           
            startInfo.FileName = filePath;
            using (Process exeProcess = Process.Start(startInfo))
            {
                exeProcess.WaitForExit();
            }

        }
    }
}
