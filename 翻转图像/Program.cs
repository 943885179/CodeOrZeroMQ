using Quartz;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ZeroMQ;

namespace 翻转图像
{
    public class HelloJob : Quartz.IJob
    {
        Task IJob.Execute(IJobExecutionContext context)
        {
            Console.WriteLine("Greetings from HelloJob!");
            return null;
            //throw new NotImplementedException();
        }
    }

    public class MinStack
    {
        private static List<int> data;
        /** initialize your data structure here. */

        public MinStack()
        {
            data = new List<int>();
        }

        public int GetMin()
        {
            return data.Min();
            //var min =data[0];
            //foreach (var item in data)
            //{
            //    if (min >= item)
            //    {
            //        min = item;
            //    }
            //}
            //return min;
        }

        public void Pop()
        {
            if (data.Count() >= 1)
            {
                data.RemoveAt(data.Count() - 1);
            }
        }

        public void Push(int x)
        {
            data.Add(x);
        }

        public int Top()
        {
            if (data.Count() >= 1)
            {
                return data[data.Count() - 1];
            }
            return 0;
        }
    }

    internal class Program
    {
        public static string AddBinary(string a, string b)
        {
            return Convert.ToString(Convert.ToInt32(a, 2) + Convert.ToInt32(b, 2));
        }

