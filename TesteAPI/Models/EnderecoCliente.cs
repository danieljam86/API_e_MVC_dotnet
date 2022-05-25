namespace GTISolutionTesteAPI.Models
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

        [StringLength(20)]
        public string cep { get; set; }

        [StringLength(50)]
        public string logradouro { get; set; }

        [StringLength(10)]
        public string numero { get; set; }

        [StringLength(50)]
        public string complemento { get; set; }

        [StringLength(50)]
        public string bairro { get; set; }

        [StringLength(50)]
        public string cidade { get; set; }

        [StringLength(10)]
        public string UF { get; set; }

        public int? Cliente_id_cliente { get; set; }

        public virtual Cliente Cliente { get; set; }
    }
}
