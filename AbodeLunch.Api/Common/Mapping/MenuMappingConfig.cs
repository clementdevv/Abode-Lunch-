
// using AbodeLunch.Application.Menus.Commands.CreateMenu;
// using AbodeLunch.Contracts.Menu;
// using AbodeLunch.Domain.Host.ValueObjects;
// using AbodeLunch.Domain.Menu;

// using Mapster;

// // using MenuSection = AbodeLunch.Domain.MenuAggregate.Entities.MenuSection;


// namespace AbodeLunch.Api.Common.Mapping;

// public class MenuMappingConfig : IRegister
// {
//     public void Register(TypeAdapterConfig config)
//     {
//         config.NewConfig<(CreateMenuRequest Request, string HostId), CreateMenuCommand>()
//         .Map(dest => dest.HostId, src => src.HostId)
//         .Map(dest => dest, src => src.Request);

//         config.NewConfig<Menu, MenuResponse>()
//             .Map(dest => dest.Id, src => src.Id.Value)
//             .Map(dest => dest.HostId, src => src.HostId.Value)
//             .Map(dest => dest.DinnerId, src => src.DinnerId.Select(dinnerId => dinnerId.Value))
//             .Map(dest => dest.MenuReviewIds, src => src.MenuReviewIds.Select(menuId => menuId.Value));

//         config.NewConfig<MenuSection, MenuSectionResponse>()
//             .Map(dest => dest.Id, src => src.Id.Value);

//         config.NewConfig<MenuItem, MenuItemResponse>()
//             .Map(dest => dest.Id, src => src.Id.Value);
//     }
// }