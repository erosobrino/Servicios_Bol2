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

namespace Ejer2
{
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
                tbNota.Text = "";
            }
        }
        private DialogResult options(object sender, EventArgs e)
        {
            if (tbNota.Text.Length > 0 && modified)
            {
                DialogResult dialog = MessageBox.Show("Desea guardar el texto antiguo?", "Guardado", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
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
                openFile.Title = "Selecciona un archivo para abrir";
                //saveFile.InitialDirectory = "C:\\";
                openFile.InitialDirectory = "D:\\";
                openFile.Filter = "Texto (*.txt)|*.txt|Todos los archivos|*.*";
                openFile.ValidateNames = true;
                DialogResult res = openFile.ShowDialog();
                if (res == DialogResult.OK)
                {
                    using (StreamReader reader = new StreamReader(openFile.FileName))
                    {
                        //String line = reader.ReadLine();
                        //while (line != null)
                        //{
                        //    tbNota.AppendText(line);
                        //    line = reader.ReadLine();
                        //}
                        tbNota.Text = reader.ReadToEnd();
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
            saveFile.Title = "Selecciona la ruta y el nombre";
            //saveFile.InitialDirectory = "C:\\";
            saveFile.InitialDirectory = "D:\\";
            saveFile.Filter = "Texto (*.txt)|*.txt|Todos los archivos|*.*";
            saveFile.ValidateNames = true;
            DialogResult res = saveFile.ShowDialog();
            if (res == DialogResult.OK)
            {
                using (StreamWriter writer = new StreamWriter(saveFile.FileName))
                {
                    writer.Write(tbNota.Text);
                }
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
