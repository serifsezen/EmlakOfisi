using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Repository<T> : IRepository<T> where T:class
    {
        Context c = new Context();
        DbSet<T> _object;

        public Repository()
        {
            _object = c.Set<T>();
        }

        public int Delete(T p)
        {

            _object.Remove(p);
            return c.SaveChanges();
        }

        public T Find(System.Linq.Expressions.Expression<Func<T, bool>> Filter)
        {
            return _object.FirstOrDefault(Filter);
        }

        public T GetById(int id)
        {
            return _object.Find(id);
        }

        public int Insert(T p)
        {

            _object.Add(p);
            return c.SaveChanges();
        }

        public List<T> List()
        {
            return _object.ToList();
        }

        public List<T> List(System.Linq.Expressions.Expression<Func<T, bool>> Filter)
        {
            return _object.Where(Filter).ToList();
        }

        public int Update(T p)
        {
            return c.SaveChanges();
        }
    }
}
