using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment8_Part1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string constr = "server=DESKTOP-VQHITSP;database=Day8Db;trusted_connection=true;";
            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = @"
                INSERT INTO Products (Pid, PName, PPrice, MfgDate, ExpDate)
                VALUES
                ('P00001', 'Jam', 75, '12/12/23', '06/12/24'),
                ('P00002', 'Biscuits', 30, '12/11/23', '12/10/24'),
                ('P00003', 'Ice-Cream', 20, '12/10/23', '06/12/24'),
                ('P00004', 'Chips', 15, '12/09/23', '06/12/24'),
                ('P00005', 'Soap', 55, '12/11/23', '10/10/24'),
                ('P00006', 'Shampoo', 150, '10/10/23', '06/10/24'),
                ('P00007', 'FaceWash', 230, '11/08/23', '07/11/24'),
                ('P00008', 'ShowerGel', 270, '09/09/23', '06/12/24'),
                ('P00009', 'Chocolate', 20, '07/11/23', '12/09/24'),
                ('P00010', 'Mint', 50, '06/10/23', '12/10/24')";

                    cmd.ExecuteNonQuery();
                }

                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = @"
                    SELECT TOP 5 Pid, PName, PPrice, MfgDate, ExpDate
                    FROM Products
                    ORDER BY PName DESC";

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        Console.WriteLine("Top 5 Products:");
                        Console.WriteLine("-------------------------------------------------");
                        Console.WriteLine("Pid\t\tPName\t\tPPrice\t\tMfgDate\t\tExpDate");
                        Console.WriteLine("-------------------------------------------------");

                        while (reader.Read())
                        {
                            Console.WriteLine(reader["Pid"]+ "\t\t"+ reader["PName"]+"\t\t"+reader["PPrice"]+ "\t\t"+reader["MfgDate"]+ "\t\t"+reader["ExpDate"]);
                        }
                    }
                }
                Console.ReadKey();
            }
        }
    }
}
