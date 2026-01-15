namespace Sistema_Hotel_Colifornia.Models;

using System;
using System.Collections.Generic;

public class Reserva
{
    public List<Pessoa> Hospedes { get; private set; }
    public Suite Suite { get; private set; }
    public int DiasReservados { get; private set; }

    public Reserva(int diasReservados)
    {
        DiasReservados = diasReservados;
        Hospedes = new List<Pessoa>();
    }

    public void CadastrarSuite(Suite suite)
    {
        Suite = suite;
    }

    public void CadastrarHospedes(List<Pessoa> hospedes)
    {
        if (Suite == null)
            throw new Exception("Suíte não cadastrada.");

        if (hospedes.Count > Suite.Capacidade)
            throw new Exception("Número de hóspedes excede a capacidade da suíte.");

        Hospedes = hospedes;
    }

    public int ObterQuantidadeHospedes()
    {
        return Hospedes.Count;
    }

    public decimal CalcularValorDiaria()
    {
        decimal valorTotal = DiasReservados * Suite.ValorDiaria;

        if (DiasReservados > 10)
        {
            valorTotal *= 0.9m; // desconto de 10%
        }

        return valorTotal;
    }
}

