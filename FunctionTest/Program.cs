using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FunctionTest
{
    class Program
    {
        static  void Main(string[] args)
        {
            var t1 = DateTime.Now;
            //Console.WriteLine($"start:{t1}");

            //以下被注释掉的方法都是可以运行的
            //StrToTxt();
            //StringToTxt.StringToTxtFile("1234");
            //PinYinToHanZi();
            //EmailService.SenEMail(args);
            //AsyncTest.Async();//0和无参表示异步
            // AsyncUrlRequest.AsyncUrlReq();
            //TaskTest.TaskContinueWith();
            //TaskTest.Parallel_ForEcahTest();
            //TaskTest.Parallel_For();

            var res=StringTest.StringBuilder();

            var t2 = DateTime.Now;
            var t = t2 - t1;
            //Console.WriteLine($"end:{t2}");
            //Console.WriteLine($"time:{t}");
            //StringToTxt.StringToTxtFile(t,"time");
            //Console.WriteLine("主线程代码运行结束。。。\n");
            Console.ReadKey();
        }
        /// <summary>
        /// 字符输出到txt文件
        /// </summary>
        static void StrToTxt()
        {
            StringBuilder sb = new StringBuilder();
            var l = "{";
            var r = "}";
            for (int i = 0; i < 32; i++)
            {
                sb.AppendFormat(
                    "if (string.IsNullOrEmpty(var{0}))"+
                "{1}"+
                    "dr.SetColumnError(mydic[var{0}Index], errorNull);"+
                "{2}"
                    , i+1,l,r);
                sb.AppendLine();
                Console.WriteLine(sb.ToString());
            }
            StringToTxt.StringToTxtFile(sb.ToString().Trim());
        }
        /// <summary>
        /// 汉字转拼音
        /// </summary>
        public  static  void PinYinToHanZi()
        {
            Console.WriteLine(PinYinConverter.Get('峒'));
            Console.WriteLine(PinYinConverter.Get("峒邕"));
        }
    }
}
