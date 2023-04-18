using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace VendingMachine
{
    class VendingMachine
    {
        VendingProduct[] items = new VendingProduct[5];
        public VendingMachine()
        {  
            string file = string.Empty;
            if (File.Exists("item.txt"))
            {
                file = "item.txt";
                int i = 0;
                try
                {
                    using (var rd = new StreamReader(file))
                    {
                        while (!rd.EndOfStream)
                        {
                            var splits = rd.ReadLine().Split(',');
                            items[i] = new VendingProduct(splits[0], splits[1], Convert.ToDouble(splits[2]), Convert.ToInt32(splits[3]));
                            i += 1;
                        }

                    }
                    if (i != 5)
                    {
                        Console.WriteLine("Jumlah List Item tidak cocok!");
                        Console.Read();
                    }
                }

                catch
                {
                    Console.WriteLine("Error saat membaca file");
                }
            }

            else
            {
                Console.WriteLine("File tidak ditemukan!");
                Console.Read();
            }
        }

        public void UpdateStok(string ID, int stok)
        {
            List<String> lines = new List<String>();
            string file = string.Empty;
            file = "item.txt";
            if (File.Exists("item.txt"))
            {
                try
                {
                    using (var rd = new StreamReader(file))
                    {
                        String line;

                        while ((line = rd.ReadLine()) != null)
                        {
                            if (line.Contains(","))
                            {
                                String[] split = line.Split(',');

                                if (split[0].Contains(ID))
                                {
                                    split[3] = Convert.ToString(stok);
                                    line = String.Join(",", split);
                                }
                            }

                            lines.Add(line);
                        }

                    }
                    using (StreamWriter writer = new StreamWriter(file, false))
                    {
                        foreach (String line in lines)
                            writer.WriteLine(line);
                    }
                }

                catch
                {
                    Console.WriteLine("Error saat membaca file");
                }
            }

            else
            {
                Console.WriteLine("File tidak ditemukan!");
                Console.Read();
            }
        }

        public void ShowMenu()
        {
            Console.WriteLine("==========================================================");
            Console.WriteLine("             *WELCOME TO VENDING MACHINE*                 ");
            Console.WriteLine("==========================================================");
            Console.WriteLine();
            Console.WriteLine("DAFTAR SNACK");
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("|ITEM | STOK | NAMA SNACK");
            Console.WriteLine("----------------------------------------------------------");
            foreach (var item in items)
            {
                Console.WriteLine("| " + item.ID + "   | " + item.CurrentStok + "    | " + item.Name + " Rp. " + item.Price + "");
            }
            Console.WriteLine("==========================================================");
        }

        public char RequestItem()
        {
            List<char> accInput = new List<char>();

            Console.Write("PILIH SNACK ANDA [A - B]: ");

            foreach (var item in items)
            {
                char productID = item.NoItem[0];
                accInput.Add(productID);
            }

            char selection = Console.ReadLine().ToUpper()[0];

            while (!accInput.Contains(selection))
            {
                Console.WriteLine("Pilihan yang anda pilih tidak tersedia. Coba Kembali...");
                Console.Write("INPUT [A - B]: ");
                selection = Console.ReadLine().ToUpper()[0];
            }

            return selection;
        }

        public VendingProduct SelectProduct(char selection)
        {
            string stringselection = Convert.ToString(selection);

            var product = Array.Find(this.items, item => item.NoItem.StartsWith(stringselection, StringComparison.Ordinal));

            return product;
        }
    }
}
