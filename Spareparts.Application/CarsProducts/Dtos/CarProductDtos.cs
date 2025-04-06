using Spareparts.Domain.Entities;

namespace Spareparts.Application.CarsProducts.Dtos; 
public class CarProductDtos {
    public Guid Id { get; set; }

    public Guid CarId { get; set; }

    public Guid ProductId { get; set; }

    public static CarProductDtos? FromEntity(CarProduct carProduct) {
        if(carProduct == null) return null;
        return new CarProductDtos() {
            Id = carProduct.Id,
            CarId = carProduct.CarId,
            ProductId = carProduct.ProductId
        };
    }
}

