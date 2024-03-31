using CompleteDeveloperNetworkWebApp.Models;
using System.Diagnostics.Eventing.Reader;

namespace CompleteDeveloperNetworkWebApp.Services.Users
{
    public interface IUserService
    {
        User Create(User user);

        List<User> GetAll();

        User? Get(long id);

        User Update(long id, User user);

        void Delete(long id);
    }
}
