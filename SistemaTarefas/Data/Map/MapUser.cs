using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaTarefas.Models;

namespace SistemaTarefas.Data.Map;

public class MapUser : IEntityTypeConfiguration<UserModel>
{
    public void Configure(EntityTypeBuilder<UserModel> builder)
    {
        builder.HasKey(x => x.Id); ;
        builder.Property(x => x.Name).IsRequired().HasMaxLength(255);
        builder.Property(x => x.Email).IsRequired().HasMaxLength(255);

    }
}
