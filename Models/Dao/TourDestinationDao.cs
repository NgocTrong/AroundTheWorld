using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.EF;
using System.Data.SqlClient;
using Models.ViewModel;
using System.Text.RegularExpressions;
namespace Models.Dao
{
    public class TourDestinationDao
    {
        TravelDbContext db = null;
        public TourDestinationDao()
        {
            db = new TravelDbContext();
        }

        //list all 
        public List<TouristDestination> ListAll()
        {
            return db.TouristDestinations.Where(m => m.Status == true).OrderBy(m => m.DisplayOrder).ToList();
        }

        //Add Tour Destination
        public long Insert(TouristDestination td)
        {
            db.TouristDestinations.Add(td);
            db.SaveChanges();
            return td.TouristDestinationId;
        }

        // Delete Tour 

        public bool Delete(long id)
        {
            try
            {
                var td = db.TouristDestinations.Find(id);
                db.TouristDestinations.Remove(td);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        
        public List<TourViewModel> ViewByProvince(int id)
        {

            
            
            var data = (from a in db.Tours
                        join b in db.TouristDestinations on a.TouristDestinationId equals b.TouristDestinationId
                        join c in db.Provinces on b.ProvinceId equals c.ProvinceId
                        where c.ProvinceId == id
                        select new TourViewModel()
                        {
                            TourId = a.TourId,
                            TourName = a.TourName,
                            Image = a.Image,
                            DepartureTime = a.DepartureTime,
                            TourTime = a.TourTime,
                            StartingPoint = a.StartingPoint,
                            ArrivalPoint = a.ArrivalPoint,
                            Transport = a.Transport,
                            Price = a.Price,
                            TimeTable = a.TimeTable,
                            TouristDestinationName = b.TouristDestinationName,
                            TDAvartar = b.TDAvartar

                        });
            var model = data.ToList();
            return model;
        }


       


       
      
    }
}
