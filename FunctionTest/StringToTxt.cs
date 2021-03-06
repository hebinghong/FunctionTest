﻿using System;
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

        /// <summary>
        /// 将字符串输出到txt文件并保存在桌面
        /// </summary>
        /// <param name="str"></param>
        /// <param name="txtName">文件名</param>
        public static void StringToTxtFile(object str,string txtName = null)
        {
            if (txtName == null) txtName = DateTime.Now.ToString("yyyyMMddHHmmss");
            String path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)+"\\"+txtName+".txt";
            fs = new FileStream(path, FileMode.Append,FileAccess.Write);
            sw = new StreamWriter(fs);
            sw.WriteLine(str.ToString());
            sw.Flush();
            sw.Close();
            fs.Close();
            sw.Dispose();
            fs.Dispose();
        }

        //internal static void WriteLine(String str)
        //{
        //    //开始写入
        //    sw.WriteLine(str);
        //    //清空缓冲区
        //    sw.Flush();
        //}
        //internal static void Write(String str)
        //{
        //    //开始写入
        //    sw.Write(str);
        //    //清空缓冲区
        //    sw.Flush();
        //}
    }

}
