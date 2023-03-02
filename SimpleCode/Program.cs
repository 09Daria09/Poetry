using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCode
{
    internal class Program
    {
        class Poem
        {
            public string TitelPoem { get; set; }
            public string Author { get; set; }
            public int YearWriting { get; set; }
            public string TextPoem { get; set; }
            public string ThemePoem { get; set; }

            public Poem()
            {
                YearWriting = 0;
                TitelPoem = null;
                Author = null;
                TextPoem = null;
                ThemePoem = null;

            }
            public Poem(string titelPoem, string author, int yearWriting, string textPoem, string themePoem)
            {
                TitelPoem = titelPoem;
                Author = author;
                YearWriting = yearWriting;
                TextPoem = textPoem;
                ThemePoem = themePoem;
            }
            public override string ToString()
            {
                return $"Название стиха: {TitelPoem}\nАвтор: {Author}\n" +
                    $"Год написания: {YearWriting}\nТекст: {TextPoem}\nТема стиха: {ThemePoem}";
            }
        }
        class CollectionOfPoems
        {
            List<Poem> poems;
            public CollectionOfPoems()
            {
                poems = new List<Poem>();
            }
            public void Add(Poem poem)
            {
                poems.Add(poem);
            }
            public void Remove(Poem poem)
            {
                poems.Remove(poem);
            }
            public void ChangeTitel(Poem poem, string titel)
            {
                poem.TitelPoem = titel;
            }
            public void ChangeAuthor(Poem poem, string author)
            {
                poem.Author = author;
            }
            public void ChangeYearWriting(Poem poem, int yearWriting)
            {
                poem.YearWriting = yearWriting;
            }
            public void ChangeTextPoem(Poem poem, string textPoem)
            {
                poem.TextPoem = textPoem;
            }
            public void ChangeThemePoem(Poem poem, string themePoem)
            {
                poem.ThemePoem = themePoem;
            }
            public List<Poem> FindByTitelPoem(string titelPoem)
            {
                return poems.Where(p => p.TitelPoem == titelPoem).ToList();
            }
            public List<Poem> FindByAuthor(string author)
            {
                return poems.Where(p => p.Author == author).ToList();
            }
            public List<Poem> FindByTextPoem(string textPoem)
            {
                return poems.Where(p => p.TextPoem == textPoem).ToList();
            }
            public List<Poem> FindByThemePoem(string themePoem)
            {
                return poems.Where(p => p.ThemePoem == themePoem).ToList();
            }
            public List<Poem> FindByYearWriting(int yearWriting)
            {
                return poems.Where(p => p.YearWriting == yearWriting).ToList();
            }
            public void SaveFile(string fileName)
            {

                using (StreamWriter sw = new StreamWriter(fileName))
                {
                    foreach (Poem item in poems)
                    {
                        sw.WriteLine($"{item.ToString()}\n");
                    }
                }
            }
            public void File(string fileName)
            {
                List<Poem> persons = new List<Poem>();
                using (StreamReader sr = new StreamReader(fileName))
                {
                    string headerLine = sr.ReadLine();
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] fields = line.Split(',');
                        string title = fields[0];
                        string author = fields[1];
                        int year = int.Parse(fields[2]);
                        string text = fields[3];
                        string theme = fields[3];
                        persons.Add(new Poem()
                        {
                            TitelPoem = title,
                            Author = author,
                            YearWriting = year,
                            TextPoem = text,
                            ThemePoem = theme
                        });
                    }
                }
            }
            ///

            public void GenerateReportByTitelPoem(string titelPoem, string fileName = null)
            {
                List<Poem> result = FindByTitelPoem(titelPoem);

                StringBuilder report = new StringBuilder();
                report.AppendLine($"Отчет по стихам с названием '{titelPoem}':");
                report.AppendLine($"{"Название стиха",-30}{"Автор",-20}{"Год",-10}{"Тема",-20}");

                foreach (Poem poem in result)
                {
                    report.AppendLine($"{poem.TitelPoem,-30}{poem.Author,-20}{poem.YearWriting,-10}{poem.ThemePoem,-20}");
                }

                if (fileName != null)
                {
                    using (StreamWriter sw = new StreamWriter(fileName))
                    {
                        sw.Write(report);
                    }
                    Console.WriteLine($"Отчет сохранен в файл {fileName}");
                }
                else
                {
                    Console.WriteLine(report);
                }
            }

            public void GenerateReportByAuthor(string author, string fileName = null)
            {
                List<Poem> result = FindByAuthor(author);

                StringBuilder report = new StringBuilder();
                report.AppendLine($"Отчет по стихам автора {author}:");
                report.AppendLine($"{"Название стиха",-30}{"Автор",-20}{"Год",-10}{"Тема",-20}");

                foreach (Poem poem in result)
                {
                    report.AppendLine($"{poem.TitelPoem,-30}{poem.Author,-20}{poem.YearWriting,-10}{poem.ThemePoem,-20}");
                }

                if (fileName != null)
                {
                    using (StreamWriter sw = new StreamWriter(fileName))
                    {
                        sw.Write(report);
                    }
                    Console.WriteLine($"Отчет сохранен в файл {fileName}");
                }
                else
                {
                    Console.WriteLine(report);
                }
            }

            public void GenerateReportByThemePoem(string themePoem, string fileName = null)
            {
                List<Poem> result = FindByThemePoem(themePoem);

                StringBuilder report = new StringBuilder();
                report.AppendLine($"Отчет по стихам на тему '{themePoem}':");
                report.AppendLine($"{"Название стиха",-30}{"Автор",-20}{"Год",-10}{"Тема",-20}");

                foreach (Poem poem in result)
                {
                    report.AppendLine($"{poem.TitelPoem,-30}{poem.Author,-20}{poem.YearWriting,-10}{poem.ThemePoem,-20}");
                }

                if (fileName != null)
                {
                    using (StreamWriter sw = new StreamWriter(fileName))
                    {
                        sw.Write(report);
                    }
                    Console.WriteLine($"Отчет сохранен в файл {fileName}");
                }
                else
                {
                    Console.WriteLine(report);
                }
            }
            ///
            public List<Poem> FindByWord(string word)
            {
                return poems.Where(p => p.TextPoem.ToLower().Contains(word.ToLower())).ToList();
            }
            public List<Poem> FindByYear(int year)
            {
                return poems.Where(p => p.YearWriting == year).ToList();
            }
            public List<Poem> FindByLength(int length)
            {
                return poems.Where(p => p.TextPoem.Split(new char[] { ' ', '\n' }, StringSplitOptions.RemoveEmptyEntries).Length == length).ToList();
            }
        }

        static void Main(string[] args)
        {
            CollectionOfPoems collection = new CollectionOfPoems();

            Poem poem1 = new Poem("Название1", "Автор1", 1990, "Текст1", "Тема1");
            Poem poem2 = new Poem("Название2", "Автор2", 2000, "Текст2", "Тема2");

            collection.Add(poem1);
            collection.Add(poem2);

            List<Poem> poemsByAuthor = collection.FindByAuthor("Автор2");
            foreach (Poem poem in poemsByAuthor)
            {
                Console.WriteLine(poem);
            }

            collection.ChangeYearWriting(poem1, 2000);
            Console.WriteLine(poem1.YearWriting);

            collection.GenerateReportByAuthor("Автор1", "report.txt");
        }
    }
}

