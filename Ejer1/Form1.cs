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

namespace Ejer1
{
    public partial class Form1 : Form
    {
        //Validado
        //D:\
        DirectoryInfo d;
        public Form1()
        {
            InitializeComponent();
        }

        private void btAbrir_Click(object sender, EventArgs e)
        {
            string path = tbPath.Text;
            lblError.Text = "";
            if (path.Length > 0)
            {
                try
                {
                    if (path[0] == ('%') && path[path.Length - 1] == ('%') && path.Length >= 3)
                    {
                        path = Environment.GetEnvironmentVariable(path.Substring(1, path.Length - 2));
                    }
                    Directory.SetCurrentDirectory(path);
                    d = new DirectoryInfo(Directory.GetCurrentDirectory());
                    if (d.Exists)
                    {
                        FileInfo[] files = d.GetFiles();
                        tbFiles.Clear();
                        tbDirectories.Clear();
                        foreach (FileInfo file in files)
                        {
                            tbFiles.AppendText(file.Name);
                            tbFiles.AppendText(Environment.NewLine);
                        }
                        DirectoryInfo[] directories = d.GetDirectories();
                        foreach (DirectoryInfo directory in directories)
                        {
                            tbDirectories.AppendText(directory.Name);
                            tbDirectories.AppendText(Environment.NewLine);
                        }
                    }
                }
                catch (DirectoryNotFoundException)
                {
                    lblError.Text = "The path is not valid";
                }
                catch (ArgumentNullException)
                {
                    lblError.Text = "The environment variable doesn't exists";
                }
                catch (IOException)
                {
                    lblError.Text = "Error in the path";
                }
                catch (ArgumentException)
                {
                    lblError.Text = "Invalid characters";
                }
                catch (Win32Exception)
                {
                    lblError.Text = "You are not allowed to see this directory";
                }
                catch (UnauthorizedAccessException)
                {
                    lblError.Text = "You are not allowed to see this directory";
                }
            }
            else
            {
                lblError.Text = "Introduce the path";
            }
        }
    }
}
