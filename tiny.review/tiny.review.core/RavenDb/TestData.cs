using System;
using tiny.review.core.DataModels;

namespace tiny.review.core.RavenDb
{
    public class TestData
    {
        public static void AddTestData(DbManager db)
        {
            for (var i = 0; i < 3; i++)
            {
                db.AddDocument(new User
                {
                    UserId = Convert.ToString(i),
                    UserName = "Username " + i,
                    EmailAdress = "email@example.com",
                });
            }
        }

    }
}
