using System;
using System.Globalization;
using System.Threading;

namespace lb5
{
    class Program
    {
        static void Main(string[] args)
        {
            CultureInfo culture = (CultureInfo)CultureInfo.CurrentCulture.Clone();
            culture.DateTimeFormat.ShortDatePattern = "HH-mm-ss yyyy/MM/dd";
            culture.DateTimeFormat.LongTimePattern = "";
            Thread.CurrentThread.CurrentCulture = culture;
            Console.WriteLine(DateTime.Now);
            Console.WriteLine("Hello World!");
            utils.Reader.ReadData();
        }
    }
}
