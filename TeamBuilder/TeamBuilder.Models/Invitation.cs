namespace TeamBuilder.Models
{
    using System;

    public class Invitation
    {
        public int Id { get; set; }

        public int InvitedUserId { get; set; }

        public virtual User InvitedUser { get; set; }

        public int TeamId { get; set; }

        public Team Team { get; set; }

        public bool IsActive { get; set; }
    }
}
