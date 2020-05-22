using Libraries.DAL;
using Libraries.Factory;
using Libraries.Framwork.AttributeExtend;
using Libraries.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libraries.Project
{
    class Program
    {
        static void Main(string[] args)
        {
            IBaseDAL baseDAL = DALFactory.CreateInstance();
            
            User user = baseDAL.Find<User>(1);
           var userList= baseDAL.FindAll<User>();
            user.Name = "jxx";
            baseDAL.Insert<User>(user);
                baseDAL.Delete<User>(6);
            user.Name = "焦鑫鑫";
            user.Id = 7;
            baseDAL.Update(user);
            System.Console.Read();
        }
    }
}
