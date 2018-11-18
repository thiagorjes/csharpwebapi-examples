using System;
using System.Collections.Generic;
using System.Linq;
using sistema.Models;
using Sistema.Interfaces;
namespace Sistema.Services
{
    internal class PessoaFisicaRepository : IGenericRepository
    {
        private SistemaContext context;
        private List<PessoaFisica> _all;
        public PessoaFisicaRepository(SistemaContext ctx)
        {
            InitializeData(ctx);
        }
        private void InitializeData(SistemaContext ctx)
        {
            context = ctx;
            _all = context.PessoaFisica.ToList();
        }
        IEnumerable<object> IGenericRepository.All
        {
            get
            {
                return _all;
            }
        }
        public object Create(object p){
            try
            {
                PessoaFisica r = (context.PessoaFisica.Add((PessoaFisica)p)).Entity;
                context.SaveChanges();
                return r;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public object Read(int IdPessoaFisica){
            try
            {
                PessoaFisica r = (from p in context.PessoaFisica where p.IdPessoaFisica==IdPessoaFisica select p).FirstOrDefault<PessoaFisica>();
                return r;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public object Update(int IdPessoaFisica,object newObject ){
            try
            {
                PessoaFisica r = (from p in context.PessoaFisica where p.IdPessoaFisica==IdPessoaFisica select p).FirstOrDefault<PessoaFisica>();
                foreach(var att in ((PessoaFisica) newObject).GetType().GetProperties()){
                if(!att.Name.Equals("IdPessoaFisica"))r.GetType().GetProperty(att.Name).SetValue(r,att.GetValue(newObject));
                }
                context.Entry(r).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return r;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public string Delete(int IdPessoaFisica){
            try
            {
                var r = (from p in context.PessoaFisica where p.IdPessoaFisica==IdPessoaFisica select p).FirstOrDefault<PessoaFisica>();
                context.PessoaFisica.Remove(r);
                context.SaveChanges();
                return "PessoaFisica removido com sucesso!";
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "Falha ao remover PessoaFisica!";
            }
        }
        public List<object> ReadManyByParam(DateTime Nascimento){
            try
            {
                List<object> r = (from p in context.PessoaFisica where p.Nascimento==Nascimento select p).ToList<object>();
                return r;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public List<object> PessoaFisicaAll(){
        return _all.ToList<object>();
        }
    }
}