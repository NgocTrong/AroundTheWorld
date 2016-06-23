using System.Collections.Generic;
using System.Linq;
using Models.EF;

namespace Models.Dao
{
    public class ProvinceDao
    {
        TravelDbContext db = null;

        public ProvinceDao()
        {
            db = new TravelDbContext();
        }

        public List<Province> ListAll()
        {
            return db.Provinces.ToList(); 
        }
    }
}
