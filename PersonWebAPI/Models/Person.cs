using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;

namespace PersonWebAPI.Models
{
    public class Person
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório", AllowEmptyStrings = false)]
        [StringLength(255, ErrorMessage = "O campo Nome deve ter no máximo 255 caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O campo CPF é obrigatório", AllowEmptyStrings = false)]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "O CPF deve ter 11 caracteres")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "O campo Data de Nascimento é obrigatório")]
        [DisplayFormat(DataFormatString = "yyyy-mm-dd")]
        public DateTime DataBirth { get; set; }

        [Required(ErrorMessage = "O campo País de Nascimento é obrigatório", AllowEmptyStrings = false)]
        [StringLength(100, ErrorMessage = "O campo País de Nascimento deve ter no máximo 100 caracteres")]
        public string ContryBirth { get; set; }

        [Required(ErrorMessage = "O campo Estado de Nascimento é obrigatório", AllowEmptyStrings = false)]
        [StringLength(100, ErrorMessage = "O campo Estado de Nascimento deve ter no máximo 100 caracteres")]
        public string StateBirth { get; set; }

        [Required(ErrorMessage = "O campo Cidade de Nascimento é obrigatório", AllowEmptyStrings = false)]
        [StringLength(100, ErrorMessage = "O campo Cidade de Nascimento deve ter no máximo 100 caracteres")]
        public string CityBirth { get; set; }

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
