using System;
using System.Collections.Generic;

public class AtividadeReflexao : Atividade
{
    private List<string> _prompts = new List<string>
    {
        "Pense em uma ocasião em que você defendeu outra pessoa.",
        "Pense em uma ocasião em que você fez algo realmente difícil.",
        "Pense em uma ocasião em que você ajudou alguém necessitado.",
        "Pense em uma ocasião em que você fez algo verdadeiramente altruísta."
    };

    private List<string> _perguntas = new List<string>
    {
        "Por que essa experiência foi significativa para você?",
        "Você já fez algo assim antes?",
        "Como você começou?",
        "Como você se sentiu quando terminou?",
        "O que tornou esse momento diferente de outras vezes em que você não teve tanto sucesso?",
        "Qual é a sua coisa favorita sobre essa experiência?",
        "O que você pode aprender com essa experiência que se aplica a outras situações?",
        "O que você aprendeu sobre si mesmo por meio dessa experiência?",
        "Como você pode manter essa experiência em mente no futuro?"
    };

    private Random _aleatorio = new Random();

    public AtividadeReflexao() : base(
        "Atividade de Reflexão",
        "Esta atividade ajudará você a refletir sobre momentos da sua vida em que você " +
        "demonstrou força e resiliência. Isso ajudará você a reconhecer o poder que você " +
        "tem e como pode usá-lo em outros aspectos da sua vida.")
    {
    }

    public override void Executar()
    {
        ExibirMensagemInicial();

        Console.WriteLine("\nConsidere o seguinte prompt:\n");
        Console.WriteLine($"--- {ObterPromptAleatorio()} ---\n");

        Console.WriteLine("Quando tiver isso em mente, pressione Enter para continuar.");
        Console.ReadLine();

        Console.WriteLine(
            "Agora pondere sobre cada uma das seguintes questões relacionadas a essa experiência.");

        Console.Write("Você pode começar em: ");
        ExibirContagemRegressiva(5);

        Console.Clear();

        DateTime inicio = DateTime.Now;
        DateTime fim = inicio.AddSeconds(_duracao);

        while (DateTime.Now < fim)
        {
            Console.Write($"\n> {ObterPerguntaAleatoria()} ");
            ExibirSpinner(6);
        }

        ExibirMensagemFinal();
    }

    private string ObterPromptAleatorio()
    {
        int indice = _aleatorio.Next(_prompts.Count);
        return _prompts[indice];
    }

    private string ObterPerguntaAleatoria()
    {
        int indice = _aleatorio.Next(_perguntas.Count);
        return _perguntas[indice];
    }
}
