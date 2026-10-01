using System;
using System.Collections.Generic;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        bool running = true;
        while (running)
        {
            Console.Clear();
            Console.WriteLine("Menu Principal - Programa de Introspecção");
            Console.WriteLine("1. Atividade de Respiração");
            Console.WriteLine("2. Atividade de Reflexão");
            Console.WriteLine("3. Atividade de Listagem");
            Console.WriteLine("4. Sair");
            Console.Write("\nEscolha uma opção (1-4): ");

            string choice = Console.ReadLine();
            Activity activity = null;

            switch (choice)
            {
                case "1":
                    activity = new BreathingActivity();
                    break;
                case "2":
                    activity = new ReflectingActivity();
                    break;
                case "3":
                    activity = new ListingActivity();
                    break;
                case "4":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Opção inválida. Pressione Enter para tentar novamente.");
                    Console.ReadLine();
                    continue;
            }

            if (!running) break;

            if (activity != null)
            {
                activity.Run();
            }
        }
    }
}

// Classe Base (Abstração e Encapsulamento)
public class Activity
{
    private string _name;
    private string _description;
    protected int _duration;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Bem-vindo à {_name}.\n");
        Console.WriteLine($"{_description}\n");
        Console.Write("Quanto tempo, em segundos você deseja para esta atividade? ");
        _duration = int.Parse(Console.ReadLine());

        Console.Clear();
        Console.WriteLine("Prepare-se...");
        ShowSpinner(3);
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine("\n");
        Console.WriteLine("Bom trabalho!!");
        ShowSpinner(3);
        Console.WriteLine($"\nVocê concluiu a {_name} por {_duration} segundos.");
        ShowSpinner(3);
    }

    public void ShowSpinner(int seconds)
    {
        List<string> animationStrings = new List<string> { "|", "/", "-", "\\" };
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(seconds);

        int i = 0;
        while (DateTime.Now < endTime)
        {
            string s = animationStrings[i];
            Console.Write(s);
            Thread.Sleep(250);
            Console.Write("\b \b");

            i++;
            if (i >= animationStrings.Count)
            {
                i = 0;
            }
        }
    }

    public void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }

    public virtual void Run()
    {
    }
}

// Atividade de Respiração
public class BreathingActivity : Activity
{
    public BreathingActivity() : base("Atividade de Respiração", 
        "Esta atividade ajudará você a relaxar, inspirando e expirando lentamente. Limpe sua mente e concentre-se na sua respiração.")
    {
    }

    public override void Run()
    {
        DisplayStartingMessage();

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);

        bool inhale = true;
        while (DateTime.Now < endTime)
        {
            if (DateTime.Now >= endTime) break;

            if (inhale)
            {
                Console.Write("\nInspire...");
                ShowCountDown(4);
            }
            else
            {
                Console.Write("\nExpire...");
                ShowCountDown(6);
            }
            inhale = !inhale;
        }

        DisplayEndingMessage();
    }
}

// Atividade de Reflexão
public class ReflectingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Pense em uma ocasião em que você defendeu outra pessoa.",
        "Pense em uma ocasião em que você fez algo realmente difícil.",
        "Pense em uma ocasião em que você ajudou alguém necessitado.",
        "Pense em uma ocasião em que você fez algo verdadeiramente altruísta."
    };

    private List<string> _questions = new List<string>
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

    private Random _random = new Random();

    public ReflectingActivity() : base("Atividade de Reflexão",
        "Esta atividade ajudará você a refletir sobre momentos da sua vida em que você demonstrou força e resiliência. Isso ajudará você a reconhecer o poder que você tem e como pode usá-lo em outros aspectos da sua vida.")
    {
    }

    public override void Run()
    {
        DisplayStartingMessage();

        Console.WriteLine("\nConsidere o seguinte prompt:\n");
        Console.WriteLine($"--- {GetRandomPrompt()} ---\n");
        Console.WriteLine("Quando tiver isso em mente, pressione Enter para continuar.");
        Console.ReadLine();

        Console.WriteLine("Agora pondere sobre cada uma das seguintes questões relacionadas a essa experiência.");
        Console.Write("Você pode começar em: ");
        ShowCountDown(5);
        Console.Clear();

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            if (DateTime.Now >= endTime) break;

            Console.Write($"\n> {GetRandomQuestion()} ");
            ShowSpinner(6);
        }

        DisplayEndingMessage();
    }

    private string GetRandomPrompt()
    {
        int index = _random.Next(_prompts.Count);
        return _prompts[index];
    }

    private string GetRandomQuestion()
    {
        int index = _random.Next(_questions.Count);
        return _questions[index];
    }
}

// Atividade de Listagem
public class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Quem são as pessoas que você aprecia?",
        "Quais são seus pontos fortes pessoais?",
        "Quem são as pessoas que você ajudou esta semana?",
        "Quando você sentiu paz interior e gratidão neste mês?",
        "Quem são alguns dos seus heróis pessoais?"
    };

    private Random _random = new Random();

    public ListingActivity() : base("Atividade de Listagem",
        "Esta atividade ajudará você a refletir sobre as coisas boas da sua vida, fazendo com que você liste o máximo de coisas que puder em uma determinada área.")
    {
    }

    public override void Run()
    {
        DisplayStartingMessage();

        Console.WriteLine("\nConsidere o seguinte prompt:\n");
        Console.WriteLine($"--- {GetRandomPrompt()} ---\n");
        Console.WriteLine("Você poderá começar a listar em:");
        ShowCountDown(5);
        Console.WriteLine();

        List<string> userItems = GetListFromUser();
        Console.WriteLine($"\nVocê listou {userItems.Count} itens!");

        DisplayEndingMessage();
    }

    private string GetRandomPrompt()
    {
        int index = _random.Next(_prompts.Count);
        return _prompts[index];
    }

    private List<string> GetListFromUser()
    {
        List<string> items = new List<string>();
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            TimeSpan remaining = endTime - DateTime.Now;
            if (remaining.TotalSeconds <= 0) break;

            Console.Write("> ");
            string line = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(line))
            {
                items.Add(line);
            }

            if (DateTime.Now >= endTime) break;
        }
        return items;
    }
}