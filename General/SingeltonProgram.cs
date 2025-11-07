using System;
using System.Collections.Generic;
using System.Linq;

namespace General
{
    //ctrl + k + f // to indent
    internal class SingletonProgram
    {

        public class Singleton
        {
            private static Singleton _instance;

            private static Object _synObject = new object();

            public static Singleton Instance
            {
                get
                {
                    // First check (no lock) — fast path for already-created instance
                    if (_instance == null)
                    {
                        lock (_synObject)
                        {
                            // Second check (with lock) — ensures only one thread creates the instance
                            if (_instance == null)
                            {
                                _instance = new Singleton();
                            }
                        }
                    }
                    return _instance;
                }
            }

            protected Singleton()
            {

            }
        }

        public class SingeltonLogger
        {
            private static SingeltonLogger _instance;
            private static readonly object _lock = new();
            private SingeltonLogger() { }
            public static SingeltonLogger Instance
            {
                get
                {
                    if (_instance == null)
                    {
                        lock (_lock)
                        {
                            if (_instance == null)
                                _instance = new SingeltonLogger();
                        }
                    }
                    return _instance;
                }
            }
            public void Log(string msg) => Console.WriteLine(msg);
        }

        public class DerivedSingleton : Singleton
        {

        }

        //Simpler safer: use static ctor (implicit) and sealed !
        public sealed class SimplerSaferSingleton
        {
            private static readonly SimplerSaferSingleton _instance = new SimplerSaferSingleton();
            private SimplerSaferSingleton() { }

            public static SimplerSaferSingleton Instance => _instance;
        }

        /*
        static void Main(string[] args)
        {

            var singelton = Singelton.SingeltonInstance;
            var singelton2 = Singelton.SingeltonInstance;
            var derivedSingelton = DerivedSingelton.SingeltonInstance;

            if (singelton == singelton2 && singelton  == derivedSingelton)
            {
                Console.WriteLine("Succeeded!");
            }
            else
            {
                Console.WriteLine("Failed!");
            }

        }*/
    }
}
