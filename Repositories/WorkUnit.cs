using Repositories.Interfaces;
using Repositories.Models;
using System;

namespace Repositories
{
    public class WorkUnit : IDisposable
    {
        private DataContext _db = null;

        public WorkUnit(string connectionString)
        {
            _db = new DataContext(connectionString);
        }
        
        private IRepository<Student> _studentsRepository = null;
        
        public IRepository<Student> StudentsRepository
        {
            get
            {
                if (_studentsRepository == null)
                {
                    _studentsRepository = new StudentsRepository(_db);
                }
                return _studentsRepository;
            }
        }

        public void SaveChanges()
        {
            _db.SaveChanges();
        }

        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
