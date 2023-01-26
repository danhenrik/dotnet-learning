using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Dapper;


namespace DotNETAPI.controllers.VarController
{
    [ApiController]
    [Route("v1")]
    public class VarController : ControllerBase
    {
        // GET /var/5
        [HttpGet]
        [Route("var/{qtt}")]
        public async Task<IActionResult> Get([FromRoute] int qtt)
        {
            var DB_Server = Environment.GetEnvironmentVariable("DB_SERVER");
            var DB_User = Environment.GetEnvironmentVariable("DB_USER");
            var DB_Password = Environment.GetEnvironmentVariable("DB_PWD");
            var DB_Database = Environment.GetEnvironmentVariable("DB_DB");
            
            dynamic result;
            using (var conn = new MySqlConnection($"Server={DB_Server};Database={DB_Database};Uid={DB_User};Pwd={DB_Password};"))
            {   
                var sql = $"CALL getTopJogadores({qtt});";
                result = conn.Query(sql).ToList();
            };
            
            return Ok(result);
        }
    }
}
