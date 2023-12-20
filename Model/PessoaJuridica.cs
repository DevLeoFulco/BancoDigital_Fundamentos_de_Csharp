using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BancoLL.Model
{
    public class PessoaJuridica : Cliente
    {
        public PessoaJuridica(string codigo,string nome): base(codigo,nome)
        {

        }

        public override decimal DescontarTaxa(decimal valor)
        {
            return valor - 2;
        }
    }
}