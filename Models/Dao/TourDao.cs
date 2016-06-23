using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dao
{
    public class TourDao
    {
        private TravelDbContext db;
        public TourDao()
        {
            db = new TravelDbContext();
        }

        //detail
        public Tour Details(long? id)
        {
           var tour = db.Tours.Find(id);
           return tour;
        }

        //List Tourist Destination
        public List<TouristDestination> ListAll()
        {
            return db.TouristDestinations.Where(m => m.Status == true).ToList();
        }

        //Create Tour 
        public void Insert(Tour entity)
        {
            db.Tours.Add(entity);
            db.SaveChanges();
        }

        public void Delete(long id)
        {
            var tour = db.Tours.Find(id);
            db.Tours.Remove(tour);
            db.SaveChanges();
        }
    }
}
