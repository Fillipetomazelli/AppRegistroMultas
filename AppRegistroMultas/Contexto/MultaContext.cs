using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using AppRegistroMultas.Models;
using System.Reflection;
using Mysqlx.Crud;

namespace AppRegistroMultas.Contexto
{
    public class MultaContext
    {
        private string dados_conexao;
        private MySqlConnection conexao = null;

        //método construtor para carregar as informações dentro do objeto
        //"conexao" ara conectar com o banco Mysql

        public MultaContext()
        {
            dados_conexao = "server=localhost;port=3360;database=bd_registro_multa;user=root;password=root;Persist Security Info=False;Connect Timeout=300;";
            conexao = new MySqlConnection(dados_conexao);//conexão preparada => objeto criado e pronto para conectar ao banco

        }//fim do método construtor

        public List<Multa> ListarMultas()
        {

            List<Multa> listaMultasParaExportar = new List<Multa>();//para retornar(return) o resultado e ser utilizado na aplicação
            string sql = "SELECT * FROM MULTA";//consulta SQL para trazer todas as pessoas
            try
            {
                MySqlCommand comando = new MySqlCommand(sql, conexao); // objeto "comando" responsavel por ir até o banco e realizar ações
                conexao.Open();//abir a porta do Banco para realizar a consulta
                MySqlDataReader dados = comando.ExecuteReader();

                //laço responsável por percorrer todos os registros que estõ dentro do objeto "dados".
                while (dados.Read())
                {
                    Multa multa = new Multa();
                    multa.Id = Convert.ToInt32(dados["Id"]);
                    multa.Descricao = dados["Descricao"].ToString();
                    multa.ValorMulta = Convert.ToDecimal(dados["ValorMulta"]);
                    multa.VeiculoId = Convert.ToInt32(dados["VeiculoId"]);
                    listaMultasParaExportar.Add(multa);

                }//fim do while
                conexao.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show("ERRO" + ex.Message);
            }
            return listaMultasParaExportar;


        }//fim do metodo para consultar a lista veiculos(listar veiculos)

        public void InserirMulta(Multa multa)
        {
            //para inserir uma pessoa no banco
            string sql = "INSERT INTO MULTA (Descricao, ValorMulta, VeiculoId) VALUES (@Descricao, @ValorMulta, @VeiculoId)";
            try
            {
                MySqlCommand comando = new MySqlCommand(sql, conexao);

                //adicionando parâmetros para o evitar SQL Injection
                comando.Parameters.AddWithValue("@Descricao", multa.Descricao);
                comando.Parameters.AddWithValue("@ValorMulta", multa.ValorMulta);
                comando.Parameters.AddWithValue("@VeiculoId", multa.VeiculoId);

                conexao.Open(); //abrir as portas do banco
                int linhasAfetadas = comando.ExecuteNonQuery(); //executa e mostrar linha foram afetados

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao inserir Multa" + ex.Message);

            }
            finally
            {
                conexao.Close();//Fecha Fechar portas do banco, mesmo que ocorra erro
            }



        }//fim do metodo inserir veiculos

        public void AtualizarMulta(Multa multa)
        {
            // Comando SQL para atualizar os dados da pessoa
            string sql = "UPDATE MULTA SET Descricao = @Descricao, ValorMulta = @ValorMulta, veiculoId = @VeiculoId, WHERE Id = @Id";

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, conexao);

                // Adicionando parâmetros para evitar SQL Injection
                comando.Parameters.AddWithValue("@Descricao", multa.Descricao);
                comando.Parameters.AddWithValue("@ValorMulta", multa.ValorMulta);
                comando.Parameters.AddWithValue("@VeiculoId", multa.VeiculoId);
                comando.Parameters.AddWithValue("@Id", multa.Id); // Identifica qual registro será atualizado

                conexao.Open(); // Abrir conexão com o banco
                int linhasAfetadas = comando.ExecuteNonQuery(); // Executa o comando e retorna quantas linhas foram alteradas

                if (linhasAfetadas > 0)
                {
                    MessageBox.Show("Multa atualizada com sucesso!");
                }
                else
                {
                    MessageBox.Show("Nenhuma Multa foi atualizado. Verifique o ID informado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar Multa: " + ex.Message);
            }
            finally
            {
                conexao.Close(); // Fecha a conexão com o banco
            }
        } //fim do Atualizar Pessoa

        public void DeletarMulta(Multa multa)
        {
            // Comando SQL para atualizar os dados da pessoa
            string sql = "DELETE FROM MULTA WHERE Id = @Id";

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, conexao);

                // Adicionando parâmetros para evitar SQL Injection
                comando.Parameters.AddWithValue("@Descricao", multa.Descricao);
                comando.Parameters.AddWithValue("@ValorMulta", multa.ValorMulta);
                comando.Parameters.AddWithValue("@VeiculoId", multa.VeiculoId);
                comando.Parameters.AddWithValue("@Id", multa.Id); // Identifica qual registro será atualizado

                conexao.Open(); // Abrir conexão com o banco
                int linhasAfetadas = comando.ExecuteNonQuery(); // Executa o comando e retorna quantas linhas foram alteradas

                if (linhasAfetadas > 0)
                {
                    MessageBox.Show("Multa deletada com sucesso!");
                }
                else
                {
                    MessageBox.Show("Nenhuma Multa foi atualizado. Verifique o ID informado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar Multa: " + ex.Message);
            }
            finally
            {
                conexao.Close(); // Fecha a conexão com o banco
            }
        } //fim do Atualizar Pessoa



    }
}
