using Framework.Log;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Http
{
   public class HttpHelper
    {
        private static LogHelper logger = new LogHelper(typeof(HttpHelper));

        /// <summary>
        /// 下载html
        /// http://tool.sufeinet.com/HttpHelper.aspx
        /// HttpWebRequest功能比较丰富，WebClient使用比较简单
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string DownloadHtml(string url)
        {
            string html = string.Empty;
            try
            {
                //logger.Info($"准备下载{url}");
                //HttpClient
                HttpWebRequest request = HttpWebRequest.Create(url) as HttpWebRequest;//模拟请求

                request.Timeout = 30 * 1000;//设置30s的超时
                request.UserAgent = "Mozilla / 5.0(Windows NT 10.0; Win64; x64) AppleWebKit / 537.36(KHTML, like Gecko) Chrome / 77.0.3865.90 Safari / 537.36";//pc浏览器
                //request.UserAgent = "Ruanmou Crawler";
                //request.UserAgent = "Mozilla / 5.0(iPhone; CPU iPhone OS 7_1_2 like Mac OS X) App leWebKit/ 537.51.2(KHTML, like Gecko) Version / 7.0 Mobile / 11D257 Safari / 9537.53";//移动端浏览器

                request.ContentType = "text/html; charset=utf-8";// "text/html;charset=gbk";// 
                //request.Host = "www.jd.com";

                request.Headers.Add("Cookie", @"__jdu=1571148241040680859459; shshshfpa=18fed0fc-0de6-c6fc-86bf-a6d191047adb-1571148242; shshshfpb=i3m6HagPxrAZBtO15k7EJKg%3D%3D; o2State={%22webp%22:true%2C%22lastvisit%22:1571752115191}; pinId=0hbzt8-aeBBY7hC1VXyMY7V9-x-f3wj7; TrackID=1V_F4tTI_zfWIv1bWW3SSKYoFY5K1JIDCk8Hck0CvMehMQG8RwYQndRtnKNdtw2FxwQepPgvsjVkPQrx1OCBFxMNepVElC0hTLwsh5oQPMbEC81nEkERL1E6E_NMMwOL0; __jdv=76161171|direct|-|none|-|1587646911028; __jdc=76161171; areaId=13; ipLoc-djd=13-2900-3533-0; PCSYCityID=CN_370000_370900_0; __jda=76161171.1571148241040680859459.1571148241.1587646911.1587698352.28; __jdb=76161171.2.1571148241040680859459|28.1587698352; shshshfp=200079b745bdd8c77868ea89eb0698b0; shshshsID=89fd23c5e5624ed622e2fc6e7b9b4f6c_2_1587698356983");

                //request.Headers.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8");
                //request.Headers.Add("Accept-Encoding", "gzip, deflate, sdch");
                //request.Headers.Add("Referer", "http://list.yhd.com/c0-0/b/a-s1-v0-p1-price-d0-f0-m1-rt0-pid-mid0-kiphone/");
                request.Method = "GET";
                //Encoding enc = Encoding.GetEncoding("GB2312"); // 如果是乱码就改成 utf-8 / GB2312

                //int sort = 2;//人数
                //string dataString = string.Format("k={0}&n=24&st={1}&iso=0&src=1&v=4093&p={2}&isRecommend=false&city_id=0&from=1&ldw=1361580739", keyword, sort, 1);
                //Encoding encoding = Encoding.UTF8;//根据网站的编码自定义  
                //byte[] postData = encoding.GetBytes(dataString);
                //request.ContentLength = postData.Length;
                //Stream requestStream = request.GetRequestStream();
                //requestStream.Write(postData, 0, postData.Length);

                Encoding enc = Encoding.UTF8;//.GetEncoding("GB2312");
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)//发起请求
                {
                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        logger.Warn(string.Format("抓取{0}地址返回失败,response.StatusCode为{1}", url, response.StatusCode));
                    }
                    else
                    {
                        try
                        {
                            StreamReader sr = new StreamReader(response.GetResponseStream(), enc);
                            html = sr.ReadToEnd();//读取数据
                            sr.Close();
                        }
                        catch (Exception ex)
                        {
                            logger.Error(string.Format($"DownloadHtml抓取{url}失败"), ex);
                            html = null;
                        }
                    }
                }
            }
            catch (System.Net.WebException ex)
            {
                if (ex.Message.Equals("远程服务器返回错误: (306)。"))
                {
                    logger.Error("远程服务器返回错误: (306)。", ex);
                    html = null;
                }
            }
            catch (Exception ex)
            {
                logger.Error(string.Format("DownloadHtml抓取{0}出现异常", url), ex);
                html = null;
            }
            return html;
        }
    }
}
