﻿using System.ComponentModel.DataAnnotations;

namespace JoseRivera_Ap1_p1.Models
{
    public class Deudores
    {
        [Key]
        public int DeudorId { get; set; }
        [Required(ErrorMessage = "Nombres")]
        public string? Nombres { get; set; }
    }
}