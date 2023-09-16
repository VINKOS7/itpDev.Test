using Microsoft.EntityFrameworkCore;

using ITPDev.Test.Domain.Aggregates.ProjectAggregate;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ITPDev.Test.Infrastructure.EntityConfs;

public class ProjectEntityConfiguration : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> builder)
    {
        builder
            .OwnsMany(p => p.Assignments)
            .OwnsOne(ass => ass.Comment);
    }
}
