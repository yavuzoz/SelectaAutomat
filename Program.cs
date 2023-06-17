using System;
using System.Collections.Generic;

class Produkt
{
    public int ProduktNummer { get; set; }
    public string Name { get; set; }
    public decimal Preis { get; set; }
    public int Menge { get; set; }
}

class Programm
{
    static Produkt[] produkte = new Produkt[]
    {
        new Produkt { ProduktNummer = 1, Name = "Haribo", Preis = 5.00m, Menge = 20 },
        new Produkt { ProduktNummer = 2, Name = "Chips", Preis = 3.00m, Menge = 20 },
        new Produkt { ProduktNummer = 3, Name = "Cola", Preis = 2.50m, Menge = 20 },
        new Produkt { ProduktNummer = 4, Name = "Rivella", Preis = 1.75m, Menge = 20 },
        new Produkt { ProduktNummer = 5, Name = "Toblerone", Preis = 5.00m, Menge = 20 }
    };

    static void Main(string[] args)
    {
        Console.WriteLine("Verfügbare Produkte:");
        foreach (var produkt in produkte)
        {
            Console.WriteLine($"Produktnummer: {produkt.ProduktNummer}, Produkt: {produkt.Name}, Preis: {produkt.Preis.ToString("0.00")} CHF");
        }

        Console.WriteLine();

        List<Produkt> ausgewählteProdukte = new List<Produkt>();

        bool weiterEinkaufen = true;

        while (weiterEinkaufen)
        {
            Console.WriteLine("Geben Sie die Produktnummer ein: ");
            int produktNummer = int.Parse(Console.ReadLine());

            Produkt ausgewähltesProdukt = ProduktNachNummerSuchen(produktNummer);

            if (ausgewähltesProdukt != null)
            {
                Console.WriteLine("Geben Sie die gewünschte Menge ein: ");
                int menge = int.Parse(Console.ReadLine());

                if (ausgewähltesProdukt.Menge >= menge)
                {
                    ausgewähltesProdukt.Menge -= menge;

                    if (ausgewähltesProdukt.Menge < 3)
                    {
                        Console.WriteLine("Warnung: Produktmenge ist unter 3 gefallen!");
                    }

                    ausgewählteProdukte.Add(new Produkt
                    {
                        ProduktNummer = ausgewähltesProdukt.ProduktNummer,
                        Name = ausgewähltesProdukt.Name,
                        Preis = ausgewähltesProdukt.Preis,
                        Menge = menge
                    });
                }
                else
                {
                    Console.WriteLine("Fehler: Nicht genügend Vorrat!");
                }
            }


            Console.WriteLine();
            Console.WriteLine("Verfügbare Produkte:");
            foreach (var produkt in produkte)
            {
                Console.WriteLine($"Produktnummer: {produkt.ProduktNummer}, Produkt: {produkt.Name}, Preis: {produkt.Preis.ToString("0.00")} CHF, Menge: {produkt.Menge}");
            }

            Console.WriteLine();

            Console.WriteLine("Möchten Sie ein anderes Produkt auswählen? (J/N)");
            string antwort = Console.ReadLine();
            weiterEinkaufen = (antwort.ToLower() == "j");
        }

        decimal gesamtPreis = GesamtPreisBerechnen(ausgewählteProdukte);
        Console.WriteLine("Gesamtbetrag, den Sie bezahlen müssen: " + gesamtPreis.ToString("0.00") + " CHF");

        Console.ReadLine();
    }

    static Produkt ProduktNachNummerSuchen(int produktNummer)
    {
        foreach (var produkt in produkte)
        {
            if (produkt.ProduktNummer == produktNummer)
            {
                return produkt;
            }
        }

        return null;
    }

    static decimal GesamtPreisBerechnen(List<Produkt> ausgewählteProdukte)
    {
        decimal gesamtPreis = 0;

        foreach (var produkt in ausgewählteProdukte)
        {
            gesamtPreis += produkt.Preis * produkt.Menge;
        }

        return gesamtPreis;
    }

}

