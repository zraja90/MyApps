using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ToolDepot.Core.Domain.Products;
using ToolDepot.Data;

namespace ToolDepot.Models
{
    public class UsersContext : DbContext, IDbContext
    {
        public UsersContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<UnderConstructionModel> UnderConstruction { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategory { get; set; }
        public DbSet<ProductDescription> ProductDescription { get; set; }

        IDbSet<TEntity> IDbContext.Set<TEntity>()
        {
            return base.Set<TEntity>();
        }

        public IEnumerable<TEntity> SqlQuery<TEntity>(string sql, params object[] parameters) where TEntity : class
        {
            return base.Database.SqlQuery<TEntity>(sql, parameters);
        }

        public IEnumerable<TEntity> SqlQuery<TEntity>(SqlWrap spWrap) where TEntity : class
        {
            return SqlQuery<TEntity>(spWrap.Sql, spWrap.Parameters.Cast<object>().ToArray());
        }
    }
}