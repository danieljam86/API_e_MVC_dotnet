
namespace GTISolutionTeste.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Cliente")]
    public class ClienteEnderecoDTO
    {
        public int Id { get; set; }

        [Display(Name = "CPF*")]
        [Required(ErrorMessage = "*Informe o CPF")]
        [StringLength(11, MinimumLength =11, ErrorMessage ="O cpf deve ter 11 caracteres.")]
        public string cpf { get; set; }

        [Required(ErrorMessage = "*Informe o Nome")]
        [Display(Name = "Nome*")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "O nome deve no mínimo 4 caracteres.")]
        public string nome { get; set; }

        [Display(Name = "RG")]
        [StringLength(15)]
        public string rg { get; set; }

        [Display(Name = "Data Expedição")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? dt_expedicao { get; set; }


        [Display(Name = "Órgão Expedição")]
        [StringLength(10)]
        public string orgaoExpedicao { get; set; }

        [Display(Name = "UF Expedição")]
        [StringLength(10)]
        public string UF { get; set; }

        [Required(ErrorMessage = "*Informe a data de Nascimento")]
        [Display(Name = "Data de Nascimento*")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime dt_nascimento { get; set; }

        [Required(ErrorMessage = "*Informe o Sexo")]
        [Display(Name = "Sexo*")]
        [StringLength(1)]
        public string sexo { get; set; }

        [Required(ErrorMessage = "*Informe o Estado Civil")]
        [Display(Name = "Estado Civil*")]
        [StringLength(50)]
        public string estadoCivil { get; set; }

        [Required(ErrorMessage = "*Informe o CEP")]
        [Display(Name = "CEP*")]
        [StringLength(20)]
        public string cep { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "*Informe a Rua")]
        [Display(Name = "Rua*")]
        public string logradouro { get; set; }

        [StringLength(10)]
        [Required(ErrorMessage = "*Informe o número")]
        [Display(Name = "Número*")]
        public string numero { get; set; }


        [StringLength(50)]
        [Display(Name = "Complemento")]
        public string complemento { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "*Informe o Bairro")]
        [Display(Name = "Bairro*")]
        public string bairro { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "*Informe a cidade")]
        [Display(Name = "Cidade*")]
        public string cidade { get; set; }

        [StringLength(10)]
        [Required(ErrorMessage = "*Informe o estado (UF)")]
        [Display(Name = "UF*")]
        public string UFEndereco { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EnderecoCliente> EnderecoCliente { get; set; }

    }
}