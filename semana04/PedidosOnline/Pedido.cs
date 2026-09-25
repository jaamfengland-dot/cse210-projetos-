using System;
using System.Collections.Generic;

public class Pedido
{
    private List<Produto> _produtos;
    private Cliente _cliente;

    public Pedido(Cliente cliente)
    {
        _cliente = cliente;
        _produtos = new List<Produto>();
    }

    public void AdicionarProduto(Produto produto)
    {
        _produtos.Add(produto);
    }

    public double CalcularCustoTotal()
    {
        double totalParcial = 0;
        
        foreach (Produto produto in _produtos)
        {
            totalParcial += produto.CalcularCustoTotal();
        }

        double frete = _cliente.MoraNosEUA() ? 5.00 : 35.00;
        
        return totalParcial + frete;
    }

    public string GerarEtiquetaEmbalagem()
    {
        string etiqueta = "--- ETIQUETA DE EMBALAGEM ---\n";
        foreach (Produto produto in _produtos)
        {
            etiqueta += $"ID: {produto.ObterId()} - {produto.ObterNome()}\n";
        }
        return etiqueta;
    }

    public string GerarEtiquetaEnvio()
    {
        string etiqueta = "--- ETIQUETA DE ENVIO ---\n";
        etiqueta += $"Destinatário: {_cliente.ObterNome()}\n";
        etiqueta += $"{_cliente.ObterEnderecoCompleto()}";
        return etiqueta;
    }
}