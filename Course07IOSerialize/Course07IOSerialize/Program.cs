using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course07IOSerialize
{
    class Program
    {
        static void Main(string[] args)
        {
            string rootPath = AppDomain.CurrentDomain.BaseDirectory;
            string folderPath = Path.Combine(rootPath, "folder");
            string filePath = Path.Combine(folderPath, "Log.txt");
            DirectoryInfo directory = new DirectoryInfo(folderPath);
            directory.Create();
            using (FileStream fs = File.Create(filePath))
            {
                string content = "123457890";
                byte[] bytes = Encoding.Default.GetBytes(content);
                fs.Write(bytes, 0, bytes.Length);
                fs.Flush();//使用flush是因为当缓存区不满的情况下，将数据写到文件中，而不是等到缓存区满后再写入。
            }
            using (FileStream fs = File.Create(filePath))
            {
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine("123456780987654321");
                sw.Flush();
            }
            using (StreamWriter fs = File.AppendText(filePath))
            {
                fs.WriteLine("65345679874567");
                fs.WriteLine("65345679874567");
                fs.WriteLine("65345679874567");
            }
            foreach (var item in File.ReadAllLines(filePath))
            {
                Console.WriteLine(item);
            }
            string[] fileText = File.ReadAllLines(filePath);
            foreach (var item in fileText)
            {
                Console.WriteLine(item);
            }

        }
        public static IList<DirectoryInfo> GetFileInfo(string path)
        {
            
        }
    }
}
