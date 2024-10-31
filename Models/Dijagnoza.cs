using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using arhitektura_projekat.Models;

namespace arhitektura_projekat.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.Text.Json.Serialization;

    public class Dijagnoza
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Naziv { get; set; }

    [StringLength(500)]
    public string Opis { get; set; }

    public string Slika { get; set; }

    [StringLength(50)]
    public string Oznaka { get; set; }

    [JsonIgnore]
    public ICollection<Pacijent> Pacijenti { get; set; }
}

}