using System;

class Program
{
    static void Main(string[] args)
    {
        Diario meuDiario = new Diario();
        GeradorDePerguntas gerador = new GeradorDePerguntas();

        string escolha = "";
        while (escolha != "5")
        {
            Console.WriteLine("Diário");
            Console.WriteLine("1. Escrever ");
            Console.WriteLine("2. Exibir ");
            Console.WriteLine("3. Salvar ");
            Console.WriteLine("4. Carregar");
            Console.WriteLine("5. Sair");
            Console.Write("O que você gostaria de fazer? ");
            escolha = Console.ReadLine();
            Console.WriteLine();

            if (escolha == "1")
            {
                string pergunta = gerador.ObterPerguntaAleatoria();
                Console.WriteLine(pergunta);
                string resposta = Console.ReadLine();

                Registro novoRegistro = new Registro();
                novoRegistro._data = DateTime.Now.ToShortDateString();
                novoRegistro._textoPergunta = pergunta;
                novoRegistro._textoResposta = resposta;

                meuDiario.AdicionarRegistro(novoRegistro);
            }
            else if (escolha == "2")
            {
                meuDiario.ExibirTodos();
            }
            else if (escolha == "3")
            {
                Console.Write("Qual é o nome do arquivo? ");
                string nomeArquivo = Console.ReadLine();
                meuDiario.SalvarNoArquivo(nomeArquivo);
            }
            else if (escolha == "4")
            {
                Console.Write("Qual é o nome do arquivo? ");
                string nomeArquivo = Console.ReadLine();
                meuDiario.CarregarDoArquivo(nomeArquivo);
            }

            Console.WriteLine();
        }
    }
}