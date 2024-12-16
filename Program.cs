using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лаба3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] files =
            { "10.txt", "11.txt", "12.txt" , "13.txt"
                 , "14.txt" , "15.txt", "16.txt", "17.txt" , "18.txt",
                "19.txt", "20.txt", "21.txt","22.txt","23.txt","24.txt" ,"25.txt"
            };
            List <string> nofile = new List<string>();
            List<string > badData = new List<string>();
            List<string>overflow=new List<string>();
            List<int> result = new List<int>();
            foreach (string file in files)
            {
                try
                {
                    var lines = File.ReadAllLines(file);
                    if (lines.Length < 2)
                    {
                        throw new Exception();
                    }
                    int number1 = int.Parse(lines[0]);
                    int number2 = int.Parse(lines[1]);
                    checked
                    {
                        result.Add(number1 * number2);
                    }


                }
            catch(FileNotFoundException)
                {

                    nofile.Add(file);
                   
                }
                catch (FormatException)
                {
                    Console.WriteLine($"Невірний формат даних у файлі: {file}");
                }
                catch (OverflowException)
                {
                    Console.WriteLine($"Переповнення в файлі: {file}");
                }
            }
            try
            {
                File.WriteAllLines("no_file.txt", nofile);
                File.WriteAllLines("bad_data.txt", badData);
                File.WriteAllLines("overflow.txt", overflow);
            }
            catch
            {
                Console.WriteLine("Не вдалося створити вихідні файли!");
                return;
            }
            if (result.Count > 0)
            {
                double average = result.Sum() / (double)result.Count;
                Console.WriteLine($"Середнє арифметичне добутків: {average}");
            }
            else
            {
                Console.WriteLine("Не вдалося обчислити жодного добутку.");
            }




        }
    }
}
