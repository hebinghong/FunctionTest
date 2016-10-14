using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FunctionTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //PinYinToHanZi();
            //EmailService.SenEMail(args);
            AsyncTest.Async(1);
            Console.ReadLine();
        }
        /// <summary>
        /// 字符输出到txt文件
        /// </summary>
        void StrToTxt()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 32; i++)
            {
                sb.AppendFormat("string var{0} = var{1}Index >= 0 ? dr[mydic[var{2}Index]].ToString() : \"\";", i, i, i);
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
