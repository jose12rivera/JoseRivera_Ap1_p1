using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JoseRivera_Ap1_p1.Models;

public class Cobros
{
    [Key]
    public int CobroId { get; set; }
    [Required(ErrorMessage = "Intentar Nuevamente la Fecha")]
    public DateTime? Fecha { get; set; }

    public int DeudorId { get; set; }
    [ForeignKey("DeudorId")]
    public Deudores? Deudor { get; set; }
    [Required(ErrorMessage = "Intentar Nuevamente el Deudor")]
    public decimal Monto { get; set; }
    public ICollection<CobrosDetalle> CobroDetalles { get; set; } = new List<CobrosDetalle>();
}
