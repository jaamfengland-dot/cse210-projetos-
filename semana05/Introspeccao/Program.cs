using System;

class Program
{
    static void Main(string[] args)
    {
        bool executando = true;

        while (executando)
        {
            Console.Clear();
            Console.WriteLine("Menu Principal - Programa de Introspecção");
            Console.WriteLine("1. Atividade de Respiração");
            Console.WriteLine("2. Atividade de Reflexão");
            Console.WriteLine("3. Atividade de Listagem");
            Console.WriteLine("4. Sair");
            Console.Write("\nEscolha uma opção (1-4): ");

            string escolha = Console.ReadLine();
            Atividade atividade = null;

            switch (escolha)
            {
                case "1":
                    atividade = new AtividadeRespiracao();
                    break;

                case "2":
                    atividade = new AtividadeReflexao();
                    break;

                case "3":
                    atividade = new AtividadeListagem();
                    break;

                case "4":
                    executando = false;
                    break;

                default:
                    Console.WriteLine("Opção inválida. Pressione Enter para tentar novamente.");
                    Console.ReadLine();
                    continue;
            }

            if (!executando)
                break;

            if (atividade != null)
            {
                atividade.Executar();
            }
        }
    }
}
