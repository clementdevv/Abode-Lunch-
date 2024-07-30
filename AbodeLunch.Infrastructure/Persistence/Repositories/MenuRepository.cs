using AbodeLunch.Application.Common.Interfaces.Persistence;
using AbodeLunch.Domain.Menu;

namespace AbodeLunch.Infrastructure.Persistence;

public class MenuRepository : IMenuRepository
{
    // private static readonly List<Menu> _menus = new();
    private readonly AbodeLunchDbContext _dbContext;

    public MenuRepository(AbodeLunchDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public void Add(Menu menu)
    {
        _dbContext.Add(menu);
        _dbContext.SaveChanges();
    }

}

