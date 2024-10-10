﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JoseRivera_Ap1_p1.Models;

public class CobroDetalle
{
    [Key]
    public int DetalleId { get; set; }

  
    public int CobroId { get; set; }
    [ForeignKey("CobroId")]
    public Cobros cobros { get; set; }
    [Required(ErrorMessage = "Intentar Nuevamente el PrestamoId")]
    public int PrestamoId { get; set; }
    [ForeignKey("PrestamoId")]
    public Prestamos Prestamos { get; set; }
    [Required(ErrorMessage = "Intentar Nuevamente el valorCobrado")]
    public decimal? ValorCobrado { get; set; }

}
