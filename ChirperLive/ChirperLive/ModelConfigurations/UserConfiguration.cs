namespace ChirperLive.ModelConfigurations
{
    using Models;
    using System.Data.Entity.ModelConfiguration;

    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            this.ToTable("People");

            this.Ignore(u => u.CurrentSessionId);

            this.HasKey(u => u.Key);

            this.Property(u => u.Alias)
                .IsUnicode(false)
                .IsRequired()
                .HasMaxLength(50);

            this.HasMany(u => u.FriendRequestsMade)
                .WithMany(u => u.FriendRequestAccepted)
                .Map(m =>
                {
                    m.ToTable("UserFriends");
                    m.MapLeftKey("RequestedUserId");
                    m.MapRightKey("AcceptedUserId");
                });
        }
    }
}
