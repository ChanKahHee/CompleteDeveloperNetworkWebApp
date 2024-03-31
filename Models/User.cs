using System.ComponentModel.DataAnnotations;

namespace CompleteDeveloperNetworkWebApp.Models
{
    public class User
    {
        [Key]
        public long Id { get; set; }

        public string Username { get; set; }

        public string Mail { get; set; }

        public string PhoneNumber { get; set; }

        public ICollection<Skill> SkillSets { get; set; }

        public string Hobby { get; set; }

        public User() { }

        public User(string username, string mail, string phoneNumber, ICollection<Skill> skillSets, string hobby)
        {
            Username = username;
            Mail = mail;
            PhoneNumber = phoneNumber;
            Hobby = hobby;
            SkillSets = skillSets;
        }

        public User(int id, string username, string mail, string phoneNumber, List<Skill> skillSets, string hobby)
        {
            Id = id;
            Username = username;
            Mail = mail;
            PhoneNumber = phoneNumber;
            SkillSets = skillSets;
            Hobby = hobby;
        }
    }
}
