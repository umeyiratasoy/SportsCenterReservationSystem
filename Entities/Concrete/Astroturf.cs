using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Astroturf : IEntity
    {
        public int Id { get; set; }
        public int TypeId { get; set; }
        public int CityId { get; set; }
        public int DistrictId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string About { get; set; }
        public int BusinessContactNumber { get; set; }
        public int MobileContactNumber { get; set; }
        public int Price { get; set; }
    }
}
