using System;

public class AtividadeRespiracao : Atividade
{
    public AtividadeRespiracao() : base(
        "Atividade de Respiração",
        "Esta atividade ajudará você a relaxar, inspirando e expirando lentamente. " +
        "Limpe sua mente e concentre-se na sua respiração.")
    {
    }

    public override void Executar()
    {
        ExibirMensagemInicial();

        DateTime inicio = DateTime.Now;
        DateTime fim = inicio.AddSeconds(_duracao);

        bool inspirar = true;

        while (DateTime.Now < fim)
        {
            if (inspirar)
            {
                Console.Write("\nInspire...");
                ExibirContagemRegressiva(4);
            }
            else
            {
                Console.Write("\nExpire...");
                ExibirContagemRegressiva(6);
            }

            inspirar = !inspirar;
        }

        ExibirMensagemFinal();
    }
}
