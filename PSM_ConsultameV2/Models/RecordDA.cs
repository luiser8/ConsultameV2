using System;

namespace PSM_ConsultameV2.Models
{
    public class RecordDA
    {
        public int IdAl { get; set; }
        public string Cedula { get; set; }
        public string FullNombre { get; set; }
        public byte Sexo { get; set; }
        public byte IdEstdo { get; set; }
        public string NrBachiller { get; set; }
        public string IRABachiller { get; set; }
        public byte IdStAca { get; set; }
        public string LapIng { get; set; }
        public string LapAnt { get; set; }
        public string LapCur { get; set; }
        public decimal Iraa { get; set; }
        public int UCC { get; set; }
        public int UCA { get; set; }
        public int IdCar { get; set; }
        public string EstAca { get; set; }
        public int Codcarrera { get; set; }
        public string Area { get; set; }
        public string Descripciontitulo { get; set; }
        public Byte[] Foto { get; set; }
    }
}