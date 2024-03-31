using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CompleteDeveloperNetworkWebApp.Models
{
    public class Skill
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }

        [ForeignKey("User")]
        public long UserId { get; set; }

        [JsonIgnore]
        public User User { get; set; }

        public Skill() {}

        public Skill(string name)
        {
            Name = name;
        }
    }
}
