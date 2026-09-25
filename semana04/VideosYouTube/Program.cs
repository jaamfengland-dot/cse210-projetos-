using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Variáveis locais usando camelCase (Critério 8)
        List<Video> listaVideos = new List<Video>();

        // Criando Vídeo 1 e seus 3 comentários (Critério 5)
        Video video1 = new Video("Aprenda C# em 10 minutos", "João Augusto", 600);
        video1.AdicionarComentario(new Comentario("Maria", "Ótimo vídeo!"));
        video1.AdicionarComentario(new Comentario("Carlos", "Me ajudou muito na prova."));
        video1.AdicionarComentario(new Comentario("Ana", "Poderia fazer um sobre Python?"));
        listaVideos.Add(video1);

        // Criando Vídeo 2 e seus 3 comentários
        Video video2 = new Video("Gameplay de Nier Replicant", "GamerBR", 1200);
        video2.AdicionarComentario(new Comentario("Pedro", "Essa parte do jogo é muito difícil."));
        video2.AdicionarComentario(new Comentario("Lucas", "Qual configuração você usa?"));
        video2.AdicionarComentario(new Comentario("Sofia", "A trilha sonora é incrível."));
        listaVideos.Add(video2);

        // Criando Vídeo 3 e seus 3 comentários
        Video video3 = new Video("Receita de Coxinha", "Cozinha Prática", 450);
        video3.AdicionarComentario(new Comentario("Teresa", "Fiz e ficou uma delícia!"));
        video3.AdicionarComentario(new Comentario("Roberto", "Posso assar em vez de fritar?"));
        video3.AdicionarComentario(new Comentario("Juliana", "Vou tentar fazer neste fim de semana."));
        listaVideos.Add(video3);

        // Percorrendo a lista e exibindo os dados (Critério 6)
        foreach (Video video in listaVideos)
        {
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine($"Título: {video.ObterTitulo()}");
            Console.WriteLine($"Autor: {video.ObterAutor()}");
            Console.WriteLine($"Duração: {video.ObterDuracao()} segundos");
            
            // Usando o método para exibir o número de comentários
            Console.WriteLine($"Número de Comentários: {video.ObterNumeroComentarios()}");
            Console.WriteLine("Comentários:");
            
            // Percorrendo os comentários daquele vídeo
            foreach (Comentario comentario in video.ObterComentarios())
            {
                Console.WriteLine($"- {comentario.ObterNome()}: {comentario.ObterTexto()}");
            }
        }
        Console.WriteLine("--------------------------------------------------");
    }
}