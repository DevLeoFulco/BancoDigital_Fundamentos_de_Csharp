using System;



namespace BancoLL.Model
{   

    public class Movimentacao
    {
        public string Tipo { get; set; }
        public decimal Valor { get; set; }

        public Movimentacao(string tipo, decimal valor)
        {
            Tipo = tipo;
            Valor = valor;
        }
    }
    public abstract class Cliente
    {
        public string Codigo { get; private set; }
        public string Nome { get; private set; }
        public decimal Saldo { get; private set; }

        public List<Movimentacao> Movimentacoes { get; private set; }

        protected Cliente()
        {
            Movimentacoes = new List<Movimentacao>();
        }

        protected Cliente(string codigo, string nome) : this()
        {
            Nome = nome;
            Codigo = codigo;
        }

        public void RealizarSaque(decimal valor)
        {
            if (Saldo >= valor && valor > 0)
            {
                AtualizarSaldo(valor, "SAQUE");
            }
            else
            {
                Console.WriteLine("Saldo insuficiente ou valor inválido!");
            }
        }

        public void RealizarDeposito(decimal valor)
        {
            if (valor >= 10)
            {
                AtualizarSaldo(valor, "DEPOSITO");
            }
            else
            {
                Console.WriteLine("Valor deve ser maior ou igual a R$10,00");
            }
        }

        private void AtualizarSaldo(decimal valor, string tipo)
        {
            decimal valorDescontado = DescontarTaxa(valor);
            Saldo += tipo == "SAQUE" ? -valorDescontado : valorDescontado;
            Movimentacoes.Add(new Movimentacao(tipo, valorDescontado));
            Console.WriteLine($"{tipo} realizado com SUCESSO! Saldo: {Saldo}");
        }

        protected abstract decimal DescontarTaxa(decimal valor);
    }
}
