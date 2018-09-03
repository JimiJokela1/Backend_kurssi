using System;
using System.Threading.Tasks;

namespace web_api
{
    public interface IRepository
    {
        Task<Player> Get(Guid id);
        Task<Player[]> GetAll();
        Task<Player> Create(Player player);
        Task<Player> Modify(Guid id, ModifiedPlayer player);
        Task<Player> Delete(Guid id);

        Task<Item> GetItem(Guid id);
        Task<Item[]> GetAllItems();
        Task<Item> CreateItem(Item item);
        Task<Item> ModifyItem(Guid id, ModifiedItem item);
        Task<Item> DeleteItem(Guid id);
    }
}
