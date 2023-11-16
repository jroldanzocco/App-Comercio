using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface.Actions
{
    public interface IUpdateRepository<T> where T : class
    {
        void Update(T entity);
    }
}
