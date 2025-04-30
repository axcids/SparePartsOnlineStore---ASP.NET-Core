
using Microsoft.EntityFrameworkCore;
using Spareparts.Domain.Entities;
using Spareparts.Domain.Repositories;
using Spareparts.Infrastructure.Persistence;

namespace Spareparts.Infrastructure.Repositories; 
internal class SupplierRepository (SparepartsDbContext dbContext) :  ISupplierRepository {

    public async Task<Guid> AddNewSupplier(Supplier entity) {
        dbContext.Add(entity);
        await dbContext.SaveChangesAsync();
        return entity.Id;
    }
    public async Task<bool> UpdateSupplierById(Guid id, Supplier entity) {
        var supplier = await dbContext.Suppliers.FirstOrDefaultAsync(x => x.Id == id);
        if (supplier != null) {
            supplier.UserId = entity.UserId;
            supplier.Name = entity.Name;
            supplier.SupplierCode = entity.SupplierCode;
            supplier.SupplierType = entity.SupplierType;
            supplier.ContactEmail = entity.ContactEmail;
            supplier.ContactPhone = entity.ContactPhone;
            supplier.Website = entity.Website;
            supplier.IsActive = entity.IsActive;
            supplier.AddressLine1 = entity.AddressLine1;
            supplier.AddressLine2 = entity.AddressLine2;
            supplier.City = entity.City;
            supplier.StateOrProvince = entity.StateOrProvince;
            supplier.PostalCode = entity.PostalCode;
            supplier.Country = entity.Country;
            supplier.UpdatedAt = DateTime.UtcNow;
            dbContext.Update(supplier);
            await dbContext.SaveChangesAsync(); 
            return true;
        }
        return false;
    }
    public async Task<IEnumerable<Supplier>> GetAllSuppliers() {
        var AllSuppliers = await dbContext.Suppliers.ToListAsync();
        return AllSuppliers;
    }
    public async Task<Supplier> GetSupplierById(Guid id) {
        var supplier = await dbContext.Suppliers.FirstOrDefaultAsync(x => x.Id == id);
        return supplier;
    }
    public async Task<IEnumerable<Supplier>> GetSuppliersBySupplierCode(string supplierCode) { 
        var suppliers = await dbContext.Suppliers.Where(x => x.SupplierCode == supplierCode).ToListAsync();
        return suppliers;
    }
    public async Task<Supplier> GetSupplierByName(string name) {
        var supplier = dbContext.Suppliers.FirstOrDefault(x => x.Name == name);
        return supplier;
    }
    public async Task<IEnumerable<Supplier>> GetSuppliersByCountry(string country) {
        var suppliers = await dbContext.Suppliers.Where(x => x.Country == country).ToListAsync();
        return suppliers;
    }
    public async Task<bool> DeleteSupplierById(Guid supplierId) {
        var entity = dbContext.Suppliers.FirstOrDefault(x => x.Id == supplierId);
        dbContext.Suppliers.Remove(entity);
        var isDeleted = dbContext.SaveChanges();
        if (isDeleted == 1) {
            return true;
        }
        else {
            return false;
        }
    }
    public async Task<bool> DeleteSuppliersBySupplierCode(string supplierCode) {
        var entities = dbContext.Suppliers.Where(x => x.SupplierCode == supplierCode).ToList();
        dbContext.RemoveRange(entities);
        var isDeleted = dbContext.SaveChanges();
        if (isDeleted == 1) {
            return true;
        }
        else {
            return false;
        }
    }

    public async Task SaveChanges() {
        await dbContext.SaveChangesAsync();
    }

}
