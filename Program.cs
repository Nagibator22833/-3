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
           
            var noFile = new FileStream(@"C:\Лаби ооп\Лаба3\bin\Debug\no_file.txt", FileMode.Open);
            var badData = new FileStream(@"C:\Лаби ооп\Лаба3\bin\Debug\bad_data.txt", FileMode.Open);
            var overflow = new FileStream(@"C:\Лаби ооп\Лаба3\bin\Debug\overflow.txt", FileMode.Open);
            var noFileWriter = new StreamWriter(noFile);
            var badDataWriter = new StreamWriter(badData);
            var overflowWriter = new StreamWriter(overflow);

            double result = 0;
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
                    noFileWriter.WriteLine($"{i}.txt");
                    Console.WriteLine($"Файл не знайдено: {i}.txt");
                }
                catch (FormatException)
                {
                    badDataWriter.WriteLine($"{i}.txt");
                    Console.WriteLine($"Невірний формат даних у файлі: {i}.txt");
                }
                catch (OverflowException)
                {
                   overflowWriter.WriteLine($"{i}.txt");
                    Console.WriteLine($" Переповнення у файлі: {i}.txt");
                }
                catch
                {
                    Console.WriteLine("Не вдалося відкрити вихідні файли!");
                }
            }
            noFileWriter.Close();
            badDataWriter.Close();
            overflowWriter.Close();
            Console.WriteLine(result/count);
        }
    }
}
