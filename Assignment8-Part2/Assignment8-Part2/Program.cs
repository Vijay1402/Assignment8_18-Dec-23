using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment8_Part2
{
    internal class Program
    {
        static DataTable Create()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("PId", typeof(int));
            dt.Columns.Add("Pname", typeof(string));
            dt.Columns.Add("PPrice", typeof(float));
            dt.Columns.Add("MfgDate", typeof(DateTime));
            dt.Columns.Add("ExpDate", typeof(DateTime));
            dt.PrimaryKey = new DataColumn[] { dt.Columns["Id"] };
            return dt;
        }

        static void Insert(DataTable dt, int id, string pn, float pp, DateTime mfg, DateTime exp)
        {
            DataRow dr = dt.NewRow();
            dr["PId"] = id;
            dr["Pname"] = pn;
            dr["PPrice"] = pp;
            dr["MfgDate"] = mfg;
            dr["ExpDate"] = exp;
            dt.Rows.Add(dr);
        }

        static void Search(DataTable dt, int id)
        {
            DataRow foundRow = dt.Rows.Find(id);
            if (foundRow == null)
            {
                Console.WriteLine($"No such Id{id} exist");
            }
            else
            {
                Console.WriteLine("Record Found Details as follows");
                Console.WriteLine($"PId: \t {foundRow["PId"]}");
                Console.WriteLine($"Pname: \t {foundRow["Pname"]}");
                Console.WriteLine($"PPrice: \t {foundRow["PPrice"]}");
                Console.WriteLine($"MfgDate: \t {foundRow["MfgDate"]}");
                Console.WriteLine($"ExpDate: \t {foundRow["ExpDate"]}");
            }
        }
        static void Delete(DataTable dt, int id)
        {
            DataRow delRow = dt.Rows.Find(id);
            if (delRow == null)
            {
                Console.WriteLine($"No such Id{id} exist");
            }
            else
            {
                dt.Rows.Remove(delRow);
                Console.WriteLine($"Record with Id{id} deleted from Table");
            }
        }
        static void Update(DataTable dt, int id, string pn, float pp, DateTime mfg, DateTime exp)
        {
            DataRow updateRow = dt.Rows.Find(id);
            if (updateRow != null)
            {
                updateRow["Pname"] = pn;
                updateRow["PPrice"] = pp;
                updateRow["MfgDate"] = mfg; 
                updateRow["ExpDate"] = exp;
            }
            else
            {
                Console.WriteLine($"No such Id{id} exist");
            }
        }

        static void Display(DataTable dt)
        {
            Console.WriteLine("Stored Current Data in Table");
            foreach (DataRow row in dt.Rows)
            {
                Console.WriteLine("PId: \t " + row["PId"]);
                Console.WriteLine("Pname: \t " + row["Pname"]);
                Console.WriteLine("PPrice: \t " + row["PPrice"]);
                Console.WriteLine($"MfgDate: \t" + row["MfgDate"]);
                Console.WriteLine($"ExpDate: \t " + row["ExpDate"]);
                Console.WriteLine("-------------------------------- ");
            }
        }
        static void Main(string[] args)
        {
            DataTable dt = Create();
            //Insert
            Insert(dt, 2, "Jam", 75, new DateTime(day: 26, month: 11, year: 2019), new DateTime(day: 26, month: 11, year: 2023));
            Insert(dt, 3, "Sauce", 55, new DateTime(day: 26, month: 11, year: 2019), new DateTime(day: 26, month: 11, year: 2023));
            Insert(dt, 4, "Ketchup", 65, new DateTime(day: 26, month: 11, year: 2019), new DateTime(day: 26, month: 11, year: 2023));
            Display(dt);
            //Delete
            Console.WriteLine("Enter ID to delete the Data Row");
            int DelId = int.Parse(Console.ReadLine());
            Delete(dt, DelId);
            //Search
            Console.WriteLine("Enter ID to search the Data Row");
            int sId = int.Parse(Console.ReadLine());
            Search(dt, sId);
        }
    }
}
