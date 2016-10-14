using System;
using System.Collections.Generic;
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
        public static async void Async(int isAsync=0 )
        {
            // ExampleMethodAsync returns a Task<int>, which means that the method
            // eventually produces an int result. However, ExampleMethodAsync returns
            // the Task<int> value as soon as it reaches an await.
            txtStr += "\n";
            try
            {
                int length;
                if (isAsync==0)
                {
                    length = await ExampleMethodAsync();
                }
                else
                {
                    length =  ExampleMethod();
                }
                // Note that you could put "await ExampleMethodAsync()" in the next line where
                // "length" is, but due to when '+=' fetches the value of ResultsTextBox, you
                // would not see the global side effect of ExampleMethodAsync setting the text.
                txtStr += String.Format("Length: {0}\n", length);
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
            txtStr += "（异步）Preparing to finish ExampleMethodAsync.\n";
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
            int exampleInt =  httpClient.GetStringAsync("http://msdn.microsoft.com").ToString().Length;
            txtStr += "（同步）Preparing to finish ExampleMethodAsync.\n";
            Console.WriteLine(txtStr);

            // After the following return statement, any method that's awaiting
            // ExampleMethodAsync (in this case, StartButton_Click) can get the 
            // integer result.
            return exampleInt;
        }
    }
}
