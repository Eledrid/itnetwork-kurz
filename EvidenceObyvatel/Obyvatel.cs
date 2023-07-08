using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvidenceObyvatel
{
    /// <summary>
    /// Obyvatel který se bude evidovat v databázi
    /// </summary>
    internal class Obyvatel
    {
        /// <summary>
        /// Jméno obyvatele
        /// </summary>
        public string Jmeno { get; private set; }
        /// <summary>
        /// Příjmení obyvatele
        /// </summary>
        public string Prijmeni { get; private set; }
        /// <summary>
        /// Věk obyvatele
        /// </summary>
        public byte Vek { get; private set; }
        /// <summary>
        /// Konstruktor obyvatele a jeho parametry
        /// </summary>
        /// <param name="jmeno"></param>
        /// <param name="prijmeni"></param>
        /// <param name="vek"></param>
        public Obyvatel(string jmeno, string prijmeni, byte vek)
        {
            Jmeno = jmeno;
            Prijmeni = prijmeni;
            Vek = vek;
            
        }
        /// <summary>
        /// Metoda a zpřístupnění pro úpravu jména obyvatele použité v DatabazeObyvatel
        /// </summary>
        /// <param name="noveJmeno"></param>
        public void ZmenJmeno(string noveJmeno)
        {
            Jmeno = noveJmeno;
        }
        /// <summary>
        /// Metoda a zpřístupnění pro úpravu příjmení obyvatele použité v DatabazeObyvatel
        /// </summary>
        /// <param name="novePrijmeni"></param>
        public void ZmenPrijmeni(string novePrijmeni)
        {
            Prijmeni = novePrijmeni;
        }
        /// <summary>
        /// Metoda a zpřístupnění pro úpravu věku obyvatele použité v DatabazeObyvatel
        /// </summary>
        /// <param name="novyVek"></param>
        public void ZmenVek(byte novyVek)
        {
            Vek = novyVek;
        }
        /// <summary>
        /// Metoda na vypsání obyvatele
        /// </summary>
        /// <returns>Jméno přijmení a věk obyvatele</returns>/// 
        public override string ToString()
        {
            return Jmeno.PadRight(15) + Prijmeni.PadRight(15)  + Vek;
        }
    }
}
