namespace CompleteDeveloperNetworkWebApp.DTOs.Users
{
    public record UpdateUserRequestDto(
        string Username, string Mail, string PhoneNumber, ICollection<String> SkillSets, string Hobby);
}
