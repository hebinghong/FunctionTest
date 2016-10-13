using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionTest
{
    public static class StringToTxt
    {
        //输入输出流
        static FileStream fs;
        static StreamWriter sw;
        public static void StringToTxtFile(string str)
        {
            string txtName = DateTime.Now.ToString("yyyyMMddHHmmss");
            String path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)+"\\"+txtName+".txt";
            fs = new FileStream(path, FileMode.Create,FileAccess.ReadWrite);
            sw = new StreamWriter(fs);
            sw.WriteLine(str);
            sw.Flush();
            sw.Close();
        }

        internal static void WriteLine(String str)
        {
            //开始写入
            sw.WriteLine(str);
            //清空缓冲区
            sw.Flush();
        }
        internal static void Write(String str)
        {
            //开始写入
            sw.Write(str);
            //清空缓冲区
            sw.Flush();
        }
    }

}
