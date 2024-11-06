using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ApiTarefasNet80.DTOs
{
    public class CategoriaDTO
    {
      
            [Required(ErrorMessage = "Campo obrigatório")]
            [MinLength(5, ErrorMessage = "Obrigatório mínimo de 5 caracteres")]
            public string? Nome{ get; set; }

           
        
    }
}
