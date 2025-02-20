using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppRegistroMultas.Contexto;
using AppRegistroMultas.Models;

namespace AppRegistroMultas.Formulario
{
    public partial class FormConsultaVeiculo : Form
    {
        int cont = 1; 
        List<Veiculo> listaVeiculos = new List<Veiculo>();  
        List<Multa> listaMulta = new List<Multa>();

        public FormConsultaVeiculo()
        {
            InitializeComponent();
            //listaVeiculos = Context.ListaVeiculos.ToList();
            VeiculoContext context = new VeiculoContext();
            listaVeiculos = context.ListarVeiculos();
            //listaMulta = Context.ListaMultas.ToList();
            MultaContext contextt = new MultaContext();
            listaMulta = contextt.ListarMultas();
            cbVeiculo.DataSource = listaVeiculos.ToList();
            cbVeiculo.DisplayMember = "Placa";
            cbVeiculo.SelectedIndex = -1; //combobox em branco
        }

        private void cbVeiculo_SelectedIndexChanged(object sender, EventArgs e)
        {
            int linhaSelec = cbVeiculo.SelectedIndex;
            if (linhaSelec > -1 && cont > 1)
            {
                var veiculo = listaVeiculos[linhaSelec];
                txtModelo.Text = veiculo.Modelo;
                txtMarca.Text = veiculo.Marca;
                txtPlaca.Text = veiculo.Placa;
                
                var listaMultasVinc = listaMulta.Where(m=>m.VeiculoId == veiculo.Id).ToList();
                //selecionar multas vinculas ao veículo selecionado 
                dtTabela.DataSource = listaMultasVinc.ToList();//mostrar na tabela
            }
            cont++;
        }
    }
}
