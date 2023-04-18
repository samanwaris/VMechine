using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    class Program
    {
        
        static void Main(string[] args)
        {
            VendingM();

            while (!Console.KeyAvailable)
            {
                System.Threading.Thread.Sleep(10);
            }

        }

        private static void VendingM()
        {
            var vendingMachine = new VendingMachine();
            vendingMachine.ShowMenu();

            var selectionID = vendingMachine.RequestItem();

            VendingProduct product = vendingMachine.SelectProduct(selectionID);

            if (product.Stok > 0)
            {
                var VendingPayment = new VendingPayment();
                if (VendingPayment.TakePayment(product.Price)== true)
                {
                    product.Stok -= 1;
                    vendingMachine.UpdateStok(product.NoItem, product.Stok);
                    RepeatOrder();
                }
            }
            else
            {
                Console.WriteLine("Stok Item {0} Habis, silahkan pilih item lain", product.NamaItem);
                selectionID = vendingMachine.RequestItem();
            }

        }

        private static void RepeatOrder()
        {
            Console.Write("Apakah anda ingin membeli lagi? (Y/N) : ");

            string input = Console.ReadLine().ToUpper();

            if (input == "Y")
            {
                Console.Clear();
                VendingM();
            }
            else
            {
                Environment.Exit(0);
            }
            
        }

    }
}
