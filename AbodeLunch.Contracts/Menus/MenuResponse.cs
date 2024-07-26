namespace AbodeLunch.Contracts.Menu;

public record MenuResponse(
    Guid id,
    string Name, 
    string Description,
    float? AverageRating, 
    List<MenuSection> Sections,
    string HostId,
    List<string> DinnerIds,
    List<string> ReviewIds,
    List<string> MenuReviewIds,
    DateTime CreatedDateTime,
    DateTime UpdatedDateTime
);

public record MenuSectionResponse(
    string Id,
    string Name,
    string Description,
    List<MenuItemResponse> Items
);

public record MenuItemResponse(
    string Id,
    string Name, 
    string Description
);