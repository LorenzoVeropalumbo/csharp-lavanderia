// CREAZIONE ACQUISTO GETTONI
using System;
using System.Diagnostics;
using System.Reflection.PortableExecutable;

//instazio la lavanderia
Lavanderia Bella = new Lavanderia();
//creazione del loop
bool loop = true;

while (loop)
{
    //Console.WriteLine("Il Tuo Credito è di : " + credito + "gettoni");
    //Chiedo all'utente cosa vuole fare
    Console.WriteLine("Scegli un opzione");
    Console.WriteLine("1) Vedi lo stato delle macchine");
    Console.WriteLine("2) Dettagli macchine");
    Console.WriteLine("3) Vedi l’attuale incasso generato dall’utilizzo delle macchine");
    Console.WriteLine("4) Esci");
    int risposta = Convert.ToInt32(Console.ReadLine());

    switch (risposta)
    {
        case 1:
            Bella.GetMachine();
            break;
        case 2:
            Bella.MachineDetail();
            break;
        case 3:
            Console.WriteLine(Bella.Saldo() + " euro");
            break;
        case 4:
            loop = false;
            break;
        default:
            Console.WriteLine("Non è stata selezionata un opzione valida");
            break;
    }
}



public class Lavanderia
{
    //Creazione dell'array che conterrà gli oggetti
    private Lavatrici[] lavatriciArray;
    private Asciugatrici[] asciugatriciArray;

    //instazio i programmi cosi da poterli inserire nelle lavatrici appena create

    public Lavanderia()
    {
        lavatriciArray = new Lavatrici[5];
        asciugatriciArray = new Asciugatrici[5];

        //instazio le lavatrici
        for (int i = 0; i < 5; i++)
        {
            lavatriciArray[i] = new Lavatrici("Lavatrice " + (i + 1), true, null,1000,500, 0);
            lavatriciArray[i].randomLoad();
        }
        for (int i = 0; i < 5; i++)
        {
            asciugatriciArray[i] = new Asciugatrici("Asciugatrice " + (i + 1), true, null, 0);
            asciugatriciArray[i].randomLoad();
        }
    }

    public void GetMachine()
    {
        Console.WriteLine();
        Console.WriteLine("--- lavatrici presenti ---");
        //scorro l'arrey delle lavatrici
        for (int i = 0; i < lavatriciArray.Length; i++)
        {
            // se lo stato è true dico che la lavatrice è in funzione
            if (lavatriciArray[i].Stato)
            {
                Console.WriteLine(lavatriciArray[i].Nome + " - Stato in funzione lavaggio");
            }
            else
            {
                Console.WriteLine(lavatriciArray[i].Nome + " - Stato non in funzione");
            }
        }
        Console.WriteLine("--- asciugatrici presenti ---");
        //scorro l'arrey delle asciugatrici
        for (int i = 0; i < asciugatriciArray.Length; i++)
        {
            // se lo stato è true dico che l' asciugatrice è in funzione
            if (asciugatriciArray[i].Stato)
            {
                Console.WriteLine(asciugatriciArray[i].Nome + " - Stato in funzione asciuga");
            }
            else
            {
                Console.WriteLine(asciugatriciArray[i].Nome + " - Stato non in funzione");
            }
        }
        Console.WriteLine();
    }

