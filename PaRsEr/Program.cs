using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using PaRsEr.Entities;

namespace PaRsEr
{
    class Program
    {
        static void Main(string[] args)
        {
            // var a = '分'; // 20998
            // var c = '\x5206';
            // string q = "\xd83d\xdd00";

            // var b = '';
            // しょ•りОбработка処理<div>処(しょ) - onyomi<br></div><div>&nbsp; &nbsp;処罰(しょ•ばつ) - наказание</div>

            StartWith();

            using (var context = new AnkiDbContext())
            {
                var cards = context
                    .Set<Card>()
                    .ToList();
                
                var notes = context
                    .Set<Note>()
                    .ToList();

                var a = 0;
            }

            EndWith();

            Console.WriteLine("Hello World!");
        }

        private static void StartWith()
        {
            #region Clear directories

            DirectoryInfo decoded = new DirectoryInfo(@"C:\Users\butin\Desktop\test");

            foreach (FileInfo file in decoded.GetFiles())
            {
                file.Delete();
            }

            foreach (DirectoryInfo dir in decoded.GetDirectories())
            {
                dir.Delete(true);
            }


            DirectoryInfo encoded = new DirectoryInfo(@"C:\Users\butin\Desktop\testArchived");

            foreach (FileInfo file in encoded.GetFiles())
            {
                file.Delete();
            }

            foreach (DirectoryInfo dir in encoded.GetDirectories())
            {
                dir.Delete(true);
            }

            #endregion
            
            ZipFile.ExtractToDirectory(@"C:\Users\butin\Downloads\IT_Vocabulary_Temp_v1_1.apkg",
                @"C:\Users\butin\Desktop\test");
        }

        private static void EndWith()
        {
            ZipFile.CreateFromDirectory(@"C:\Users\butin\Desktop\test",
                @"C:\Users\butin\Desktop\testArchived\IT_Vocabulary_Temp_v1_1.apkg");
        }
    }
}