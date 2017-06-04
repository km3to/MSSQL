
namespace ChirperLive.ModelConfigurations
{
    using Models;
    using System.Data.Entity.ModelConfiguration;


    public class ChImgConfiguration : EntityTypeConfiguration<ChImg>
    {
        public ChImgConfiguration()
        {
            this.HasKey(c => c.ChirpId)
                .HasRequired(c => c.Chirp)
                .WithRequiredDependent(c => c.Image);
        }
    }
}
