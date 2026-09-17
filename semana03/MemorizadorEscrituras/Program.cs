using System;

class Program
{
    static void Main(string[] args)
    {
        Reference reference = new Reference("Provérbios", 3, 5, 6);
        string text = "Confie no Senhor de todo o seu coração e não se apoie em sua própria inteligência.";
        
        Scripture scripture = new Scripture(reference, text);

        string userInput = "";

        while (userInput != "sair" && !scripture.IsAllHidden())
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();
            Console.WriteLine("Pressione Enter para ocultar mais palavras ou digite 'sair' para encerrar:");
            
            userInput = Console.ReadLine()?.Trim().ToLower();

            if (userInput != "sair")
            {
                scripture.HideRandomWords(3);
            }
        }

        Console.Clear();
        Console.WriteLine(scripture.GetDisplayText());
        Console.WriteLine("\nPrograma encerrado.");
    }
}