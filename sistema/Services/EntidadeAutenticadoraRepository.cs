using System;
using System.Collections.Generic;
using System.Linq;
using sistema.Models;
using Sistema.Interfaces;
namespace Sistema.Services
{
    internal class EntidadeAutenticadoraRepository : IGenericRepository
    {
        private SistemaContext context;
        private List<EntidadeAutenticadora> _all;
        public EntidadeAutenticadoraRepository(SistemaContext ctx)
        {
            InitializeData(ctx);
        }
        private void InitializeData(SistemaContext ctx)
        {
            context = ctx;
            _all = context.EntidadeAutenticadora.ToList();
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
                EntidadeAutenticadora r = (context.EntidadeAutenticadora.Add((EntidadeAutenticadora)p)).Entity;
                context.SaveChanges();
                return r;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public object Read(int IdEntidadeAutenticadora){
            try
            {
                EntidadeAutenticadora r = (from p in context.EntidadeAutenticadora where p.IdEntidadeAutenticadora==IdEntidadeAutenticadora select p).FirstOrDefault<EntidadeAutenticadora>();
                return r;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public object Update(int IdEntidadeAutenticadora,object newObject ){
            try
            {
                EntidadeAutenticadora r = (from p in context.EntidadeAutenticadora where p.IdEntidadeAutenticadora==IdEntidadeAutenticadora select p).FirstOrDefault<EntidadeAutenticadora>();
                foreach(var att in ((EntidadeAutenticadora) newObject).GetType().GetProperties()){
                if(!att.Name.Equals("IdEntidadeAutenticadora"))r.GetType().GetProperty(att.Name).SetValue(r,att.GetValue(newObject));
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
        public string Delete(int IdEntidadeAutenticadora){
            try
            {
                var r = (from p in context.EntidadeAutenticadora where p.IdEntidadeAutenticadora==IdEntidadeAutenticadora select p).FirstOrDefault<EntidadeAutenticadora>();
                context.EntidadeAutenticadora.Remove(r);
                context.SaveChanges();
                return "EntidadeAutenticadora removido com sucesso!";
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "Falha ao remover EntidadeAutenticadora!";
            }
        }
        /*public List<object> ReadManyByParam(paramType paramName){
            try
            {
                List<object> r = (from p in context.EntidadeAutenticadora where p.paramName==paramName select p).ToList<object>();
                return r;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }*/
        public List<object> EntidadeAutenticadoraAll(){
        return _all.ToList<object>();
        }
    }
}