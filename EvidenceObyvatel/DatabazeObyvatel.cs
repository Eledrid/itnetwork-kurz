using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace EvidenceObyvatel
{
    /// <summary>
    /// Databáze obyvatel vstupy výstupy
    /// </summary>
    internal class DatabazeObyvatel
    {
        /// <summary>
        /// List obyvatel
        /// </summary>
        private List<Obyvatel> obyvatele;
        /// <summary>
        /// List obyvatel který je readonly
        /// </summary>
        public List<Obyvatel> Obyvatele  // Nové pro přístup
        {
            get { return obyvatele; }
        }
        /// <summary>
        /// Vytvoření obyvatele do listu
        /// </summary>
        public DatabazeObyvatel()
        {
            obyvatele = new List<Obyvatel>();
        }
        /// <summary>
        /// Přidá obyvatele do listu
        /// </summary>
        public void PridejObyvatele()
        {
            ConsoleKeyInfo klavesa;
            do
            {
                Console.WriteLine("\nZALOŽENÍ NOVÉHO OBYVATELE\n");
                Console.WriteLine("Zadejte jméno obyvatele: ");
                string jmeno = Console.ReadLine().Trim();
                while (string.IsNullOrWhiteSpace(jmeno))
                {
                    Sablony.PrazdnyRetezec();
                    jmeno = Console.ReadLine().Trim();
                }

                Console.WriteLine("Zadejte příjmení obyvatele: ");
                string prijmeni = Console.ReadLine().Trim();
                while (string.IsNullOrWhiteSpace(prijmeni))
                {
                    Sablony.PrazdnyRetezec();
                    prijmeni = Console.ReadLine().Trim();
                }

                Console.WriteLine("Zadejte věk obyvatele: ");
                byte vek;
                while (!byte.TryParse(Console.ReadLine().Trim(), out vek))
                {
                    Sablony.SpatneCisloVeku();
                }

                Obyvatel obyvatel = new Obyvatel(jmeno, prijmeni, vek);

                obyvatele.Add(obyvatel);

                Console.WriteLine("Chcete zadat dalšího obyvatele? [A/N]");
                klavesa = Console.ReadKey();
            } while (klavesa.Key == ConsoleKey.A);
            Console.WriteLine("\nObyvatel/é byl/i zaevidován/i");
        }
        /// <summary>
        /// Vypíše aktuální obyvatele v listu s pořadovým číslem
        /// </summary>
        /// <returns>Index vybraného obyvatele</returns>
        public int VyberObvatele()
        {
            int poradoveCislo = -1;

            while (poradoveCislo == -1)
            {
                if (obyvatele.Count == 0) // Ošetření v případě prázdného listu
                {
                    Console.WriteLine("\nEvidence neobsahuje obyvatele\n");
                    break;
                }
                Sablony.HlavickaProUpravu();
                for (int i = 0; i < obyvatele.Count; i++)
                {
                    Console.WriteLine("{0}. {1}", i + 1, obyvatele[i]); // i + 1 protože indexy začínají 0
                }

                Console.WriteLine("\nZadejte pořadové číslo pro úpravu obyvatele:");

                while (!int.TryParse(Console.ReadLine().Trim(), out poradoveCislo))
                {
                    Sablony.SpatneCislo();
                }

                poradoveCislo -= 1; // z důvodu toho, že Indexy začínají 0
                if (poradoveCislo < 0 || poradoveCislo >= obyvatele.Count)
                {
                    Console.WriteLine("Zadali jste neplatné pořadové číslo");
                    Sablony.StiskniEnter();
                    poradoveCislo = -1;
                }
            }
            return poradoveCislo;
        }
        /// <summary>
        /// Úprava zaevidovaných obyvatel
        /// </summary>
        public void UpravitObyvatele()
        {
            ConsoleKeyInfo klavesa;

            Console.WriteLine("ÚPRAVA OBYVATEL");
            int indexObyvatel = VyberObvatele();
            if (indexObyvatel != -1)
            {
                Obyvatel obyvatel = obyvatele[indexObyvatel];
                Console.WriteLine("\nAktuální jméno obyvatel: {0}\nChcete upravit [A/N]", obyvatel.Jmeno);
                klavesa = Console.ReadKey();
                if (klavesa.Key == ConsoleKey.A)
                {

                    Console.WriteLine("\nNové jméno: ");
                    string noveJmeno = Console.ReadLine().Trim();
                    while (string.IsNullOrWhiteSpace(noveJmeno))
                    {
                        Sablony.PrazdnyRetezec();
                        noveJmeno = Console.ReadLine().Trim();
                    }

                    obyvatel.ZmenJmeno(noveJmeno);
                }

                Console.WriteLine("\nAktuální příjmení obyvatele: {0}\nChcete upravit [A/N]", obyvatel.Prijmeni);
                klavesa = Console.ReadKey();
                if (klavesa.Key == ConsoleKey.A)
                {
                    Console.WriteLine("\nNové příjmení:");
                    string novePrijmeni = Console.ReadLine().Trim();
                    while (string.IsNullOrWhiteSpace(novePrijmeni))
                    {
                        Sablony.PrazdnyRetezec();
                        novePrijmeni = Console.ReadLine().Trim();
                    }

                    obyvatel.ZmenPrijmeni(novePrijmeni);
                }

                Console.WriteLine("\nAktuální věk obyvatele: {0}\nChcete upravit [A/N]", obyvatel.Vek);
                klavesa = Console.ReadKey();
                if (klavesa.Key == ConsoleKey.A)
                {
                    Console.WriteLine("\nNový věk:");
                    byte novyVek;
                    while (!byte.TryParse(Console.ReadLine().Trim(), out novyVek))
                    {
                        Sablony.SpatneCisloVeku();
                    }
                    obyvatel.ZmenVek(novyVek);
                }
                Console.WriteLine("\nÚprava provedena úspešně\n");
            }
        }
        public void VymazObyvatele()
        {
            Console.WriteLine("\nVYMAZAT OBYVATELE");
            int indexObyvatel = VyberObvatele();

            if (indexObyvatel != -1)
            {
                Console.WriteLine("\nObyvatel:\n{0}\n\n\tZÁZNAM BYL SMAZÁN", obyvatele[indexObyvatel]);
                obyvatele.RemoveAt(indexObyvatel);
            }
        }
    }
}
