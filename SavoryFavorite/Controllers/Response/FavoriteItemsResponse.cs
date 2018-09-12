using SavoryFavorite.Vo;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SavoryFavorite.Controllers.Response
{
    public class FavoriteItemsResponse : BaseResponse
    {
        [JsonProperty("items")]
        public List<FavoriteVo> Items { get; set; }
    }
}
