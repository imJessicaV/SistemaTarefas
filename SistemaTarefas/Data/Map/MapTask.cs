using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaTarefas.Enums;
using SistemaTarefas.Models;

namespace SistemaTarefas.Data.Map;

public class MapTask : IEntityTypeConfiguration<TaskModel>
{
    public void Configure(EntityTypeBuilder<TaskModel> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).IsRequired().HasMaxLength(255);
        builder.Property(x => x.Description).HasMaxLength(500);
        builder.Property(x => x.Status).IsRequired();
        builder.Property(x => x.UserId);

        builder.HasOne(x => x.User);
    }
}
