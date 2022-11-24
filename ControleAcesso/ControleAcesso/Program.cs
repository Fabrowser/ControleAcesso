


using ControleAcesso;

internal class Program
{

    private static void Main(string[] args)
    {

        Cadastro cadastro = new Cadastro();

        cadastro.download();

        string opcao = "";

        while (opcao != "0")
        {

            Console.WriteLine(" 0. Sair\r\n 1. Cadastrar ambiente\r\n 2. Consultar ambiente\r\n " +
                "3. Excluir ambiente\r\n " +
                "4. Cadastrar usuario\r\n 5. Consultar usuario\r\n 6. Excluir usuario\r\n" +
                " 7. Conceder permissão de acesso ao usuario\r\n" +
                " 8. Revogar permissão de acesso ao usuario\r\n 9. Registrar acesso\r\n" +
                " 10. Consultar logs de acesso\r\n 11. Listar todos os usuários(com seus ambientes)");
            opcao = Console.ReadLine();


            switch (opcao)
            {

                case "1":
                    {
                        Console.Write("ID: ");
                        int id = int.Parse(Console.ReadLine());
                        Console.Write("Nome: ");
                        string nome = Console.ReadLine();
                        Ambiente ambiente = new Ambiente(id, nome);
                        cadastro.ambientes.Add(ambiente);
                        break;
                    }

                case "2":
                    {

                        //Pesquisa Ambiente
                        Console.WriteLine("Digite o ID Pesquisar: ");
                        int id = int.Parse(Console.ReadLine());

                        Ambiente ambiente_encontrado = cadastro.pesquisarAmbiente(id);
                        if (ambiente_encontrado != null)
                        {
                            Console.WriteLine("----------------------");
                            Console.WriteLine("Ambiente encontrado\n");
                            Console.WriteLine(ambiente_encontrado + "\n");
                            Console.WriteLine("----------------------");
                        }
                        else
                        {
                            Console.WriteLine("Ambiente não encontrado\n");
                        }
                        break;
                    }

                case "3":
                    {

                        Console.WriteLine("Excluir - Digite o ID: ");
                        int id = int.Parse(Console.ReadLine());
                        //Testa se existe o usuário
                        Ambiente ambiente_pesquisado = cadastro.pesquisarAmbiente(id);

                        if (ambiente_pesquisado != null)
                        {
                            if (cadastro.removerAmbiente(ambiente_pesquisado))
                            {
                                Console.WriteLine("Ambiente removido com SUCESSO!");

                            }

                        }
                        else
                        {

                            Console.WriteLine("Ambiente não localizado!");
                        }



                        break;

                    }
                case "4":
                    {
                        //Cadastra Usuario
                        Console.Write("ID: ");
                        int id = int.Parse(Console.ReadLine());
                        Console.Write("Nome: ");
                        string nome = Console.ReadLine();
                        Usuario usuario = new Usuario(id, nome);
                        if (cadastro.adicionarUsuario(usuario)==true)
                        {
                            cadastro.upload(usuario); //Grava usuario no banco de dados

                        }
                        else
                        {
                            Console.WriteLine("Ja existe usuario com o ID informado");
                        } 
                        Console.WriteLine();
                        break;
                    }

                case "5":
                    {
                        //Pesquisa Usuario
                        Console.WriteLine("Pesquisar - Digite o ID: ");
                        int id = int.Parse(Console.ReadLine());

                        //Testa se existe o usuário
                        Usuario usuario_encontrado = cadastro.pesquisarUsuario(id);

                        if (usuario_encontrado != null)
                        {
                            Console.WriteLine("----------------------");
                            Console.WriteLine("Usuário encontrado\n");
                            Console.WriteLine(usuario_encontrado + "\n");
                            Console.WriteLine("----------------------");
                        }
                        else
                        {
                            Console.WriteLine("Usuário não encontrado\n");
                        }
                        break;
                    }

                case "6":
                    {
                        Console.WriteLine("Excluir - Digite o ID: ");
                        int id = int.Parse(Console.ReadLine());
                        //Testa se existe o usuário
                        Usuario usuario_pesquisado = cadastro.pesquisarUsuario(id);

                        if (usuario_pesquisado != null)
                        {

                            if (cadastro.removerUsuario(usuario_pesquisado))
                            {
                                Console.WriteLine("Usuário removido com SUCESSO!");

                            }
                        }
                        else
                        {

                            Console.WriteLine("Usuário não localizado!");
                        }
                        break;
                    }

                case "7":
                    {
                        //Conceder Permissão
                        Console.WriteLine("Digite o ID do usuário");
                        int id_usuario = int.Parse(Console.ReadLine());
                        Console.WriteLine("Digite o ambiente");
                        int id_ambiente = int.Parse(Console.ReadLine());

                        // Pesquisar usuário
                        Usuario usuario_encontrado = cadastro.pesquisarUsuario(id_usuario);
                        // Pesquisar ambiente
                        Ambiente ambiente_encontrato = cadastro.pesquisarAmbiente(id_ambiente);

                        if (usuario_encontrado != null && ambiente_encontrato != null)
                        {
                            Console.WriteLine((usuario_encontrado.concederPermissao(ambiente_encontrato)) ? "Acesso concedido com SUCESSO!" : "Usuário ja possui essa permissão");
                        }
                        else
                        {
                            Console.WriteLine("\nUsuário ou ambiente não localizado na base\n");
                        }

                        break;
                    }

                case "11":
                    {
                        cadastro.ListarCadastro();
                        break;

                    }

            }

        }
    }
}