﻿using FriendOrganizer.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FriendOrganizer.UI.Data
{
    public interface IFriendDataService
    {
        Task<Friend> GetFriendbyIdAsync(int friendId);
        Task SaveAsync(Friend friend);
    }
}