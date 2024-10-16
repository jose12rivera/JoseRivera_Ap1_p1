using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace JoseRivera_Ap1_p1.Models;

public class CobrosDetalle
{
    [Key]
    public int DetalleId { get; set; }
    public int CobroId { get; set; }
    [ForeignKey("CobroId")]
    [InverseProperty("CobrosDetalle")]
    public virtual Cobros cobros { get; set; } = null;
  
    public int PrestamoId { get; set; }
    public decimal? ValorCobrado { get; set; }
}
