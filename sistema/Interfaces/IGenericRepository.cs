using System.Collections.Generic;
namespace Sistema.Interfaces
{
    public interface IGenericRepository
    {
        IEnumerable<object> All { get; }
        object Read(int id);
        object Create(object t);
        string Delete(int id);
        object Update(int id, object newAll);
    } //Nada mais a ser feito aqui!!!  -- Nothing more to do here!!!
}