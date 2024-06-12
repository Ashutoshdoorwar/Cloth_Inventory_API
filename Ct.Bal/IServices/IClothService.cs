using Ct.common.Entities;
using Ct.common.Models;
using Ct.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ct.Bal.InterfacesBal
{
    public interface IClothService
    {
        public List<ShowClothModel> GetAllCloth();
        void AddCloth(ClothModel clothModel);
        void DeleteCloth(int id);
        void UpdateCloth(ClothDto clothdto);

        public ShowClothModel GetClothById(int id);

    }
}
