using System;

public class Comentario
{
    // Variáveis de membro usando _underscoreCamelCase (Critério 8)
    private string _nome;
    private string _texto;

    // Método construtor em TitleCase
    public Comentario(string nome, string texto)
    {
        _nome = nome;
        _texto = texto;
    }

    // Métodos em TitleCase para recuperar os dados
    public string ObterNome()
    {
        return _nome;
    }

    public string ObterTexto()
    {
        return _texto;
    }
}