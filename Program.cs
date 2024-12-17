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
            string[] files = Directory.GetFiles(Directory.GetCurrentDirectory());
           
            var noFile = new FileStream(@"C:\Лаби ооп\Лаба3\bin\Debug\no_file.txt", FileMode.Append);
            var badData = new FileStream(@"C:\Лаби ооп\Лаба3\bin\Debug\bad_data.txt", FileMode.Append);
            var overflow = new FileStream(@"C:\Лаби ооп\Лаба3\bin\Debug\overflow.txt", FileMode.Append);
            long result = 0;
            for (int i = 10; i <= 29; i++)
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
                        result.Add((int)number1 * (int)number2);
                        double average = result.Sum() / (double)result.Count;
                        Console.WriteLine($"Середнє арифметичне добутків: {average}");

                    }


                }
            catch(FileNotFoundException)
                {

                    nofile.Add(file);
                   
                }
                catch (FormatException)
                {
                    badData.Add(file);
                    Console.WriteLine($"Невірний формат даних у файлі: {file}");
                }
                catch (OverflowException)
                {
                    overflow.Add(file);
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
           
              
            
           




        }
    }
}
