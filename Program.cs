// CREAZIONE ACQUISTO GETTONI
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
    public Programmi rinfrescante = new Programmi("Rinfrescante", 2, 20, 20, 5);
    public Programmi rinnovante = new Programmi("Rinnovante", 3, 40, 40, 10);
    public Programmi sgrassante = new Programmi("Sgrassante", 4, 60, 60, 15);
    public Programmi rapido = new Programmi("Rapido", 2, 20, 0, 0);
    public Programmi intenso = new Programmi("Intenso", 4, 20, 0, 0);

    public Lavanderia()
    {
        lavatriciArray = new Lavatrici[5];
        asciugatriciArray = new Asciugatrici[5];

        //instazio le lavatrici
        for (int i = 0; i < 5; i++)
        {
            Random rnd = new Random();
            // generazione del booleano per capire se la lavatrice è attiva
            int active = rnd.Next(1, 3);
            // genero un random per sapere quale programma è attivo
            int programma = rnd.Next(1, 4);

            if (active == 1)
            {
                //questa funzione è riutilizabile in seguito quando vorremo attivare una lavatrice prendendo un valore da 1 a 3 e un indice prende un programma e lo fa eseguire alla lavatrice 
                loadMachineLavatrice(programma, i);
            }
            else
            {
                // istanzio la lavatrice disattiva
                lavatriciArray[i] = new Lavatrici("Lavatrice " + (i + 1), false, null, 1000, 500, 0);
            }

        }

        for (int i = 0; i < 5; i++)
        {
            Random rnd = new Random();
            int active = rnd.Next(1, 3);
            int active2 = rnd.Next(1, 3);
            if (active == 1)
            {
                //questa funzione è riutilizabile in seguito quando vorremo attivare una lavatrice prendendo un valore da 1 a 2 e un indice prende un programma e lo fa eseguire all'asciugatrice 
                loadMachineAsciugatrice(active2, i);
            }
            else
            {
                // istazione un asciugatrice vuota
                asciugatriciArray[i] = new Asciugatrici("Lavatrice " + (i + 1), false, null, 0);
            }

        }
    }

    public void GetMachine()
    {
        Console.WriteLine();
        Console.WriteLine("--- lavatrici presenti ---");
        //scorro l'arrey delle lavatrici
        for (int i = 0; i < lavatriciArray.Length; i++)
        {
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
        for (int i = 0; i < asciugatriciArray.Length; i++)
        {
            if (asciugatriciArray[i].Stato)
            {
                Console.WriteLine(asciugatriciArray[i].Nome + " - Stato in funzione lavaggio");
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
        Console.WriteLine("seleziona una macchina per le info");
        Console.WriteLine("1 Lavatrice");
        Console.WriteLine("2 Asciugatrice");

        int response = Convert.ToInt32(Console.ReadLine());

        if(response == 1){
            
            Console.WriteLine("seleziona la lavatrice");
            int selected = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("----- " + lavatriciArray[selected - 1].Nome + " -----");
            if(lavatriciArray[selected - 1].Stato)
            {
                Console.WriteLine("Stato : in lavaggio");
            }
            else
            {
                Console.WriteLine("Stato : disattivata");
            }    
            if (lavatriciArray[selected - 1].ProgrammaSelezionato != null)
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
            Console.WriteLine("seleziona l' asciugatrice");
            int selected = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("----- " + asciugatriciArray[selected - 1].Nome + " -----");
            if (asciugatriciArray[selected - 1].Stato)
            {
                Console.WriteLine("Stato : in asciugatura");
            }
            else
            {
                Console.WriteLine("Stato : disattivata");
            }
            if (asciugatriciArray[selected - 1].ProgrammaSelezionato != null)
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

    public void loadMachineLavatrice(int load, int index)
    {
        if (load == 1)
        {
            lavatriciArray[index] = new Lavatrici("Lavatrice " + (index + 1), true, rinnovante, 1000, 500, rinnovante.Durata);
            lavatriciArray[index].QuantitàDiDetersivo -= rinnovante.ConsumoDetersivo;
            lavatriciArray[index].QuantitàDiAmmorbidente -= rinnovante.ConsumoAmmorbidente;
            lavatriciArray[index].GuadagnoMacchine += rinnovante.Costo;
        }
        else if (load == 2)
        {
            lavatriciArray[index] = new Lavatrici("Lavatrice " + (index + 1), true, sgrassante, 1000, 500, sgrassante.Durata);
            lavatriciArray[index].QuantitàDiDetersivo -= sgrassante.ConsumoDetersivo;
            lavatriciArray[index].QuantitàDiAmmorbidente -= sgrassante.ConsumoAmmorbidente;
            lavatriciArray[index].GuadagnoMacchine += sgrassante.Costo;
        }
        else
        {
            lavatriciArray[index] = new Lavatrici("Lavatrice " + (index + 1), true, rinfrescante, 1000, 500, rinfrescante.Durata);
            lavatriciArray[index].QuantitàDiDetersivo -= rinfrescante.ConsumoDetersivo;
            lavatriciArray[index].QuantitàDiAmmorbidente -= rinfrescante.ConsumoAmmorbidente;
            lavatriciArray[index].GuadagnoMacchine += rinfrescante.Costo;
        }

    }
    public void loadMachineAsciugatrice(int load, int index)
    {
        if (load == 1)
        {
            asciugatriciArray[index] = new Asciugatrici("Asciugatrice " + (index + 1), true, rapido, rinnovante.Durata);
            asciugatriciArray[index].GuadagnoMacchine += rapido.Costo;
        }
        else
        {
            asciugatriciArray[index] = new Asciugatrici("Asciugatrice " + (index + 1), true, intenso, rinfrescante.Durata);
            asciugatriciArray[index].GuadagnoMacchine += intenso.Costo;
        }

    }

    public int Saldo()
    {
        int saldo = 0;
        for (int i = 0; i < lavatriciArray.Length; i++)
        {
            saldo += lavatriciArray[i].GuadagnoMacchine;
            saldo += asciugatriciArray[i].GuadagnoMacchine;
        }

        return saldo;
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
    public Programmi ProgrammaSelezionato { get; set; }
    public int QuantitàDiDetersivo { get; set; }
    public int QuantitàDiAmmorbidente { get; set; }
    public int DurataDelLavaggio { get; set; }

    public int GuadagnoMacchine { get; set; }

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
    }

    public string Nome { get; private set; }
    public bool Stato { get; set; }
    public Programmi ProgrammaSelezionato { get; set; }
    public int DurataDelLavaggio { get; set; }

    public int GuadagnoMacchine { get; set; }
}