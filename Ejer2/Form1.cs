﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejer2
{
    //Validado
    public partial class Form1 : Form
    {
        bool modified = false;
        public Form1()
        {
            InitializeComponent();
        }
        private void btNew_Click(object sender, EventArgs e)
        {
            DialogResult res = options(sender, e);
            if (res.Equals(DialogResult.OK))
            {
                tbNote.Text = "";
            }
        }
        private DialogResult options(object sender, EventArgs e)
        {
            if (tbNote.Text.Length > 0 && modified)
            {
                DialogResult dialog = MessageBox.Show("Do you want to save the old text?", "Options", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                switch (dialog)
                {
                    case DialogResult.Yes:
                        return Save(sender, e);
                    case DialogResult.No:
                        return DialogResult.OK;
                    case DialogResult.Cancel:
                        return DialogResult.Cancel;
                    default: return DialogResult.Cancel;
                }
            }
            else
            {
                return DialogResult.OK;
            }
        }

        private void btOpen_Click(object sender, EventArgs e)
        {
            DialogResult oldText = options(sender, e);
            if (oldText.Equals(DialogResult.OK))
            {
                OpenFileDialog openFile = new OpenFileDialog();
                openFile.Title = "Select a file to open";
                //saveFile.InitialDirectory = "C:\\";
                openFile.InitialDirectory = "D:\\";
                openFile.Filter = "Text (*.txt)|*.txt|All files|*.*";
                openFile.ValidateNames = true;
                DialogResult res = openFile.ShowDialog();
                if (res == DialogResult.OK)
                {
                    using (StreamReader reader = new StreamReader(openFile.FileName))
                    {
                        String line = reader.ReadLine();
                        while (line != null)
                        {
                            tbNote.AppendText(line);
                            line = reader.ReadLine();
                        }
                        //tbNota.Text = reader.ReadToEnd();
                    }
                }
                modified = false;
            }
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            Save(sender, e);
        }

        private DialogResult Save(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Title = "Select path and name";
            //saveFile.InitialDirectory = "C:\\";
            saveFile.InitialDirectory = "D:\\";
            saveFile.Filter = "Text (*.txt)|*.txt|All files|*.*";
            saveFile.ValidateNames = true;
            DialogResult res = saveFile.ShowDialog();
            if (res == DialogResult.OK)
            {
                using (StreamWriter writer = new StreamWriter(saveFile.FileName))
                {
                    writer.Write(tbNote.Text);
                }
                modified = false;
            }
            return res;
        }

        private void tbNota_TextChanged(object sender, EventArgs e)
        {
            modified = true;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult res = options(sender, e);
            if (res.Equals(DialogResult.Cancel))
            {
                e.Cancel = true;
            }
        }
    }
}
