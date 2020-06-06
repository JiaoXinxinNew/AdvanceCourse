using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetStudy.Lucene.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            LuceneTest.InitIndex();
            LuceneTest.Show();
        }
    }
}
