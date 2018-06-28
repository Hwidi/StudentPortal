using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repositories.Models;

namespace Repositories.Tests
{
    [TestClass]
    public class StudentsRepositoryTests
    {
        private WorkUnit _unit = null;

        [TestInitialize]
        public void SetupTest()
        {
            var connString = System.Configuration.ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;
            _unit = new WorkUnit(connString);
        }

        [TestMethod]
        public void GetAllStudents_Success()
        {
            var students = _unit.StudentsRepository.GetAll().ToList();
            Assert.IsTrue(students.Any());
        }
    }
}
