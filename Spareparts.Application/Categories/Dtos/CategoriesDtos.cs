using Spareparts.Domain.Entities;
using System.Diagnostics;

namespace Spareparts.Application.Categories.Dtos; 
public class CategoriesDtos {

    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }

    public static CategoriesDtos? FromEntity(Category category) {
        if (category == null) return null;
        return new CategoriesDtos() {
            Id = category.Id,
            Name = category.Name,
            Description = category.Description
        };
    }
}
