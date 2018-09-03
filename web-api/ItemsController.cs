using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace web_api
{
    [Route("api/players/{id:Guid}/items")]
    public class ItemsController
    {
        ItemsProcessor _processor;

        public ItemsController(ItemsProcessor processor){
            _processor = processor;
        }

        public Task<Item> CreateItem(NewItem item)
        {
            return _processor.CreateItem(item);
        }

        public Task<Item[]> GetAllItems()
        {
            return _processor.GetAllItems();
        }

        public Task<Item> GetItem(Guid id)
        {
            return _processor.GetItem(id);
        }

        public Task<Item> ModifyItem(Guid id, ModifiedItem item)
        {
            return _processor.ModifyItem(id, item);
        }

        public Task<Item> DeleteItem(Guid id)
        {
            return _processor.DeleteItem(id);
        }
    }
}