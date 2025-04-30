using MediatR;
using Spareparts.Application.Categories.Dtos;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace Spareparts.Application.Categories.Commands.UpdateCategoryByIdCommand; 
public class UpdateCategoryByIdCommand : IRequest<CategoriesDtos>{
    [JsonIgnore]
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    [JsonIgnore]
    public DateTime UpdateAt { get; set; } = DateTime.Now;
}