        public static int DominantIndex(int[] nums)
        {
            int max = 0;
            int maxthen = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] > nums[max])
                {
                    max = i;
                }
            }
            for (int i = 0; i < nums.Length; i++)
            {
                if (max == 0)
                {//如果第一个是最大的
                    maxthen++;
                }
                if (nums[i] >= nums[maxthen] && i != max)
                {
                    maxthen = i;
                }
            }
            if (nums[max] >= 2 * nums[maxthen])
            {
                return max;
            }
            return -1;
        }

        public static double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            int[] newInt = new int[nums1.Length + nums2.Length];
            for (int i = 0; i < nums1.Length; i++)
            {
                newInt[i] = nums1[i];
            }
            for (int i = 0; i < nums2.Length; i++)
            {
                newInt[nums1.Length + i] = nums2[i];
            }
            Array.Sort(newInt);
            if (newInt.Length % 2 == 0)
            {
                var ttt = newInt[newInt.Length / 2] + newInt[newInt.Length / 2 - 1];
                return Convert.ToDouble((newInt[newInt.Length / 2] + newInt[newInt.Length / 2 - 1]) / 2d);
            }
            else
            {
                return Convert.ToDouble(newInt[newInt.Length / 2]);
            }
        }

        public static int[][] FlipAndInvertImage(int[][] A)
        {
            for (int i = 0; i < A.Length; i++)
            {
                var len = A[i].Length / 2 + A[i].Length % 2;
                for (int j = 0; j < len; j++)
                {
                    var tmp = A[i][j];
                    A[i][j] = A[i][A[i].Length - 1 - j] == 1 ? 0 : 1;
                    A[i][A[i].Length - 1 - j] = tmp == 1 ? 0 : 1;
                }
            }
            return A;
        }

        public static IList<IList<int>> Generate(int numRows)
        {
            IList<IList<int>> arr = new List<IList<int>>();
            var index = 1;
            while (index <= numRows)
            {
                IList<int> a = new List<int>();
                for (var i = 0; i < index; i++)
                {
                    if (index - 1 == i || i == 0)
                    {
                        a.Add(1);
                    }
                    else
                    {
                        var lef = arr[index - 2][i - 1];
                        var re = arr[index - 2][i];
                        a.Add(lef + re);
                    }
                }
                arr.Add(a);
                index++;
            }
            return arr;
        }

        public static IList<int> GetRow(int rowIndex)
        {
            IList<IList<int>> arr = new List<IList<int>>();
            IList<int> a = new List<int>();
            var index = 1;
            while (index <= rowIndex)
            {
                a = new List<int>();
                for (var i = 0; i < index; i++)
                {
                    if (index - 1 == i || i == 0)
                    {
                        a.Add(1);
                    }
                    else
                    {
                        var lef = arr[index - 2][i - 1];
                        var re = arr[index - 2][i];
                        a.Add(lef + re);
                    }
                }
                if (index == rowIndex)
                {
                    return a;
                }
                arr.Add(a);
                index++;
            }
            return a;
        }

        public static int HammingDistance(int x, int y)
        {
            var xr = Convert.ToString(x, 2).ToCharArray();
            var yr = Convert.ToString(y, 2).ToCharArray();
            int s = 0;
            var len = xr.Length > yr.Length ? xr.Length : yr.Length;
            for (int i = 0; i < len; i++)
            {
                var yindex = xr.Length > yr.Length ? yr.Length - xr.Length + i : xr.Length - yr.Length + i;
                if (len == xr.Length && xr[i].ToString() == "0" && (yindex < 0 || yindex > yr.Length))
                {
                }
                else if (len == yr.Length && yr[i].ToString() == "0" && (yindex < 0 || yindex > xr.Length))
                {
                }
                else if (len == xr.Length && ((xr[i].ToString() != "0" && (yindex < 0 || yindex > yr.Length)) || (xr[i] != yr[yindex] && yindex >= 0)))
                {
                    s++;
                }
                else if (len == yr.Length && ((yr[i].ToString() != "0" && (yindex < 0 || yindex > xr.Length)) || (yr[i] != xr[yindex] && yindex >= 0)))
                {
                    s++;
                }
            }
            return s;
        }

        public static bool IsPalindrome(string s)
        {
            Regex.Match(s, "^[a-z][A-Z]");
            var sls = Regex.Matches(s, "[a-zA-Z]");
            var sl = "";
            foreach (var item in sls)
            {
                sl += item.ToString().ToLower();
            }

            for (int i = 0; i < sl.Length / 2; i++)
            {
                if (sl[i] != sl[sl.Length - 1 - i])
                {
                    return false;
                }
            }
            return true;
        }

        public static bool JudgeCircle(string moves)
        {
            int x = 0;
            int y = 0;
            var arr = moves.ToCharArray();
            foreach (var item in arr)
            {
                if (item == 'R')
                {
                    x++;
                }
                else if (item == 'L')
                {
                    x--;
                }
                else if (item == 'U')
                {
                    y--;
                }
                else if (item == 'D')
                {
                    y++;
                }
                else
                {
                }
            }
            if (x == 0 && y == 0)
            {
                return true;
            }
            return false;
        }

        public static int MaxProduct(int[] nums)
        {
            var res = nums[0];
            for (int i = 1; i < nums.Count(); i++)
            {
                var r = nums[i];
                var thisMax = nums[i];
                for (int j = i - 1; j >= 0; j--)
                {
                    r = r * nums[j];
                    if (thisMax < r)
                    {
                        thisMax = r;
                    }
                }
                if (thisMax > res)
                {
                    res = thisMax;
                }
            }
            return res;
        }

        public static void MoveZeroes(int[] nums)
        {
            for (int i = nums.Length - 1; i >= 0; i--)
            {
                if (nums[i] == 0)
                {
                    var tep = nums[i];
                    for (int j = i; j < nums.Length - 1; j++)
                    {
                        nums[j] = nums[j + 1];
                    }
                    nums[nums.Length - 1] = tep;
                }
            }
            var ss = nums;
        }

        public static int[] PlusOne(int[] digits)
        {
            double x = 0;
            for (int i = 0; i < digits.Length; i++)
            {
                x += digits[i] * Math.Pow(10, digits.Length - 1 - i);
            }
            x++;
            return x.ToString().ToArray().Select(o => int.Parse(o.ToString())).ToArray();
        }

        public static int[] RemoveDuplicates(int[] nums)
        {
            // Array.Sort(nums);
            int s = nums.GroupBy(o => o).Select(o => new { o.Key, c = o.Count() }).Where(o => o.c == 1).First().Key;
            var list = new List<int>();
            foreach (var item in nums)
            {
                var ssd = list.Contains(item);
                if (!list.Contains(item))
                {
                    list.Add(item);
                }
            }
            return list.ToArray();
        }

        public static int SingleNumber(int[] nums)
        {
            int result = 0;
            int len = nums.Length;
            for (int i = 0; i < len; i++)
            {
                result = result ^ nums[i];
            }
            return result;
        }

        public static int[] SortedSquares(int[] A)
        {
            for (int i = 0; i < A.Length; i++) A[i] *= A[i];
            Array.Sort(A);
            return A;
        }

        public static int UniqueMorseRepresentations(string[] words)
        {
            var mm = new string[] { ".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....", "..", ".---", "-.-", ".-..", "--", "-.", "---", ".--.", "--.-", ".-.", "...", "-", "..-", "...-", ".--", "-..-", "-.--", "--.." };
            var ms = new string[words.Length];
            int s = 0;
            foreach (var item in words)
            {
                var ascll = Encoding.Default.GetBytes(item);
                var thisMs = "";
                foreach (var asc in ascll)
                {
                    int i = 0;//数值对应下标；
                    if (asc > 65 && asc < 97)
                    {//大写字母
                        i = asc - 65;
                        thisMs += mm[i];
                    }
                    else if (asc > 97 && asc < 97 + mm.Length)
                    {//小写字母
                        i = asc - 97;
                        thisMs += mm[i];
                    }
                }
                ms[s] = thisMs;

                s++;
            }
            List<string> listString = new List<string>();
            foreach (string eachString in ms)
            {
                if (!listString.Contains(eachString))
                    listString.Add(eachString);
            }
            return listString.Count();
        }

        public string ReverseWords(string s)
        {
            var sp = s.Split(' ');
            var result = "";
            for (var i = sp.Length - 1; i >= 0; i--)
            {
                if (sp[i] != "")
                {
                    result = result + sp[i] + " ";
                }
            }
            return result.Trim();
        }

        public string ReverseWordsNew(string s)
        {
            var sp = s.Split(' ');
            var list = new List<string>();
            for (var i = sp.Length - 1; i >= 0; i--)
            {
                if (sp[i] != "")
                {
                    list.Add(sp[i]);
                }
            }
            return String.Join(" ", list);
        }

        public int[] TwoSum(int[] nums, int target)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = 0; j < nums.Length; j++)
                {
                    if (i != j && nums[i] + nums[j] == target)
                    {
                        return new int[] { i, j };
                    }
                }
            }
            return null;
        }

        /*
        private static void Main(string[] args)
        {
            using (var context = ZContext.Create())
            {
                using (var resp = new ZSocket(context, ZSocketType.REP))
                {
                    resp.Bind("tcp://*:5555");
                    while (true)
                    {
                        ZFrame reply = resp.ReceiveFrame();
                        string message = reply.ReadString();

                        Console.WriteLine("Receive message {0}", message);

                        resp.Send(new ZFrame(message));

                        if (message == "exit")
                        {
                            break;
                        }
                    }
                }
            }
        }

        //客户端代码
        static void Main(string[] args)
        {
            using (var context = new ZContext())
            using (var requester = new ZSocket(context, ZSocketType.REQ))
            {
                // Connect
                requester.Connect("tcp://127.0.0.1:5555");

                while (true)
                {
                    Console.WriteLine("Please enter your message:");
                    string message = Console.ReadLine();
                    requester.Send(new ZFrame(message));

                    // Send
                    //requester.Send(new ZFrame(requestText));

                    // Receive
                    using (ZFrame reply = requester.ReceiveFrame())
                    {
                        Console.WriteLine("Received: {0} {1}!", message, reply.ReadString());
                        if ("exit" == reply.ReadString())
                        {
                            break;
                        }
                    }
                }
            }
        }*/

        //订阅者
        private static void Subscribe()
        {
            using (var context = new ZContext())
            using (var subscribe = new ZSocket(context, ZSocketType.SUB))
            {
                subscribe.SubscribeAll();
                subscribe.Connect("tcp://127.0.0.1:5555");
                while (true)
                {
                    using (ZFrame replay = subscribe.ReceiveFrame())
                    {
                        Console.WriteLine("REceive: {0}", replay.ReadString());
                    }
                }
            }
        }

        private static void Pullscribe()
        {
            using (var context = new ZContext())
            {
                using (var subscribe = new ZSocket(context, ZSocketType.PULL))
                {
                    subscribe.SubscribeAll();
                    subscribe.Connect("tcp://127.0.0.1:5555");
                    while (true)
                    {
                        using (ZFrame replay = subscribe.ReceiveFrame())
                        {
                            Console.WriteLine("REceive: {0}", replay.ReadString());
                        }
                    }
                }
            }
        }

        //普通客户端
        private static void Req()
        {
            using (var context = new ZContext())
            {
                using (var requester = new ZSocket(context, ZSocketType.REQ))
                {
                    // Connect
                    requester.Connect("tcp://127.0.0.1:5555");

                    while (true)
                    {
                        Console.WriteLine("Please enter your message:");
                        string message = Console.ReadLine();
                        requester.Send(new ZFrame(message));

                        // Send
                        //requester.Send(new ZFrame(requestText));

                        // Receive
                        using (ZFrame reply = requester.ReceiveFrame())
                        {
                            Console.WriteLine("Received: {0} {1}!", message, reply.ReadString());
                            if ("exit" == reply.ReadString())
                            {
                                break;
                            }
                        }
                    }
                }
            }
        }

        private static void Main(string[] args)
        {
            // Req();
            Pullscribe();
            /*
            using (var context = new ZContext())
            {
                using (var requester = new ZSocket(context, ZSocketType.REQ))
                {
                    // Connect
                    requester.Connect("tcp://127.0.0.1:5555");

                    while (true)
                    {
                        Console.WriteLine("Please enter your message:");
                        string message = Console.ReadLine();
                        requester.Send(new ZFrame(message));

                        // Send
                        //requester.Send(new ZFrame(requestText));

                        // Receive
                        using (ZFrame reply = requester.ReceiveFrame())
                        {
                            Console.WriteLine("Received: {0} {1}!", message, reply.ReadString());
                            if ("exit" == reply.ReadString())
                            {
                                break;
                            }
                        }
                    }
                }
            }*/
            var i = new List<int>();
            var arr = new ArrayList();
            int[] s = i.ToArray();
            int[] ts = arr.ToArray(typeof(int)) as int[];

            // RemoveDuplicates(new int[] { 1, 2, 1 });
            //Console.WriteLine(Math.Max(1,2));
            // MaxProduct(new int[3] {-2, 3, -2 });
            //{
            //    MinStack minStack = new MinStack();
            //    minStack.Push(2);
            //    minStack.Push(0);
            //    minStack.Push(3);
            //    minStack.Push(0);
            //    Console.WriteLine(minStack.GetMin());
            //    minStack.Pop();
            //    Console.WriteLine(minStack.GetMin());
            //    minStack.Pop();
            //    Console.WriteLine(minStack.GetMin());
            //    minStack.Pop();
            //    Console.WriteLine(minStack.GetMin());
            //}
            //{
            //    QuartzHelp.JobFactory<HelloJob>("Job1", "Trigger1", 1);
            //}
            /* {
                 try
                 {
                     // Grab the Scheduler instance from the Factory
                     var scheduler = StdSchedulerFactory.GetDefaultScheduler();

                     // and start it off
                     scheduler.Result.Start();

                     // define the job and tie it to our HelloJob class
                     IJobDetail job = JobBuilder.Create<HelloJob>()
                         .WithIdentity("job1", "group1")
                         .Build();

                     // Trigger the job to run now, and then repeat every 10 seconds
                     ITrigger trigger = TriggerBuilder.Create()
                         .WithIdentity("trigger1", "group1")
                         .StartNow()
                         .WithSimpleSchedule(x => x.WithIntervalInSeconds(2)
                            // .WithIntervalInSeconds(10)
                             .RepeatForever())
                         .Build();

                     // Tell quartz to schedule the job using our trigger
                     scheduler.Result.ScheduleJob(job, trigger);

                     // some sleep to show what's happening
                      Thread.Sleep(TimeSpan.FromSeconds(6));
                     // and last shut down the scheduler when you are ready to close your program
                     scheduler.Result.Shutdown();
                 }
                 catch (SchedulerException se)
                 {
                     Console.WriteLine(se);
                 }
             }
             */
            /*
            {
                //每个4秒执行一次，启动两秒后开始执行“1”这个任务
                System.Threading.Timer thread = new System.Threading.Timer((n) => { Console.WriteLine(n); },"1", 2000, 4000);
            }*/

            Console.ReadKey();
            /*
            var GetRows = GetRow(3);
            var ss = Generate(5);
            FindMedianSortedArrays(new int[] { 1, 2 }, new int[] { 3, 4 });
            HammingDistance(1, 4);
            var ttt = Convert.ToString(11, 2);
            PlusOne(new int[] { 9, 8, 2, 1, 3 });
            DominantIndex(new int[] { 0, 1 });
            Console.WriteLine(6 ^ 6);
            Console.WriteLine(6 ^ 5);
            Console.WriteLine(6 ^ 4);
            IsPalindrome("A man, a plan, a canal: Panama");
            Console.WriteLine("true ^ false:{0}", true ^ false);
            SingleNumber(new int[]{
                4,1,2,1,2
            });
            var dd = new string[] {
               "rwjje", "aittjje", "auyyn", "lqtktn", "lmjwn"
            };
            UniqueMorseRepresentations(dd);

            int[][] a = new int[][] {
                new int[]{ 1,0,0}, new int[]{ 1,1,0}
            };
            var s = FlipAndInvertImage(a);
            var xx = "Asdasda";
            var lxx = xx.ToLower();
            var rr = xx.ToCharArray();
            var result = "";
            var bytexx = Encoding.Default.GetBytes(xx);
            foreach (var item in bytexx)
            {
                //ascllA:65 a:97
                if (item >= 65 && item <= 96)
                {
                    result += new ASCIIEncoding().GetString(new byte[] {
                    (byte)(item+97-65)
                });
                }
                else if (item >= 97 && item <= 128)
                {
                    result += new ASCIIEncoding().GetString(new byte[] {
                    item
                });
                }
            }*/
        }
    }
}