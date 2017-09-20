﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taustajarjestelmat_2.Models;

namespace Taustajarjestelmat_2.Repos
{
    public interface IRepository
    {
    Task<Player> CreatePlayer(Player player);
    Task<Player> GetPlayer(Guid playerId);
    Task<Player[]> GetAllPlayers();
    Task<Player> UpdatePlayer(Player player);
    Task<Player> DeletePlayer(Guid playerId);
    Task<Item> CreateItem(Guid playerId, Item item);
    Task<Item> GetItem(Guid playerId, Guid itemId);
    Task<Item[]> GetAllItems(Guid playerId);
    Task<Item> UpdateItem(Guid playerId, Item item);
    Task<Item> DeleteItem(Guid playerId, Item item);

}
}
