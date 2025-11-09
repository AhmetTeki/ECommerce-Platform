using Microsoft.EntityFrameworkCore;
using MultiShop.Comment.Entities;

namespace MultiShop.Comment.Context;

public class CommentContex: DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost,1437;Database=MultiShopCommentDb;User=sa;Password=Ahmet0234.;");
    }

    public DbSet<UserComment> UserComments { get; set; }
}