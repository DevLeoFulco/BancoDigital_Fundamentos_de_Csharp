using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


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

    public class Cliente
    {
        public string Codigo { get; private set; }
        public string Nome { get;private set; }
        public decimal Saldo { get;private set; }

     

        public List<Movimentacao> Movimentacoes {get; set;}

        public Cliente()
        {   
            
            Movimentacoes = new List<Movimentacao>();
        }

        public Cliente (string codigo, string nome ):this()
        {
            Nome = nome;
            Codigo = codigo;
        }

        public void RealizarSaque(decimal valor)
        {
            if(Saldo>valor)
            {
                decimal valorMenosTaxa = DescontarTaxa(valor);
                Saldo -= valor;
                AdicionarMovimentacao("SAQUE", valorMenosTaxa);
                Console.WriteLine($"Saque realizado com SUCESSO! Saldo: {Saldo}");
            }else
            {
                Console.WriteLine("Saldo insuficiente!");
            }
        }

        public void RealizarDeposito(decimal valor)
        {
            if (valor>=10)
            {
                decimal valorMenosTaxa = DescontarTaxa(valor);
                Saldo+= valorMenosTaxa;
                AdicionarMovimentacao("DEPOSITO", valorMenosTaxa);
                Console.WriteLine($"Deposito realizado com SUCESSO! Saldo: {Saldo}");
            }else
            {
                Console.WriteLine("Valor deve ser maior ou igua a R$10,00");
            }
            
        }

        private void AdicionarMovimentacao(string tipo, decimal valor)
        {
            Movimentacoes.Add(new Movimentacao(tipo, DescontarTaxa(valor)));
        }

        public virtual decimal DescontarTaxa(decimal valor)
        {
            return valor;
        }
    }   

}