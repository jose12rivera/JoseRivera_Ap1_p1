using System.ComponentModel.DataAnnotations;

namespace JoseRivera_Ap1_p1.Models;
public class Registros
{
    [Key]
    public int Id { get; set; }
    [Required(ErrorMessage = "Intentar Nuevamente")]
    public string? Nombre { get; set; }
}
