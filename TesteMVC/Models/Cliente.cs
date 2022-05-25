namespace GTISolutionTeste.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Cliente")]
    public partial class Cliente
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cliente()
        {
            EnderecoCliente = new HashSet<EnderecoCliente>();
        }

        [Key]
        public int id_cliente { get; set; }

        [Display(Name = "CPF*")]
        [Required(ErrorMessage = "*Informe o CPF")]
        [StringLength(11)]
        public string cpf { get; set; }

        [Required(ErrorMessage = "*Informe o Nome")]
        [Display(Name = "Nome*")]
        [StringLength(50)]
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
        public DateTime? dt_nascimento { get; set; }


        [Required(ErrorMessage = "*Informe o Sexo")]
        [Display(Name = "Sexo*")]
        [StringLength(1)]
        public string sexo { get; set; }


        [Required(ErrorMessage = "*Informe o Estado Civil")]
        [Display(Name = "Estado Civil*")]
        [StringLength(50)]
        public string estadoCivil { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EnderecoCliente> EnderecoCliente { get; set; }


    }
}
