using CompleteDeveloperNetworkWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CompleteDeveloperNetworkWebApp.Services.Users
{
    public class UserService : IUserService
    {
        private readonly ILogger<UserService> _logger;

        private readonly AppDbContext _dbContext;

        public UserService(ILogger<UserService> logger, AppDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public List<User> GetAll()
        {
            _logger.LogInformation("GetAll()");
            return _dbContext.Users.Include(user => user.SkillSets).ToList();
        }
        public User? Get(long id)
        {
            _logger.LogInformation("Get(id={})", id);
            return _dbContext.Users.Include(user => user.SkillSets).FirstOrDefault(user => user.Id == id);
        }

        public User Create(User user)
        {
            _logger.LogInformation("Create(user={})", user);
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
            _logger.LogInformation("Create(user={}) END", user);
            return user;
        }

        public User Update(long id, User newUser)
        {
            _logger.LogInformation("Update(id={}, newUser={})", id, newUser);
            var user = _dbContext.Users.Where(u => u.Id == id).Include(u => u.SkillSets).SingleOrDefault();
 
            if (user == null)
            {
                throw new ArgumentNullException("User(id={}) does not exist.");
            }

            _dbContext.Entry(user).CurrentValues.SetValues(newUser);

            foreach (var skill in user.SkillSets.ToList())
            {
                if (!newUser.SkillSets.Any(s => s.Id == skill.Id)) {
                    _dbContext.Skills.Remove(skill);
                }
            }

            foreach (var skill in newUser.SkillSets)
            {
                var skillEntity = newUser.SkillSets.FirstOrDefault(s => s.Id == skill.Id);
                if (skillEntity != null)
                {
                    _dbContext.Entry(skillEntity).CurrentValues.SetValues(skill);
                }
                else
                {
                    newUser.SkillSets.Add(skill);
                }
            }

            _dbContext.SaveChanges();
            _logger.LogInformation("Update(user={}) END", user);
            return user;
        }

        public void Delete(long id)
        {
            _logger.LogInformation("Delete(id={})", id);
            var user = _dbContext.Users.Local.FirstOrDefault(x => x.Id == id);

            // Entity is not tracked by dbContext, avoid making select query
            if (user == null) {
                user = new User { Id = id };
                _dbContext.Attach(user);
            }

            _dbContext.Users.Remove(user);
            _dbContext.SaveChanges();
            _logger.LogInformation("Delete(id={}) END", id);
        }
    }
}
