using System;
using System.Collections.Generic;

class Comentario
{
    public string NomeAutor;
    public string Texto;

    public Comentario(string nomeAutor, string texto)
    {
        NomeAutor = nomeAutor;
        Texto = texto;
    }
}

class Video
{
    public string Titulo;
    public string Autor;
    public int Duracao; // em segundos
    public List<Comentario> Comentarios = new List<Comentario>();

    public Video(string titulo, string autor, int duracao)
    {
        Titulo = titulo;
        Autor = autor;
        Duracao = duracao;
    }

    public int ObterQuantidadeComentarios()
    {
        return Comentarios.Count;
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Video> listaVideos = new List<Video>();

        // Criando Vídeo 1
        Video v1 = new Video("Aprenda C# em 10 minutos", "João Augusto", 600);
        v1.Comentarios.Add(new Comentario("Maria", "Ótimo vídeo!"));
        v1.Comentarios.Add(new Comentario("Carlos", "Me ajudou muito na prova."));
        v1.Comentarios.Add(new Comentario("Ana", "Poderia fazer um sobre Python?"));
        listaVideos.Add(v1);

        // Criando Vídeo 2
        Video v2 = new Video("Gameplay de Nier Replicant", "GamerBR", 1200);
        v2.Comentarios.Add(new Comentario("Pedro", "Essa parte do jogo é muito difícil."));
        v2.Comentarios.Add(new Comentario("Lucas", "Qual configuração você usa?"));
        v2.Comentarios.Add(new Comentario("Sofia", "A trilha sonora é incrível."));
        listaVideos.Add(v2);

        // Criando Vídeo 3
        Video v3 = new Video("Receita de Coxinha", "Cozinha Prática", 450);
        v3.Comentarios.Add(new Comentario("Teresa", "Fiz e ficou uma delícia!"));
        v3.Comentarios.Add(new Comentario("Roberto", "Posso assar em vez de fritar?"));
        v3.Comentarios.Add(new Comentario("Juliana", "Vou tentar fazer neste fim de semana."));
        listaVideos.Add(v3);

        // Exibindo os dados
        foreach (Video video in listaVideos)
        {
            Console.WriteLine($"\nTítulo: {video.Titulo} | Autor: {video.Autor} | Duração: {video.Duracao}s");
            Console.WriteLine($"Número de Comentários: {video.ObterQuantidadeComentarios()}");
            
            foreach (Comentario c in video.Comentarios)
            {
                Console.WriteLine($"- {c.NomeAutor}: {c.Texto}");
            }
            Console.WriteLine("--------------------------------------------------");
        }
    }
}