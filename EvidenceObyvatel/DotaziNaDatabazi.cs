using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvidenceObyvatel
{
    /// <summary>
    /// Dotazi na kolekci obyvatel
    /// </summary>
    internal class DotaziNaDatabazi
    {
        /// <summary>
        /// List obyvatel a její proměna pro třídu
        /// </summary>
        private List<Obyvatel> obyvatele;
        /// <summary>
        /// Konstruktor pro používání databáze z třídy DatabazeObyvatel
        /// </summary>
        /// <param name="databaze">Kolekce na kterou budeme volat dotazi</param>
        public DotaziNaDatabazi(DatabazeObyvatel databaze)
        {
            obyvatele = databaze.Obyvatele;
        }
        /// <summary>
        /// Vypíše všechny evidované obyvatele seřazené abecedně podle jména
        /// </summary>
        public void VypsatVsechnyObyvatele()
        {
            Console.WriteLine("Výpis obyvatel: {0}", obyvatele.Count);
            Sablony.HlavickaVypisu();
            foreach (var s in obyvatele)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine();
        }
        /// <summary>
        /// Vyhledání podle příjmení a seřazení abecedně podle jména
        /// </summary>
        public void VyhledatDlePrijmeni()
        {
            string hledanePrijmeni = "";
            var obyvatelDlePrijmeni = from o in obyvatele
                                      where (o.Prijmeni.ToLower() == hledanePrijmeni)
                                      orderby o.Jmeno
                                      select o;

            Console.WriteLine("VYHLEDÁVÁNÍ OBYVATEL PODLE PŘÍJMENÍ");
            Console.WriteLine("Zadejte příjmení obyvatele:");
            hledanePrijmeni = Console.ReadLine().Trim().ToLower();
            while (string.IsNullOrWhiteSpace(hledanePrijmeni))
            {
                Sablony.PrazdnyRetezec();
                hledanePrijmeni = Console.ReadLine().Trim().ToLower();
            }

            Console.WriteLine("Nalezení obyvatelé: {0}", obyvatelDlePrijmeni.Count());
            Sablony.HlavickaVypisu();
            foreach (var s in obyvatelDlePrijmeni)
            {
                Console.WriteLine(s);
            }
        }
        /// <summary>
        /// Vyhledání podle křestního jména a jejich abecední seřazení podle jména
        /// </summary>
        public void VyhledatDleJmena()
        {
            string hledaneJmeno = "";
            var obyvatelDleJmena = from o in obyvatele
                                   where (o.Jmeno.ToLower() == hledaneJmeno)
                                   orderby o.Jmeno
                                   select o;

            Console.WriteLine("VYHLEDÁVÁNÍ OBYVATEL PODLE JMÉNA");
            Console.WriteLine("Zadejte jméno obyvatele:");
            hledaneJmeno = Console.ReadLine().Trim().ToLower();
            while (string.IsNullOrEmpty(hledaneJmeno))
            {
                Sablony.PrazdnyRetezec();
                hledaneJmeno = Console.ReadLine().Trim().ToLower();
            }

            Console.WriteLine("Nalezení obyvatelé: {0}", obyvatelDleJmena.Count());
            Sablony.HlavickaVypisu();
            foreach (var s in obyvatelDleJmena)
            {
                Console.WriteLine(s);
            }
        }
        /// <summary>
        /// Vyhledání obyvatele dle jména a příjmení
        /// </summary>
        public void VyhledatDleJmenaAPrijmeni()
        {
            string hledaneJmeno = "";
            string hledanePrijmeni = "";
            var obyvatelDleJmenaAPrijmeni = from o in obyvatele
                                            where (o.Prijmeni.ToLower() == hledanePrijmeni && o.Jmeno.ToLower() == hledaneJmeno)
                                            orderby o.Jmeno
                                            select o;

            Console.WriteLine("VYHLEDÁVÁNÍ OBYVATEL PODLE JMÉNA A PŘÍJMENÍ");
            Console.WriteLine("Zadejte jméno obyvatele:");
            hledaneJmeno = Console.ReadLine().Trim().ToLower();
            while (string.IsNullOrWhiteSpace(hledaneJmeno))
            {
                Sablony.PrazdnyRetezec();
                hledaneJmeno = Console.ReadLine().Trim().ToLower();
            }
            Console.WriteLine("Zadejte příjmení obyvatele");
            hledanePrijmeni = Console.ReadLine().Trim().ToLower();
            while (string.IsNullOrWhiteSpace(hledanePrijmeni))
            {
                Sablony.PrazdnyRetezec();
                hledanePrijmeni = Console.ReadLine().Trim().ToLower();
            }

            Console.WriteLine("Nalezení obyvatelé: {0}", obyvatelDleJmenaAPrijmeni.Count());
            Sablony.HlavickaVypisu();
            foreach (var s in obyvatelDleJmenaAPrijmeni)
            {
                Console.WriteLine(s);
            }
        }
        /// <summary>
        /// Vyhledá obyvatele podle zadaného výrazu
        /// </summary>
        public void VyhledatDleVyrazu()
        {
            string hledanyVyraz = "";

            var obyvatelDleVyrazu = from o in obyvatele
                                    where (o.Jmeno.ToLower().Contains(hledanyVyraz) || o.Prijmeni.ToLower().Contains(hledanyVyraz))
                                    orderby o.Jmeno
                                    select o;

            Console.WriteLine("VYHLEDÁVÁNÍ OBYVATEL PODLE ZADANÉHO VÝRAZU");
            Console.WriteLine("Zadejte výraz, který chcete vyhledat:");
            hledanyVyraz = Console.ReadLine().ToLower().Trim();
            while (string.IsNullOrWhiteSpace(hledanyVyraz))
            {
                Sablony.PrazdnyRetezec();
                hledanyVyraz = Console.ReadLine().ToLower().Trim();
            }

            Console.WriteLine("Nalezení obyvatelé: {0}", obyvatelDleVyrazu.Count());
            Sablony.HlavickaVypisu();
            foreach (var s in obyvatelDleVyrazu)
            {
                Console.WriteLine(s);
            }
        }
    }
}
