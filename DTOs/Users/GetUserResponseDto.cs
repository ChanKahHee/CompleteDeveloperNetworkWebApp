using CompleteDeveloperNetworkWebApp.Models;

namespace CompleteDeveloperNetworkWebApp.DTOs.Users
{
    public record GetUserResponseDto(
        long Id, string Username, string Mail, string PhoneNumber, ICollection<Skill> SkillSets, string Hobby);
}
