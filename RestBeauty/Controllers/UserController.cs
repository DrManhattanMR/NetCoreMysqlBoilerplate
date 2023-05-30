using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BussinessLogic;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;

namespace RestBeauty.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // GET: api/User
        [HttpGet]
        public IActionResult Get()
        {
            List<User> userList = new();
            LogicaNegocio srv = new();
            userList = srv.GetUsers();
            if (userList.Count>0)
                return Ok(userList);
            return NotFound(new { message = "Items Not Found" });

        }

        // GET: api/User/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/User
        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            try
            {
                LogicaNegocio srv = new();
                bool result = srv.InsertUser(user);
                if (result)
                    return Ok(new { message = "Item Added" });
                return BadRequest(new { message = "Fail Added" });
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }

        // PUT: api/User/5
        [HttpPut]
        public IActionResult Put([FromBody] User user)
        {
            try
            {
                LogicaNegocio srv = new();
                bool result = srv.UpdateUser(user);
                if (result)
                    return Ok(new { message = "Item Updated" });
                return BadRequest(new { message = "Fail Updated" });
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }

        // DELETE: api/User/5
        [HttpDelete]
        public IActionResult Delete([FromQuery] int id)
        {
            try
            {
                LogicaNegocio srv = new();
                bool result = srv.DeleteUser(id);
                if (result)
                    return Ok(new { message = "Item Deleted" });
                return BadRequest(new { message = "Fail Delete" });
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }
    }
}
