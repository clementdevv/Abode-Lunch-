using AbodeLunch.Domain.Host.ValueObjects;
using AbodeLunch.Domain.Menu.Entities;
using AbodeLunch.Domain.Menu.Events;
using AbodeLunch.Domain.Menu.ValueObjects;
using AbodeLunch.Domain.Models;

namespace AbodeLunch.Domain.Menu;

public sealed class Menu : AggregateRoot<MenuId>
{
    private readonly List<MenuSection> _sections = new();
    private readonly List<DinnerId> _dinnerIds = new();
    private readonly List<MenuReviewId> _menuReviewIds = new();
    public string Name { get; private set;}
    public string Description { get; private set;}
    public float AverageRating { get; private set;}

    public IReadOnlyList<MenuSection> Sections => _sections.AsReadOnly();

    public HostId HostId { get; private set;}
    public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();
    public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();
    
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    private Menu(
        MenuId menuId,
        string name,
        string description,
        HostId hostId,
        DateTime createdDaTime,
        DateTime updatedDaTime)
        : base(menuId)
    {
        Name = name;
        Description = description;
        HostId = hostId;
        CreatedDateTime = createdDaTime;
        UpdatedDateTime = updatedDaTime;
        // _sections = sections;
    }

    public static Menu Create(
        string name,
        string description,
        HostId hostId,
        List<MenuSection>? sections
        )
    {
        var menu = new Menu(
            MenuId.CreateUnique(),
            name,
            description,
            hostId,
            DateTime.UtcNow,
            DateTime.UtcNow);
        menu.AddDomainEvent(new MenuCreated(menu));
        return menu;
    }
    
#pragma warning disable CS8618
    // private Menu()
    // {

    // }
#pragma warning disable CS8618    
}