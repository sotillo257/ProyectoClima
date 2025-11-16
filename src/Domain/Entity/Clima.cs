using System;

namespace Domain.Entity;

public class Clima
{
    public string Ciudad { get; private set; }
    public double Celsius { get; private set; }


    private Clima(string ciudad, double celsius)
    {
        ArgumentException.ThrowIfNullOrEmpty(ciudad, nameof(ciudad));

        Ciudad = ciudad;
        Celsius = celsius;
    }

    public static Clima Create(string ciudad, double temperatura)
    {
        return new(ciudad, temperatura);
    }


}