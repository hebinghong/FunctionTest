using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FunctionTest
{
    /// <summary>
    /// 异步编程测试
    /// </summary>
    class AsyncTest
    {
        static string txtStr = "";

        /// <summary>
        /// 异步编程示例
        /// </summary>
        /// <param name="isAsync">参数为空或者是0表示同步</param>
        public static async void Async(int isAsync = 0)
        {
            // ExampleMethodAsync returns a Task<int>, which means that the method
            // eventually produces an int result. However, ExampleMethodAsync returns
            // the Task<int> value as soon as it reaches an await.
            txtStr += "\n";
            try
            {
                int length;
                if (isAsync == 0)
                {
                    length = await ExampleMethodAsync();
                }
                else
                {
                    length = ExampleMethod();
                }
                // Note that you could put "await ExampleMethodAsync()" in the next line where
                // "length" is, but due to when '+=' fetches the value of ResultsTextBox, you
                // would not see the global side effect of ExampleMethodAsync setting the text.
                txtStr = String.Format("Length: {0}\n", length);
                Console.WriteLine(txtStr);
            }
            catch (Exception)
            {
                // Process the exception if one occurs.
            }
        }

        public static async Task<int> ExampleMethodAsync()
        {
            var httpClient = new HttpClient();
            int exampleInt = (await httpClient.GetStringAsync("http://msdn.microsoft.com")).Length;
            txtStr = "（异步）Preparing to finish ExampleMethodAsync.\n";
            Console.WriteLine(txtStr);

            // After the following return statement, any method that's awaiting
            // ExampleMethodAsync (in this case, StartButton_Click) can get the 
            // integer result.
            return exampleInt;
        }

        // Output:
        // Preparing to finish ExampleMethodAsync.
        // Length: 53292
        public static int ExampleMethod()
        {
            var httpClient = new HttpClient();
            int exampleInt = httpClient.GetStringAsync("http://msdn.microsoft.com").ToString().Length;
            txtStr = "（同步）Preparing to finish ExampleMethod.\n";
            Console.WriteLine(txtStr);

            // After the following return statement, any method that's awaiting
            // ExampleMethodAsync (in this case, StartButton_Click) can get the 
            // integer result.
            return exampleInt;
        }
    }
    /// <summary>
    /// 发送请求链接，获取请求结果
    /// </summary>
    class AsyncUrlRequest
    {
        static string Text = "";

        public static async void AsyncUrlReq()
        {

            // One-step async call.
            await SumPageSizesAsync();

            //// Two-step async call.
            //Task sumTask = SumPageSizesAsync();
            //await sumTask;

            Text += "\r\nControl returned to startButton_Click.\r\n";
            Console.WriteLine(Text);
        }


        public static async Task SumPageSizesAsync()
        {
            // Declare an HttpClient object and increase the buffer size. The
            // default buffer size is 65,536.
            HttpClient client =
                new HttpClient() { MaxResponseContentBufferSize = 1000000 };

            // Make a list of web addresses.
            List<string> urlList = SetUpURLList();

            var total = 0;

            foreach (var url in urlList)
            {
                // GetByteArrayAsync returns a task. At completion, the task
                // produces a byte array.
                string urlTest = String.Format(
                    "http://api.map.baidu.com/geocoder/v2/?ak=MZY8Qaa3Gih0mS6aERSwUpB1cGs3kG9r&address={0}&output=json",
                    //"https://www.google.cn/maps/api/geocode/json?address={0}&region=cn&key=AIzaSyA2EDTy13-ulmFgVQ5ypj0GXWM7NoD2LOA",//谷歌地图地址解析坐标
                    "广西大学");
                var urlContentsTest = await client.GetStreamAsync(urlTest);
                var urlRes = await client.GetStringAsync(urlTest);
                var sr = new StreamReader(urlContentsTest, Encoding.UTF8);
                var content = sr.ReadToEnd();

                byte[] urlContents = await client.GetByteArrayAsync(url);

                // The following two lines can replace the previous assignment statement.
                //Task<byte[]> getContentsTask = client.GetByteArrayAsync(url);
                //byte[] urlContents = await getContentsTask;

                DisplayResults(url, urlContents);

                // Update the total.
                total += urlContents.Length;
            }

            // Display the total count for all of the websites.
            Text =
                string.Format("\r\n\r\nTotal bytes returned:  {0}\r\n", total);
            Console.WriteLine(Text);
        }


        private static List<string> SetUpURLList()
        {
            List<string> urls = new List<string>
            {
                "http://msdn.microsoft.com/library/windows/apps/br211380.aspx",
                "http://msdn.microsoft.com",
                "http://msdn.microsoft.com/en-us/library/hh290136.aspx",
                "http://msdn.microsoft.com/en-us/library/ee256749.aspx",
                "http://msdn.microsoft.com/en-us/library/hh290138.aspx",
                "http://msdn.microsoft.com/en-us/library/hh290140.aspx",
                "http://msdn.microsoft.com/en-us/library/dd470362.aspx",
                "http://msdn.microsoft.com/en-us/library/aa578028.aspx",
                "http://msdn.microsoft.com/en-us/library/ms404677.aspx",
                "http://msdn.microsoft.com/en-us/library/ff730837.aspx"
            };
            return urls;
        }


        private static void DisplayResults(string url, byte[] content)
        {
            // Display the length of each website. The string format 
            // is designed to be used with a monospaced font, such as
            // Lucida Console or Global Monospace.
            var bytes = content.Length;
            // Strip off the "http://".
            var displayURL = url.Replace("http://", "");
            Text = string.Format("\n{0,-58} {1,8}", displayURL, bytes);
            Console.WriteLine(Text);

        }
    }

    class TaskTest
    {
        /// <summary>
        /// 创建一个异步任务，完成后执行延续任务，不阻塞线程
        /// </summary>
        public static async void TaskContinueWith()
        {
            Task<Int32> t = new Task<Int32>(n => Sum((Int32)n), 1000);
            t.Start();
            //t.Wait();

            //如果使用等待，之后的代码不会立刻执行，控制权返回方法调用方
            t.ContinueWith(task => Console.WriteLine("The result is {0}", t.Result));
            Console.WriteLine("异步任务创建成功");
        }
        /// <summary>
        /// 并行循环
        /// </summary>
        public static void Parallel_ForEcahTest()
        {
            var sTime = DateTime.Now;
            var list = new List<string> {"a","b","c"};
            int i = 0;
            Parallel.ForEach<string>(list, str =>
                {
                    i++;
                    Console.WriteLine(i);
                    var sum = 0;
                    if (str.Contains("a"))
                    {
                        sum=Sum(10000);
                    }
                    if (str.Contains("b"))
                    {
                        sum = Sum(20000);
                    }
                    if (str.Contains("c"))
                    {
                        sum = Sum(30000);
                    }
                    Console.WriteLine(str+":"+sum);
                }
            );
            var eTime = DateTime.Now;
            var time = eTime - sTime;
            Console.WriteLine("Parallel.ForEcah=>" + time);
        }

        public static void Parallel_For()
        {
            var list = new List<string> { "a", "b", "c" };
            var sTime = DateTime.Now;
            Parallel.For(0, list.Count(), i =>
                {
                    Console.WriteLine(i);
                     var str = list[i];
                     var sum = 0;
                     if (str.Contains("a"))
                     {
                         sum = Sum(10000);
                     }
                     if (str.Contains("b"))
                     {
                         sum = Sum(20000);
                     }
                     if (str.Contains("c"))
                     {
                         sum = Sum(30000);
                     }
                     Console.WriteLine(str + ":" + sum);
                 }
            );
            var eTime = DateTime.Now;
            var time = eTime-sTime;
            Console.WriteLine("Parallel.For=>" + time);
        }

        private static int Sum(Int32 i)
        {
            int sum = 0;
            for (; i > 0; --i)
            {
                checked
                {
                    sum += i;
                } //结果溢出，抛出异常
            }
            //Console.WriteLine(sum);
            return sum;
        }

    }
}