    public void MachineDetail()
    {
        //chiedo all'utente di quale macchina vuole sapere i dettagli
        Console.WriteLine("seleziona una macchina per le info");
        Console.WriteLine("1) Lavatrice");
        Console.WriteLine("2) Asciugatrice");
        int response = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("seleziona la macchine"); Console.WriteLine();
        int selected = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine();
        if (response == 1){
           
            Console.WriteLine("----- " + lavatriciArray[selected - 1].Nome + " -----");
            if(lavatriciArray[selected - 1].Stato)
            {
                Console.WriteLine("Stato : in lavaggio");
            }
            else
            {
                Console.WriteLine("Stato : disattivata");
            }    
            if (lavatriciArray[selected - 1].ProgrammaSelezionato.Tipo != "Spento")
            {
                Console.WriteLine("Programma selezionato : " + lavatriciArray[selected - 1].ProgrammaSelezionato.Tipo);
                Console.WriteLine("Programma durata : " + lavatriciArray[selected - 1].ProgrammaSelezionato.Durata);
                Random rnd = new Random();
                int time = rnd.Next(1, lavatriciArray[selected - 1].ProgrammaSelezionato.Durata);
                Console.WriteLine("Tempo rimanente : " + (lavatriciArray[selected - 1].ProgrammaSelezionato.Durata - time) + " min");
            }
            Console.WriteLine("Quantità di detersivo rimanente : " + lavatriciArray[selected - 1].QuantitàDiDetersivo);
            Console.WriteLine();
        }
        else
        {

            Console.WriteLine("----- " + asciugatriciArray[selected - 1].Nome + " -----");
            if (asciugatriciArray[selected - 1].Stato)
            {
                Console.WriteLine("Stato : in asciugatura");
            }
            else
            {
                Console.WriteLine("Stato : disattivata");
            }
            
            if (asciugatriciArray[selected - 1].ProgrammaSelezionato.Tipo != "Spento")
            {
                Console.WriteLine("Programma selezionato : " + asciugatriciArray[selected - 1].ProgrammaSelezionato.Tipo);
                Console.WriteLine("Programma durata : " + asciugatriciArray[selected - 1].ProgrammaSelezionato.Durata);
                Random rnd = new Random();
                int time = rnd.Next(1, asciugatriciArray[selected - 1].ProgrammaSelezionato.Durata);
                Console.WriteLine("Tempo rimanente : " + (asciugatriciArray[selected - 1].ProgrammaSelezionato.Durata - time) + " min");
            }
            Console.WriteLine();
        }

    }
    //calcolo del saldo
    public float Saldo()
    {
        int saldo = 0;
        for (int i = 0; i < lavatriciArray.Length; i++)
        {
            saldo += lavatriciArray[i].GuadagnoMacchine;
            saldo += asciugatriciArray[i].GuadagnoMacchine;
        }

        return saldo/2;
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

        loads = new Programmi[4];
        loads[0] = new Programmi("Rinfrescante", 2, 20, 20, 5);
        loads[1] = new Programmi("Rinnovante", 3, 40, 40, 10);
        loads[2] = new Programmi("Sgrassante", 4, 60, 60, 15);
        loads[3] = new Programmi("Spento", 0, 0, 0, 0);
    }

   
    public string Nome { get; private set; }
    public bool Stato{ get; set; }
    public Programmi ProgrammaSelezionato { get; set; }
    public int QuantitàDiDetersivo { get; set; }
    public int QuantitàDiAmmorbidente { get; set; }
    public int DurataDelLavaggio { get; set; }
    public int GuadagnoMacchine { get; set; }

    public Programmi[] loads;

    public void randomLoad() {

        Random rnd = new Random();
        int programs = rnd.Next(0, loads.Length);
        ProgrammaSelezionato = loads[programs];
        GuadagnoMacchine += ProgrammaSelezionato.Costo;
        QuantitàDiDetersivo -= ProgrammaSelezionato.ConsumoDetersivo;
        QuantitàDiAmmorbidente -= ProgrammaSelezionato.ConsumoAmmorbidente;

        if (loads[programs].Tipo == "Spento")
        {
            Stato = false;
        }
    }
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
    public Asciugatrici(string nome, bool stato, Programmi programmaSelezionato, int durataDelLavaggio)
    {
        Nome = nome;
        Stato = stato;
        ProgrammaSelezionato = programmaSelezionato;
        DurataDelLavaggio = durataDelLavaggio;


        loads = new Programmi[3];
        loads[0] = new Programmi("Intenso", 4, 20, 0, 0);
        loads[1] = new Programmi("Rapido", 2, 20, 0, 0); ;
        loads[2] = new Programmi("Spento", 0, 0, 0, 0);
    }

    public string Nome { get; private set; }
    public bool Stato { get; set; }
    public Programmi ProgrammaSelezionato { get; set; }
    public int DurataDelLavaggio { get; set; }

    public int GuadagnoMacchine { get; set; }

    public Programmi[] loads;


    public void randomLoad()
    {
        Random rnd = new Random();
        int programs = rnd.Next(0, loads.Length);
        ProgrammaSelezionato = loads[programs];
        GuadagnoMacchine += ProgrammaSelezionato.Costo;
        if (loads[programs].Tipo == "Spento")
        {
            Stato = false;
        }
    }
}