using System;
using System.IO;

namespace FormattingText
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                WriteLineFile();
                ReadFileLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void WriteLineFile()
        {
            try
            {
                using (var file = new StreamWriter("Data.txt"))
                {
                    var str = AddZeroLeft(1, 6) + AddSpaceRight("Núbio Knupp", 20) + AddZeroLeft(20120411, 8) + "\r\n";
                    str += AddZeroLeft(2, 6) + AddSpaceRight("Neuber Knupp", 20) + AddZeroLeft(20120417, 8) + "\r\n";
                    str += AddZeroLeft(3, 6) + AddSpaceRight("Maria José Knupp", 20) + AddZeroLeft(20120410, 8) + "\r\n";
                    str += AddZeroLeft(4, 6) + AddSpaceRight("Nivia Knupp", 20) + AddZeroLeft(20120405, 8);

                    file.WriteLine(str);
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                throw new Exception("Access is denied, contact the admnistrador " +
                                    " to access the file. Details: " + ex.Message);
            }
            catch (FileLoadException ex)
            {
                throw new Exception("Could not load file. Details: " + ex.Message);
            }
            catch (DirectoryNotFoundException ex)
            {
                throw new Exception("Directory File not found. Details: " + ex.Message);
            }
            catch (IOException ex)
            {
                throw new Exception("Error accessing file. Details: " + ex.Message);
            }

        }

        private static string AddZeroLeft(int value, int size)
        {
            return value.ToString("D" + size.ToString());
        }

        private static string AddSpaceRight(string value, int size)
        {
            return value.PadRight(size);
        }

        private static void ReadFileLine()
        {
            try
            {
                using (var file = new StreamReader("Data.txt"))
                {
                    string line;

                    while ((line = file.ReadLine()) != null)
                    {
                        Console.WriteLine("ID: " + line.Substring(0, 6));
                        Console.WriteLine("Name: " + line.Substring(6, 20));
                        Console.WriteLine("Registration: " + line.Substring(26, 8));
                        Console.WriteLine("----------------------------------------------------");
                    }
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                throw new Exception("Access is denied, contact the admnistrador " +
                                    " to access the file. Details: " + ex.Message);
            }
            catch (FileLoadException ex)
            {
                throw new Exception("Could not load file. Details: " + ex.Message);
            }
            catch (FileNotFoundException ex)
            {
                throw new Exception("File not found. Details: " + ex.Message);
            }
            catch (DirectoryNotFoundException ex)
            {
                throw new Exception("Directory File not found. Details: " + ex.Message);
            }
            catch (IOException ex)
            {
                throw new Exception("Error accessing file information. Details: " + ex.Message);
            }
        }
    }
}
