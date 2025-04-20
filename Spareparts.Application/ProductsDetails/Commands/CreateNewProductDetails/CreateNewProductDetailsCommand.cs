using MediatR;

namespace Spareparts.Application.ProductsDetails.Commands.CreateNewProductDetails; 
public class CreateNewProductDetailsCommand(Guid carId, Guid supplierId) : IRequest<Guid>{
    public Guid CategoryId { get; set; }
    //public Guid SupplierId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string UPC { get; set; }
    public decimal Price { get; set; }
    public float WeightInKg { get; set; }
    public string Dimensions { get; set; }
    public string Material { get; set; }
    public Boolean HasWarranty { get; set; }
    public int? WarrantyPeriodInMonths { get; set; }

    // CarsProductTable 
    public Guid CarId { get; } = carId; // CarId is the foreign key to the Cars table
    //SuppliersProduct Table 
    public Guid SupplierId { get; } = supplierId; // SupplierId is the foreign key to the Suppliers table


}
