namespace IS110OBLIG1
{
    // Arver fra Student - får med seg alt Student har
    class Utvekslingsstudent : Student
    {
        public string Hjemuniversitet { get; set; }
        public string Land { get; set; }
        public string Periode { get; set; }

        public Utvekslingsstudent(string id, string navn, string epost, string hjemuniversitet, string land, string periode)
            : base(id, navn, epost) // kaller konstruktøren til Student
        {
            Hjemuniversitet = hjemuniversitet;
            Land = land;
            Periode = periode;
        }

        // override betyr at vi overskriver PrintInfo() fra Student
        public override void PrintInfo()
        {
            base.PrintInfo(); // skriver ut det Student sin PrintInfo() skriver
            Console.WriteLine("  Hjemuniversitet: " + Hjemuniversitet + " | Land: " + Land + " | Periode: " + Periode);
        }
    }
}
