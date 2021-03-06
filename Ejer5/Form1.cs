﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejer5
{
    //Validado
    public partial class Form1 : Form
    {
        string directory = Environment.GetEnvironmentVariable("homedrive") + "\\" + Environment.GetEnvironmentVariable("homepath") + "\\extensionesEjer5.txt";
        Thread thread;
        string[] extensiones;
        private static readonly object l = new object();
        delegate void DelegateText(string text, TextBox t);
        public Form1()
        {
            InitializeComponent();
            tbPath.Text = "D:/";
            tbWord.Text = "a";
        }

        List<string> textFiles;

        private void btFind_Click(object sender, EventArgs e)
        {
            textFiles = new List<string>();
            tbFind.Clear();
            lblError.Text = "";
            if (tbPath.Text.Length > 0 && tbWord.Text.Length > 0)
            {
                DirectoryInfo directory = null;
                try
                {
                    directory = new DirectoryInfo(tbPath.Text);
                    for (int i = 0; i < directory.GetFiles().Length; i++)
                    {
                        for (int j = 0; j < extensiones.Length; j++)
                        {
                            if (directory.GetFiles()[i].Extension == extensiones[j])
                            {
                                textFiles.Add(directory.GetFiles()[i].FullName);
                            }
                        }
                    }
                }
                catch (ArgumentException)
                {
                    lblError.Text = "The directory is invalid";
                }
                catch (DirectoryNotFoundException)
                {
                    lblError.Text = "The path is not valid";
                }
                catch (IOException)
                {
                    lblError.Text = "Error in the path";
                }
                catch (Win32Exception)
                {
                    lblError.Text = "You are not allowed to see this directory";
                }
                catch (UnauthorizedAccessException)
                {
                    lblError.Text = "You are not allowed to see this directory";
                }
                foreach (string str in textFiles)
                {
                    thread = new Thread(() => ThreadFind(str, tbWord.Text, chCapital.Checked));
                    thread.Start();
                    thread.IsBackground = true;
                }
            }
            else
            {
                lblError.Text = "Error in the Path or the Word";
            }
        }

        private void changeText(string text, TextBox textBox)
        {
            textBox.AppendText(text + Environment.NewLine);
        }

        private void ThreadFind(string path, string word, bool capital)
        {
            int number = 0;
            try
            {
                Console.WriteLine(path);
                using (StreamReader reader = new StreamReader(path))
                {
                    String line = reader.ReadLine();
                    while (line != null)
                    {
                        if (chCapital.Checked)
                        {
                            number += line.Replace(word, "|").Split('|').Length-1;
                        }
                        else
                        {
                            number += line.ToUpper().Replace(word.ToUpper(), "|").Split('|').Length-1;
                        }
                        line = reader.ReadLine();
                    }
                }
                DelegateText delegateText = new DelegateText(changeText);
                FileInfo file = new FileInfo(path);
                lock (l)
                    this.Invoke(delegateText, String.Format("{0,30} {1,15}", file.Name, number), tbFind);
            }
            catch { }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string text = "";
            try
            {
                using (StreamReader reader = new StreamReader(directory))
                {
                    text = reader.ReadToEnd().Trim();
                    if (text.Length > 0)
                    {
                        extensiones = text.Trim().Split(';');
                    }
                }
                tbExtensions.Text = text;
            }
            catch
            {
                extensiones = new string[] { ".txt" };
                tbExtensions.Text = ".txt";
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(directory))
                {
                    writer.Write(tbExtensions.Text);
                }
            }
            catch { }
        }
    }
}