using Raven.Abstractions.Data;
using Raven.Client;
using Raven.Client.Document;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using tiny.review.core.DataModels;

namespace tiny.review.core.RavenDb
{
    public class DbManager
    {
        private readonly IDocumentStore docStore;

        public DbManager()
	    {
            docStore = new DocumentStore { Url = "http://localhost:8080" };
            docStore.Initialize(); 
	    }

        public object GetDocument<T>(string key)
        {
            using (var session = docStore.OpenSession())
            {
                return session.Load<T>(key);
            }
        }

        public T GetDocument<T>(Expression<Func<T, bool>> where = null)
        {
            using (var session = docStore.OpenSession())
            {
                return where == null ? session.Query<T>().FirstOrDefault() : session.Query<T>().Where(where).FirstOrDefault();
            }
        }
        public IEnumerable<T> GetDocuments<T>(Expression<Func<T, bool>> where = null)
        {
            using (var session = docStore.OpenSession())
            {
                return where == null ? session.Query<T>().ToList() : session.Query<T>().Where(where).ToList();
            }
        }

        public void AddDocument<T>(T document)
        {

            using (var session = docStore.OpenSession())
            {
                session.Store(document);
                session.SaveChanges();
            }
        }

        public bool Uppdate<T>(Expression<Func<T, bool>> where, IDbType entity)
        {
            using (var session = docStore.OpenSession())
            {
                var existing = where == null ? session.Query<T>().FirstOrDefault() : session.Query<T>().Where(where).FirstOrDefault();
                if (existing == null || entity == null)
                    return false;

                ((IDbType)existing).Update(entity);
                session.SaveChanges();
                return true;
            }
        }

        public void DeleteEverything()
        {
            docStore.DatabaseCommands.DeleteByIndex("Auto/AllDocs", new IndexQuery());
        }

        public void DeleteAllOfType<T>()
        {
            using (var session = docStore.OpenSession())
            {
                var docs = session.Query<T>().Customize(x => x.WaitForNonStaleResults());
                foreach (var doc in docs)
                    session.Delete(doc);

                session.SaveChanges();
            } 
        }

        public int Count<T>()
        {
            using (var session = docStore.OpenSession())
            {
                RavenQueryStatistics queryStatistics;
                session.Query<T>().Statistics(out queryStatistics).Take(0).ToList();
                return queryStatistics.TotalResults;
            }
        }

        //public static List<T> GetAll<T>(this List<T> list, Func<T, bool> where)
        //{
        //    return list.Where(where).ToList();
        //}
    }
}
