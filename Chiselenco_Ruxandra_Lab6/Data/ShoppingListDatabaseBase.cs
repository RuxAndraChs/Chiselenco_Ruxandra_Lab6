namespace Chiselenco_Ruxandra_Lab6.Data
{
    public class ShoppingListDatabaseBase
    {

        public Task<int> DeleteProductAsync(Product product)
        {
            return _database.DeleteAsync(product);
        }
        public Task<int> SaveProductAsync(Product product)
        {
            if (product.ID != 0)
            {
                return _database.UpdateAsync(product);
            }
            else
            {
                return _database.InsertAsync(product);
            }
        }
    }
}