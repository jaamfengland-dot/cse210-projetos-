using System;
using System.Collections.Generic;
using System.IO;

public class Diario
{
    private List<Registro> _registros = new List<Registro>();

    public void AdicionarRegistro(Registro novoRegistro)
    {
        _registros.Add(novoRegistro);
    }

    public void ExibirTodos()
    {
        foreach (Registro registro in _registros)
        {
            registro.Exibir();
        }
    }

    public void SalvarNoArquivo(string arquivo)
    {
        using (StreamWriter writer = new StreamWriter(arquivo))
        {
            foreach (Registro registro in _registros)
            {
                writer.WriteLine($"{registro._data}~|~{registro._textoPergunta}~|~{registro._textoResposta}");
            }
        }
    }

    public void CarregarDoArquivo(string arquivo)
    {
        _registros = new List<Registro>();
        string[] linhas = File.ReadAllLines(arquivo);

        foreach (string linha in linhas)
        {
            string[] partes = linha.Split("~|~");
            Registro registro = new Registro();
            registro._data = partes[0];
            registro._textoPergunta = partes[1];
            registro._textoResposta = partes[2];
            _registros.Add(registro);
        }
    }
}