using System;
using System.Threading.Tasks;

namespace web_api
{
    public interface IRepository
    {
        Task<Player> GetPlayer(Guid id);
        Task<Player[]> GetAllPlayers();
        Task<Player> CreatePlayer(Player player);
        Task<Player> ModifyPlayer(Guid id, ModifiedPlayer player);
        Task<Player> DeletePlayer(Guid id);

        Task<Item> GetItem(Guid playerId, Guid itemId);
        Task<Item[]> GetAllItems(Guid playerId);
        Task<Item> CreateItem(Guid playerId, Item item);
        Task<Item> ModifyItem(Guid playerId, Guid itemId, ModifiedItem item);
        Task<Item> DeleteItem(Guid playerId, Guid itemId);

        // Assignment 5 stuff
        Task<Player[]> MoreThanXScore(int x);
        Task<Player> GetPlayerWithName(string name);
        Task<Player[]> GetPlayersWithItemType(Item.ItemType itemType);
        Task<int> GetLevelsWithMostPlayers();

        // Assignment 6
        Task WriteToLog(LogEntry logEntry);
        Task<LogEntry[]> GetLog();
    }
}
