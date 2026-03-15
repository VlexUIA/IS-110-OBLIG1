namespace IS110OBLIG1
{
    class Ansatt
    {
        // Informerer oss om Ansatt - ID, Navn og stilling. 
        public string AnsattId { get; set; }
        public string Navn { get; set; }
        public string Stilling { get; set; }

        public Ansatt(string id, string navn, string stilling)
        {
            AnsattId = id;
            Navn = navn;
            Stilling = stilling;
        }

        public void PrintInfo()
        {
            Console.WriteLine("Ansatt: " + Navn + " | ID: " + AnsattId + " | Stilling: " + Stilling);
        }
    }
}
