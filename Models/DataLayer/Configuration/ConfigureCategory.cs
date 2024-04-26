using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace AmazonFresh.Models
{
    internal class ConfigureCategory : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> entity)
        {
            // seed initial data
            entity.HasData(
                new Category { CategoryID = 1, Name = "Fruits" },
                new Category { CategoryID = 2, Name = "Vegetables" },
                new Category { CategoryID = 3, Name = "Sweets" }
            );
        }
    }
}
