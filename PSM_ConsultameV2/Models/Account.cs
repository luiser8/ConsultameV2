using System.ComponentModel.DataAnnotations;

namespace PSM_ConsultameV2.Models
{
    public class Account
    {
        public int IdAL { get; set; }

        [Required(ErrorMessage = "Debes colocar tu número de cédula")]
        public string Cedula { get; set; }

        [Required(ErrorMessage = "Debes colocar los 5 primeros dígitos de tu cédula que corresponde a tu contraseña")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}