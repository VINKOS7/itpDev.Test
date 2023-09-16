using Microsoft.EntityFrameworkCore;

using MediatR;
using Dotseed.Context;

using ITPDev.Test.Domain.Aggregates.ProjectAggregate;
using ITPDev.Test.Infrastructure.EntityConfs;

namespace ITPDev.Test.Infrastructure;

public class Context : UnitOfWorkContext
{
    public DbSet<Project> Projects { get; set; }

    public Context(DbContextOptions options, IMediator mediator) : base(options, mediator) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new ProjectEntityConfiguration());
    }
}
