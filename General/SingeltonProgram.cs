using System;
using System.Collections.Generic;
using System.Linq;

namespace General
{
    //ctrl + k + f // to indent
    internal class SingletonProgram
    {
        
        public class Singelton
        {
            private static Singelton _instance;

            private static Object _synObject = new object();

            public static Singelton SingeltonInstance
            {

                get
                {
                    lock (_synObject)
                    {
                        if (_instance == null)
                        {
                            lock (_synObject)
                            {
                                _instance = new Singelton();
                            }
                        }
                    }
                    return _instance;
                }
            }

            protected Singelton()
            {

            }

        }

        public class DerivedSingelton : Singelton
        {

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
