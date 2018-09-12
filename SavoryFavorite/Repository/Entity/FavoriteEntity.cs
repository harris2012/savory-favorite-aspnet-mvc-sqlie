using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SavoryFavorite.Repository.Entity
{
    public class FavoriteEntity
    {

        public int Id { get; set; }

        public string Host { get; set; }

        public string Title { get; set; }

        public int CategoryId { get; set; }
    }
}
