using System;

namespace IS110OBLIG1
{
    class Program
    {
        // Liste som lagrer data imens programmer er på
        static List<Student> studenter = new List<Student>();
        static List<Kurs> kursliste   = new List<Kurs>();
        static List<Bok> bokliste     = new List<Bok>();
        static List<Lan> lanliste     = new List<Lan>();
        //LanTeller = Første bok får ID "L1", neste får "L2" osv.
        static int lanTeller = 1;

        static void Main()
        {
            // Eksempler 
            studenter.Add(new Student("S001", "Marceli Majcher", "marcelim@uni.no"));
            studenter.Add(new Student(id: "S002", "Dawid Pasut", "dawidpas@uia.no"));
            studenter.Add(new Student (id: "S003", "Sohib Ferhan", "sohibfer@uia.no"));
            // Eksempel på utvekslingsstudent som arver fra vanlig student.
            studenter.Add(new Utvekslingsstudent("S004", "Max Verstapen", "Maxverstap@uniwar.pl", "Warszawa", "POL", "Jan-Jun 2026"));
            kursliste.Add(new Kurs("IS110", "Programmering", 10, 30));
            kursliste.Add(new Kurs("IS105", "Datasystemer", 5, 20));
            kursliste.Add(new Kurs("BE112", "Prosjektøkonomi", 15, 10));
            bokliste.Add(new Bok("B001", "C# med gutta", "Adam Cuptea", 3));

            
            // bool som styrer om løkken fortsetter eller stopper
            bool kjorer = true;
            // while - Holder programmet i gang helt bruker trykker 0.
            while (kjorer)
            {
                Console.WriteLine("=== UNIVERSITETSSYSTEM ===");
                Console.WriteLine("[1] Opprett kurs");
                Console.WriteLine("[2] Meld student på kurs");
                Console.WriteLine("[3] Vis alle kurs");
                Console.WriteLine("[4] Søk kurs");
                Console.WriteLine("[5] Søk bok");
                Console.WriteLine("[6] Lån bok");
                Console.WriteLine("[7] Returner bok");
                Console.WriteLine("[8] Registrer bok");
                Console.WriteLine("[9] Vis alle studenter");
                Console.WriteLine("[0] Avslutt");
                Console.Write("Valg: ");

                // Sjekker hva bruker har trykket - ?? betyr hvis null, bruk som tom tekst.
                string valg = Console.ReadLine() ?? "";

                //Kjører funksjon basert på hva brukeren har valgt.
                if      (valg == "1") OpprettKurs();
                else if (valg == "2") MeldPaKurs();
                else if (valg == "3") VisAlleKurs();
                else if (valg == "4") SokKurs();
                else if (valg == "5") SokBok();
                else if (valg == "6") LanBok();
                else if (valg == "7") ReturnerBok();
                else if (valg == "8") RegistrerBok();
                else if (valg == "9") VisAlleStudenter();
                else if (valg == "0") kjorer = false;  //Hvis 0 blir trykket - stopper while-løkken.
                else Console.WriteLine("Ugyldig valg."); // Hvis noe annet blir trykket - informerer om ugyldig valg.

                Console.WriteLine(); // Tom linje for lesbarhet.
            }

            Console.WriteLine("Ha en fin dag!");
        }

        // Opretter kurs

        static void OpprettKurs()
        {
            // Spør brukeren om info lagrer svaret ved bruk av variabler
            Console.Write("Kurskode: ");
            string kode = Console.ReadLine() ?? "";

            Console.Write("Kursnavn: ");
            string navn = Console.ReadLine() ?? "";

            Console.Write("Studiepoeng: ");
            //Gjør teksten til desimaltall
            double sp = double.Parse(Console.ReadLine() ?? "0");

            Console.Write("Maks plasser: ");
            // Gjør teksten til heltall
            int maks = int.Parse(Console.ReadLine() ?? "0");
            
            // legger til kurset med kode, navn, sp og maxstudenter inn i listen - blir til ny kurs som du kan melde på.
            kursliste.Add(new Kurs(kode, navn, sp, maks));
            Console.WriteLine("Kurs opprettet!");
        }

        // Melder på kurs
        static void MeldPaKurs()
        {
            Console.Write("Student-ID: ");
            string sid = Console.ReadLine() ?? "";

            // LINQ: finn studenten med denne ID-en - hvis ingen finnes = null.
            Student? student = studenter.FirstOrDefault(s => s.StudentId == sid);
            if (student == null) { Console.WriteLine("Student ikke funnet."); return; }

            Console.Write("Kurskode: ");
            string kode = Console.ReadLine() ?? "";

            // LINQ: finn kurset med denne ID-en - hvis ingen finnes = null.
            Kurs? kurs = kursliste.FirstOrDefault(k => k.Kode == kode);
            if (kurs == null) { Console.WriteLine("Kurs ikke funnet."); return; }

            // Skriver til MeldPa som fikser påmeldingen.
            kurs.MeldPa(student);
        }

