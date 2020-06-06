using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace DotNetStudy.WCF.UI.Models
{
    [DataContractAttribute]
    public class UserInfo
    {
        public UserInfo(int i)
        {

        }
        [DataMember]
        public int Id { get; set; }
        public string Name { get; set; }
        [DataMember]
        public int Age { get; set; }
    }
}