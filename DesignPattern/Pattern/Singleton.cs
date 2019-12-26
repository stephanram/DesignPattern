using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Pattern
{

    public static class Singleton
    {
        public static void Init()
        {
            #region basic
            /*
            var employee = ThreadUnsafeSingleton.GetInstanceProperty; //Singleton.GetInstance(); 
            employee.PrintDetails("Employee");

            var student = ThreadUnsafeSingleton.GetInstanceProperty; //Singleton.GetInstance(); 
            student.PrintDetails("student");
            */
            #endregion

            #region MultiThreadIssue
            /*
            Parallel.Invoke(() => PrintEmployee(), () => PrintStudent());
            */
            #endregion

            #region MultiThreadIssue
            /*
            Parallel.Invoke(() => PrintEmployee(), () => PrintStudent());
            */
            #endregion

            #region MultiThreadIssueLazy
            Parallel.Invoke(() => PrintEmployeeLazy(), () => PrintStudentLazy());
            #endregion

        }

        public static void PrintEmployee()
        {
            var employee = ThreadUnsafeSingleton.GetInstanceProperty; //Singleton.GetInstance(); 
            employee.PrintDetails("Employee");
        }

        public static void PrintStudent()
        {
            var student = ThreadUnsafeSingleton.GetInstanceProperty; //Singleton.GetInstance(); 
            student.PrintDetails("student");
        }

        public static void PrintEmployeeLazy()
        {
            var employee = ThreadSafetySingletonLazy.GetInstanceProperty; //Singleton.GetInstance(); 
            employee.PrintDetails("Employee");
        }

        public static void PrintStudentLazy()
        {
            var student = ThreadSafetySingletonLazy.GetInstanceProperty; //Singleton.GetInstance(); 
            student.PrintDetails("student");
        }

    }

    public sealed class ThreadUnsafeSingleton
    {
        private static ThreadUnsafeSingleton singleton = null;
        private static int counter = 0;

        private ThreadUnsafeSingleton()
        {
            counter++;
            Console.WriteLine($"Instance Created So far - {counter}");
        }

        //Through Get Property
        public static ThreadUnsafeSingleton GetInstanceProperty
        {
            get
            {
                if (singleton == null)
                {
                    singleton = new ThreadUnsafeSingleton();
                }
                else
                {
                    return singleton;
                }

                return singleton;
            }
        }

        public void PrintDetails(string message)
        {
            Console.WriteLine($"Input message - {message}");
        }
    }

    public sealed class ThreadSafetySingleton
    {
        private static ThreadSafetySingleton singleton = null;
        private static int counter = 0;
        private static readonly object obj = new object();

        private ThreadSafetySingleton()
        {
            counter++;
            Console.WriteLine($"Instance Created So far - {counter}");
        }

        //Through Get Property
        public static ThreadSafetySingleton GetInstanceProperty
        {
            get
            {
                if (singleton == null)
                {
                    if (singleton == null)
                    {
                        lock (obj)
                        {
                            singleton = new ThreadSafetySingleton();
                        }
                    }

                }
                return singleton;
            }
        }

        public void PrintDetails(string message)
        {
            Console.WriteLine($"Input message - {message}");
        }
    }

    public sealed class ThreadSafetySingletonLazy
    {
        private static Lazy<ThreadSafetySingletonLazy> singleton = new Lazy<ThreadSafetySingletonLazy>(()=> new ThreadSafetySingletonLazy());
        private static int counter = 0;

        private ThreadSafetySingletonLazy()
        {
            counter++;
            Console.WriteLine($"Instance Created So far - {counter}");
        }

        //Through Get Property
        public static ThreadSafetySingletonLazy GetInstanceProperty
        {
            get
            {
                return singleton.Value;
            }
        }

        public void PrintDetails(string message)
        {
            Console.WriteLine($"Input message - {message}");
        }
    }
}
