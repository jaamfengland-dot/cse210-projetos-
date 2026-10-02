using System;
using System.Collections.Generic;

public class AtividadeListagem : Atividade
{
    private List<string> _prompts = new List<string>
    {
        "Quem são as pessoas que você aprecia?",
        "Quais são seus pontos fortes pessoais?",
        "Quem são as pessoas que você ajudou esta semana?",
        "Quando você sentiu paz interior e gratidão neste mês?",
        "Quem são alguns dos seus heróis pessoais?"
    };

    private Random _aleatorio = new Random();

    public AtividadeListagem() : base(
        "Atividade de Listagem",
        "Esta atividade ajudará você a refletir sobre as coisas boas da sua vida, " +
        "fazendo com que você liste o máximo de coisas que puder em uma determinada área.")
    {
    }

    public override void Executar()
    {
        ExibirMensagemInicial();

        Console.WriteLine("\nConsidere o seguinte prompt:\n");
        Console.WriteLine($"--- {ObterPromptAleatorio()} ---\n");

        Console.WriteLine("Você poderá começar a listar em:");
        ExibirContagemRegressiva(5);
        Console.WriteLine();

        List<string> itens = ObterListaDoUsuario();

        Console.WriteLine($"\nVocê listou {itens.Count} itens!");

        ExibirMensagemFinal();
    }

    private string ObterPromptAleatorio()
    {
        int indice = _aleatorio.Next(_prompts.Count);
        return _prompts[indice];
    }

    private List<string> ObterListaDoUsuario()
    {
        List<string> itens = new List<string>();

        DateTime inicio = DateTime.Now;
        DateTime fim = inicio.AddSeconds(_duracao);

        while (DateTime.Now < fim)
        {
            TimeSpan restante = fim - DateTime.Now;

            if (restante.TotalSeconds <= 0)
                break;

            Console.Write("> ");

            string linha = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(linha))
            {
                itens.Add(linha);
            }

            if (DateTime.Now >= fim)
                break;
        }

        return itens;
    }
}
