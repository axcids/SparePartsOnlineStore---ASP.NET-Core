using Spareparts.Domain.Entities;

namespace Spareparts.Application.Manufacturers.Dtos; 
public class ManufacturersDtos {
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public string? Logo { get; set; }
    public static ManufacturersDtos? FromEntity(Manufacturer manufacturer) {
        if (manufacturer == null) return null;
        return new ManufacturersDtos {
            Id = manufacturer.Id,
            Name = manufacturer.Name,
            Description = manufacturer.Description,
            Logo = manufacturer.Logo,
        };
    }

}
