using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetStudy.Lucene.Console.Model
{
    public partial class Activity
    {
        public int Id { get; set; }

        public int StuId { get; set; }

        public int CourseId { get; set; }

        
        public string CourseName { get; set; }

        public int ClassId { get; set; }

        public int ActivityId { get; set; }

       
        public string ActivityName { get; set; }

        
        public string ActivityType { get; set; }

        public DateTime EntryTime { get; set; }

       
        public DateTime EntryDay { get; set; }

        public int StudyTime { get; set; }
    }
}
