using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Dapper;

using SavoryFavorite.Repository.Entity;

namespace SavoryFavorite.Repository.Sqlite
{
    public class SqliteFavoriteRepository : IFavoriteRepository
    {

        private SqliteConnectionProvider connectionProvider;

        public SqliteFavoriteRepository(SqliteConnectionProvider connectionProvider)
        {
            this.connectionProvider = connectionProvider;
        }

        public void Create(FavoriteEntity entity)
        {
            string sql = "insert into favorite(host, title, category_id) values (@Host, @Title, @CategoryId);";

            using (var sqliteConn = connectionProvider.GetConnection())
            {
                sqliteConn.Execute(sql, new { Host = entity.Host, Title = entity.Title, CategoryId = entity.CategoryId });
            }
        }

        public FavoriteEntity GetById(long id)
        {
            string sql = "select id as Id, host as Host, title as Title, category_id as CategoryId from favorite where Id = ?";

            using (var sqliteConn = connectionProvider.GetConnection())
            {
                return sqliteConn.QueryFirstOrDefault<FavoriteEntity>(sql, new { Id = id });
            }
        }

        public int GetCount()
        {
            string sql = "select count(1) from favorite";

            using (var sqliteConn = connectionProvider.GetConnection())
            {
                return sqliteConn.QuerySingle<int>(sql);
            }
        }

        public List<FavoriteEntity> GetEntityList()
        {
            string sql = "select id as Id, host as Host, title as Title, category_id as CategoryId from favorite";

            using (var sqliteConn = connectionProvider.GetConnection())
            {
                return sqliteConn.Query<FavoriteEntity>(sql).ToList();
            }
        }

        public List<FavoriteEntity> GetEntityList(int pageIndex, int pageSize)
        {
            string sql = "select id as Id, host as Host, title as Title, category_id as CategoryId from favorite limit @Start, @Count";

            using (var sqliteConn = connectionProvider.GetConnection())
            {
                return sqliteConn.Query<FavoriteEntity>(sql, new { Start = (pageIndex - 1) * pageSize, Count = pageSize }).ToList();
            }
        }

        public void Update(FavoriteEntity entity)
        {
            string sql = "update favorite set host = @Host, title = @Title, category_id = @CategoryId where id = @Id;";

            using (var sqliteConn = connectionProvider.GetConnection())
            {
                sqliteConn.Execute(sql, new { Id = entity.Id, Host = entity.Host, Title = entity.Title, CategoryId = entity.CategoryId });
            }
        }
    }
}
