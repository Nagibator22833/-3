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
            var noFileWriter = new StreamWriter(noFile);
            var badDataWriter = new StreamWriter(badData);
            var overflowWriter = new StreamWriter(overflow);

            long result = 0;
            int count = 0;
            for (int i = 10; i <= 29; i++)
            {
                try
                {
                    using (var fileReader = new StreamReader($@"C:\Лаби ооп\Лаба3\bin\Debug\{i}.txt"))
                    {
                        int number1 = int.Parse(fileReader.ReadLine());
                        int number2 = int.Parse(fileReader.ReadLine());
                        result += checked(number1 * number2);
                    }
                    count++;
                }
                catch(FileNotFoundException)
                {

                    noFile.;
                   
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
