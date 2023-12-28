using System;

namespace BancoLL.Model
{
    public class PessoaFisica : Cliente
    {
        public PessoaFisica(string codigo, string nome) : base(codigo, nome)
        {
        }

        protected override decimal DescontarTaxa(decimal valor)
        {
            return valor - 1;
        }
    }
}
