namespace ChirperLive.ModelConfigurations
{
    using Models;
    using System.Data.Entity.ModelConfiguration;

    public class ChirpConfiguration : EntityTypeConfiguration<Chirp>
    {
        public ChirpConfiguration()
        {
            this.Property(c => c.Id).HasColumnName("Key");


            this.Property(c => c.Content)
                .HasMaxLength(130)
                .IsRequired();
        }
    }
}
