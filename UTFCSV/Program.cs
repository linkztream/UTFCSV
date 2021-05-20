using System;
using System.IO;
using System.Text;

namespace UTFCSV
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
                return; // Ingen fil droppad så slutar vi
            string text = File.ReadAllText(args[0]);

            text = "sep=,\n" + text;

            // Sno namn och sökväg från filen som blev droppad och skapa en ny
            string path = Path.GetDirectoryName(args[0])
                + Path.DirectorySeparatorChar
                + Path.GetFileNameWithoutExtension(args[0])
                + "_reCSV" + Path.GetExtension(args[0]);

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Encoding destEnc = Encoding.GetEncoding(1250);
            File.WriteAllText(path, text, destEnc);

            Console.WriteLine("Hit any key to exit...");
            Console.ReadKey();
            return;

        }
    }
}