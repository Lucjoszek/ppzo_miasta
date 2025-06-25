using Miasta.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.OleDb;

namespace Miasta.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\User\Desktop\Studia\PPZO\Zadania\Miasta\miasta.mdb;";

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var wojewodztwa = new List<Wojewodztwo>();

            using OleDbConnection connection = new OleDbConnection(connectionString);
            string queryString = "SELECT * FROM Wojewodztwa";
            using OleDbCommand command = new OleDbCommand(queryString, connection);
            connection.Open();
            using OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                wojewodztwa.Add(new Wojewodztwo
                {
                    ID = Convert.ToInt32(reader["ID"]),
                    Nazwa = Convert.ToString(reader["Wojewodztwo"])
                });
            }

            return View(wojewodztwa);
        }

        [HttpGet]
        public JsonResult GetMiasta(int wojId)
        {
            var miasta = new List<Miasto>();

            using OleDbConnection connection = new OleDbConnection(connectionString);
            string queryString = $"SELECT ID, Miasto, ID_woj FROM Miasta WHERE ID_woj = {wojId}";
            using OleDbCommand command = new OleDbCommand(queryString, connection);
            connection.Open();
            using OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                miasta.Add(new Miasto
                {
                    ID = Convert.ToInt32(reader["ID"]),
                    Nazwa = Convert.ToString(reader["Miasto"]),
                    ID_Woj = Convert.ToInt32(reader["ID_woj"])
                });
            }
            
            return Json(miasta);
        }

        [HttpGet]
        public JsonResult GetWspolrzedne(int miastoId)
        {
            Miasto miasto = null;

            using OleDbConnection connection = new OleDbConnection(connectionString);
            string queryString = $"SELECT ID, Miasto, Dl, Szer FROM Miasta WHERE ID = {miastoId}";
            using OleDbCommand command = new OleDbCommand(queryString, connection);
            connection.Open();
            using OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                miasto = new Miasto
                {
                    ID = Convert.ToInt32(reader["ID"]),
                    Nazwa = Convert.ToString(reader["Miasto"]),
                    Dl = Convert.ToString(reader["Dl"]),
                    Szer = Convert.ToString(reader["Szer"])
                };
            }
            
            return Json(miasto);
        }
    }
}