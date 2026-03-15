namespace IS110OBLIG1
{
    class Lan
    {
        // Egenskaper som beskriver hva et Lån er.
        public string LanId { get; set; }
        public string BrukerNavn { get; set; }
        public string BokTittel { get; set; }
        public string BokId { get; set; }
        
        // Bool er true eller false
        // True = Bok utlånt - false = kan lånes og er tilbake.
        public bool ErAktivt { get; set; } = true;
        
        // Konstruktør som kjører når vi kjører new Lan.
        public Lan(string lanId, string brukerNavn, string bokTittel, string bokId)
        {
            // Lagrer verdier og informasjon.
            LanId = lanId;
            BrukerNavn = brukerNavn;
            BokTittel = bokTittel;
            BokId = bokId;
        }

        public void PrintInfo()
        {
            // Hvis ErAktivt er true, skriv "Aktiv", ellers "Returnert"
            string status = ErAktivt ? "Aktiv" : "Returnert";
            // Skriver ut informasjon om boken og status.
            Console.WriteLine("[" + LanId + "] " + BokTittel + " -> " + BrukerNavn + " | Status: " + status);
        }
    }
}
