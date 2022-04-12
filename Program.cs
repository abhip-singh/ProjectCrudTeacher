using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class Program
    {
        static void Main(string[] args)
        {
    label:  Console.WriteLine("Press (1) To Enter Records  (2) To Update Records  (3) To Delete Records (4) To Display All Records");
            int choice=Convert.ToInt32(Console.ReadLine());
            TeachRecords tr = new TeachRecords();
            switch (choice)
            {
                //Objects used
                //tid = Teacher Id
                //tname = Teacher Name
                //tsec = section and class
                case 1:
                    Console.Write("Enter Teacher ID (All ID's must be unique):");
                    int tid = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter Teacher Name:");
                    string tname = Console.ReadLine();
                    Console.Write("Enter Class and Section:");
                    string tsec = Console.ReadLine();
                    tr.addteach(new Teacher { TeachId = tid, TeachName = tname, TeachSec = tsec });
                    break;
                case 2:
                    Console.WriteLine("Enter the ID to be updated");
                    int tid3 = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter details for update, First with ID");
                    int tid1 = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter Teacher Name:");
                    string tname1 = Console.ReadLine();
                    Console.Write("Enter Class and Section:");
                    string tsec1 = Console.ReadLine();
                    tr.addteach(new Teacher { TeachId = tid1, TeachName = tname1, TeachSec = tsec1 });
                    tr.delteach(tid3);
                    break;
                case 3:
                    Console.WriteLine("Enter Teacher ID to delete that particular record");
                    int tid2 = Convert.ToInt32(Console.ReadLine());
                    tr.delteach(tid2);
                    break;
                case 4:
                    tr.DisplayRecords();
                    break;
                default:
                    Console.WriteLine("Enter Correct Choice");
                    break;
            }
            Console.WriteLine("Do You Want to Continue:(yes/no)?");
            string response = Console.ReadLine();
            if (response.ToLowerInvariant() == "yes")
            {
                goto label;
            }
            Console.ReadLine();
        }
    }
}