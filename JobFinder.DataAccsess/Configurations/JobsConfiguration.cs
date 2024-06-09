using Microsoft.EntityFrameworkCore;
using JobFinder.Domain.Entities.Concretes;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class JobsConfiguration : IEntityTypeConfiguration<Jobs>{
    public void Configure(EntityTypeBuilder<Jobs> builder) {
        builder.HasOne(p => p.User).WithMany(p => p.Jobs).HasForeignKey(p => p.UserId);
        builder.HasOne(p => p.Category).WithMany(p => p.Jobs).HasForeignKey(p => p.CategoryId);
    }
}
