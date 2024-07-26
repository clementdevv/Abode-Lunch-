namespace AbodeLunch.Contracts.Menu;
public record CreateMenuRequest(
    string name,
    string Description,
    List<MenuSection> Section
);

public record MenuSection(
    string Name,
    string Description,
    List<MenuItem> Items
);

public record MenuItem(
    string Name,
    string Description
);