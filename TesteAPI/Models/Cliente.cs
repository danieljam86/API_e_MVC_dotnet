namespace GTISolutionTesteAPI.Models
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

        [StringLength(11)]
        public string cpf { get; set; }

        [StringLength(50)]
        public string nome { get; set; }

        [StringLength(15)]
        public string rg { get; set; }

        public DateTime? dt_expedicao { get; set; }

        [StringLength(10)]
        public string orgaoExpedicao { get; set; }

        [StringLength(10)]
        public string UF { get; set; }

        public DateTime? dt_nascimento { get; set; }

        [StringLength(1)]
        public string sexo { get; set; }

        [StringLength(50)]
        public string estadoCivil { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EnderecoCliente> EnderecoCliente { get; set; }
    }
}
