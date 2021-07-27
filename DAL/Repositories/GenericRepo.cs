using DAL.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        private readonly AppDbContext _context = null;
        private readonly DbSet<T> _table = null;
        public GenericRepo(AppDbContext context)
        {
            _context = context;
            _table = _context.Set<T>();
        }
        
        public IEnumerable<T> GetAll()
        {
            var data =_table.ToList();
            return data;
        }

        public T GetById(object id)
        {
            var data = _table.Find(id);
            return data;
        }

        public T Insert(T obj)
        {
            try
            {
                if(obj == null)
                {
                    throw new ArgumentNullException(nameof(obj));
                }
                T createdObj = _table.Add(obj).Entity;
                _context.SaveChanges();
                return createdObj;
            }
            catch(Exception exception)
            {
                throw new Exception("ERROR: DAL - Insert()", exception);
            }
        }

        public void Update(T obj)
        {
            _table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }

        public void Delete(object id)
        {
            T existing = _table.Find(id);
            if(existing != null)
            {
                _table.Remove(existing);
            }
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
