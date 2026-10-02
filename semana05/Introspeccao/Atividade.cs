using System;
using System.Collections.Generic;
using System.Threading;

public class Atividade
{
    private string _nome;
    private string _descricao;
    protected int _duracao;

    public Atividade(string nome, string descricao)
    {
        _nome = nome;
        _descricao = descricao;
    }

    public void ExibirMensagemInicial()
    {
        Console.Clear();
        Console.WriteLine($"Bem-vindo à {_nome}.\n");
        Console.WriteLine($"{_descricao}\n");
        Console.Write("Quantos segundos você deseja para esta atividade? ");

        _duracao = int.Parse(Console.ReadLine());

        Console.Clear();
        Console.WriteLine("Prepare-se...");
        ExibirSpinner(3);
    }

    public void ExibirMensagemFinal()
    {
        Console.WriteLine("\n");
        Console.WriteLine("Bom trabalho!!");
        ExibirSpinner(3);
        Console.WriteLine($"\nVocê concluiu a {_nome} por {_duracao} segundos.");
        ExibirSpinner(3);
    }

    public void ExibirSpinner(int segundos)
    {
        List<string> animacoes = new List<string>
        {
            "|", "/", "-", "\\"
        };

        DateTime inicio = DateTime.Now;
        DateTime fim = inicio.AddSeconds(segundos);

        int indice = 0;

        while (DateTime.Now < fim)
        {
            string animacao = animacoes[indice];

            Console.Write(animacao);
            Thread.Sleep(250);
            Console.Write("\b \b");

            indice++;

            if (indice >= animacoes.Count)
            {
                indice = 0;
            }
        }
    }

    public void ExibirContagemRegressiva(int segundos)
    {
        for (int i = segundos; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }

    public virtual void Executar()
    {
    }
}
