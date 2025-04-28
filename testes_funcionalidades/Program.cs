using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        List<UsuarioP> usuarios = new List<UsuarioP> {
            new UsuarioP() { Nome = "Lucas", Pais = new Paises { Nome = "Brasil", Quantidade = 50 }, Salario = 1000 },
            new UsuarioP() { Nome = "João", Pais = new Paises { Nome = "Argentina", Quantidade = 100 }, Salario = 2000 },
            new UsuarioP() { Nome = "Maria", Pais = new Paises { Nome = "Brasil", Quantidade = 100 }, Salario = 3000 },
            new UsuarioP() { Nome = "Ana", Pais = new Paises { Nome = "Argentina", Quantidade = 30 }, Salario = 4000 },
            new UsuarioP() { Nome = "Carlos", Pais = new Paises { Nome = "Brasil", Quantidade = 10 }, Salario = 5000 },
            new UsuarioP() { Nome = "Fernanda", Pais = new Paises { Nome = "Canada", Quantidade = 250 }, Salario = 6000 },
        };


        var rankPaises = usuarios.GroupBy(u => u.Pais.Nome);

        var paisesrankeados = rankPaises.Select(g => g.Key);


    }
}

class UsuarioP
{
    public string Nome { get; set; }
    public Paises Pais { get; set; }
    public int Salario { get; set; }
}
class Paises
{
    public string Nome { get; set; }
    public int Quantidade { get; set; }
}
