using System.ComponentModel.DataAnnotations;

namespace JoseRivera_Ap1_p1.Models;
public class Prestamos
{
    [Key]
    public int PrestamoId { get; set; }
    [Required(ErrorMessage = "Intentar Nuevamente el Deudor")]
    public string? Deudor { get; set; }
    [Required(ErrorMessage = "Intentar Nuevamente el concepto")]
    public decimal? Concepto  { get; set; }
    [Required(ErrorMessage = "Intentar Nuevamente el Monto")]
    public decimal? Monto { get; set; }
}
