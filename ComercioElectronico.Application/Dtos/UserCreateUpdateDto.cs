using System.ComponentModel.DataAnnotations;
using ComercioElectronico.Domain;

namespace ComercioElectronico.Application;

public class UserCreateUpdateDto
{   
    [Required]
    [StringLength(DominioConstantes.NOMBRE_MAX)]
    public string UserName{get;set;}    
    [Required]
    [StringLength(DominioConstantes.NOMBRE_MAX)]
    public string Contrasenia{get;set;}    
}
