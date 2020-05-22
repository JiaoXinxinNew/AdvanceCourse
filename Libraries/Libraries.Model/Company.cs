using Libraries.Framwork.AttributeExtend;
using Libraries.Framwork.AttributeExtend.Validate;
using Libraries.Framwork.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libraries.Model
{
    public partial class Company : BaseModel
    {
        [Length(1,7)]
        public string Name { get; set; }

        public DateTime CreateTime { get; set; }

        [Column("CreatorId")]
        public int CreatorID { get; set; }

        public int? LastModifierId { get; set; }

        public DateTime? LastModifyTime { get; set; }
    }
}
