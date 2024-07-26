

using AbodeLunch.Application.Common.Interfaces.Persistence;
using AbodeLunch.Domain.Host.ValueObjects;
using AbodeLunch.Domain.Menu;
using AbodeLunch.Domain.Menu.Entities;

using ErrorOr;

using MediatR;

namespace AbodeLunch.Application.Menus.Commands.CreateMenu;

public class CreateMenuCommandHandler : IRequestHandler<CreateMenuCommand, ErrorOr<Menu>> {
    private readonly IMenuRepository _menuRepository;

    public CreateMenuCommandHandler(IMenuRepository menuRepository)
    {
        _menuRepository = menuRepository;
    }

    public async Task<ErrorOr<Menu>> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
    {
        //Create Menu
        await Task.CompletedTask; 
        var menu = Menu.Create(
            hostId: HostId.Create(request.HostId),
            name: request.Name,
            description: request.Description, 
            sections: request.Sections.ConvertAll(section => new MenuSection.Create(
                section.Name,
                section.Description,                
                section.Items.ConvertAll(item => new MenuItem.Create(
                    item.Name,
                    item.Description
                ))
            )));
        //Persist Menu
        _menuRepository.Add(menu);
        //Return Menu
        return menu;
    }
}
