using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class TeachRecords
    {
        public void addteach(Teacher teach)
        {       
                string path = Environment.CurrentDirectory;
                FileInfo fileInfo = new FileInfo(path +"\\Teacher Records.txt");
                using (StreamWriter streamWriter = new StreamWriter(fileInfo.FullName,append: true))
                {
                    streamWriter.WriteLine($"{teach.TeachId}\t{teach.TeachName}\t{teach.TeachSec}");
                    streamWriter.Flush();
                }
        }
        public void delteach(int teacherid)
        {
            //How delete works - make a list of all strings present in file
            //Match the string.id with the id you want to delete
            //Delete that record 
            //Now rewrite the list of all strings
            List<Teacher> teachers = new List<Teacher>();
            string path = Environment.CurrentDirectory;
            FileInfo fileInfo = new FileInfo(path + "\\Teacher Records.txt");
            string[] lines = File.ReadAllLines(fileInfo.FullName);
            
            foreach(var line in lines)
            {
                Teacher t1 = new Teacher();
                string[] values = line.Split('\t');
                t1.TeachId = Convert.ToInt32(values[0]);
                t1.TeachName = values[1];
                t1.TeachSec = values[2];
                teachers.Add(t1); // adding each record at the end of list 
            }
            if(teachers!=null)
            {
                var IdDelete = teachers.Where(x => x.TeachId == teacherid).FirstOrDefault();
                teachers.Remove(IdDelete);
                fileInfo.Delete();
                foreach(var teach in teachers)
                {
                    addteach(teach);
                }
            }

        }
        public void DisplayRecords()
        {
            string path = Environment.CurrentDirectory;
            string[] lines = System.IO.File.ReadAllLines(path + "\\Teacher Records.txt");
            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }
        }
    }
}

