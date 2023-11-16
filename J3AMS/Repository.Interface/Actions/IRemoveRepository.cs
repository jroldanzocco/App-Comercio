using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface.Actions
{
    public interface IRemoveRepository<T> where T : struct
    {
        void Delete(T id);
    }
}
