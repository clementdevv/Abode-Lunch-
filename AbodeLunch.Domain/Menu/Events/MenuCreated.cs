using AbodeLunch.Domain.Common.Models;

namespace AbodeLunch.Domain.Menu.Events;

public record MenuCreated(Menu Menu) : IDomainEvent;
