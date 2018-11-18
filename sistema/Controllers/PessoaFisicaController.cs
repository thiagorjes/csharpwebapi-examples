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
    public class PessoaFisicaController : Controller
    {
        PessoaFisicaRepository repositorio;
        public PessoaFisicaController(){
            repositorio = new PessoaFisicaRepository(new SistemaContext());
        }
        [HttpPost]
        public IActionResult Create([FromBody]PessoaFisica t){
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
        [HttpGet("{IdPessoaFisica}")]
        public IActionResult Read(int IdPessoaFisica){
            try {
                return this.Ok(repositorio.Read(IdPessoaFisica));
            }
            catch (Exception ex){
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        [HttpPut("{IdPessoaFisica}")]
        public IActionResult Update(int IdPessoaFisica,[FromBody]PessoaFisica newObject){
            try {
                var c = repositorio.Update(IdPessoaFisica, newObject );
                return this.Ok(c);
            }
            catch (Exception ex){
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
        }
        [HttpDelete("{IdPessoaFisica}")]
        public IActionResult Delete(int IdPessoaFisica){
            try {
                //Console.WriteLine("ok " + IdPessoaFisica);
                repositorio.Delete(IdPessoaFisica);
                return this.Ok("PessoaFisica " + IdPessoaFisica + " deletado.");
            }
            catch (Exception ex){
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
        }
        [HttpGet]
        public IEnumerable<object> PessoaFisicaAll(){
            return repositorio.PessoaFisicaAll();
        }
    }
}