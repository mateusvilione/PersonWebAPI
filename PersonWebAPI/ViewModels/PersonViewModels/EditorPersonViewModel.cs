using System.ComponentModel.DataAnnotations;

namespace PersonWebAPI.ViewModels.PersonViewModels
{
    public class EditorPersonViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório", AllowEmptyStrings = false)]
        [StringLength(255, ErrorMessage = "O campo Nome deve ter no máximo 255 caracteres")]
        public string Name { get; set; }   

        [StringLength(255, ErrorMessage = "O campo Nome do Pai deve ter no máximo 100 caracteres")]
        public string FatherName { get; set; }

        [StringLength(255, ErrorMessage = "O campo Nome do Mãe deve ter no máximo 100 caracteres")]
        public string MotherName { get; set; }

        [Required(ErrorMessage = "O campo E-mail é obrigatório")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Informe um email válido...")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "O Email deve ter no mínimo 5 e no máximo 100 caracteres.")]
        public string Email { get; set; }
    }
}