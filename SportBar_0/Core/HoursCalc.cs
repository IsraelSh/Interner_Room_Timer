using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;
using System.Xml.Serialization;

namespace SportBar_0.Core
{

    /// <summary>
    /// This class calculates the cost based on the duration spent at the sports bar.
    /// </summary>
    public class HoursCalc
    {

        // Arrays to store start and end times (consider using a List<DateTime> for dynamic sizing if needed)

        public static DateTime[] date1 = new DateTime[15];
        public static DateTime[] date3 = new DateTime[15];

        // Array to store calculated sums (consider using a List<float> for dynamic sizing if needed)
        public static float[] sum = new float[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,0 };


        // Prices for different time ranges, retrieved from Settings1.Default (consider using a dedicated class for prices if needed)
        public static int price1 = Settings1.Default.price1;  // Price for the first range (0 - 15 minutes)
        public static int price2 = Settings1.Default.price2;  // Price for the second range (15 - 30 minutes)
        public static int price3 = Settings1.Default.price3; // Price for the third range (30 - 45 minutes)
        public static int price4 = Settings1.Default.price4; // Price for the fourth range (45 - 60 minutes)



        /// <summary>
        /// Initializes an instance of the HoursCalc class.
        /// </summary>
        public HoursCalc()
        {

        }


        /// <summary>
        /// Allows changing the prices for different time ranges.
        /// </summary>
        /// <param name="p1">Price for the first range (0 - 15 minutes)</param>
        /// <param name="p2">Price for the second range (15 - 30 minutes)</param>
        /// <param name="p3">Price for the third range (30 - 45 minutes)</param>
        /// <param name="p4">Price for the fourth range (45 - 60 minutes)</param>

        public void PriceChenge(int p1=6,int p2=10,int p3=14, int p4=16 )
        {
            price1 = p1;
            price2 = p2;
            price3 = p3;   
            price4 = p4;
        }


       
        public DateTime[] DateStart { get { return date1; } set { date1 = value; } }

        public DateTime[] DateEnd { get { return date3; } set { date3 = value; } }

        public float[] Sum { get { return sum; } set { sum = value; } }


        /// <summary>
        /// Calculates the cost based on the provided start and end times using a tiered pricing structure.
        /// </summary>
        /// <param name="TimeStart">Start date and time</param>
        /// <param name="TimeEnd">End date and time</param>
        /// <returns>The total cost for the duration spent</returns>
        static public int Func1(DateTime TimeStart ,DateTime TimeEnd )
        {
            TimeSpan ts = TimeEnd - TimeStart;
            var num = ts.TotalMinutes-3;
            int sum = 0;
           


            while (num  > 1)
            {


                if (num <= 15 && num > 0)
                { sum += price1; num -= 15; };
                if (num <= 30 && num > 0)
                { sum += price2; num -= 30; };
                if (num <= 45 && num > 0)
                { sum += price3; num -= 45; };
                if (num <= 60 && num > 0)
                { sum += price4; num -= 60; }

                else if (num > 0) { sum  += price4; num -= 60; }
            }
            return sum;


        }

        /// <summary>
        /// Calculates a simplified cost based on the provided start and end times, assuming a flat rate per 5 minutes.
        /// (Consider using this function for a simpler pricing model or as a base for more complex calculations)
        /// </summary>
        /// <param name="TimeStart">Start date and time</param>
        /// <param name="TimeEnd">End date and time</param>
        /// <returns>The total simplified cost for the duration spent</returns>

        static public int Func2(DateTime TimeStart, DateTime TimeEnd)
        {

            TimeSpan ts = TimeEnd - TimeStart;
            var num = ts.TotalMinutes - 5;
            int sum = 0;


            while (num > 1)
            {


                if (num <= 15 && num > 0)
                { sum += 5; num -= 15; };
                if (num <= 30 && num > 0)
                { sum += 10; num -= 30; };
                if (num <= 45 && num > 0)
                { sum += 15; num -= 45; };
                if (num <= 60 && num > 0)
                { sum += 20; num -= 60; }

                else if (num > 0) // Handles remaining minutes beyond 60
                { sum += 20; num -= 60; }
            }
            return sum;


        }






        /// <summary>
        /// Saves the current state of the HoursCalc object (including prices and arrays) to a file using XML serialization.
        /// </summary>
        /// <param name="fileName">The name of the file to save to.</param>

        public void Save(string fileName)
        {
           

            using (var stream = new FileStream(fileName, FileMode.Create))
            {
                XmlSerializer XML = new XmlSerializer(typeof(HoursCalc));
                XML.Serialize(stream, this);
                stream.Close(); 
            };
         }


        /// <summary>
        /// Loads the state of the HoursCalc object (including prices and arrays) from a file using XML deserialization.
        /// </summary>
        /// <param name="fileName">The name of the file to load from.</param>
        /// <returns>A new HoursCalc object populated with the loaded data.</returns>
        public static HoursCalc LoadFromFile(string fileName)
        {
           
            

            using (var stream = new FileStream(fileName, FileMode.Open))
            {
                var XML = new XmlSerializer(typeof(HoursCalc));

                return (HoursCalc)XML.Deserialize(stream);
            };

        }


    }
}
















//public HoursCalc(DateTime date3)
//{
//    this.dateEnd = date3;

//}

//DateTime date3 = DateTime.Now;


// string hour = Console.ReadLine();
// string minute = Console.ReadLine();


//  DateTime date2 = new DateTime(y, m, d, int.Parse(hour), int.Parse(minute), 00);
//  Console.WriteLine("No. of Hours (Difference) = {0}", ts.TotalHours);
//Console.WriteLine("No. of Minute (Difference) = {0}", ts.TotalMinutes);










//XmlSerializer ser = new XmlSerializer(typeof(DataSet));



//DataSet ds = new DataSet("myDataSet");
//DataTable t = new DataTable("table1");
//DataColumn c = new DataColumn("thing");
//t.Columns.Add(c);
//ds.Tables.Add(t);
//DataRow r;
//for (int i = 0; i < 10; i++)
//{
//    r = t.NewRow();
//    r[0] = "Thing " + i;
//    t.Rows.Add(r);
//}
//TextWriter writer = new StreamWriter(fileName);
//ser.Serialize(writer, ds);
//writer.Close();







// public static DateTime date1;
// public static DateTime date3;