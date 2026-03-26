using System;
using System.Security.Cryptography.X509Certificates;


namespace Esercizio
{
    public class VanoImmobiliare
    {
        public string NomeVano { get; set; }
        public decimal CostoMq { get; set; }
        public decimal CostoBattiscopaAlMetro { get; set; }




        public virtual decimal CalcolaArea()
        {
            return 0;
        }

        public virtual decimal CalcoloPerimetro()
        {
            return 0;
        }

        public virtual decimal CalcoloCostoTotale()
        {
            return (CalcolaArea() * CostoMq) + (CalcoloPerimetro() * CostoBattiscopaAlMetro);

        }


        public void StampaPreventivo()
        {
            Console.WriteLine($"La stanza si chiama {NomeVano}, ha un area pari a {CalcolaArea():F2} mq, ha un perimetro di {CalcoloPerimetro():F2} e il costo totale è {CalcoloCostoTotale():F2} ");
            Console.WriteLine();
        }
    }


    class StanzaRettangolare : VanoImmobiliare
    {

        public decimal Base { get; set; }
        public decimal Altezza { get; set; }

        public override decimal CalcolaArea()
        {
            return Base * Altezza;
        }

        public override decimal CalcoloPerimetro()
        {
            return 2 * (Base + Altezza);
        }

    }

    class StanzaTriangolare : VanoImmobiliare
    {
        public decimal Base { get; set; }
        public decimal Altezza { get; set; }

        public override decimal CalcolaArea()
        {
            return (Base * Altezza) / 2;
        }

        public override decimal CalcoloPerimetro()
        {
            decimal ipotenusa = (decimal)Math.Sqrt((double)(Base * Base + Altezza * Altezza));
            return Base + Altezza + ipotenusa;
        }

    }


    class StanzaCircolare : VanoImmobiliare
    {
        public decimal Raggio { get; set; }
        public override decimal CalcolaArea()
        {

            return Raggio * Raggio * (decimal)Math.PI;
        }

        public override decimal CalcoloPerimetro()
        {
            return 2 * Raggio * (decimal)Math.PI;
        }

    }


    class Program
    {
        static void Main()
        {

            List<VanoImmobiliare> stanze = new List<VanoImmobiliare>();



            StanzaRettangolare salone = new StanzaRettangolare()
            {
                NomeVano = "Salone",
                Base = 6,
                Altezza = 8,
                CostoMq = 10,
                CostoBattiscopaAlMetro = 5

            };


            StanzaTriangolare sottoscale = new StanzaTriangolare()
            {
                NomeVano = "Sottoscale",
                Base = 3,
                Altezza = 4,
                CostoMq = 20,
                CostoBattiscopaAlMetro = 2
            };


            StanzaCircolare ingresso = new StanzaCircolare()
            {
                NomeVano = "Ingresso",
                Raggio = 2.5m,
                CostoMq = 30,
                CostoBattiscopaAlMetro = 6
            };




            stanze.Add(salone);
            stanze.Add(sottoscale);
            stanze.Add(ingresso);


            decimal costoTotale = 0; 

            foreach (var stanza in stanze)
            {
                stanza.StampaPreventivo();
                costoTotale += stanza.CalcoloCostoTotale();
            }



        }
    }

}