using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JoseRivera_Ap1_p1.Models;
public class Prestamos
{
    [Key]
    public int PrestamoId { get; set; }
    [Required(ErrorMessage = "Intentar Nuevamente el Deudor")]
    [Range(1, int.MaxValue, ErrorMessage = "Puede seleccionar un deudor válido.")]
    public int DeudorId { get; set; }
    [ForeignKey("DeudorId")]
    public Deudores? Deudor { get; set; }
    [Required(ErrorMessage = "Intentar Nuevamente el Concepto")]
    public string? Concepto  { get; set; }
    [Required(ErrorMessage = "Intentar Nuevamente el Monto")]
    public decimal? Monto { get; set; }
    [Required(ErrorMessage = "Intentar Nuevamente el Balance")]
    public decimal? Balance { get; set; }

    [ForeignKey("PrestamoId")]
    public ICollection<Deudores> Deudores { get; set; } = new List<Deudores>();
}   
