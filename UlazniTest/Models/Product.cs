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

        [Required(ErrorMessage = "Polje je ibavezno")]
        [StringLength(50)]
        public string Naziv { get; set; }

        [StringLength(250, ErrorMessage = "Prekoracili ste maksimakni broj od 250 karaktera")]
        public string Opis { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Prekoracili ste maksimakni broj od 50 karaktera")]
        public string Kategorija { get; set; }

        [Required(ErrorMessage = "Polje je obavezno")]
        [StringLength(50, ErrorMessage = "Prekoracili ste maksimakni broj od 50 karaktera")]
        public string Proizvodjac { get; set; }

        [Required(ErrorMessage = "Polje je obvavezno")]
        [StringLength(50, ErrorMessage = "Prekoracili ste maksimakni broj od 50 karaktera")]
        public string Dobavljac { get; set; }

        [Column(TypeName = "money")]
        public decimal Cena { get; set; }
    }
}
