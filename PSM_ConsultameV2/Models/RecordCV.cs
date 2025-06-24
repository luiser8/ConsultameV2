namespace PSM_ConsultameV2.Models
{
    public class RecordCV
    {
        public int Codmateria { get; set; }
        public string NombreMateria { get; set; }
        public byte TH { get; set; }
        public byte UC { get; set; }
        public string NombreOpcion { get; set; }
        public decimal Corte1 { get; set; }
        public decimal Corte2 { get; set; }
        public decimal Corte3 { get; set; }
        public decimal Definitiva { get; set; }
        public byte Semestre { get; set; }
    }
}