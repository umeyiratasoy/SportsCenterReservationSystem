using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entities.Dtos
{
    public class AstroturfListDto : IDto
    {
        public int TypeId { get; set; }
        public int CityId { get; set; }
        public int DistrictId { get; set; }
        public string TypeName { get; set; }
        public string CityName { get; set; }
        public string DistrictName { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string About { get; set; }
        public int BusinessContactNumber { get; set; }
        public int MobileContactNumber { get; set; }
        public int Price { get; set; }
    }
}
