namespace IS110OBLIG1
{
    class Bok
    {
        // Informerer oss om ID, Tittel, Forfatter, AntallEksempler og om den er utlånt. 
        public string Id { get; set; }
        public string Tittel { get; set; }
        public string Forfatter { get; set; }
        public int AntallEksemplarer { get; set; }
        public int Utlant { get; set; } = 0;

        public Bok(string id, string tittel, string forfatter, int antall)
        {
            Id = id;
            Tittel = tittel;
            Forfatter = forfatter;
            AntallEksemplarer = antall;
        }

        public int Tilgjengelige()
        {
            return AntallEksemplarer - Utlant;
        }

        public void PrintInfo()
        {
            Console.WriteLine("[" + Id + "] " + Tittel + " av " + Forfatter + " | Tilgjengelig: " + Tilgjengelige() + "/" + AntallEksemplarer);
        }
    }
}
