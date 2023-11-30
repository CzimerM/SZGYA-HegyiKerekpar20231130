using System.Text;

namespace SZGYA_HegyiKerekpar20231130
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Versenyzo> versenyzok = new List<Versenyzo>();

            StreamReader sr = new StreamReader("../../../src/bukkm2019.txt",Encoding.UTF8);
            _ = sr.ReadLine();
            while (!sr.EndOfStream)
            {
                versenyzok.Add(new Versenyzo(sr.ReadLine()));
            }
            sr.Close();

            const int osszVersenyzo = 691;
            Console.WriteLine($"4. feladat: Versenytávot nem teljesítők: {((osszVersenyzo - versenyzok.Count) / (float)osszVersenyzo) * 100}%");
            Console.WriteLine($"5. feladat: Női versenyzők száma a rövid távú versenyen: {versenyzok.Where(v => v.Kategoria.Last() == 'n' && v.Tav == "Rövid").ToList().Count}fő");
            Console.WriteLine($"6. feladat: {(versenyzok.Any(v => v.Ido > new TimeSpan(6,0,0)) ? "Van" : "Nincs")} ilyen versenyző");
            Console.WriteLine($"7. feladat: A felnőtt férfi (ff) kategória győztese rövid távon\n{versenyzok.Where(v => v.Kategoria == "ff" && v.Tav == "Rövid").MinBy(v => v.Ido)}");
            Console.WriteLine("8. feladat: Statisztika");
            var f8stat = versenyzok
                .Where(v => v.Kategoria.Last() == 'f')
                .GroupBy(v => v.Kategoria)
                .ToDictionary(k => k.Key, v => v.ToList().Count);
            foreach (var kv in f8stat)
            {
                Console.WriteLine($"\t{kv.Key} - {kv.Value}fő");
            }
        }
    }
}