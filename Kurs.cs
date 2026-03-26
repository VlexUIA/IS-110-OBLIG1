namespace IS110OBLIG1
{
    class Kurs
    {
        
        // Informerer oss om kurs koden, navnet, SP og max plasser / Altså beskriver hva et kurs er
        // get = du kan lese verdien
        // set = du kan endre verdien
        public string Kode { get; set; } // Kurskode, eksempel: IS110
        public string Navn { get; set; } // Navn på kurset
        public double Studiepoeng { get; set; } // Studiepoeng fra kurset
        public int MaksPlasser { get; set; } // Maks plasser i kurset
        
        // Liste av hvem som er påmeldt, legges til fra MeldPa()
        public List<Student> Deltakere { get; set; } = new List<Student>();

        //Konstruktør, kjører når vi skriver ny kurs.
        public Kurs(string kode, string navn, double studiepoeng, int maksPlasser)
        {
            //Informasjon av kurset som blir lagt til
            Kode = kode;
            Navn = navn;
            Studiepoeng = studiepoeng;
            MaksPlasser = maksPlasser;
        }
        
        // Melder på student i kurset.
        public void MeldPa(Student student)
        {
            // Sjekker hvor mange deltakere og om det er plass
            if (Deltakere.Count >= MaksPlasser)
            {
                // Informerer at kurset er fullt hvis det ikke er plasser.
                Console.WriteLine("Kurset er fullt!");
                return;
            }

            // Legger til i deltaker listen.
            Deltakere.Add(student);
            student.PamelteKurs.Add(Kode);
            Console.WriteLine(student.Navn + " er meldt på " + Navn);
        }

        // Skriver ut info om kurset og hvilken student er påmeldt.
        public void PrintInfo()
        {
            Console.WriteLine("Kurs: " + Kode + " - " + Navn + " (" + Studiepoeng + " sp) | Plasser: " + Deltakere.Count + "/" + MaksPlasser);
            // Går gjennom alle studenter og skriver ut di sitt navn.
            foreach (Student s in Deltakere)
            {
                Console.WriteLine("  - " + s.Navn);
            }
        }
    }
}
