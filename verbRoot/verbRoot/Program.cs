using System;
using System.Collections.Generic;
using System.IO;

namespace verbRoot
{
    class Program
    {
        static Dictionary<string, string> verb_lemmas = new Dictionary<string, string>();
        static void Main(string[] args)
        {
            #region getData
            string[] data;
            Dictionary<string, string[]> verb_tenses = new Dictionary<string, string[]>();
            
            using (StreamReader sr = new StreamReader(filePath))
            {
                string line = sr.ReadToEnd();
                data = line.Split(new char[] {'\n'});
            }
            for(int i = 0; i < data.Length; i++)
            {
                string[] a = data[i].Split(new char[]{','});
                verb_tenses[a[0]] = a;
            }
            foreach (KeyValuePair<string, string[]> infinitive in verb_tenses)
            {
                foreach (string tense in verb_tenses[infinitive.Key])
                {
                    if (!tense.Equals(""))
                    {
                        verb_lemmas[tense] = infinitive.Key;
                    }
                }
            }
            #endregion
            #region test
            Console.WriteLine(getVerbRoot("playing"));
            Console.WriteLine(getVerbRoot("played"));
            Console.ReadKey();
            #endregion
        }
        private static string filePath = Directory.GetCurrentDirectory() + "\\verb.txt";
        private static string getVerbRoot(string v)
        {
            try
            {
                return verb_lemmas[v];
            }
            catch (Exception)
            {
                return v;
            }
        }
    }
}
