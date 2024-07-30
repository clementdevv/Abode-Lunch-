using AbodeLunch.Domain.Menu.ValueObjects;
using AbodeLunch.Domain.Models;

namespace AbodeLunch.Domain.Menu.Entities;

public sealed class MenuSection : Entity<MenuSectionId>
{
    private readonly List<MenuItem> _items = new();
    public string Name { get; }
    public string Description { get; }
    public IReadOnlyList<MenuItem> Items => _items.AsReadOnly();

    private MenuSection(
        MenuSectionId menuSectionId,
        string name, 
        string description)
        : base(menuSectionId)
    {
        Name = name;
        Description = description;
    }

    public static MenuSection Create(
        string name, 
        string description)
    {
        return new(
            MenuSectionId.CreateUnique(),
            name,
            description
        );
    }
    
    #pragma warning disable CS8618
    private MenuSection()    
    {
    }
    #pragma warning disable CS8618

}