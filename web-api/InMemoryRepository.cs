using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace web_api
{
    public class InMemoryRepository : IRepository
    {
        private List<Player> players = new List<Player>();
        private List<Item> items = new List<Item>();

        public async Task<Player> Create(Player player)
        {
            await Task.CompletedTask;
            players.Add(player);
            return player;
        }

        public async Task<Player> Delete(Guid id)
        {
            await Task.CompletedTask;

            Player found = GetPlayerById(id);

            if (found != null)
            {
                players.Remove(found);
                return found;
            }
            else
            {
                return null;
            }
        }

        public async Task<Player> Get(Guid id)
        {
            await Task.CompletedTask;
            return GetPlayerById(id);
        }

        public async Task<Player[]> GetAll()
        {
            await Task.CompletedTask;
            return players.ToArray();
        }

        public async Task<Player> Modify(Guid id, ModifiedPlayer player)
        {
            await Task.CompletedTask;
            Player found = GetPlayerById(id);
            if (found != null)
            {
                found.Score = player.Score;
            }
            return found;
        }

        private Player GetPlayerById(Guid id)
        {
            foreach (Player player in players)
            {
                if (player.Id == id)
                {
                    return player;
                }
            }

            return null;
        }

        public async Task<Item> CreateItem(Item item)
        {
            await Task.CompletedTask;
            items.Add(item);
            return item;
        }

        public async Task<Item[]> GetAllItems()
        {
            await Task.CompletedTask;
            return items.ToArray();
        }

        public async Task<Item> GetItem(Guid id)
        {
            await Task.CompletedTask;
            return GetItemById(id);
        }

        public async Task<Item> ModifyItem(Guid id, ModifiedItem item)
        {
            await Task.CompletedTask;
            Item found = GetItemById(id);

            return found;
        }

        public async Task<Item> DeleteItem(Guid id)
        {
            await Task.CompletedTask;

            Item found = GetItemById(id);

            if (found != null)
            {
                items.Remove(found);
                return found;
            }
            else
            {
                return null;
            }
        }

        private Item GetItemById(Guid id)
        {
            foreach (Item item in items)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }

            return null;
        }
    }
}
