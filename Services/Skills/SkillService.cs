using CompleteDeveloperNetworkWebApp.Models;
using CompleteDeveloperNetworkWebApp.Services.Users;

namespace CompleteDeveloperNetworkWebApp.Services.Skills
{
    public class SkillService : ISkillService
    {
        private readonly ILogger<SkillService> _logger;

        private readonly AppDbContext _dbContext;

        public SkillService(ILogger<SkillService> logger, AppDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public Skill Create(Skill skill)
        {
            _dbContext.Skills.Add(skill);
            _dbContext.SaveChanges();
            return skill;
        }
    }
}
