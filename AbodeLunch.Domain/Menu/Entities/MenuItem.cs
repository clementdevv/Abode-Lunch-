using AbodeLunch.Domain.Menu.ValueObjects;
using AbodeLunch.Domain.Models;

namespace AbodeLunch.Domain.Menu.Entities;

public sealed class MenuItem : Entity<MenuItemId>
{
    public string Name { get; }
    public string Description { get; }
    // private readonly List<MenuItem> _items = new();

    public MenuItem(MenuItemId menuItemId, string name, string description) : base(menuItemId)
    {
        Name = name; 
        Description = description;
    }

    public static MenuItem Create(
        string name,
        string description
    )   
    {
        return new(
            MenuItemId.CreateUnique(),
            name,
            description
        );
    }

    #pragma warning disable CS8618
    private MenuItem()    
    {
    }
    #pragma warning disable CS8618
}
    

