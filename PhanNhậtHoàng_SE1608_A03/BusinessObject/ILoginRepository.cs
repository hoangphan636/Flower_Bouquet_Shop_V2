using BussinessObject.DataAccess;
using DataAccess;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public interface ILoginRepository
    {
        Tokens Authenticate(Login  users);


    }
}
