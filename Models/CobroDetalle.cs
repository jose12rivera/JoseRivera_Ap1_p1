using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JoseRivera_Ap1_p1.Models;

public class CobroDetalle
{
    [Key]
    public int DetalleId { get; set; }

    [ForeignKey("CobroId")]
    public int CobroId { get; set; }
    [Required(ErrorMessage = "Intentar Nuevamente el PrestamoIdf")]
    public int PrestamoId { get; set; }

    [Required(ErrorMessage = "Intentar Nuevamente el valorCobrado")]
    public decimal? ValorCobrado { get; set; }

}
