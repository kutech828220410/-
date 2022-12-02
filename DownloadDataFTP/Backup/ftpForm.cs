//Downloaded from
//Visual C# Kicks - http://vcskicks.com/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//Needed
using System.IO;
using System.Net;

namespace DownloadDataFTP
{
    public partial class ftpForm : Form
    {
        public ftpForm()
        {
            InitializeComponent();
        }

        private byte[] downloadedData;

        //Connects to the FTP server and downloads the file
        private void downloadFile(string FTPAddress, string filename, string username, string password)
        {
            downloadedData = new byte[0];

            try
            {
                //Optional
                this.Text = "Connecting...";
                Application.DoEvents();

                //Create FTP request
                //Note: format is ftp://server.com/file.ext
                FtpWebRequest request = FtpWebRequest.Create(FTPAddress + "/" + filename) as FtpWebRequest;

                //Optional
                this.Text = "Retrieving Information...";
                Application.DoEvents();

                //Get the file size first (for progress bar)
                request.Method = WebRequestMethods.Ftp.GetFileSize;
                request.Credentials = new NetworkCredential(username, password);
                request.UsePassive = true;
                request.UseBinary = true;
                request.KeepAlive = true; //don't close the connection

                int dataLength = (int)request.GetResponse().ContentLength;

                //Optional
                this.Text = "Downloading File...";
                Application.DoEvents();

                //Now get the actual data
                request = FtpWebRequest.Create(FTPAddress + "/" + filename) as FtpWebRequest;
                request.Method = WebRequestMethods.Ftp.DownloadFile;
                request.Credentials = new NetworkCredential(username, password);
                request.UsePassive = true;
                request.UseBinary = true;
                request.KeepAlive = false; //close the connection when done

                //Set up progress bar
                progressBar1.Value = 0;
                progressBar1.Maximum = dataLength;
                lbProgress.Text = "0/" + dataLength.ToString();

                //Streams
                FtpWebResponse response = request.GetResponse() as FtpWebResponse;
                Stream reader = response.GetResponseStream();

                //Download to memory
                //Note: adjust the streams here to download directly to the hard drive
                MemoryStream memStream = new MemoryStream();
                byte[] buffer = new byte[1024]; //downloads in chuncks

                while (true)
                {
                    Application.DoEvents(); //prevent application from crashing

                    //Try to read the data
                    int bytesRead = reader.Read(buffer, 0, buffer.Length);

                    if (bytesRead == 0)
                    {
                        //Nothing was read, finished downloading
                        progressBar1.Value = progressBar1.Maximum;
                        lbProgress.Text = dataLength.ToString() + "/" + dataLength.ToString();

                        Application.DoEvents();
                        break;
                    }
                    else
                    {
                        //Write the downloaded data
                        memStream.Write(buffer, 0, bytesRead);

                        //Update the progress bar
                        if (progressBar1.Value + bytesRead <= progressBar1.Maximum)
                        {
                            progressBar1.Value += bytesRead;
                            lbProgress.Text = progressBar1.Value.ToString() + "/" + dataLength.ToString();

                            progressBar1.Refresh();
                            Application.DoEvents();
                        }
                    }
                }

                //Convert the downloaded stream to a byte array
                downloadedData = memStream.ToArray();

                //Clean up
                reader.Close();
                memStream.Close();
                response.Close();

                MessageBox.Show("Downloaded Successfully");
            }
            catch (Exception)
            {
                MessageBox.Show("There was an error connecting to the FTP Server.");
            }

            txtData.Text = downloadedData.Length.ToString();
            this.Text = "Download Data through FTP";

            username = string.Empty;
            password = string.Empty;
        }

        //Connects to the FTP server and request the list of available files
        private void getFileList(string FTPAddress, string username, string password)
        {
            List<string> files = new List<string>();

            try
            {
                //Optional
                this.Text = "Connecting...";
                Application.DoEvents();

                //Create FTP request
                FtpWebRequest request = FtpWebRequest.Create(FTPAddress) as FtpWebRequest;

                request.Method = WebRequestMethods.Ftp.ListDirectory;
                request.Credentials = new NetworkCredential(username, password);
                request.UsePassive = true;
                request.UseBinary = true;
                request.KeepAlive = false;

                //Read the server's response
                this.Text = "Retrieving List...";
                Application.DoEvents();

                FtpWebResponse response = request.GetResponse() as FtpWebResponse;
                Stream responseStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(responseStream);

                while (!reader.EndOfStream)
                {
                    Application.DoEvents();
                    files.Add(reader.ReadLine());
                }

                //Clean-up
                reader.Close();
                responseStream.Close(); //redundant
                response.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("There was an error connecting to the FTP Server");
            }

            username = string.Empty;
            password = string.Empty;

            this.Text = "Download Data through FTP"; //Back to normal title

            //If the list was successfully received, display it to the user
            //through a dialog
            if (files.Count != 0)
            {
                listDialogForm dialog = new listDialogForm(files);
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    //Update the File Name field
                    txtFileName.Text = dialog.ChosenFile;
                }
            }
        }

        //Make sure the FTP server address has ftp:// at the beginning
        private void txtFTPAddress_Leave(object sender, EventArgs e)
        {
            if (!txtFTPAddress.Text.StartsWith("ftp://"))
                txtFTPAddress.Text = "ftp://" + txtFTPAddress.Text;
        }

        private void btnGetList_Click(object sender, EventArgs e)
        {
            if (txtFTPAddress.Text != "ftp://" && txtFTPAddress.Text != string.Empty)
                getFileList(txtFTPAddress.Text, txtUsername.Text, txtPassword.Text);
            else
                MessageBox.Show("Please enter a FTP address");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://vcskicks.com/");
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            if (txtFTPAddress.Text != "ftp://" && txtFTPAddress.Text != string.Empty)
                if (txtFileName.Text != string.Empty)
                {
                    downloadFile(txtFTPAddress.Text, txtFileName.Text, txtUsername.Text, txtPassword.Text);

                    saveFile1.FileName = txtFileName.Text;
                }
                else
                    MessageBox.Show("Please enter a file name or click the Get File List button");
            else
                MessageBox.Show("Please enter a FTP address");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (downloadedData != null && downloadedData.Length != 0)
            {
                if (saveFile1.ShowDialog() == DialogResult.OK)
                {
                    this.Text = "Saving Data...";
                    Application.DoEvents();

                    //Write the bytes to a file
                    FileStream newFile = new FileStream(saveFile1.FileName, FileMode.Create);
                    newFile.Write(downloadedData, 0, downloadedData.Length);
                    newFile.Close();

                    this.Text = "Download Data";
                    MessageBox.Show("Saved Successfully");
                }
            }
            else
                MessageBox.Show("No File was Downloaded Yet!");
        }
    }
}