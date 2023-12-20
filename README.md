# BancoLL

Bem-vindo ao projeto **BancoLL**, um sistema simples de banco desenvolvido em C#. Este README fornece uma visão geral dos principais conceitos de C# aplicados neste projeto.

## Conceitos de C# Aplicados

### 1. Classes e Objetos

No C#, as classes são a base da orientação a objetos. Em `Cliente.cs`, temos uma classe `Cliente` que representa um cliente do banco. 

```csharp
namespace BancoLL.Model
{
    public class Cliente
    {
        // Propriedades e métodos da classe Cliente
    }
}
```

### 2. Propriedades

As propriedades são usadas para encapsular variáveis privadas e permitir a leitura e/ou escrita dessas variáveis por meio de métodos específicos. Exemplo em `Cliente.cs`:

```csharp
public string Codigo { get; private set; }
public string Nome { get; private set; }
```

### 3. Listas

A classe `List<T>` é usada para armazenar coleções de itens em C#. Em `Cliente.cs`, usamos uma lista para rastrear as movimentações financeiras do cliente.

```csharp
public List<Movimentacao> Movimentacoes { get; set; }
```

### 4. Iterações e Estruturas de Controle

Foram utilizados loops `foreach` e estruturas `if` para iterar sobre listas e tomar decisões com base nas condições. Veja `Program.cs` para exemplos.

```csharp
foreach (Movimentacao mov in cliente.Movimentacoes)
{
    Console.WriteLine($"{mov.Tipo} - {mov.Valor}");
}
```

### 5. Métodos e Sobrecarga

Métodos foram utilizados para realizar operações específicas, como saques e depósitos. A sobrecarga de métodos foi aplicada para lidar com diferentes tipos e números de parâmetros.

```csharp
public void RealizarSaque(decimal valor)
{
    // Implementação
}

public void RealizarDeposito(decimal valor)
{
    // Implementação
}
```

### 6. Tratamento de Exceções

Para lidar com entradas inválidas, foi utilizado o tratamento de exceções com `try-catch`. Veja `Program.cs` para exemplos.

```csharp
if (decimal.TryParse(valorStr, out decimal valor))
{
    // Código
}
else
{
    Console.WriteLine("Valor inserido é inválido.");
}
```

---

Esse README serve como uma introdução básica aos conceitos de C# aplicados no projeto. 
