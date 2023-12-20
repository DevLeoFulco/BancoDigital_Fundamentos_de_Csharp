using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BancoLL.Model
{
    public class PessoaFisica:Cliente
    {
        public PessoaFisica(string codigo,string nome):base(codigo,nome)
        {

        }

        public override decimal DescontarTaxa(decimal valor)
        {
            return valor - 1;
        }
    }
}