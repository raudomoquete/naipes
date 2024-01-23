using System;
//using System.Collections.Generic;
//using System.Linq;

//public enum Palo
//{
//    Oros,
//    Copas,
//    Espadas,
//    Bastos
//}

//public class Naipe
//{
//    public Palo Palo { get; set; }
//    public int Numero { get; set; }

//    public Naipe(Palo palo, int numero)
//    {
//        Palo = palo;
//        Numero = numero;
//    }
//}

//public class Baraja
//{
//    private List<Naipe> naipes;

//    public Baraja()
//    {
//        naipes = new List<Naipe>();
//        InicializarNaipes();
//    }

//    public void InicializarNaipes()
//    {
//        for (int i = 0; i < 4; i++)
//        {
//            Palo palo = (Palo)i;
//            for (int numero = 1; numero <= 12; numero++)
//            {
//                naipes.Add(new Naipe(palo, numero));
//            }
//        }
//    }

//    public void Ordenar()
//    {
//        naipes = naipes.OrderBy(n => n.Palo).ThenBy(n => n.Numero).ToList();
//    }

//    public void Barajar()
//    {
//        Random random = new Random();
//        naipes = naipes.OrderBy(n => random.Next()).ToList();
//    }

//    public void Imprimir()
//    {
//        foreach (var naipe in naipes)
//        {
//            Console.WriteLine($"{naipe.Numero} de {naipe.Palo}");
//        }
//    }
//}

//class Program
//{
//    static void Main()
//    {
//        Baraja baraja = new Baraja();

//        Console.WriteLine("Baraja Inicial:");
//        baraja.Imprimir();

//        Console.WriteLine("\nBaraja Ordenada:");
//        baraja.Ordenar();
//        baraja.Imprimir();

//        Console.WriteLine("\nBaraja Barajada:");
//        baraja.Barajar();
//        baraja.Imprimir();
//    }
//}


public class Hueso : IComparable<Hueso>
{
    public string Nombre { get; set; }
    public double Peso { get; set; }
    public double Densidad { get; set; }
    public double Longitud { get; set; }
    public double Diametro { get; set; }

    public Hueso(string nombre, double peso, double densidad, double longitud, double diametro)
    {
        Nombre = nombre;
        Peso = peso;
        Densidad = densidad;
        Longitud = longitud;
        Diametro = diametro;
    }

    // Implementación de IComparable para permitir la comparación de huesos
    public int CompareTo(Hueso other)
    {
        
        return Nombre.CompareTo(other.Nombre);
    }
}

public class Esqueleto
{
    private Hueso[] huesos;

    public Esqueleto()
    {
        huesos = new Hueso[206];

        for (int i = 0; i < 206; i++)
        {
            huesos[i] = new Hueso("Nombre" + i, 1.0, 2.0, 3.0, 4.0);
        }
    }

    public void CargarInformacion(Hueso[] informacion)
    {
        if (informacion.Length != 206)
        {
            throw new ArgumentException("La información debe contener 206 huesos.");
        }

        Array.Copy(informacion, huesos, 206);
    }

    public void OrdenarPorCriterio<T>(Func<Hueso, T> criterio)
    {
        Array.Sort(huesos, (a, b) =>
        {
            var comparer = Comparer<T>.Default;
            return comparer.Compare(criterio(a), criterio(b));

        });
    }

    public void Imprimir()
    {
        foreach (var hueso in huesos)
        {
            if (hueso != null)
            {
                Console.WriteLine($"{hueso.Nombre} - Peso: {hueso.Peso}, Densidad: {hueso.Densidad}, Longitud: {hueso.Longitud}, Diámetro: {hueso.Diametro}");
            }
            else
            {
                Console.WriteLine("Hueso nulo");
            }
        }
    }
}

class Program
{
    static void Main()
    {
        Hueso[] informacionHuesos = new Hueso[206];

        for (int i = 0; i < 206; i++)
        {
            informacionHuesos[i] = new Hueso($"Hueso{i + 1}", 0.5 + i * 0.1, 1.5 + i * 0.2, 5.0 + i * 0.3, 2.0 + i * 0.1);
        }
        Console.WriteLine("Huesos creados:");
        foreach (var hueso in informacionHuesos)
        {
            Console.WriteLine($"{hueso.Nombre} - Peso: {hueso.Peso}, Densidad: {hueso.Densidad}, Longitud: {hueso.Longitud}, Diámetro: {hueso.Diametro}");
        }

        Esqueleto esqueleto = new Esqueleto();
        esqueleto.CargarInformacion(informacionHuesos);

        Console.WriteLine("Ordenados por nombre:");
        esqueleto.OrdenarPorCriterio(h => h.Nombre);
        esqueleto.Imprimir();

    }
}
