using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaPerolaNegra
{
    public partial class FrmLoguin : Form
    {
        public FrmLoguin()
        {
            InitializeComponent();
        }

        private void btnAcessar_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "adm")
            {

                this.Hide();
                var form2 = new SistemaPerolaNegra();
                form2.Closed += (s, args) => this.Close();
                form2.Show();

            }
            else
                MessageBox.Show("Usuario não reconhecido!!");
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
