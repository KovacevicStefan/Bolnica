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
    public class Pacijent
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Ime { get; set; }

    [Required]
    [StringLength(100)]
    public string Prezime { get; set; }

    public bool Zdr_osiguranje { get; set; }

    public DateTime DatumRodjenja { get; set; }

    public string Slika { get; set; }

    [ForeignKey("Odeljenje")]
    public int OdeljenjeId { get; set; }
    [JsonIgnore]
    public Odeljenje Odeljenje { get; set; }

    [ForeignKey("Dijagnoza")]
    public int DijagnozaId { get; set; }
    [JsonIgnore]
    public Dijagnoza Dijagnoza { get; set; }
}
}