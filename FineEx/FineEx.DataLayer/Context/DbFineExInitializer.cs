using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using FineEx.DataLayer.Models;

namespace FineEx.DataLayer.Context
{
    public class DbFineExInitializer : CreateDatabaseIfNotExists<DbFineEx>
    {
        protected override void Seed(DbFineEx context)
        {
            IList<User> users = new List<User>();

            users.Add(new User() {  Email= "test@test.hr", Password = "Test" }); ;

            context.Users.AddRange(users);
            base.Seed(context);
        }
    }
}
