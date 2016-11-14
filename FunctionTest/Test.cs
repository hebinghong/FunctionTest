using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionTest
{
    class StringTest
    {
        public string s = "";
        public string a = 1+"";
        public string s1 => "{s}";
        public static  string  StringBuilder()
        {
            StringBuilder sb=new StringBuilder();
            string str = "";
            for (int j = 0; j < 5; j++)
            {
                sb.Clear();
                str = "";
                var t1 = DateTime.Now;
                for (int i = 0; i < 100000; i++)
                {
                    switch (j)
                    {
                        case 0:
                            //sb.Append("qwe123qwe123");
                            str += "qwe123qwe123";
                            break;
                        case 1:
                            //sb.AppendFormat("qwe{0}qwe{1}", i, i);
                            str +=string.Format("qwe{0}qwe{1}", i, i);

                            break;
                        case 2:
                            //sb.Append($"qwe{i}qwe{i}");
                            str += $"qwe{i}qwe{i}";


                            break;
                        case 3:
                            //sb.Append("qwe" + i + "qwe" + i);
                            str += "qwe" + i + "qwe" + i;

                            break;
                        case 4:
                            //sb.AppendFormat($"qwe{i}qwe{i}");
                            str += $"qwe{i}qwe{i}";

                            break;
                    }
                }
                var t2 = DateTime.Now;
                var t = t2 - t1;
                StringToTxt.StringToTxtFile(t,"time");
                Console.WriteLine($"time:{t}");

            }
            StringToTxt.StringToTxtFile("-------", "time");

            return sb.ToString();
        }
    }
}
