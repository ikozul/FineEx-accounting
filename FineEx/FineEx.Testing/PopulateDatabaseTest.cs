using System;
using FineEx.BusinessLayer.Utils;
using FineEx.DataLayer.Context;
using FineEx.DataLayer.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FineEx.Testing
{
    [TestClass]
    public class PopulateDatabaseTest
    {
        [TestMethod]
        public void GivenData_WhenDataInsertedIntoDatabase_ThenHaveCountGreaterThanZero()
        {

        }

        [TestMethod]
        public void InsertRoles()
        {
            User user = new User();
            user.FirstName = "Test";
            user.LastName = "Test";
            user.Email = "test@test.com";
            user.Password = PasswordHelper.HashPassword("Test");
            user.RoleId = 100;
            user.IsActive = true;
            App.Db.Users.Add(user);
            App.Db.SaveChanges();
        }
    }
}
