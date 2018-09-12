using SavoryFavorite.Controllers.Request;
using SavoryFavorite.Repository.Entity;
using SavoryFavorite.Vo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SavoryFavorite.Convertor
{
    public interface IFavoriteConvertor
    {
        /// <summary>
        /// entity 转换为 vo
        /// </summary>
        FavoriteVo toLessVo(FavoriteEntity entity);

        /// <summary>
        /// entityList 转换为 voList
        /// </summary>
        List<FavoriteVo> toLessVoList(List<FavoriteEntity> entityList);
    }
}
