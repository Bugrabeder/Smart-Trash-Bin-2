using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using Dapper;
using iotdustbin.Models;
using iotdustbin.Data;
using System.Linq;
using System.Net.Mail;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace iotdustbin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VerilerController : ControllerBase
    {
        private IDbConnection db;

        public VerilerController(IConfiguration configuration)
        {
            this.db = new SqlConnection(configuration.GetConnectionString("db"));
        }

        // GET: api/<VerilerController>
        [HttpGet]
        public IList<veriler> Get()
        {
            var sql = "SELECT * FROM verilers WHERE id=1";
            //var sql = "SELECT doluluk, sicaklik, atesdurumu, gazdurumu FROM verilers WHERE id=1";
            var pr = db.Query<veriler>(sql);
            return pr.ToList();
        }

        // POST api/<VerilerController>
        [Route("postfanhizli")]
        [HttpGet]
        public int postfan()
        {
            var sql = "UPDATE verilers SET fan=3 WHERE id=1";
            var r = db.Query(sql);
            return 3;
        }
        [Route("postfanorta")]
        [HttpGet]
        public int postfanorta()
        {
            var sql = "UPDATE verilers SET fan=2 WHERE id=1";
            var r = db.Query(sql);
            return 2;
        }

        [Route("postfanyavas")]
        [HttpGet]
        public int postfanyavas()
        {
            var sql = "UPDATE verilers SET fan=1 WHERE id=1";
            var r = db.Query(sql);
            return 1;
        }

        [Route("postfankapat")]
        [HttpGet]
        public int postfankapat()
        {
            var sql = "UPDATE verilers SET fan=0 WHERE id=1";
            var r = db.Query(sql);
            return 3;
        }

        [Route("buzzercalistir")]
        [HttpGet]
        public int buzzercalistir()
        {
            var sql = "UPDATE verilers SET buzzer=1 WHERE id=1";
            var r = db.Query(sql);
            return 4;
        }

        [Route("buzzerkapat")]
        [HttpGet]
        public int buzzerkapat()
        {
            var sql = "UPDATE verilers SET buzzer=0 WHERE id=1";
            var r = db.Query(sql);
            return 5;
        }

        [Route("kapakac")]
        [HttpGet]
        public int kapakac()
        {
            var sql = "UPDATE verilers SET kapakacma=1 WHERE id=1";
            var r = db.Query(sql);
            return 6;
        }

        [Route("kapakkapat")]
        [HttpGet]
        public int kapakkapat()
        {
            var sql = "UPDATE verilers SET kapakacma=0 WHERE id=1";
            var r = db.Query(sql);
            return 7;
        }

        [Route("mailgonder")]
        [HttpGet]
        public int mailgonder()
        {
            var sql = "SELECT doluluk, sicaklik, atesdurumu, gazdurumu FROM verilers WHERE id=1";
            var r = db.Query<veriler>(sql);
            IList<veriler> veriler = r.ToList();
            var sicaklik = veriler[0].sicaklik;
            var doluluk = veriler[0].doluluk;
            var atesdurumu = veriler[0].atesdurumu;
            var gazdurumu = veriler[0].gazdurumu;
            string veriler1 = ($"Doluluk oranı:{doluluk},Sıcaklık degeri:{sicaklik},sigara dumanı durumu:{gazdurumu},ateş durumu:{atesdurumu}");
            MailMessage message = new MailMessage();
            message.Subject= "Sensor Verileri";
            message.From = new MailAddress("admin@iotdustbin.com", "Buğra Beder");
            message.To.Add("admin@iotdustbin.com");
            message.Body =veriler1;
            message.IsBodyHtml = true;
            SmtpClient sc = new SmtpClient("mail.iotdustbin.com",587);
            sc.EnableSsl = false;
            sc.Credentials = new NetworkCredential("admin@iotdustbin.com", "Bugra159753123147");
            
            sc.Send(message);
            return 8;
        }

        [Route("verigonder")]
        [HttpGet]
        public int verigonder(string doluluk, string sıcaklık, string atesdurumu, string gazdurumu)
        {
            var sql = ($"UPDATE verilers SET doluluk={doluluk} sicaklik={sıcaklık} atesdurumu={atesdurumu} gazdurumu={gazdurumu}  WHERE id=1");
            var m = db.Query(sql);
            return 9;
        } 

    }
}
