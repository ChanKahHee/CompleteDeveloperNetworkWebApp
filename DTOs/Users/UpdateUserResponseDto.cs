using CompleteDeveloperNetworkWebApp.Models;

namespace CompleteDeveloperNetworkWebApp.DTOs.Users
{
    public record UpdateUserResponseDto(
        long Id,
        string Username,
        string Mail,
        string PhoneNumber,
        ICollection<Skill> Skillset,
        string Hobby);
}
