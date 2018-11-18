using System;
using System.Collections.Generic;
using System.Linq;
using sistema.Models;
using Sistema.Interfaces;
namespace Sistema.Services
{
    internal class AccessTokenRepository : IGenericRepository
    {
        private SistemaContext context;
        private List<AccessToken> _all;
        public AccessTokenRepository(SistemaContext ctx)
        {
            InitializeData(ctx);
        }
        private void InitializeData(SistemaContext ctx)
        {
            context = ctx;
            _all = context.AccessToken.ToList();
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
                AccessToken r = (context.AccessToken.Add((AccessToken)p)).Entity;
                context.SaveChanges();
                return r;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public object Read(int IdAccessToken){
            try
            {
                AccessToken r = (from p in context.AccessToken where p.IdAccessToken==IdAccessToken select p).FirstOrDefault<AccessToken>();
                return r;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public object Update(int IdAccessToken,object newObject ){
            try
            {
                AccessToken r = (from p in context.AccessToken where p.IdAccessToken==IdAccessToken select p).FirstOrDefault<AccessToken>();
                foreach(var att in ((AccessToken) newObject).GetType().GetProperties()){
                if(!att.Name.Equals("IdAccessToken"))r.GetType().GetProperty(att.Name).SetValue(r,att.GetValue(newObject));
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
        public string Delete(int IdAccessToken){
            try
            {
                var r = (from p in context.AccessToken where p.IdAccessToken==IdAccessToken select p).FirstOrDefault<AccessToken>();
                context.AccessToken.Remove(r);
                context.SaveChanges();
                return "AccessToken removido com sucesso!";
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "Falha ao remover AccessToken!";
            }
        }
        public List<object> ReadManyByParam(int PessoaFisica){
            try
            {
                List<object> r = (from p in context.AccessToken where p.PessoaFisica==PessoaFisica select p).ToList<object>();
                return r;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public List<object> AccessTokenAll(){
        return _all.ToList<object>();
        }
    }
}