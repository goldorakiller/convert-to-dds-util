using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConvertToDDSUtil
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnSelectFiles_Click(object sender, EventArgs e)
        {
            if (ofdSelectFiles.ShowDialog() == DialogResult.OK)
            {
                foreach (string item in ofdSelectFiles.FileNames)
                {
                    if (!lstSelectedFiles.Items.Contains(item))
                    {
                        lstSelectedFiles.Items.Add(item);
                    }
                }
            }
        }

        private void btnSelectDestination_Click(object sender, EventArgs e)
        {
            if (fbdSelectDestination.ShowDialog() == DialogResult.OK)
            {
                if (!Directory.Exists(fbdSelectDestination.SelectedPath))
                {
                    MessageBox.Show("Directory does not exist");
                    return;
                }
                if (Utility.HasWriteAccessToFolder(fbdSelectDestination.SelectedPath))
                {
                    txtDestination.Text = fbdSelectDestination.SelectedPath;
                }
                else
                {
                    MessageBox.Show("You don't have permission to write to this folder. Start the application as administrator.");
                }
            }
        }

        private void btnClearDestination_Click(object sender, EventArgs e)
        {
            txtDestination.Text = string.Empty;
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            StringBuilder sbFailed = new StringBuilder();
            StringBuilder sbAll = new StringBuilder();
            bool fileMoveError = false;

            for (int i = lstSelectedFiles.Items.Count - 1; i >= 0; i--)
            {
                string item = (string)lstSelectedFiles.Items[i];
                bool conversionFailed = false;

                Process p = new Process();

                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.FileName = "ExternalDependencies\\texconv.exe";
                p.StartInfo.Arguments = " -nologo \"" + item + "\"";

                p.Start();
                string output = p.StandardOutput.ReadToEnd();
                p.WaitForExit();

                if (output.Contains("FAILED"))
                {
                    conversionFailed = true;
                    MessageBox.Show("Conversion failed for \n\n" + item +
                        "texconv.exe output is stored in texconv-failed-output-latest");

                    sbFailed.Append(output);
                    sbFailed.Append("\r\n\r\n");
                }
                else
                {
                    string fileName = Path.GetFileNameWithoutExtension(item) + ".dds";
                    string filePath = Path.GetDirectoryName(item);
                    string workingDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase).Replace("file:\\", "");

                    if (txtDestination.Text.Trim() != string.Empty)
                    {

                        bool moveSuccess = Utility.MoveFile(workingDirectory + "\\" + fileName
                                                        , txtDestination.Text.Trim()
                                                        , true);

                        if (!moveSuccess)
                        {
                            Utility.MoveFile(workingDirectory + "\\" + fileName, workingDirectory + "\\DDSOutput", true);
                            fileMoveError = true;
                        }
                    }
                    else
                    {
                        Utility.MoveFile(workingDirectory + "\\" + fileName, workingDirectory + "\\DDSOutput", true);
                    }
                }

                sbAll.Append(output);
                sbAll.Append("\r\n\r\n");

                if (cbClearList.Checked)
                {
                    if (!cbExceptFailed.Checked || !conversionFailed)
                    {
                        lstSelectedFiles.Items.RemoveAt(i);
                    }
                }

            }

            string failedOutput = sbFailed.ToString();
            string allOutput = sbAll.ToString();

            if (fileMoveError)
            {
                MessageBox.Show("Files are converted but failed to move. Check working directory for files.");
            }

            if (!Utility.WriteFailedLogFile(failedOutput))
            {
                MessageBox.Show("Failed to write to texconv-failed-output. Check write permissions for working directory");
            }
            if (!Utility.WriteAllLogFile(allOutput))
            {
                MessageBox.Show("Failed to write to texconv-all-output. Check write permissions for working directory");
            }
            if (!Utility.WriteLatestFailedLogFile(failedOutput))
            {
                MessageBox.Show("Failed to write to texconv-failed-output-latest. Check write permissions for working directory");
            }
            if (!Utility.WriteLatestAllLogFile(allOutput))
            {
                MessageBox.Show("Failed to write to texconv-all-output-latest. Check write permissions for working directory");
            }
        }

        private void lstSelectedFiles_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                for (int i = lstSelectedFiles.SelectedIndices.Count - 1; i >= 0; i--)
                {
                    lstSelectedFiles.Items.RemoveAt(lstSelectedFiles.SelectedIndices[i]);
                }
            }
        }

        private void cbClearList_CheckedChanged(object sender, EventArgs e)
        {
            cbExceptFailed.Checked = cbExceptFailed.Enabled = cbClearList.Checked;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ofdSelectFiles.InitialDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);
            cbExceptFailed.Enabled = false;
        }

    }
}