        // Viser alle kurs
        static void VisAlleKurs()
        {
            //Hvis kurs ikke finnes eller det er ingen kurs - programmet informerer om det.
            if (kursliste.Count == 0) { Console.WriteLine("Ingen kurs registrert."); return; }

            // foreach = går gjennom alle kurs og skriver di ut ved bruk av PrintInfo.
            foreach (Kurs k in kursliste)
            {
                k.PrintInfo();
            }
        }

        // Søker på kurs
        static void SokKurs()
        {
            Console.Write("Søk: ");
            // .toLower gjør alt av tekst til lowercase som gjør lettere å søke.
            string sok = Console.ReadLine()?.ToLower() ?? "";

            // LINQ: filtrer kurs som inneholder søketeksten
            List<Kurs> treff = kursliste.Where(k => k.Kode.ToLower().Contains(sok) || k.Navn.ToLower().Contains(sok)).ToList();
            
            //Hvis kurs ikke finnes eller det er ingen kurs - programmet informerer om det.
            if (treff.Count == 0) { Console.WriteLine("Ingen kurs funnet."); return; }

            foreach (Kurs k in treff)
            {
                k.PrintInfo();
            }
        }

        // BOK

        // Søker på bok
        static void SokBok()
        {
            Console.Write("Søk: ");
            string sok = Console.ReadLine()?.ToLower() ?? "";

            // LINQ: filtrer bøker som inneholder søketeksten
            List<Bok> treff = bokliste.Where(b => b.Tittel.ToLower().Contains(sok) || b.Forfatter.ToLower().Contains(sok)).ToList();

            // Hvis ikke finnes, altså count 0 - writeline.
            if (treff.Count == 0) { Console.WriteLine("Ingen bøker funnet."); return; }

            foreach (Bok b in treff)
            {
                b.PrintInfo();
            }
        }

        // Låner bok
        static void LanBok()
        {
            //Printer tilgjenlige bøker som finnes med ID.
            Console.WriteLine("Tilgjengelige bøker:");
            foreach (Bok b in bokliste)
            {
                b.PrintInfo();
            }

            Console.Write("Bok-ID: ");
            string bokId = Console.ReadLine() ?? "";

            // LINQ: finn boken med ID som ble brukt.
            Bok? bok = bokliste.FirstOrDefault(b => b.Id == bokId);
            if (bok == null) { Console.WriteLine("Bok ikke funnet."); return; }
            
            // Tilgjenlige() sjekker AntallEksempler - utlånt.
            if (bok.Tilgjengelige() == 0) { Console.WriteLine("Ingen eksemplarer tilgjengelig."); return; }

            Console.Write("Ditt navn: ");
            string navn = Console.ReadLine() ?? "";

            // Øker utlånt teller med 1.
            bok.Utlant++;
            Lan nyttLan = new Lan("L" + lanTeller, navn, bok.Tittel, bok.Id);
            lanTeller++;
            lanliste.Add(nyttLan);

            Console.WriteLine("Lånt! Lån-ID: " + nyttLan.LanId);
        }

        static void ReturnerBok()
        {
            // LINQ: hent kun aktive lån
            List<Lan> aktive = lanliste.Where(l => l.ErAktivt).ToList();
            if (aktive.Count == 0) { Console.WriteLine("Ingen aktive lån."); return; }

            Console.WriteLine("Aktive lån:");
            foreach (Lan l in aktive)
            {
                l.PrintInfo();
            }

            Console.Write("Lån-ID: ");
            string lanId = Console.ReadLine() ?? "";

            // LINQ: finn lånet med samme ID
            Lan? lan = aktive.FirstOrDefault(l => l.LanId == lanId);
            if (lan == null) { Console.WriteLine("Fant ikke lånet."); return; }

            lan.ErAktivt = false;

            // LINQ: finn boken og reduser utlånt med 1, som gjør at den er tilgjenlig igjen.
            Bok? bok = bokliste.FirstOrDefault(b => b.Id == lan.BokId);
            if (bok != null) bok.Utlant--;

            Console.WriteLine("Bok returnert. Takk!");
        }

        static void RegistrerBok()
        {
            Console.Write("ID: ");
            string id = Console.ReadLine() ?? "";

            Console.Write("Tittel: ");
            string tittel = Console.ReadLine() ?? "";

            Console.Write("Forfatter: ");
            string forfatter = Console.ReadLine() ?? "";

            Console.Write("Antall eksemplarer: ");
            int antall = int.Parse(Console.ReadLine() ?? "0");

            bokliste.Add(new Bok(id, tittel, forfatter, antall));
            Console.WriteLine("Bok registrert!");
            
            /* Programmet spør om informasjon av boken - når kunden har skrevet det inn, programmet lagrer alt informasjon
             inn i systemet.*/
        }

        // STUDENTER

        static void VisAlleStudenter()
        {
            // For vanlig Student og Utvekslingsstudent
            foreach (Student s in studenter)
            {
                s.PrintInfo();
            }
        }
    }
}
