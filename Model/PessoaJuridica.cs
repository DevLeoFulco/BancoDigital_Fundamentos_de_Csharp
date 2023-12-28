using System;

namespace BancoLL.Model
{
    public class PessoaJuridica : Cliente
    {
        public PessoaJuridica(string codigo, string nome) : base(codigo, nome)
        {
        }

        protected override decimal DescontarTaxa(decimal valor)
        {
            return valor - 2;
        }
    }
}
