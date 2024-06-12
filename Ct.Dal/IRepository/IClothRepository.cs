using Ct.common.Entities;
using Ct.common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ct.Dal.InterfacesDal
{
    public interface IClothRepository
    {
        void AddCloth(Cloth cloth, Stock newStock);
        void DeleteCloth(int id);
        void UpdateCloth(Cloth cloth,Stock stock);

        void UpdateClothFromStock(Cloth cloth);

        public List<Cloth> GetAllCloth();

        public Cloth GetClothById(int id);

        public bool IsClothExist(int clothid);

        public int GetCurrentId();
        public List<Cloth> GetClothByBrand(int id);

        public List<Cloth> GetClothByCatId(int id);

        public Cloth ClothExist(string clothname);
       




    }
}
