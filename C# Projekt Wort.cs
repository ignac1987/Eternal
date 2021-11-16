using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


namespace Datail
{
    class Program
    {
        // wie gros ist meine arbeitsspeiher
        // mit extrem grose datei(liste) arbeiten kann. 
        
        static void Main(string[] args)
        {
            // Datail einlesen
            string txt = new string(@"C:\Users\CC-Student\Documents\Schulesache\Textdatei.txt");                      

            // string umwandlung
            string readText = new string(File.ReadAllText(txt).Where(c => c != '-' && (c < '0' || c > '9')).ToArray());
            
                // Console.WriteLine(readText);            

                foreach (KeyValuePair<string, int> wort in WortZahl(readText))
                {
                    Console.WriteLine(wort.Key + ": " + wort.Value);
                }
            Console.ReadKey();           
        }

        static Dictionary<string, int> WortZahl(string readText)
        {                    
            Dictionary<string, int> ZahlenDieWörte = new Dictionary<string, int>();         

            // ToLower: macht jeder Buchstabe klein
            readText = readText.ToLower();            

            // Die angezeichnette Sonderzeichen(Charakter) würde nicht aufgenommen
            string[] worten = readText.Split(new char[] { '\r', '\n', ' ','.', ',', '\t', '(', ')', '?', '%', '_', ':'}, StringSplitOptions.RemoveEmptyEntries);
                       

            // Prüft nach jeder Woerte
            for (int i = 0; i < worten.Length; i++)
            {
                // string speichern
                string wort = worten[i];             
                
                // Wenn die letzte Charakter keine Buchstabe ist dann wird entfernt
                if (!char.IsLetterOrDigit(wort[wort.Length - 1]))
                {
                    wort = wort.Remove(wort.Length - 1);                   
                }

                // Die gefundete Wort wuerde zu Dictionary geben und erhöhen 
                if (ZahlenDieWörte.ContainsKey(wort))
                {
                    ZahlenDieWörte[wort]++;                    
                }

                // wenn nicht dann addirt als key zu liste mit 1
                else
                {
                    ZahlenDieWörte.Add(wort, 1);
                }              
            }            
            return ZahlenDieWörte;
        }
    }
}