namespace ChirperLive.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class User
    {
        public User()
        {
            this.Chirps = new HashSet<Chirp>();
            this.FriendRequestsMade = new HashSet<User>();
            this.FriendRequestAccepted = new HashSet<User>();
        }
        
        public int Key { get; set; }

        public string Alias { get; set; }

        public virtual ICollection<Chirp> Chirps { get; set; }

        public int CurrentSessionId { get; set; }

        public virtual ICollection<User> FriendRequestsMade { get; set; }

        public virtual ICollection<User> FriendRequestAccepted { get; set; }
    }
}
