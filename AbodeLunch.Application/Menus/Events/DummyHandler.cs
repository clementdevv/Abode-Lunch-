using AbodeLunch.Domain.Menu.Events;
using MediatR;

namespace AbodeLunch.Application.Dinners.Events;

public class DummyHandler : INotificationHandler<MenuCreated>
{
    public Task Handle(MenuCreated notification, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}