using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace txt_line_breaker
{
    class Program
    {
        private static List<string> ErrorMessages = new List<string>();
        static void Main(string[] args)
        {
            string filePath = (args != null && args.Length > 0) ? args[0] : "";
            breakLinesInTxtFile(filePath);
            if(ErrorMessages.Count != 0) ErrorMessages.ForEach(n=>Console.WriteLine(n));
        }

        private static void breakLinesInTxtFile(string filePath){
            var linesToBreak = getLinesToBreakFromFile(filePath);
            var brokeLines = breakLines(linesToBreak);
            if(brokeLines != null) createNewFile(filePath, brokeLines);
        }

        private static string[] getLinesToBreakFromFile(string filePath){
            if(!File.Exists(filePath)) {
                ErrorMessages.Add($"File: {filePath} does not exists");
                return null;
            }

            var lines = File.ReadAllLines(filePath);
            return lines;
        }

        private static string[] breakLines(string[] lines){
            if(lines == null) return null;
            List<string> brokeLines = new List<string>();
            foreach (var line in lines)
            {
                var singleWords = line.Split('/');
                brokeLines.AddRange(singleWords.ToList());
            }
            return brokeLines.ToArray();
        }

        private static void createNewFile(string filePath, string[] lines){
            if(string.IsNullOrEmpty(filePath) || 
                (lines == null || lines.Length == 0)) return;

            string path = Path.GetDirectoryName(filePath);
            string filename = Path.GetFileNameWithoutExtension(filePath);
            string extension = Path.GetExtension(filePath);

            string newFilePath = $"{path}\\{filename}_break{extension}";

            try
            {
                File.WriteAllLines(newFilePath, lines);
            }
            catch (Exception ex)
            {
                ErrorMessages.Add(ex.Message);
            }
        }
    }
}
