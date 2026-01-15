using System.Linq;

namespace Sistema_Hotel_Colifornia.Models;

public class Pessoa
{
    public string NomeCompleto {get;set;}
    public string Celular {get;set;}
    public string Cpf {get;set;}

    public Pessoa (string nomeCompleto, string celular, string cpf)
    {
        if(nomeCompleto.Length > 150)
            throw new ArgumentException("O Nome só pode conter até 150 caracteres");

        if(!ValidarCelular(celular))
            throw new ArgumentException("Celular Inválido");

        if (!ValidarCpf(cpf))
            throw new ArgumentException("CPF inválido.");
       

        NomeCompleto = nomeCompleto;
        Celular = celular;
        Cpf = cpf;

    }

    private static bool ValidarCelular(string celular)
    {
        string numeros = "";

        // Remove tudo que não for número
        foreach (char c in celular)
        {
            if (char.IsDigit(c))
                numeros += c;
        }

        // Deve ter exatamente 11 dígitos
        if (numeros.Length != 11)
            return false;

        // Terceiro dígito deve ser 9 (celular)
        if (numeros[2] != '9')
            return false;

        return true;
    }
    
     private static string ApenasNumeros(string input)
    {
    string resultado = "";

    foreach (char c in input)
        {
           if (char.IsDigit(c))
              resultado += c;
        }

        return resultado;
    }

    private static bool ValidarCpf (string cpf)
    {
        cpf = ApenasNumeros(cpf);

    if (cpf.Length != 11)
        return false;

    bool todosIguais = true;
    for (int i = 1; i < cpf.Length; i++)
    {
        if (cpf[i] != cpf[0])
        {
            todosIguais = false;
            break;
        }
    }

    if (todosIguais)
        return false;

    int soma = 0;
    int resto;

    for (int i = 0; i < 9; i++)
        soma += (cpf[i] - '0') * (10 - i);

    resto = soma % 11;
    resto = resto < 2 ? 0 : 11 - resto;

    if ((cpf[9] - '0') != resto)
        return false;

    soma = 0;
    for (int i = 0; i < 10; i++)
        soma += (cpf[i] - '0') * (11 - i);

    resto = soma % 11;
    resto = resto < 2 ? 0 : 11 - resto;

    return (cpf[10] - '0') == resto;
    }
}
