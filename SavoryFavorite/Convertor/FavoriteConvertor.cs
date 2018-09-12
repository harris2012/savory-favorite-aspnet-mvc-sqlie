using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using SavoryFavorite.Controllers.Request;
using SavoryFavorite.Repository.Entity;
using SavoryFavorite.Vo;

namespace SavoryFavorite.Convertor
{
    public class FavoriteConvertor : IFavoriteConvertor
    {
        public FavoriteVo toLessVo(FavoriteEntity entity)
        {
            FavoriteVo vo = toVo(entity);

            return vo;
        }

        public List<FavoriteVo> toLessVoList(List<FavoriteEntity> entityList)
        {
            if (entityList == null || entityList.Count == 0)
            {
                return null;
            }

            List<FavoriteVo> voList = new List<FavoriteVo>();
            foreach (FavoriteEntity entity in entityList) {
                voList.Add(toLessVo(entity));
            }

            return voList;
        }

        /// <summary>
        /// 将entity转换为vo。不包括来自元数据的属性
        /// </summary>
        private FavoriteVo toVo(FavoriteEntity entity)
        {
            FavoriteVo vo = new FavoriteVo();

            vo.Id = entity.Id;
            vo.Host = entity.Host;
            vo.Title = entity.Title;

            return vo;
        }
    }
}
