using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Manager
{
    public class RoleManager
    {
        Model1 db = new Model1();
        public List<tbl_Role> GetAllRoles()
        {
            return   db.tbl_Role.ToList();
        }
    }
}
