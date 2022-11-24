using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;
using MySql.Data.MySqlClient;
using System.IO;
using System.Data.Common;
using System.Data;

namespace ControleAcesso


{
    internal class Cadastro
    {

        MySqlConnection Conexao;

        public List<Usuario> usuarios = new List<Usuario>();
        public List<Ambiente> ambientes = new List<Ambiente>();


        public void carregaDadosBanco(Usuario usuario)
        {
            usuarios.Add(usuario);
        }


        public bool adicionarUsuario(Usuario usuario)
        {

            foreach (Usuario user in usuarios)
            {

                if (usuario.id == user.id)
                {
                  
                    return false;

                }

            }
            usuarios.Add(usuario);
            return true;

        }

        public bool removerUsuario(Usuario usuario)
        {

            foreach (Usuario user in usuarios)
            {

                if (usuario.id == user.id)
                {
                    usuarios.Remove(usuario);
                    return true;

                }

            }
            return false;
        }

        public Usuario pesquisarUsuario(int id)
        {

            foreach (Usuario user in usuarios)
            {

                if (id == user.id)
                {

                    return user;

                }

            }
            return null;

        }

        public void adicionarAmbiente(Ambiente ambiente)
        {



        }

        public bool removerAmbiente(Ambiente ambiente)
        {

            foreach (Ambiente amb in ambientes)
            {

                if (amb.id == ambiente.id)
                {
                    ambientes.Remove(ambiente);
                    return true;

                }
            }
            return false;

        }


        public Ambiente pesquisarAmbiente(int id)
        {

            foreach (Ambiente ambient in ambientes)
            {

                if (ambient.id == id)
                {

                    return ambient;

                }

            }
            return null;


        }


        public void ListarCadastro()
        {

            foreach (Usuario user in usuarios)
            {
                Console.WriteLine("----------------------");
                Console.WriteLine("Usuário");
                Console.WriteLine(user);
                Console.WriteLine();

                if (user.ambientes.Count != 0)
                {
                    Console.WriteLine("   Ambientes de acesso");
                    foreach (Ambiente ambiente in user.ambientes)
                    {
                        if (ambiente != null)
                            Console.WriteLine(ambiente);
                    }

                }
                Console.WriteLine("----------------------");

            }

        }

        public void upload(Usuario user)
        {
            try
            {
                string data_source = "datasource=localhost;username=root;password=;database=db_controleacesso";
                //Criar conexao MySQL
                Conexao = new MySqlConnection(data_source);


                string sql = "INSERT INTO usuario(id,nome)" +
                "VALUES" +
                "('" + user.id + "','" + user.nome + "')";

                MySqlCommand comando = new MySqlCommand(sql, Conexao);
                Conexao.Open();
                comando.ExecuteReader();
                Console.Write(" - Dados inseridos com Sucesso!!");

            }

            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);

            }
            finally
            {
                Conexao.Close();
            }

        }

        public void download()
        {
            try
            {

                MySqlDataAdapter dataAdapter;

                string data_source = "datasource=localhost;username=root;password=;database=db_controleacesso";
                //Criar conexao MySQL e abrir banco de dados
                Conexao = new MySqlConnection(data_source);
                Conexao.Open();

                string sql = "SELECT id,nome from usuario order by nome";
                MySqlCommand comando = new MySqlCommand(sql, Conexao);
                dataAdapter = new MySqlDataAdapter(comando);

                //Estrutura da tabela 
                DataTable tabela = new DataTable();

                //Preencher com a estrutura do select enviado com as tuplas
                dataAdapter.Fill(tabela);

                //Cria lista

                //Percorrer as linhas do datatable para adicionar na lista 
                foreach (DataRow dataRow in tabela.Rows)
                {
                    //Adiciona na lista Especificando a clouna 
                    int id = int.Parse(dataRow["id"].ToString());
                    string nome = dataRow["nome"].ToString();

                    Usuario user = new Usuario(id, nome);
                    carregaDadosBanco(user);

                }

                Console.WriteLine("QUANTIDADE DE USUARIOS ADICIONADOS: " + usuarios.Count());


            }

            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);

            }
            finally
            {
                Conexao.Close();
            }

        }

    }
}
