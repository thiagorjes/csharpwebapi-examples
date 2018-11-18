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
    public class EntidadeAutenticadoraController : Controller
    {
        EntidadeAutenticadoraRepository repositorio;
        public EntidadeAutenticadoraController(){
            repositorio = new EntidadeAutenticadoraRepository(new SistemaContext());
        }
        [HttpPost]
        public IActionResult Create([FromBody]EntidadeAutenticadora t){
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
        [HttpGet("{IdEntidadeAutenticadora}")]
        public IActionResult Read(int IdEntidadeAutenticadora){
            try {
                return this.Ok(repositorio.Read(IdEntidadeAutenticadora));
            }
            catch (Exception ex){
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        [HttpPut("{IdEntidadeAutenticadora}")]
        public IActionResult Update(int IdEntidadeAutenticadora,[FromBody]EntidadeAutenticadora newObject){
            try {
                var c = repositorio.Update(IdEntidadeAutenticadora, newObject );
                return this.Ok(c);
            }
            catch (Exception ex){
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
        }
        [HttpDelete("{IdEntidadeAutenticadora}")]
        public IActionResult Delete(int IdEntidadeAutenticadora){
            try {
                //Console.WriteLine("ok " + IdEntidadeAutenticadora);
                repositorio.Delete(IdEntidadeAutenticadora);
                return this.Ok("EntidadeAutenticadora " + IdEntidadeAutenticadora + " deletado.");
            }
            catch (Exception ex){
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
        }
        [HttpGet]
        public IEnumerable<object> EntidadeAutenticadoraAll(){
            return repositorio.EntidadeAutenticadoraAll();
        }
    }
}