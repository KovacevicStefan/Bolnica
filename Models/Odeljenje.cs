using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using arhitektura_projekat.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace arhitektura_projekat.Models
{
    public class Odeljenje
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Naziv { get; set; }

    [StringLength(200)]
    public string Lokacija { get; set; }

    public string Slika { get; set; }

    [ForeignKey("Bolnica")]
    public int BolnicaId { get; set; }
    [JsonIgnore]
    public Bolnica Bolnica { get; set; }

    [JsonIgnore]
    public ICollection<Pacijent> Pacijenti { get; set; }
}
}