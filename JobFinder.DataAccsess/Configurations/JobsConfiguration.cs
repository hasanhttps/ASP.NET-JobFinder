using Microsoft.EntityFrameworkCore;
using JobFinder.Domain.Entities.Concretes;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class JobsConfiguration : IEntityTypeConfiguration<Jobs>{
    public void Configure(EntityTypeBuilder<Jobs> builder) {
        
    }
}
