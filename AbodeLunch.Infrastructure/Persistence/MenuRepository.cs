

using AbodeLunch.Application.Common.Interfaces.Persistence;
using AbodeLunch.Domain.Menu;

namespace AbodeLunch.Infrastructure.Persistence;

public class MenuRepository : IMenuRepository
{
    private static readonly List<Menu> _menus = new();
    public void Add(Menu menu)
    {
        _menus.Add(menu);
    }

}