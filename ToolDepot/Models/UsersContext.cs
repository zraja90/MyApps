using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
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
        public IDbSet<TEntity> Set<TEntity>() where TEntity : class
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