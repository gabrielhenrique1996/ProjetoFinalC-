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
    public partial class SistemaPerolaNegra : Form
    {

        int idAlterar;
        public SistemaPerolaNegra()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            tabCadastrar.Height = btnBuscar.Height;
            tabCadastrar.Top = btnBuscar.Top;
            tabControl.SelectedTab = tabControl.TabPages[1];
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            tabBuscar.Height = btnCadastrar.Height;
            tabBuscar.Top = btnCadastrar.Top;
            tabControl.SelectedTab = tabControl.TabPages[0];
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        void listaDGMercadoria()
        {
            ConectaBanco con = new ConectaBanco();
            dgMercadoria.DataSource = con.listaMercadoria();
            lblMensagem.Text = con.mensagem;
        }
        private void SistemaPerolaNegra_Load(object sender, EventArgs e)
        {
            listaDGMercadoria();
        }

        void limpaCampos()
        {
            txtProduto.Clear();
            txtCategoria.Clear();
            txtQuantidade.Clear();
            txtTamanho.Clear();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            mercadoria m = new mercadoria();
            m.Produto = txtProduto.Text;
            m.Categoria = txtCategoria.Text;
            m.Quantidade = Convert.ToInt32(txtQuantidade.Text);
            m.Tamanho = txtTamanho.Text;
            ConectaBanco con = new ConectaBanco();
            bool r = con.insereMercadoria(m);
            if (r == true)
            {
                MessageBox.Show("Dados inseridos com sucesso!!");
                listaDGMercadoria();
                limpaCampos();
                txtProduto.Focus();
            }
            else
                lblMensagem.Text = con.mensagem;

            
        }

        private void txtBusca_TextChanged(object sender, EventArgs e)
        {
            (dgMercadoria.DataSource as DataTable).DefaultView.RowFilter = 
                string.Format("produto like '{0}%'", txtBusca.Text);


        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            int linha = dgMercadoria.CurrentRow.Index;
            int id = Convert.ToInt32(dgMercadoria.Rows[linha].Cells["idmercadoria"].Value.ToString() );
            DialogResult resp = MessageBox.Show("Tem certeza que deseja excluir a mercadoria?",
                "Remove Mercadoria", MessageBoxButtons.OKCancel);
            if (resp == DialogResult.OK)
            {
                ConectaBanco con = new ConectaBanco();
                bool retorno = con.deleteMercadoria(id);
                if (retorno == true)
                {
                    MessageBox.Show("Banda excluida com sucesso!");
                    listaDGMercadoria();
                }
                else
                    MessageBox.Show(con.mensagem);

            }

            else
                MessageBox.Show("A Exclusão foi cancelada!");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int linha = dgMercadoria.CurrentRow.Index;
            idAlterar = Convert.ToInt32(dgMercadoria.Rows[linha].Cells["idmercadoria"].Value.ToString());
            txtAlteraProduto.Text = dgMercadoria.Rows[linha].Cells["produto"].Value.ToString();
            txtAlteraCategoria.Text = dgMercadoria.Rows[linha].Cells["categoria"].Value.ToString();
            txtAlteraQuantidade.Text = dgMercadoria.Rows[linha].Cells["quantidade"].Value.ToString();
            txtAlteraTamanho.Text = dgMercadoria.Rows[linha].Cells["tamanho"].Value.ToString();
            tabControl.SelectedTab = tabAlterar;
        }

        private void btnAlterar2_Click(object sender, EventArgs e)
        {
            mercadoria m = new mercadoria();
            m.Produto = txtAlteraProduto.Text;
            m.Categoria = txtAlteraCategoria.Text;
            m.Quantidade = Convert.ToInt32(txtAlteraQuantidade.Text);
            m.Tamanho = txtAlteraTamanho.Text;
            ConectaBanco con = new ConectaBanco();
            bool ret = con.alteraMercadoria(m, idAlterar);
            if (ret == true)
            {
                MessageBox.Show("Sua mercadoria foi alterada com sucesso!!");
                listaDGMercadoria();
                tabControl.SelectedTab = tabBuscar;
            }
            else
                MessageBox.Show(con.mensagem);
        }
    }
}
