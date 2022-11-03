// CREAZIONE ACQUISTO GETTONI
using System.Diagnostics;

bool loop = true;
int credito = 0;
while (loop)
{
    //Console.WriteLine("Il Tuo Credito è di : " + credito + "gettoni");
    Console.WriteLine("Scegli un opzione");
    Console.WriteLine("1) Vedi lo stato delle macchine");
    Console.WriteLine("2) Utilizza una macchina");
    Console.WriteLine("3) Vedi l’attuale incasso generato dall’utilizzo delle macchine");
    Console.WriteLine("4) Esci");
    int risposta = Convert.ToInt32(Console.ReadLine());

    switch (risposta)
    {
        case 1:
            Console.WriteLine("Non è stata selezionata un opzione valida");
            break;
        default:
            Console.WriteLine("Non è stata selezionata un opzione valida");
            break;
    }
}

public class Lavanderia
{
    private Lavatrici[] lavatriciArray;
    private Asciugatrici[] asciugatriciArray;

    public Lavanderia()
    {
        lavatriciArray = new Lavatrici[5];
        asciugatriciArray = new Asciugatrici[5];

        for (int i = 0; i < 5; i++)
        {
            lavatriciArray[i] = new Lavatrici("Lavatrice " + i, false, null, 1000, 500, 0);
        }
    }

    public GetMachine()
    {

    }
}

public class Lavatrici
{
    public Lavatrici(string nome, bool stato, Programmi programmaSelezionato,int quantitàDiDetersivo,int quantitàDiAmmorbidente, int durataDelLavaggio)
    {
        Nome = nome;
        Stato = stato;
        ProgrammaSelezionato = programmaSelezionato;
        QuantitàDiDetersivo = quantitàDiDetersivo;
        QuantitàDiAmmorbidente = quantitàDiAmmorbidente;
        DurataDelLavaggio = durataDelLavaggio;
    }

    public string Nome { get; private set; }
    public bool Stato{ get; set; }
    Programmi ProgrammaSelezionato { get; set; }
    public string TipoDiLavaggioInCorso { get; private set; }
    public int QuantitàDiDetersivo { get; set; }
    public int QuantitàDiAmmorbidente { get; set; }
    public int DurataDelLavaggio { get; set; }

    Programmi rinfrescante = new Programmi("Rinfrescante", 2, 20, 20, 5);
    Programmi rinnovante = new Programmi("Rinnovante", 3, 40, 40, 10);
    Programmi sgrassante = new Programmi("Sgrassante", 4, 60, 60, 15);


}

public class Programmi
{
    // COSTRUTTORE
    public Programmi(string tipo, int costo, int durata, int consumoDetersivo, int consumoAmmorbidente)
    {
        Tipo = tipo;
        Costo = costo;
        Durata = durata;
        ConsumoDetersivo = consumoDetersivo;
        ConsumoAmmorbidente = consumoAmmorbidente;
    }

    
    // VARIABILI
    public int Costo { get; set; }
    public int Durata { get; set; }
    public int ConsumoDetersivo { get; set; }
    public int ConsumoAmmorbidente { get; set; }
    public string Tipo { get; } 
}

public class Asciugatrici
{
    Programmi rapido = new Programmi("Rapido", 2, 20, 0, 0);
    Programmi intenso = new Programmi("Intenso", 4, 20, 0, 0);
}