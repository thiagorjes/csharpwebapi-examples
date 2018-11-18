using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using sistema.Models;
using Sistema.Services;

namespace Sistema.Controllers
{
    [Route("Sistema/[controller]")]
    public class AccessTokenController : Controller
    {
        AccessTokenRepository repositorio;
        public AccessTokenController(){
            repositorio = new AccessTokenRepository(new SistemaContext());
        }
        [HttpPost]
        public IActionResult Create([FromBody]AccessToken t){
            try {
                var c = repositorio.Create(t);
                Console.WriteLine("ok ");
                return this.Ok(c);
            }
            catch (Exception){
                Console.WriteLine("erro");
                return BadRequest();
            }
        }
        [HttpGet("{IdAccessToken}")]
        public IActionResult Read(int IdAccessToken){
            try {
                return this.Ok(repositorio.Read(IdAccessToken));
            }
            catch (Exception ex){
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        [HttpPut("{IdAccessToken}")]
        public IActionResult Update(int IdAccessToken,[FromBody]AccessToken newObject){
            try {
                var c = repositorio.Update(IdAccessToken, newObject );
                return this.Ok(c);
            }
            catch (Exception ex){
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
        }
        [HttpDelete("{IdAccessToken}")]
        public IActionResult Delete(int IdAccessToken){
            try {
                //Console.WriteLine("ok " + IdAccessToken);
                repositorio.Delete(IdAccessToken);
                return this.Ok("AccessToken " + IdAccessToken + " deletado.");
            }
            catch (Exception ex){
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
        }
        [HttpGet]
        public IEnumerable<object> AccessTokenAll(){
            return repositorio.AccessTokenAll();
        }
    }
}