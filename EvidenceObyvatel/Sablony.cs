using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace EvidenceObyvatel
{
    /// <summary>
    /// Statická třída pro používané textové šablony využité v programu
    /// </summary>
    internal static class Sablony
    {
        /// <summary>
        /// Odřádkuje pomocí Console.WriteLine
        /// </summary>
        public static void Odradkuj()
        {
            Console.WriteLine();
        }
        /// <summary>
        /// Text pro zadání špatného čísla
        /// </summary>
        public static void SpatneCislo()
        {
            Console.WriteLine("Nezadali jste číslo. Prosím zadejte znovu celé číslo.");
        }
        /// <summary>
        /// Text pro zadání špatného čísla u věku
        /// </summary>
        public static void SpatneCisloVeku()
        {
            Console.WriteLine("Zadejte pouze čísla v rozmezí [0 - 255]:");
        } 
        /// <summary>
        /// Text pro zadání prázdného stringu
        /// </summary>
        public static void PrazdnyRetezec()
        {
            Console.WriteLine("Zadali jste prázdnou položku. Prosím zadejte znovu.");
        }
        /// <summary>
        /// Vyčištění konzole a její uspání na dobu zadanou v parametru
        /// </summary>
        /// <param name="casUspani">Čas uspání</param>
        public static void VycisteniConzolePauza(int casUspani)
        {
            Thread.Sleep(casUspani);
            Console.Clear();
        }
        /// <summary>
        /// Požadavek na zmáčknutí enteru v případě špatné klavesy je uživatel dotázán znovu.
        /// </summary>
        public static void StiskniEnter()
        {
            ConsoleKeyInfo klavesa;

            Console.WriteLine("\nPro pokračování stiskněte Enter.");
            klavesa = Console.ReadKey();
            Console.WriteLine();
            while (klavesa.Key != ConsoleKey.Enter)
            {
                Console.WriteLine("Nestiskli jste Enter.");
                klavesa = Console.ReadKey();
                Console.WriteLine();
            }
        }
        /// <summary>
        /// Hlavička pro výpisy dotazu na obyvatele
        /// </summary>
        public static void HlavickaVypisu()
        {
            Console.WriteLine("\n{0}{1}{2}", "JMÉNO".PadRight(15), "PŘÍJMENÍ".PadRight(15), "VĚK\n");
        }
        /// <summary>
        /// Hlavička pro sekci úprava obyvatel
        /// </summary>
        public static void HlavickaProUpravu()
        {
            Console.WriteLine("\n{0}{1}{2}", "JMÉNO".PadRight(18), "PŘÍJMENÍ".PadRight(15).PadLeft(1), "VĚK\n");
        }
        /// <summary>
        /// Text pro zkoušky programu
        /// </summary>
        public static void Pripravujem()
        {
            Console.WriteLine("\n\tPracuji na tom\n");
        }
    }
}
