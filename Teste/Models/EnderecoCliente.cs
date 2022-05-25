namespace GTISolutionTeste.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EnderecoCliente")]
    public partial class EnderecoCliente
    {
        [Key]
        public int id_endereco { get; set; }

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
        public string UF { get; set; }

        public int? Cliente_id_cliente { get; set; }

        public virtual Cliente Cliente { get; set; }
    }
}
