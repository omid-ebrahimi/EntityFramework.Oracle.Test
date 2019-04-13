# EntityFramework.Oracle.Test
This library exposes a base class to simplify unit testing on EntityFramework models.
## Installation
`PM> Install-Package Database.EntityFramework.Oracle.Test -Version x.x.x`
## Usage
```c#
using DataBase.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntityFramework.Oracle.Test;

namespace Db.Test.Repositories
{
    [TestClass]
    public class UsersTests : RepositoryTestsBase<MyDbContext>
    {
        protected override decimal Create()
        {
            // arrange
            var user = new User
            {
                Username = "ebrahimi"
            };

            // act
            Db.Users.Add(user);
            Db.SaveChanges();

            // assert
            Assert.IsTrue(user.Id > 0);

            return user.Id;
        }

        protected override void Read(decimal id)
        {
            // act
            // Use Include("...") to include dependencies
            var user = Db.Users.FirstOrDefault(c => c.Id == id); 

            // assert
            Assert.IsNotNull(user);
        }

        protected override void Update(decimal id)
        {
            // arrange
            const bool username = "updated ebrahimi";
            var user = Db.Users.First(c => c.Id == id);

            // act
            user.Username = username;
            Db.SaveChanges();

            var updatedUser = Db.Users.First(c => c.Id == user.Id);

            // assert
            Assert.AreEqual(username, updatedUser.Username);
        }

        // Remove all created entities
        protected override void Delete(decimal id)
        {
            // arrange
            var user = Db.Users.First(c => c.Id == id);

            // act
            Db.Users.Remove(user);
            Db.SaveChanges();

            var removedUser = Db.Users.FirstOrDefault(c => c.Id == user.Id);

            // assert
            Assert.IsNull(removedUser);
        }
    }
}

```
