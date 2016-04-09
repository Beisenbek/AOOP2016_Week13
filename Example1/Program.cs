using MyLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Example1
{
    class Program
    {
        static void Main(string[] args)
        {
            F5();
        }


        private static void F5()
        {
            while (true)
            {
                DirectoryInfo dir = new DirectoryInfo(@"C:\libs\");
                FileInfo[] f = dir.GetFiles("*.dll");

                foreach (var x in f)
                {
                    Console.WriteLine("observing " + x.FullName);

                    var list = Assembly.LoadFrom(x.FullName).GetTypes();

                    foreach (var t in list)
                    {
                        Console.WriteLine(t.Name);
                    }
                }

                Console.ReadKey();
                Console.Clear();
            }
            
        }
        private static void F4()
        {
            var list = Assembly.LoadFrom(@"C:\libs\MyLib2.dll").GetTypes();

            foreach (var x in list)
            {
                Console.WriteLine(x.Name);
            }
        }

        private static void F3()
        {
            F f = new F();
            Console.WriteLine(f.GetInfo());   
        }

        private static void F2()
        {
            var list = Assembly.GetExecutingAssembly().GetTypes();

            foreach(var x in list)
            {
                if(x.IsClass && x.Namespace.Equals("Example1"))
                {
                    var infs = x.GetInterfaces();

                    bool ok = false;

                    foreach(var i in infs)
                    {
                        if (i.Name.Contains("IGetInfo"))
                        {
                            ok = true;
                            break;
                        }
                    }

                    if (ok)
                    {
                        IGetInfo o = Activator.CreateInstance(x) as IGetInfo;
                        Console.WriteLine(o.GetInfo());
                    }
                }
            }
            
            //q.ToList().ForEach(t => Console.WriteLine(t.Name));
        }

        private static void F1()
        {
            List<IGetInfo> list = new List<IGetInfo>();
            list.Add(new A());
            list.Add(new B());
            list.Add(new C());
            list.Add(new D());

            foreach (IGetInfo x in list)
            {
                Console.WriteLine(x.GetInfo());
            }
        }
    }

    interface IGetInfo
    {
        string GetInfo();
    }

    class A : IGetInfo
    {
        public string GetInfo()
        {
            return "Info: A";
        }
    }

    class B : IGetInfo
    {
        public string GetInfo()
        {
            return "Info: B";
        }
    }

    class C : IGetInfo
    {
        public string GetInfo()
        {
            return "Info: C";
        }
    }

    class D : IGetInfo
    {
        public string GetInfo()
        {
            return "Info: D";
        }
    }

    class E : IGetInfo
    {
        public string GetInfo()
        {
            return "Info: E";
        }
    }


}
