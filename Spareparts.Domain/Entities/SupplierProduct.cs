namespace Spareparts.Domain.Entities; 

public class SupplierProduct {

    public Guid Id { get; set; }

    //Supplier 
    public Guid SupplierId { get; set; }
    public virtual Supplier Supplier{ get; set; }

    //Product 
    public Guid ProductId { get; set; }
    public virtual ProductDetails ProductDetails { get; set; }

}
