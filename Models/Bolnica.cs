using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace arhitektura_projekat.Models
{
    public class Bolnica
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Naziv { get; set; }

    [Required]
    [StringLength(200)]
    public string Adresa { get; set; }

    public string Slika { get; set; }

    public string BrojTelefona { get; set; }

    [Range(0, Double.MaxValue)]
    public decimal Budzet { get; set; }

    [JsonIgnore]
    public ICollection<Odeljenje> Odeljenja { get; set; }
}
}