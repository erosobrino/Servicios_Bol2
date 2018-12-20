using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejer3
{
    public partial class Form2 : Form
    {
        public int R;
        public int G;
        public int B;
        public Form2()
        {
            InitializeComponent();
        }

        private void btAcept_Click(object sender, EventArgs e)
        {
            lblError.Text = "";
            try
            {
                R = Convert.ToInt32(txtRed.Text);
                G = Convert.ToInt32(txtGreen.Text);
                B = Convert.ToInt32(txtBlue.Text);
                if (R < 0 || R > 255 || G < 0 || G > 255 || B < 0 || B > 255)
                {
                    throw new OverflowException();
                }
                this.DialogResult = DialogResult.OK;
            }
            catch (FormatException)
            {
                lblError.Text = "The numbers must be valid numbers";
            }
            catch (OverflowException)
            {
                lblError.Text = "The numbers must be between 0-255";
            }
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
