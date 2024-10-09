using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JoseRivera_Ap1_p1.Models;

public class Cobros
{
    [Key]
    public int CobroId { get; set; }
    [Required(ErrorMessage ="Intentar Nuevamente la Fecha")]
    public DateTime? Fecha { get; set; }


    [ForeignKey("DeudorId")]
    public int DeudorId { get; set; }
    [Required(ErrorMessage = "Intentar Nuevamente el Deudor")]
    public Deudores? Deudor { get; set; }
    public ICollection<Deudores> Deudores { get; set; } = new List<Deudores>();
   
    [Required(ErrorMessage = "Intentar Nuevamente el Monto")]
    public  decimal Monto { get; set; }
    public ICollection<CobroDetalle> CobroDetalles { get; set; } = new List<CobroDetalle>();
}
