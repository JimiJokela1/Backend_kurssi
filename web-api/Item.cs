using System;
using System.ComponentModel.DataAnnotations;

namespace web_api
{
    public class Item
    {
        public enum ItemType
        {
            Sword,
            Axe,
            Shield
        }
        public Guid Id { get; set; }
        public ItemType Type { get; set; }
        public int Price { get; set; }
        [DateValidation]
        public DateTime CreationDate { get; set; }

        public void Modify(ModifiedItem item)
        {
            Price = item.Price;
        }
    }
}
