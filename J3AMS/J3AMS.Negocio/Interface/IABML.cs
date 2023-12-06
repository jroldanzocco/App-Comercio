using System.Collections.Generic;

namespace J3AMS.Negocio
{
    interface IABML<T>
    {
        List<T> Listar(string id = "");
        //T Get(int id);
        //void Add(T newEntity);
        //void Update(T entity);
        //void Delete(int id);
        //void LogicDelete(int id);
    }
}
