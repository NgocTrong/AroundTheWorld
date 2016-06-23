using System.Collections.Generic;
using System.Linq;
using Models.EF;

namespace Models.Dao
{
    public class BlogDao
    {
        private TravelDbContext db;
        public BlogDao()
        {
             db = new TravelDbContext();
        }

        public List<Blog> TopBlogs()
        {
            return db.Blogs.Take(5).ToList();
        }


    }
}
