using System;

namespace web_api
{
    public class Item
    {
        public enum ItemType {
            Weapon,
            Armor
        }
        public Guid Id {get; set;}
        public int Level {get; set;}
        public ItemType Type {get; set;}
        public DateTime CreationDate {get;set;}
        public Guid PlayerOwnerId {get;set;}
    }
}
