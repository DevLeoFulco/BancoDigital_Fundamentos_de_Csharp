using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BancoLL.Model;




List<Cliente> Clientes = new List<Cliente>();

    ConsultarCliente();

    void ConsultarCliente()
    {
    Console.WriteLine("Olá! Bem vindo ao BancoLL.");
    Console.WriteLine("Digite seu codigo: ");
    string codigo = Console.ReadLine();
    Cliente cliente = null;

    foreach (Cliente cli in Clientes)
    {
        if (cli.Codigo == codigo)
        {
            cliente = cli;
        }
    }
    if (cliente == null)
    {
        Console.WriteLine("Este cliente não existe. Deseja cadastrar? Digite S ou N");
        string cadastrarCliente = Console.ReadLine();
        if (cadastrarCliente == "S")
        {
            Console.WriteLine("Digite seu código:");
            string codigoClienteNovo = Console.ReadLine();
            Console.WriteLine("Digite seu nome:");
            string nomeClienteNovo = Console.ReadLine();
            Console.WriteLine("Digite PF ou PJ :");
            string tipoPessoa = Console.ReadLine();
            if (tipoPessoa == "PF")

                cliente = new PessoaFisica(codigoClienteNovo, nomeClienteNovo);
            else
                cliente = new PessoaJuridica(codigoClienteNovo, nomeClienteNovo);
            Clientes.Add(cliente);
            ExibirMenu(cliente);
        }
        else
            ConsultarCliente();
    }
}


void ExibirMenu(Cliente cliente)
{
    Console.WriteLine($"Olá {cliente.Nome}");
    Console.WriteLine("Digite a opção desejada:");
    Console.WriteLine("1- Extrato");
    Console.WriteLine("2- Saque");
    Console.WriteLine("3- Deposito");

    string menu = Console.ReadLine();

    switch (menu)
    {
        case "1":
            ExibirExtrato(cliente);
            break;
        case "2":
            RealizarSaque(cliente);
            break;
        case "3":
            RealizarDeposito(cliente);
            break;

        default:
            Console.WriteLine("Digite a opção correta.");
            ExibirMenu(cliente);
            break;
    }


}


void ExibirExtrato(Cliente cliente)
{
    Console.WriteLine("------- EXTRATO -------");

    foreach (Movimentacao mov in cliente.Movimentacoes)
    {
        Console.WriteLine($"{mov.Tipo} - {mov.Valor}");
    }

    Console.WriteLine("Deseja Exibir o menu novamente? Digite S ou N ");
    string exibirMenu = Console.ReadLine();
    if (exibirMenu == "S")
    {
        ExibirMenu(cliente);
    }
    else
    {
        Console.WriteLine("Deseja consultar outro cliente? Digite S ou N");
        string consultarCliente = Console.ReadLine();
        if (consultarCliente == "S")
        {
            ConsultarCliente();
        }
    }
}


void RealizarSaque(Cliente cliente)

{
    Console.WriteLine("Digite o valor que deseja sacar: ");
    string valorStr = Console.ReadLine();

    if (decimal.TryParse(valorStr, out decimal valor))
    {
        cliente.RealizarSaque(valor);
        Console.WriteLine("Deseja realizar outra transação? Digite S ou N");
        string realizarOutraTransacao = Console.ReadLine();
        if (realizarOutraTransacao == "S")
            ExibirMenu(cliente);
        else
            Console.WriteLine("Foi um prazer te atender! Até mais!");
    }
    else
    {
        Console.WriteLine("Valor inserido é inválido. Por favor, tente novamente.");
        RealizarSaque(cliente);  // Chama a função novamente para permitir que o usuário insira um valor válido.
    }

}

void RealizarDeposito(Cliente cliente)
{
    Console.WriteLine("Qual valor deseja depositar: ");
    string valorStr = Console.ReadLine();
    if (decimal.TryParse(valorStr, out decimal valor))
    {
        cliente.RealizarDeposito(valor);
        Console.WriteLine("Deseja realizar outra operação? Digite S ou N");
        string realizarOutraTransacao = Console.ReadLine();
        if (realizarOutraTransacao == "S")
            ExibirMenu(cliente);
        else
            Console.WriteLine("Foi um prazer te atender! Até mais!");
    }
    else
    {
        Console.WriteLine("Valor inserido é inválido. Por favor, tente novamente.");
        RealizarDeposito(cliente);  // Chama a função novamente para permitir que o usuário insira um valor válido.
    }

}
