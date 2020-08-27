using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Halo_Mod_Manager
{
    public partial class Form1 : Form
    {
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
            foreach (string file in files)
            {
                string path = DirSearch(Path.GetFileName(file));
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
            lblResult.Text += "Done";
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
                if (Path.GetFileName(f) == sFile)
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
