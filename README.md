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
            // act
            // assert
            
            // return id;
        }

        protected override void Read(decimal id)
        {
            // act
            // assert
        }

        protected override void Update(decimal id)
        {
            // arrange
            // act
            // assert
        }

        protected override void Delete(decimal id)
        {
            // arrange
            // act
            // assert
        }
    }
}

```
