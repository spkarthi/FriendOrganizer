using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FriendOrganizer.Model;

namespace FriendOrganizer.UI.Data
{
    public class FriendDataService : IFriendDataService
    {
        public IEnumerable<Friend> GetAll()
        {
            yield return new Friend { FirstName = "Karthik", LastName = "Swamy", Email = "kswamy@cquest.us" };
            yield return new Friend { FirstName = "Yasoda", LastName = "Swamy", Email = "yasoda@cquest.us" };
            yield return new Friend { FirstName = "Ajay", LastName = "Swamy", Email = "ajay@cquest.us" };
            yield return new Friend { FirstName = "Shashu", LastName = "Swamy", Email = "shashu@cquest.us" };
        }
    }
}
