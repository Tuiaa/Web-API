using MongoDB.Driver;
using Students.DataModel.Models;
using Students.DataModel.GenericRepository;
using System.Configuration;

namespace Students.DataModel.UnitOfWork
{
    public class UnitOfWork
    {
        private MongoDatabase _database;
        protected Repository<Student> _students;

        public UnitOfWork()
        {
            var connectionString = ConfigurationManager.AppSettings["MongoDBConnectionString"];
            var client = new MongoClient(connectionString);
            var server = client.GetServer();
            var databaseName = ConfigurationManager.AppSettings["MongoDBDatabaseName"];
            _database = server.GetDatabase(databaseName);
        }

        public Repository<Student> Students
        {
            get
            {
                if (_students == null)
                    _students = new Repository<Student>(_database, "students");

                return _students;
            }
        }
    }
}
