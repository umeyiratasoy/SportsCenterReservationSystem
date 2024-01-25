using Core.Entities;

namespace Entities.Concrete
{
    public class District : IEntity
    {
        public int Id { get; set; }
        public int CityId { get; set; }
        public string DistrictName { get; set; }
    }
}
