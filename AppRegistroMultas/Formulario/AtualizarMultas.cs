using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppRegistroMultas.Models;
using AppRegistroMultas.Contexto;

namespace AppRegistroMultas.Formulario
{
    public partial class AtualizarMultas : Form
    {
        int contExe = 1;
        int cont = 1;
        int IdVeiculo;
        static int IdMulta;
        List<Veiculo> listaLojas = new List<Veiculo>();
        List<Multa> listaMultaTemp = new List<Multa>();
        public AtualizarMultas()
        {   
            InitializeComponent();
            MultaContext contexto = new MultaContext();
            listaMultaTemp = contexto.ListarMultas();
            cbPesquisa.DataSource = listaMultaTemp.ToList();
            cbPesquisa.DisplayMember = "Id";
            cbPesquisa.SelectedIndex = -1;
        }

        private void cbPesquisa_SelectedIndexChanged(object sender, EventArgs e)
        {
            int linhaselec = cbPesquisa.SelectedIndex;
            if (linhaselec > -1 && cont > 1)
            {
                var multa = listaMultaTemp[linhaselec];
                txtDescricao.Text = multa.Descricao.ToString();
                txtValor.Text = multa.ValorMulta.ToString();
                txtIdVeiculo.Text = multa.VeiculoId.ToString();
                IdMulta = multa.Id;
            }
            cont++;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var linhaSelec = cbPesquisa.SelectedIndex;
            if (linhaSelec > -1 && contExe > 0)
            {
                var MultaSelec = listaMultaTemp[linhaSelec];
                MultaSelec.Descricao = txtDescricao.Text;
                MultaSelec.ValorMulta = Convert.ToInt32(txtValor.Text);
                MultaSelec.VeiculoId = Convert.ToInt32(txtIdVeiculo.Text);

                MultaContext context = new MultaContext();
                context.AtualizarMulta(MultaSelec);
                MessageBox.Show("ID: " + MultaSelec.Id + "ATUALIZADO COM SUCESSO!", "2° A INF", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDescricao.Clear(); txtValor.Clear(); txtIdVeiculo.Clear(); 
                txtDescricao.Select();
                contExe = 0;
                listaMultaTemp = context.ListarMultas();
                cbPesquisa.DataSource = listaMultaTemp.ToList();
                cbPesquisa.SelectedIndex = -1;


            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var linhaSelec = cbPesquisa.SelectedIndex;
            if (linhaSelec > -1 && contExe > 0)
            {
                var MultaSelec = listaMultaTemp[linhaSelec];
                MultaSelec.Descricao = txtDescricao.Text;
                MultaSelec.ValorMulta = Convert.ToInt32(txtValor.Text);
                MultaSelec.VeiculoId = Convert.ToInt32(txtIdVeiculo.Text);

                MultaContext context = new MultaContext();
                context.DeletarMulta(MultaSelec);
                MessageBox.Show("ID: " + MultaSelec.Id + "deletado COM SUCESSO!", "2° A INF", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDescricao.Clear(); txtValor.Clear(); txtIdVeiculo.Clear();
                txtDescricao.Select();
                contExe = 0;
                listaMultaTemp = context.ListarMultas();
                cbPesquisa.DataSource = listaMultaTemp.ToList();
                cbPesquisa.SelectedIndex = -1;


            }
        }
    }
}
