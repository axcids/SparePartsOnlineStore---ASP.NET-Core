namespace Spareparts.Domain.Entities; 
public class CarProduct {

    public Guid Id { get; set; }


    //Car 
    public Guid CarId { get; set; }
    public virtual Car Car { get; set; }

    //Product 
    public Guid ProductId { get; set; }
    public virtual Product Product { get; set; }

}
