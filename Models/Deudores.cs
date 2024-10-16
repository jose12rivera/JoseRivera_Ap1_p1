using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JoseRivera_Ap1_p1.Models;
public class Deudores
{
    [Key]
    public int DeudorId { get; set; }
    [Required(ErrorMessage = "Intentar Nuevamente el Nombre")]
    public string? Nombres { get; set; }
    [InverseProperty("Deudor")]
    public virtual ICollection<Cobros> Cobros { get; set; } = new List<Cobros>();

    [InverseProperty("Deudor")]
    public virtual ICollection<Prestamos> Prestamos { get; set; } = new List<Prestamos>();
}
