using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace web_api
{
    public class InMemoryRepository : IRepository
    {
        private List<Player> players = new List<Player>();

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
                found.Modify(player);
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

        public async Task<Item> CreateItem(Guid playerId, Item item)
        {
            await Task.CompletedTask;
            Player player = GetPlayerById(playerId);
            if (player == null)
            {
                return null;
            }

            player.items.Add(item);
            return item;
        }

        public async Task<Item[]> GetAllItems(Guid playerId)
        {
            await Task.CompletedTask;
            Player player = GetPlayerById(playerId);
            if (player == null)
            {
                return null;
            }

            return player.items.ToArray();
        }

        public async Task<Item> GetItem(Guid playerId, Guid itemId)
        {
            await Task.CompletedTask;
            Player player = GetPlayerById(playerId);
            if (player == null)
            {
                return null;
            }

            return GetItemById(player, itemId);
        }

        public async Task<Item> ModifyItem(Guid playerId, Guid itemId, ModifiedItem item)
        {
            await Task.CompletedTask;
            Player player = GetPlayerById(playerId);
            if (player == null)
            {
                return null;
            }

            Item found = GetItemById(player, itemId);

            if (found != null)
            {
                found.Modify(item);
            }
            return found;
        }

        public async Task<Item> DeleteItem(Guid playerId, Guid itemId)
        {
            await Task.CompletedTask;
            Player player = GetPlayerById(playerId);
            if (player == null)
            {
                return null;
            }

            Item found = GetItemById(player, itemId);

            if (found != null)
            {
                player.items.Remove(found);
            }
            return found;
        }

        private Item GetItemById(Player player, Guid itemId)
        {
            foreach (Item item in player.items)
            {
                if (item.Id == itemId)
                {
                    return item;
                }
            }

            return null;
        }
    }
}
