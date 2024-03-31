using CompleteDeveloperNetworkWebApp.Models;

namespace CompleteDeveloperNetworkWebApp.DTOs.Users
{
    public record CreateUserRequestDto(
        string Username, string Mail, string PhoneNumber, ICollection<String> SkillSets, string Hobby);
}
