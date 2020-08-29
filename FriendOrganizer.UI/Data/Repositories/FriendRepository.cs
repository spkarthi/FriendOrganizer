using FriendOrganizer.DataAccess;
using FriendOrganizer.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace FriendOrganizer.UI.Data.Repositories
{
    public class FriendRepository : IFriendRepository
    {
        private FriendOrganizerDbContext _context;

        public FriendRepository(FriendOrganizerDbContext context)
        {
            _context = context;
        }

        public void Add(Friend friend)
        {
            _context.Friends.Add(friend);

        }

        public async Task<Friend> GetFriendbyIdAsync(int friendId)
        {
            //TODO: later get the data from the database using Entity Framework
            return await _context.Friends.SingleAsync(f=>f.Id == friendId);
        }

        public bool HasChanges()
        {
            return _context.ChangeTracker.HasChanges();
        }

        public void Remove(Friend model)
        {
            _context.Friends.Remove(model);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}