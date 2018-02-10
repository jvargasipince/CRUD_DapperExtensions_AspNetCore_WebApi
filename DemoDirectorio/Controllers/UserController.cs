using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Directorio.Entities;
using Directorio.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoDirectorio.Controllers
{
    [Produces("application/json")]
    [Route("api/User")]
    public class UserController : Controller
    {
        IUsuarioService _usuarioService;

        public UserController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public IEnumerable<Usuario> Get()
        {
            return _usuarioService.GetAll();
        }

        [HttpGet("{id}")]
        public Usuario Get(int id)
        {
            return _usuarioService.Get(id);
        }

        // POST api/user  
        [HttpPost]
        public void Post([FromBody] Usuario user)
        {
            _usuarioService.Add(user);
        }
        // PUT api/user
        [HttpPut]
        public void Update([FromBody] Usuario user)
        {
            _usuarioService.Update(user);
        }
        // DELETE api/user/5  
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _usuarioService.Delete(id);
        }
    }
}