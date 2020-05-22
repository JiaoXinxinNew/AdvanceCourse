using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsyncThread
{
    public partial class Form1 : Form
    {
        public static readonly object threadLock = new object(); 
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine($"*********按钮线程开始{Thread.CurrentThread.ManagedThreadId.ToString()}**********");
            ThreadStart threadStart = () =>
            {
                Console.WriteLine("异步线程开始" + Thread.CurrentThread.ManagedThreadId.ToString());
                this.ComputStr();
                Console.WriteLine("异步线程结束");
            };
            ParameterizedThreadStart parameterizedThreadStart = a => Console.WriteLine(a);
            Thread thread = new Thread(threadStart);
            thread.Start();
            thread.Join();
            Console.WriteLine($"*************按钮线程结束{Thread.CurrentThread.ManagedThreadId.ToString()}************");
        }
        private void ComputStr()
        {
            string s = "123";
            string result = null;
            for (int i = 0; i < 100000; i++)
            {
                result += s;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Console.WriteLine("线城池开始");
            //ThreadPool.GetMaxThreads(out int workerThreads, out int completionPortThreads);

            //ThreadPool.SetMaxThreads(100, 100);
            //ThreadPool.SetMinThreads(5, 5);
            //ThreadPool.GetMinThreads(out int workerThreads1, out int completionPortThreads1);
            //Console.WriteLine($"{workerThreads}:{completionPortThreads}:{workerThreads1}:{completionPortThreads1}");

            //ManualResetEvent manualResetEvent = new ManualResetEvent(false);
            //ThreadPool.QueueUserWorkItem(a=>
            //{
            //    Console.WriteLine("异步线程开始");
            //    ComputStr();
            //    Console.WriteLine("异步线程结束");
            //    manualResetEvent.Set();
            //    manualResetEvent.Reset();
            //});
            //manualResetEvent.WaitOne();//初始化为false,异步调用设为true时，则该异步线程必须等待完成。反之，当初始化为false时，异步线程中调用Reset();

            Console.WriteLine("线城池结束");
        }

        /// <summary>
        /// 使用线程封装回调函数。
        /// </summary>
        /// <param name="action"></param>
        /// <param name="callBack"></param>
        private void ThreadCallBack(Action action, Action callBack)
        {
            Thread thread = new Thread(() =>
            {
                action.Invoke();//非异步
                callBack.Invoke();//非异步
            });
            thread.Start();
        }
        /// <summary>
        /// 有返回值的线程调用。获取值但不卡线程，所以返回一个委托。调用的时候如果想获取值，直接.Invoke（）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="func"></param>
        /// <returns></returns>
        private Func<T> ThreadWithReturn<T>(Func<T> func)
        {
            T t = default(T);
            Thread thread = new Thread(() =>
              {
                  t = func.Invoke();//
              });
            return () =>
            {
                thread.Join();
                return t;
            };
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Console.WriteLine("主线程开始");
            IList<Custom> tasks = new List<Custom>();
            Custom c1 = Task.Run(() => ComputStr("李四")) as Custom;
            c1.CustomTaskStatus = "李四";
            Custom c2 = Custom.Run(() => ComputStr("张三")) as Custom;
            c1.CustomTaskStatus = "张三";
            Custom c3 = Custom.Run(() => ComputStr("王二")) as Custom;
            c1.CustomTaskStatus = "王二";
            Custom c4 = Custom.Run(() => ComputStr("麻子")) as Custom;
            c1.CustomTaskStatus = "麻子";
            tasks.Add(c1);
            tasks.Add(c2);
            tasks.Add(c3);
            tasks.Add(c4);

            Custom.WhenAny(tasks.ToArray()).ContinueWith(t =>
            {
                Custom custom = t as Custom;
                Console.WriteLine(custom.CustomTaskStatus);
                Console.WriteLine("第一个线程完成。开始歇着");//当第一个任务完成后，第一个任务所使用的的线程回归线程池，WhenAny返回一个Task然后，继续调用ContinueWith开启一个新的线程执行该方法。（类似于完成一个线程后，启用一个回调函数）
            });
            Task.WhenAll(tasks.ToArray()).ContinueWith(t =>
            {
                Console.WriteLine("全部线程完成，开始部署和测试");//当所有任务执行完成后，所有任务的线程回归线程池，WhenAll返回一个TTask,然后继续调用ContinueWith开启一个新的线程执行该方法。
            });
            TaskFactory taskFactory = Task.Factory;
            taskFactory.ContinueWhenAll(tasks.ToArray(), t =>
             {
                 Console.WriteLine("第一个线程完成。开始歇着");//当第一个任务完成后，第一个任务所使用的的线程回归线程池，WhenAny返回一个Task然后，继续调用ContinueWith开启一个新的线程执行该方法。（类似于完成一个线程后，启用一个回调函数）
             });
            //使用10个线程完成1000个任务
            //List<int> list = new List<int>();
            //for (int i = 0; i < 1000; i++)
            //{
            //    list.Add(i);
            //};
            //List<Task> tasks = new List<Task>();
            //Action action = () =>
            //{
            //    Console.WriteLine($"启动一个线程，线程ID{Thread.CurrentThread.ManagedThreadId.ToString("00")}");
            //    Thread.Sleep(new Random().Next(50, 100));
            //};
            //foreach (var item in list)
            //{
            //    tasks.Add(Task.Run(() => action.BeginInvoke(null, null)));
            //    if (tasks.Count > 10)
            //    {
            //        Task.WaitAny(tasks.ToArray());
            //        tasks = tasks.Where(t => t.Status != TaskStatus.RanToCompletion).ToList();
            //    }
            //}
            //TaskFactory taskFactory = Task.Factory;
            //List<Task> tasks = new List<Task>();
            //tasks.Add(taskFactory.StartNew(o => ComputStr("张三"), "张三线程标志"));
            //tasks.Add(taskFactory.StartNew(o => ComputStr("李四"), "李四线程标志"));
            //tasks.Add(taskFactory.StartNew(o => ComputStr("王二"), "王二线程标志"));
            //taskFactory.ContinueWhenAny(tasks.ToArray(), t =>
            //{
            //    Console.WriteLine(t.AsyncState);
            //    Console.WriteLine("第一个"+Thread.CurrentThread.ManagedThreadId.ToString());
            //});
            Console.WriteLine("主线程结束");
        }
        private void ComputStr(string str)
        {
            string result = null;
            for (int i = 0; i < 100000; i++)
            {
                result += str;
            }
            Console.WriteLine($"{str}在干活，使用线程【{Thread.CurrentThread.ManagedThreadId.ToString()}】");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Console.WriteLine("线程开始");
            //Parallel.Invoke(() => ComputStr("张三"), () => ComputStr("李四"), () => ComputStr("王二"));
            //Parallel.For(1, 6, i => { ComputStr("张三"); Console.WriteLine(i); });
            //Parallel.ForEach(new int[] { 1, 2, 3, 4 }, i =>  { ComputStr("张三"); Console.WriteLine(i); });
            //ParallelOptions parallelOptions = new ParallelOptions();
            //parallelOptions.MaxDegreeOfParallelism = 3;
            //Parallel.For(1, 5, parallelOptions, i => { ComputStr("张三"); Console.WriteLine(i); });
            //Parallel.For(0, 40, (i, state) =>
            //{
            //    if (i == 2)
            //    {
            //        state.Break();
            //        return;//必须带上
            //    }
            //    if (i == 20)
            //    {
            //        state.Stop();
            //        return;
            //    }
            //});
            try
            {

            }
            catch (AggregateException aex)
            {
                foreach (var item in aex.InnerExceptions)
                {
                    Console.WriteLine(item.Message);
                }
                throw;
            }
            Console.WriteLine("线程结束");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Console.WriteLine("线程开始");

            #region MyRegion 线程取消

            //CancellationTokenSource cts = new CancellationTokenSource();
            //TaskFactory taskFactory = Task.Factory;
            //List<Task> tasks = new List<Task>();
            //try
            //{

            //    for (int i = 0; i < 40; i++)
            //    {
            //        string name = $"第{i}个线程";
            //        Action<object> action = t =>
            //        {
            //            try
            //            {
            //                Thread.Sleep(200);
            //                if (t.ToString().Equals("第5个线程"))
            //                {
            //                    Console.WriteLine("第5个线程异常");
            //                    throw new Exception("第5个线程异常");
            //                }
            //                if (t.ToString().Equals("第6个线程"))
            //                {
            //                    Console.WriteLine("第6个线程异常");
            //                    throw new Exception("第6个线程异常");
            //                }
            //                if (cts.IsCancellationRequested)
            //                {
            //                    Console.WriteLine($"{t}放弃执行");
            //                    return;
            //                }
            //                Console.WriteLine($"{t}执行成功");
            //            }
            //            catch (Exception ex)
            //            {
            //                cts.Cancel();
            //                Console.WriteLine(ex.Message);
            //            }
            //        };
            //        tasks.Add(taskFactory.StartNew(action, name, cts.Token));
            //    }
            //    Task.WaitAll(tasks.ToArray());
            //}
            //catch (AggregateException aex)
            //{
            //    foreach (var item in aex.InnerExceptions)
            //    {
            //        Console.WriteLine(item.Message);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
            #endregion

            #region 临时变量
            //for (int i = 0; i < 5; i++)
            //{
            //    int k = i;
            //    Task.Run(() =>
            //    {
            //        Thread.Sleep(100);
            //        Console.WriteLine(k);
            //    });
            //}

            #endregion

            #region 线程安全
            int TotalCountInt = 0;
            List<int> intList = new List<int>();
            List<Task> tasks = new List<Task>();
            TaskFactory taskFactory = Task.Factory;
            for (int i = 0; i < 10000; i++)
            {
                int newI = i;
               
                tasks.Add(taskFactory.StartNew(() =>
                {
                    lock (threadLock)
                    {
                        Monitor.Enter(threadLock);
                        TotalCountInt += 1;
                        intList.Add(i);
                        Monitor.Exit(threadLock);

                    }
                    string lockStr="LockString";
                    string lockStrNew = "LockString";
                    lock (lockStr)
                    {

                    }
                    lock (lockStrNew)
                    {

                    }
                }));
            }
            Task.WaitAll(tasks.ToArray());
            Console.WriteLine(TotalCountInt);
            Console.WriteLine(intList.Count);
            #endregion
            Console.WriteLine("线程结束");
        }

        private async void button5_Click(object sender, EventArgs e)
        {
            Console.WriteLine("AsyncAwait按钮被点击，主线程开始"+Thread.CurrentThread.ManagedThreadId.ToString());
           await AsyncAwaitTest();
            Console.WriteLine("方法执行完成");
            Task task = Task.Run(() =>
              {
                  Console.WriteLine("按钮异步开始");
                  Thread.Sleep(1000);
                  Console.WriteLine("按钮异步结束");
              });
            await task;
            Console.WriteLine("AsyncAwait，主线程结束" + Thread.CurrentThread.ManagedThreadId.ToString());

        }
        private async Task AsyncAwaitTest()
        {
            int i = 0;
            Console.WriteLine("AsyncAwait进入" + Thread.CurrentThread.ManagedThreadId.ToString());
           Task task= Task.Run(() =>
            {
                Console.WriteLine("AsyncAwait“异步”进入" + Thread.CurrentThread.ManagedThreadId.ToString());
                Thread.Sleep(1000);
                Console.WriteLine("AsyncAwait“异步”结束" + Thread.CurrentThread.ManagedThreadId.ToString());
            });
            await task;
            Thread.Sleep(400);
            Console.WriteLine("AsyncAwiait方法结束" + Thread.CurrentThread.ManagedThreadId.ToString());
        }
    }
    
    public class Custom : Task
    {
        //    Console.WriteLine("线程开始");

        //        Console.WriteLine("线程结束");
        public string CustomTaskStatus { get; set; }
        public Custom(Action action) : base(action)
        {
        }

        public Custom(Action action, CancellationToken cancellationToken) : base(action, cancellationToken)
        {
        }

        public Custom(Action action, TaskCreationOptions creationOptions) : base(action, creationOptions)
        {
        }

        public Custom(Action<object> action, object state) : base(action, state)
        {
        }

        public Custom(Action action, CancellationToken cancellationToken, TaskCreationOptions creationOptions) : base(action, cancellationToken, creationOptions)
        {
        }

        public Custom(Action<object> action, object state, CancellationToken cancellationToken) : base(action, state, cancellationToken)
        {
        }

        public Custom(Action<object> action, object state, TaskCreationOptions creationOptions) : base(action, state, creationOptions)
        {
        }

        public Custom(Action<object> action, object state, CancellationToken cancellationToken, TaskCreationOptions creationOptions) : base(action, state, cancellationToken, creationOptions)
        {
        }
    }
}
