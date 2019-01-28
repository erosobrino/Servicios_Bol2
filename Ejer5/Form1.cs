using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejer5
{
    public partial class Form1 : Form
    {
        Thread thread;
        delegate void DelegateText(string text, TextBox t);
        public Form1()
        {
            InitializeComponent();
            tbPath.Text = "D:/";
            tbWord.Text = "a";
        }

        List<string> textFiles = new List<string>();

        private void btFind_Click(object sender, EventArgs e)
        {
            lblError.Text = "";
            if (tbPath.Text.Length > 0 && tbWord.Text.Length > 0)
            {
                DirectoryInfo directory = null;
                try
                {
                    directory = new DirectoryInfo(tbPath.Text);
                }
                catch (ArgumentException)
                {
                    lblError.Text = "The directory is invalid";
                }
                for (int i = 0; i < directory.GetFiles().Length; i++)
                {
                    if (directory.GetFiles()[i].Extension.Equals(".txt"))
                    {
                        textFiles.Add(directory.GetFiles()[i].FullName);
                    }
                }
                foreach (string str in textFiles)
                {
                    thread = new Thread(() => ThreadFind(str, tbWord.Text, chCapital.Checked));
                    thread.Start();
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
            //try
            //{
            Console.WriteLine(path);
            using (StreamReader reader = new StreamReader(path))
            {
                String line = reader.ReadLine();
                while (line != null)
                {
                    //long b = "hola como estas".LongCount(letra => letra.ToString() == "a");
                    //number = (int)line.LongCount(worddd => worddd.ToString() == word);
                    ////if (line.Contains(word))
                    ////{
                    ////    number++;
                    ////}
                    DelegateText delegateText = new DelegateText(changeText);
                    this.Invoke(delegateText, line, tbFind);
                    line = reader.ReadLine();
                }
            }
            //}
            //catch { }
        }
    }
}
//string directory = Environment.GetEnvironmentVariable("homedrive") + "\\" + Environment.GetEnvironmentVariable("homepath") + "\\configNotas.bin";