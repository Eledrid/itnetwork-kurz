using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace EvidenceObyvatel
{
    /// <summary>
    /// Menu a navigace aplikace
    /// </summary>
    internal class NavigaceVAplikaci
    {
        /// <summary>
        /// Konstruktor pro uživání Listu
        /// </summary>
        private DatabazeObyvatel evidence = new DatabazeObyvatel();
        /// <summary>
        /// Proměnná pro dotazy na list
        /// </summary>
        private DotaziNaDatabazi databaze;
        /// <summary>
        /// Konstruktor, který umožní používat dotazy
        /// </summary>
        public NavigaceVAplikaci()
        {
            databaze = new DotaziNaDatabazi(evidence);
        }
        /// <summary>
        /// Úvod a základní menu
        /// </summary>
        public void Uvitani()
        {
            Console.WriteLine("\t**** VÍTEJTE V MENU ****");
            Console.WriteLine("\t*** Evidence obyvatel ***\n");
            Console.WriteLine("\tVyberte z následující nabídky:");
            Console.WriteLine("\t[1] - Založení nového obyvatele");
            Console.WriteLine("\t[2] - Výpis obyvatel");
            Console.WriteLine("\t[3] - Vyhledání obevatele");
            Console.WriteLine("\t[4] - Úpravy evidovaných obyvatel");
            Console.WriteLine("\t[5] - Ukončení programu");
        }
        public void DalsiUrovenVyberu3()
        {
            Console.WriteLine("\tVYHLEDÁNÍ OBYVATEL");
            Console.WriteLine("\tVyberte z následující nabídky:");
            Console.WriteLine("\t[1] - Vyhledat dle jména a příjmení");
            Console.WriteLine("\t[2] - Vyhledat dle jména");
            Console.WriteLine("\t[3] - Vyhledat dle příjmení");
            Console.WriteLine("\t[4] - Vyhledat dle výrazu");
            Console.WriteLine("\t[5] - Návrat do menu");
        }
        /// <summary>
        /// Druhá uroveň menu pro úpravu obyvatel
        /// </summary>
        public void DalsiUrovenVyberu4()
        {
            Console.WriteLine("\tÚPRAVA EVIDOVANÝCH OBYVATEL\n");
            Console.WriteLine("\tVyberte z následující nabídky:");
            Console.WriteLine("\t[1] - Úprava obyvatele");
            Console.WriteLine("\t[2] - Smazání obyvatele");
            Console.WriteLine("\t[3] - Návrat do menu");
        }
        /// <summary>
        /// Komunikace s uživatelem a jeho volby interakci v programu
        /// </summary>
        public void VolbaAkce()
        {
            char volbaHlavniMenu;
            char volbaPodMenu;
            do
            {
                volbaHlavniMenu = Console.ReadKey().KeyChar;
                switch (volbaHlavniMenu)
                {
                    case '1':
                        Sablony.Odradkuj();
                        evidence.PridejObyvatele();
                        Sablony.VycisteniConzolePauza(2000);
                        Uvitani();
                        break;
                    case '2':
                        Sablony.Odradkuj();
                        databaze.VypsatVsechnyObyvatele();
                        Sablony.StiskniEnter();
                        Console.Clear();
                        Uvitani();
                        break;
                    case '3':
                        Console.Clear();
                        DalsiUrovenVyberu3();

                        volbaPodMenu = Console.ReadKey().KeyChar;
                        switch (volbaPodMenu)
                        {
                            case '1':
                                Sablony.Odradkuj();
                                databaze.VyhledatDleJmenaAPrijmeni();
                                Sablony.StiskniEnter();
                                Console.Clear();
                                Uvitani();
                                break;
                            case '2':
                                Sablony.Odradkuj();
                                databaze.VyhledatDleJmena();
                                Sablony.StiskniEnter();
                                Console.Clear();
                                Uvitani();
                                break;
                            case '3':
                                Sablony.Odradkuj();
                                databaze.VyhledatDlePrijmeni();
                                Sablony.StiskniEnter();
                                Console.Clear();
                                Uvitani();
                                break;
                            case '4':
                                Sablony.Odradkuj();
                                databaze.VyhledatDleVyrazu();
                                Sablony.StiskniEnter();
                                Console.Clear();
                                Uvitani();
                                break;
                            case '5':
                                Console.Clear();
                                Uvitani();
                                break;
                        }
                        break;
                    case '4':
                        Console.Clear();
                        DalsiUrovenVyberu4();

                        volbaPodMenu = Console.ReadKey().KeyChar;
                        switch (volbaPodMenu)
                        {
                            case '1':
                                Sablony.Odradkuj();
                                evidence.UpravitObyvatele();
                                Sablony.VycisteniConzolePauza(2000);
                                Uvitani();
                                break;
                            case '2':
                                Sablony.Odradkuj();
                                evidence.VymazObyvatele();
                                Sablony.VycisteniConzolePauza(3000);
                                Uvitani();
                                break;
                            case '3':
                                Console.Clear();
                                Uvitani();
                                break;
                        }
                        break;
                }
            } while (volbaHlavniMenu != '5');
        }
    }
}
