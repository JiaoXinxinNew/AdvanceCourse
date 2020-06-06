using DotNetStudy.Lucene.Console.DataService;
using DotNetStudy.Lucene.Console.Model;
using DotNetStudy.Lucene.Console.Utility;
using Lucene.Net.Analysis.PanGu;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.QueryParsers;
using Lucene.Net.Search;
using Lucene.Net.Store;
using System;
using System.Collections.Generic;



namespace DotNetStudy.Lucene.Console
{
    public static class LuceneTest
    {
        /// <summary>
        /// 初始化写入数据到本地磁盘
        /// </summary>
        public static void InitIndex()
        {
            List<Activity> activities = ActivityRepository.QueryList(2, 1000);
            FSDirectory fSDirectory = FSDirectory.Open(StaticConstant.TestIndexPath);//指定文件夹路径
            using (IndexWriter write = new IndexWriter(fSDirectory, new PanGuAnalyzer(), true, IndexWriter.MaxFieldLength.LIMITED))//索引写入器 Lucene.net.analysis.pangu
            {
                foreach (var activity in activities)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        Document doc = new Document();//一条数据
                        doc.Add(new Field("id", activity.Id.ToString(), Field.Store.YES, Field.Index.NOT_ANALYZED)); // 一个字段  列名 值   是否保存值 是否分词
                        doc.Add(new Field("ActivityName", activity.ActivityName, Field.Store.YES, Field.Index.ANALYZED));
                        write.AddDocument(doc);//写入
                    }
                }
                write.Optimize();//优化，就是合并
            }
        }

        public static void Show()
        {
            FSDirectory fSDirectory = FSDirectory.Open(StaticConstant.TestIndexPath);
            IndexSearcher indexSearcher = new IndexSearcher(fSDirectory);
            //查询单元
            {
                TermQuery termQuery = new TermQuery(new Term("ActivityName", "集合"));
                TopDocs topDocs = indexSearcher.Search(termQuery, 1000);
                foreach (var sd in topDocs.ScoreDocs)
                {
                    Document document = indexSearcher.Doc(sd.Doc);
                    System.Console.WriteLine("*************");
                    System.Console.WriteLine($"id={document.Get("id")}");
                    System.Console.WriteLine($"ActivityName={document.Get("ActivityName")}");
                }
                System.Console.WriteLine($"一共命中了{topDocs.TotalHits}");
            }
            
        }
        
    }
}
