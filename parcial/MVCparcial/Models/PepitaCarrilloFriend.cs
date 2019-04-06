using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCparcial.Models
{
    public enum UniType
    {
        Conocido,
        CompañeroEstudio,
        ColegadeTrabajo,
        Amigo,
        AmigodeInfancia,
        Pariente

    }
    public enum StatusType
    {
        Activo,
        Inactivo
    }

    public class PepitaCarrilloFriend
    {
        [Key]
        public int FriendId { get; set; }
        [Required]
        public string NombreCompleto { get; set; }
        public string Apodo { get; set; }
        public int Cumpleanos { get; set; } //cambiar entero

        [Required]
        public UniType TipoAmigo { get; set; }
        public StatusType Status { get; set; }



    }
}