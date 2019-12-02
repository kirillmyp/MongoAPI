using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MongoAPI.Configs;
using MongoConsole.Models;
using MongoDB.Driver;
using System.Collections.Generic;

namespace MongoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        public readonly BookstoreDatabaseSettings bookstoreDatabaseSettings;
        public BookController(IOptionsMonitor<Appsetting> _Appsetting)
        {
            bookstoreDatabaseSettings = _Appsetting?.CurrentValue?.BookstoreDatabaseSettings;
        }

        [HttpGet("Get")]
        public IList<Book> Get()
        {
            var client = new MongoClient(bookstoreDatabaseSettings.ConnectionString);
            var database = client.GetDatabase(bookstoreDatabaseSettings.DatabaseName);


            var _books = database.GetCollection<Book>(bookstoreDatabaseSettings.BooksCollectionName);
            return _books.Find(book => true).ToList();
        }
    }
}
