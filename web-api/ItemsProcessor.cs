using System;
using System.Threading.Tasks;

namespace web_api
{
    public class ItemsProcessor
    {
        IRepository _repository;

        public ItemsProcessor(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<Item> CreateItem(Guid playerId, NewItem item)
        {
            try
            {
                Item newItem = new Item();
                newItem.Id = Guid.NewGuid();
                newItem.CreationDate = System.DateTime.Now;
                newItem.Type = item.Type;
                newItem.Price = item.Price;

                Player player = await _repository.Get(playerId);
                if (newItem.Type == Item.ItemType.Sword && player.Level < 3) {
                    throw new LowLevelPlayerException("Player too low level for sword!");
                }

                return await _repository.CreateItem(playerId, newItem);
            }
            catch (LowLevelPlayerException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public Task<Item[]> GetAllItems(Guid playerId)
        {
            return _repository.GetAllItems(playerId);
        }

        public Task<Item> GetItem(Guid playerId, Guid itemId)
        {
            return _repository.GetItem(playerId, itemId);
        }

        public Task<Item> ModifyItem(Guid playerId, Guid itemId, ModifiedItem item)
        {
            return _repository.ModifyItem(playerId, itemId, item);
        }

        public Task<Item> DeleteItem(Guid playerId, Guid itemId)
        {
            return _repository.DeleteItem(playerId, itemId);
        }
    }
}
