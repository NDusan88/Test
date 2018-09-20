namespace UlazniTest.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Product
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Naziv { get; set; }

        [StringLength(250)]
        public string Opis { get; set; }

        [Required]
        [StringLength(50)]
        public string Kategorija { get; set; }

        [Required]
        [StringLength(50)]
        public string Proizvodjac { get; set; }

        [Required]
        [StringLength(50)]
        public string Dobavljac { get; set; }

        [Column(TypeName = "money")]
        public decimal Cena { get; set; }
    }
}
