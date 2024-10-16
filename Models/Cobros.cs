using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JoseRivera_Ap1_p1.Models;

public class Cobros
{
    [Key]
    public int CobroId { get; set; }

    [Required(ErrorMessage = "La fecha es requerida.")]
    public DateTime Fecha { get; set; }

    [Required(ErrorMessage = "El DeudorId es requerido.")]
    public int DeudorId { get; set; }

    [ForeignKey("DeudorId")]
    public Deudores? Deudor { get; set; }

    [Required(ErrorMessage = "El monto es requerido.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "El monto debe ser mayor que cero.")]
    public decimal Monto { get; set; }

    public ICollection<CobrosDetalle> CobrosDetalle { get; set; } = new List<CobrosDetalle>();
}
