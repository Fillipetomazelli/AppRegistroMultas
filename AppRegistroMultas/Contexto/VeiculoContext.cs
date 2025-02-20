using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using AppRegistroMultas.Models;
using System.Reflection;

namespace AppRegistroMultas.Contexto
{
    public class VeiculoContext
    {
        private string dados_conexao;
        private MySqlConnection conexao = null;

        //método construtor para carregar as informações dentro do objeto
        //"conexao" ara conectar com o banco Mysql

        public VeiculoContext()
        {
            dados_conexao = "server=localhost;port=3360;database=bd_registro_multa;user=root;password=root;Persist Security Info=False;Connect Timeout=300;";
            conexao = new MySqlConnection(dados_conexao);//conexão preparada => objeto criado e pronto para conectar ao banco

        }//fim do método construtor

        public List<Veiculo> ListarVeiculos() 
        {

            List<Veiculo> listaVeiculosParaExportar = new List<Veiculo>();//para retornar(return) o resultado e ser utilizado na aplicação
            string sql = "SELECT * FROM VEICULO";//consulta SQL para trazer todas as pessoas
            try
            {
                MySqlCommand comando = new MySqlCommand(sql, conexao); // objeto "comando" responsavel por ir até o banco e realizar ações
                conexao.Open();//abir a porta do Banco para realizar a consulta
                MySqlDataReader dados = comando.ExecuteReader();

                //laço responsável por percorrer todos os registros que estõ dentro do objeto "dados".
                while (dados.Read())
                {
                    Veiculo veiculo = new Veiculo();
                    veiculo.Id = Convert.ToInt32(dados["Id"]);
                    veiculo.Modelo = dados["Modelo"].ToString();
                    veiculo.Marca = dados["Marca"].ToString();
                    veiculo.Placa = dados["Placa"].ToString();
                    listaVeiculosParaExportar.Add(veiculo);

                }//fim do while
                conexao.Close();
            }
             
            catch(Exception ex)
            {
                MessageBox.Show("ERRO" + ex.Message);
            }
            return listaVeiculosParaExportar;


        }//fim do metodo para consultar a lista veiculos(listar veiculos)

        public void InserirVeiculo(Veiculo veiculo)
        {
            //para inserir uma pessoa no banco
            string sql = "INSERT INTO VEICULO (Modelo, Marca, Placa) VALUES (@Modelo, @Marca, @Placa)";
            try
            {
                MySqlCommand comando = new MySqlCommand(sql, conexao);

                //adicionando parâmetros para o evitar SQL Injection
                comando.Parameters.AddWithValue("@Modelo", veiculo.Modelo);
                comando.Parameters.AddWithValue("@Marca", veiculo.Marca);
                comando.Parameters.AddWithValue("@Placa", veiculo.Placa);

                conexao.Open(); //abrir as portas do banco
                int linhasAfetadas = comando.ExecuteNonQuery(); //executa e mostrar linha foram afetados

            }
            catch(Exception ex)
            {
                MessageBox.Show("Erro ao inserir veiculo" + ex.Message);

            }
            finally
            {
                conexao.Close();//Fecha Fechar portas do banco, mesmo que ocorra erro
            }



        }//fim do metodo inserir veiculos

    }//fim da classe

}//fim do nameSpace
