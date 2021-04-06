using System;
using System.IO;
using System.Linq;
using System.Text;

namespace Schoolprocess
{
    class Program
    {

        int id;
        string name;
        int  clas;
        char section;
        string split = "|";
        string path = @"C:\Users\Ravii\Desktop\file.txt";
        String temp = @"C:\Users\Ravii\Desktop\temp.txt";

        public void storedata()
        {
            try
            {
                Console.WriteLine("How many records you want to insert");
                int num = int.Parse(Console.ReadLine());
                for (int i = 0; i < num; i++)
                {
                    Console.Write("Enter the Student id:");
                    id = int.Parse(Console.ReadLine());
                    Console.Write("Enter the name:");
                    name = Console.ReadLine();
                    Console.Write("Enter the class:");
                    clas = int.Parse(Console.ReadLine());
                    Console.Write("Enter the section:");
                    section = char.Parse(Console.ReadLine());
                    using (StreamWriter sw = new StreamWriter(path, true))
                    {
                        sw.Write(id);
                        sw.Write(split);
                        sw.Write(name);
                        sw.Write(split);
                        sw.Write(clas);
                        sw.Write(split);
                        sw.Write(section);
                        sw.Write(split);
                        sw.WriteLine();


                    }
                    Console.WriteLine("record inserted sucessfully");

                }
            }

            catch (FormatException)
            {
                Console.WriteLine("Please enter the correct value ID : Numbers , Name : Characters , Class:Numbers and section : Charcters ");
            }
        }



        public void updatedata()
        {
            Console.WriteLine("Enter the ID on which you want to perform the update");
            int userchoice = int.Parse(Console.ReadLine());
            try { 
            //read all text file to string of array 
            string[] lines = File.ReadAllLines(path);
            //read all the file until lenghth of file 
            for (int i = 0; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(split);
                if (Convert.ToInt32(parts[0]) == userchoice)

                {
                    Console.Write("Enter the name you want to update :");
                    string name1 = Console.ReadLine();
                    Console.Write("enter the clas you want to update:");
                    string  clas1 = Console.ReadLine();
                    Console.Write("Enter the section you want to update:");
                    string section1 = Console.ReadLine();
                    parts[0] = parts[0];
                    parts[1] = name1;
                    parts[2] = clas1;
                    parts[3] = section1;
                    using (StreamWriter sw = new StreamWriter(temp, true))
                    {
                        sw.Write(parts[0]);
                        sw.Write(split);
                        sw.Write(parts[1]);
                        sw.Write(split);
                        sw.Write(parts[2]);
                        sw.Write(split);
                        sw.Write(parts[3]);
                        sw.Write(split);
                        sw.WriteLine();
                    }
                    Console.WriteLine("record updated sucessfully");
                }
                else
                {

                    using (StreamWriter sw = new StreamWriter(temp, true))
                    {
                        sw.Write(parts[0]);
                        sw.Write(split);
                        sw.Write(parts[1]);
                        sw.Write(split);
                        sw.Write(parts[2]);
                        sw.Write(split);
                        sw.Write(parts[3]);
                        sw.Write(split);
                        sw.WriteLine();
                    }

                }
            
            }
           
            File.Delete(path);
            System.IO.File.Move(temp, path);
        }


            catch (FormatException)
            {
                Console.WriteLine("Please enter the correct value ID : Numbers , Name : Characters , Class:Numbers and section : Charcters ");
            }

        }
            
            //delete the file and move the data from temp file to file path  
        class implementation
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Enter the operation you want to perform 1. Storedata 2.updatedata");
                int read = int.Parse(Console.ReadLine());
                Program p1 = new Program();
                if (read == 1)
                    p1.storedata();
                else if (read == 2)
                    p1.updatedata();
                else
                    Console.WriteLine("Choose the correct operation you want to perform , Value entered is invalid");

            }
        }

    }
}




    