using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Gym_Tec_Cliente.Models;
using System.Net.Http;
using Newtonsoft.Json.Linq;





namespace Gym_Tec_Cliente.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly HttpClient _client;
        Server server = new Server();

        public LoginController()
        {  _client = new HttpClient();
        }
        [HttpPost]
        public async Task<IActionResult> LoginCliente(LoginInfo info)
        {


            if (info == null || string.IsNullOrWhiteSpace(info.User) || string.IsNullOrWhiteSpace(info.Pass))
                return Ok(false);


            string currentUser = null;

           
            var response = await _client.GetAsync($"{server.initServer()}/{server.initDataBase()}/{info.User}");
            currentUser = await response.Content.ReadAsStringAsync();
            if (currentUser == null)
                return Ok(false);

            var data = JObject.Parse(currentUser);
            string user;
            user = data["correo"].ToString();
            var pass = data["pass"].ToString();

            if (!info.User.ToLower().Equals(user.ToLower()))
                return Ok(false);

            if (!MD5Encoding.Matches(info.Pass, pass))
                return Ok(false);


            return Ok(true);
        }
    }
}
