using System;

class Program
{
    static void Main(string[] args)
    {
        // Pedido 1: Cliente nos EUA (Frete de $5)
        Endereco enderecoEua = new Endereco("123 Tech Lane", "San Jose", "CA", "EUA");
        Cliente clienteEua = new Cliente("Mark Smith", enderecoEua);
        Pedido pedido1 = new Pedido(clienteEua);
        
        pedido1.AdicionarProduto(new Produto("Mouse Gamer", "MG-01", 45.99, 1));
        pedido1.AdicionarProduto(new Produto("Teclado Mecânico", "TM-02", 89.50, 1));

        // Pedido 2: Cliente Internacional (Frete de $35)
        Endereco enderecoBrasil = new Endereco("Av. Principal, 100", "Itapeva", "SP", "Brasil");
        Cliente clienteBrasil = new Cliente("João Augusto", enderecoBrasil);
        Pedido pedido2 = new Pedido(clienteBrasil);

        pedido2.AdicionarProduto(new Produto("Placa de Vídeo GTX 1660", "VGA-1660", 210.00, 1));
        pedido2.AdicionarProduto(new Produto("Memória RAM 16GB", "RAM-016", 45.00, 2));
        pedido2.AdicionarProduto(new Produto("SSD 1TB", "SSD-001", 60.00, 1));

        // Exibindo Resultados - Pedido 1
        Console.WriteLine("================ PEDIDO 1 ================");
        Console.WriteLine(pedido1.GerarEtiquetaEmbalagem());
        Console.WriteLine(pedido1.GerarEtiquetaEnvio());
        Console.WriteLine($"\nCusto Total do Pedido: ${pedido1.CalcularCustoTotal():0.00}\n");

        // Exibindo Resultados - Pedido 2
        Console.WriteLine("================ PEDIDO 2 ================");
        Console.WriteLine(pedido2.GerarEtiquetaEmbalagem());
        Console.WriteLine(pedido2.GerarEtiquetaEnvio());
        Console.WriteLine($"\nCusto Total do Pedido: ${pedido2.CalcularCustoTotal():0.00}");
    }
}