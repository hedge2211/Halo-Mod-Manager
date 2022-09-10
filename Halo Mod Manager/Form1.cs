using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Halo_Mod_Manager
{
    public partial class Form1 : Form
    {
        private const char V = '\\';

        Settings settings { get; set; }
        public Form1()
        {
            InitializeComponent();
            this.AllowDrop = true;
            this.DragEnter += new DragEventHandler(Form1_DragEnter);
            this.DragDrop += new DragEventHandler(Form1_DragDrop);
            settings = Settings.Load();
            lblPath.Text = settings.GamePath;
            if (!Directory.Exists(settings.GamePath))
            {
                lblResult.Text = "Game Path Doesnt Exist";
            }
        }


        void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        void Form1_DragDrop(object sender, DragEventArgs e)
        {
            lblResult.Text = "Working .. \n";
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            progressBar1.Maximum = files.Length;
            progressBar1.Value = 0;
            
            lblResult.Text += "Done";

            foreach(var file in files)
            {
                if (File.Exists(file))
                {
                    if (Path.GetExtension(file) == ".zip")
                    {
                        string zipDirectory = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
                        ZipFile.ExtractToDirectory(file, zipDirectory);
                        SearchDirectory(zipDirectory);
                        Directory.Delete(zipDirectory, true);
                    }
                    else
                    {
                        SearchForFile(file);
                    }
                }
                else if (Directory.Exists(file))
                {
                    SearchDirectory(file);
                }
            }

        }

        private void SearchDirectory(string directory)
        {
            foreach( var file in Directory.GetFiles(directory))
            {
                SearchForFile(file);
            }
            foreach(var dir in Directory.GetDirectories(directory))
            {
                SearchDirectory(dir);
            }
        }

        private void SearchForFile(string file)
        {
            string filename = Path.GetFileName(file);
            string[] fileParts = file.Split(V);
            
            if (!settings.GamePath.Contains(fileParts[fileParts.Length - 2]))
            {
                filename = "";
                for (int i = 0; i < fileParts.Length; i++)
                {
                    if (!settings.GamePath.Contains(fileParts[fileParts.Length - i - 1]))
                    {
                        if (DirSearch("\\" + fileParts[fileParts.Length - i - 1] + filename) != null)
                        {
                            filename = "\\" + fileParts[fileParts.Length - i - 1] + filename;
                        }
                        else
                        {
                            break;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
                    
                
            }
            string path = DirSearch(filename);
            if (path != null)
            {
                if (File.Exists(path + ".orig"))
                {
                    lblResult.Text += Path.GetFileName(file) + " Already Modded File Replaced\n";
                    File.Delete(path);
                    File.Copy(file, path);
                }
                else
                {
                    File.Move(path, path + ".orig");
                    File.Copy(file, path);
                    lblResult.Text += Path.GetFileName(file) + " Successful\n";
                }

            }
            else
            {
                lblResult.Text += Path.GetFileName(file) + " Not Found\n";
            }
            progressBar1.Increment(1);
            
        }

        private void btnRemoveMods_Click(object sender, EventArgs e)
        {
            lblResult.Text = "Working .. \n";
            RemoveMods(settings.GamePath);
            lblResult.Text += "Done";
        }
        private void RemoveMods(string sDir)
        {
            progressBar1.Maximum = Directory.GetDirectories(sDir).Length;
            progressBar1.Value = 0;
            foreach (string f in Directory.GetFiles(sDir))
            {
                if (Path.GetFileName(f).EndsWith(".orig"))
                {
                    File.Delete(f.Replace(".orig", ""));
                    File.Move(f, f.Replace(".orig", ""));
                    lblResult.Text += Path.GetFileName(f).Replace(".orig", "") + " Removed\n";
                }
            }
            foreach (string d in Directory.GetDirectories(sDir))
            {
                progressBar1.Increment(1);
                RemoveMods(d);
            }
        }

        private void btnSetGamePath_Click(object sender, EventArgs e)
        {
            //directoryEntry1.;
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                settings.GamePath = folderBrowserDialog1.SelectedPath;
                settings.Save();
                lblPath.Text = settings.GamePath;
            }
            if (!Directory.Exists(settings.GamePath))
            {
                lblResult.Text = "Game Path Doesnt Exist";
            }
            else
            {
                lblResult.Text = "";
            }
        }
        private string DirSearch(string sFile)
        {
            return DirSearch(sFile, settings.GamePath);
        }
        private string DirSearch(string sFile,string sDir)
        {
            foreach (string f in Directory.GetFiles(sDir))
            {
                if (f.EndsWith(sFile))
                {
                    return f;
                }
            }
            foreach (string d in Directory.GetDirectories(sDir))
            {
                string result = DirSearch(sFile,d);
                if (result != null)
                    return result;
            }
            return null;
        }
    }
}
