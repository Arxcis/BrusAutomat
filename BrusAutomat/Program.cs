using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrusAutomat
{
    class Automat
    {
        // Declaring class properties
        public string[] brusutvalg = new string[1];
        public int[] pris = new int[1];

        private int maxVarebeholdning;
        private int vareBeholdning;
        private long kontantBeholdning;

        // Init fields and methods
        public Automat()
        {
            this.brusutvalg[0] = "Cola";
            this.pris[0] = 10;
            this.maxVarebeholdning = 12;
            this.vareBeholdning = maxVarebeholdning;
            this.kontantBeholdning = 0;

            this.skjekkInventory();
            this.printOffers();
        }

        // For printing the list of brus the machine offers.
        public void printOffers() {
            foreach (string brus in brusutvalg) {
                Console.WriteLine(string.Format("Tast {0} for {1}",
                               Array.IndexOf(brusutvalg, brus), brus));
            }
        }

        // Buying method
        public void kjopBrus(int brus) {
            vareBeholdning--;
            kontantBeholdning += pris[brus];
            Console.WriteLine(string.Format("Du har kjøpt en {0} for {1} kroner.", brusutvalg[brus], pris[brus]));
        }

        // Fill up method. Returns how many brus you added.
        public int fillUp() {
            int current = vareBeholdning; 
            vareBeholdning = maxVarebeholdning;
            int nycurrent = vareBeholdning;
            int forskjell = nycurrent - current;
            Console.WriteLine(string.Format("You filled the machine up with {0} new brus.", forskjell));
            return forskjell;
        }

        // Skjekk hvor mange brus igjen 
        public void skjekkInventory()
        {
            Console.WriteLine(string.Format("Det er {0} brus igjen i automaten", vareBeholdning));
        }

        // Skjekk kontantbeholdninger til maskinen.
        public void skjekkKontant()
        {
            Console.WriteLine(string.Format("Automaten inneholder {0} kroner.", kontantBeholdning));
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Automat maskin = new Automat();
            int brusvalg = Int32.Parse(Console.ReadLine());
            maskin.kjopBrus(brusvalg);
            maskin.kjopBrus(brusvalg);
            maskin.kjopBrus(brusvalg);
            maskin.kjopBrus(brusvalg);
            Console.ReadLine();
            maskin.skjekkInventory();
            Console.ReadLine();
            maskin.fillUp();
            Console.ReadLine();
            maskin.skjekkInventory();
            maskin.skjekkKontant();
            Console.ReadLine();
            
        }
    }
}
