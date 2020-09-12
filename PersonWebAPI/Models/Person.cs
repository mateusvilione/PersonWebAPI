using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonWebAPI.Models
{
    [Table("person")]
    public class Person
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório", AllowEmptyStrings = false)]
        public string Name { get; set; }

        [Required(ErrorMessage = "O campo CPF é obrigatório", AllowEmptyStrings = false)]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "O campo Data de Nascimento é obrigatório")]
        [DisplayFormat(DataFormatString = "mm/dd/yyyy")]
        public DateTime DataBirth { get; set; }

        [Required(ErrorMessage = "O campo País de Nascimento é obrigatório", AllowEmptyStrings = false)]
        public string ContryBirth { get; set; }

        [Required(ErrorMessage = "O campo Estado de Nascimento é obrigatório", AllowEmptyStrings = false)]
        public string StateBirth { get; set; }

        [Required(ErrorMessage = "O campo Cidade de Nascimento é obrigatório", AllowEmptyStrings = false)]
        public string CityBirth { get; set; }

        public string FatherName { get; set; }

        public string MotherName { get; set; }

        [Required(ErrorMessage = "O campo E-mail é obrigatório")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Informe um email válido...")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "O Email deve ter no mínimo 5 e no máximo 100 caracteres.")]
        public string Email { get; set; }

    }
}
