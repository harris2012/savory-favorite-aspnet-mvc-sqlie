using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Web.Http;

using SavoryFavorite.Controllers.Request;
using SavoryFavorite.Controllers.Response;
using SavoryFavorite.Convertor;
using SavoryFavorite.Repository;
using SavoryFavorite.Repository.Entity;

namespace SavoryFavorite.Controllers
{
    [RoutePrefix("api/favorite")]
    public class FavoriteController : BaseController
    {
        private IFavoriteRepository favoriteRepository;

        private IFavoriteConvertor favoriteConvertor;

        public FavoriteController(
            IFavoriteRepository favoriteRepository,
            IFavoriteConvertor favoriteConvertor)
        {
            this.favoriteRepository = favoriteRepository;
            this.favoriteConvertor = favoriteConvertor;
        }

        [HttpPost]
        [Route("items")]
        public FavoriteItemsResponse Items([FromBody]FavoriteItemsRequest request)
        {
            FavoriteItemsResponse response = new FavoriteItemsResponse();

            List<FavoriteEntity> entityList = favoriteRepository.GetEntityList();

            response.Items = favoriteConvertor.toLessVoList(entityList);

            response.Status = 1;
            return response;
        }
    }
}
