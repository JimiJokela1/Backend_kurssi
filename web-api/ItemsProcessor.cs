using System;
using System.Threading.Tasks;

namespace web_api
{
    public class ItemsProcessor
    {
        IRepository _repository;

        public ItemsProcessor(IRepository repository){
            _repository = repository;
        }

        public Task<Item> CreateItem(NewItem item)
        {
            Item newItem = new Item();
            newItem.Id = Guid.NewGuid();
            return _repository.CreateItem(newItem);
        }

        public Task<Item[]> GetAllItems()
        {
            return _repository.GetAllItems();
        }

        public Task<Item> GetItem(Guid id)
        {
            return _repository.GetItem(id);
        }

        public Task<Item> ModifyItem(Guid id, ModifiedItem item)
        {
            return _repository.ModifyItem(id, item);
        }

        public Task<Item> DeleteItem(Guid id)
        {
            return _repository.DeleteItem(id);
        }
    }
}