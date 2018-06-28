using Repositories.Interfaces;
using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Repositories
{
    public class StudentsRepository : IRepository<Student>
    {
        private DataContext _db = null;

        public StudentsRepository(DataContext db)
        {
            _db = db;
        }

        public void Add(Student entity)
        {
            _db.Students.Add(entity);
        }

        public void Edit(Student entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
        }

        public Student Get(Func<Student, bool> predicate)
        {
            return _db.Students.FirstOrDefault(predicate);
        }

        public IEnumerable<Student> GetAll(Func<Student, bool> predicate = null)
        {
            if (predicate != null)
            {
                if (predicate != null)
                {
                    return _db.Students.Where(predicate);
                }
            }

            return _db.Students;
        }
    }
}
