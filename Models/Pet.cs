using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;


namespace pet_hotel.Models
{
    public enum PetBreedType
    {
        Persian,
        MaineCoon,
        Ragdoll,
        BritishShorthair,
        DomesticShorthair,
        AmericanShorthair,

    }
    public enum PetColorType
    {
        Tabby,
        Tortoiseshell,
        Tuxedo,
        Black,
        White,
        Smoke,
        PartiColor
    }
    public class Pet
    {
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        [ForeignKey("ownedBy")]
        public int ownedById { get; set; }
        public PetOwner ownedBy {get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public PetBreedType type { get; set;}
    }
}
