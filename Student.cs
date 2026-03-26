namespace IS110OBLIG1
{
    class Student
    {
        // get = kan lese verdier
        // set = kan endre verdier
        public string StudentId { get; set; }
        public string Navn { get; set; }
        public string Epost { get; set; }
        public List<string> PamelteKurs { get; set; } = new List<string>();

        // Konstruktør - Når vi lager en ny Student
        public Student(string id, string navn, string epost)
        {
            StudentId = id;
            Navn = navn;
            Epost = epost;
        }

        // virtual betyr at klasser som arver fra Student kan overskrive denne
        public virtual void PrintInfo()
        {
            //Printer informasjon som den har henter, altså navn, studentid og epost - alt dette er koblet til studentene i eksemplet.
            Console.WriteLine("Student: " + Navn + " | ID: " + StudentId + " | Epost: " + Epost);
        }
    }
}
