using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BAL.Factories;

namespace BAL.Services
{
    public interface IService<TDTO>
    {
        List<TDTO> All();
        TDTO GetById(int id);

        TDTO Add(TDTO entity);

        TDTO Delete(int id);

        TDTO Update(TDTO entity);
    }
}
