namespace CompleteDeveloperNetworkWebApp.DTOs.Users
{
    public record GetAllUsersResponseDto(
        List<GetUserResponseDto> users);
}
