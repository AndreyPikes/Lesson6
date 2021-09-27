using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SApp03
{

    class Sample
    {
        public static void SampleMethod()
        {
            //Sample sample = new Sample();
            //sample.SampleMethodV2();
            SampleMethodV3();
        }

        public static void SampleMethodV3()
        {
        }

        public void SampleMethodV2()
        {

        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Sample.SampleMethod();

            Sample sample01 = new Sample();
            sample01.SampleMethodV2();
        }
    }
}
