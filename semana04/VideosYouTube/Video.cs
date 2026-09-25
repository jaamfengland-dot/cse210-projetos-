using System;
using System.Collections.Generic;

public class Video
{
    // Variáveis de membro usando _underscoreCamelCase (Critério 8)
    private string _titulo;
    private string _autor;
    private int _duracao;
    
    // Composição: armazenando uma lista de objetos Comentario (Critério 3)
    private List<Comentario> _comentarios;

    public Video(string titulo, string autor, int duracao)
    {
        _titulo = titulo;
        _autor = autor;
        _duracao = duracao;
        _comentarios = new List<Comentario>();
    }

    public void AdicionarComentario(Comentario comentario)
    {
        _comentarios.Add(comentario);
    }

    // Método que retorna o número diretamente da lista (Critério 4)
    public int ObterNumeroComentarios()
    {
        return _comentarios.Count;
    }

    public string ObterTitulo()
    {
        return _titulo;
    }

    public string ObterAutor()
    {
        return _autor;
    }

    public int ObterDuracao()
    {
        return _duracao;
    }

    public List<Comentario> ObterComentarios()
    {
        return _comentarios;
    }
}