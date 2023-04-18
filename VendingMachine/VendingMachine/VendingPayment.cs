using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{ 
    public class VendingPayment
    {
        double[] acceptedMoney = { 2000, 5000, 10000, 20000, 50000 };
        public VendingPayment()
        {
        }

        public bool TakePayment(double ItemPrice)
        {
            bool result = false;
            double Deposit = 0;
            double Change = 0;

            Console.WriteLine("Masukan jumlah uang anda dengan pecahan [2000, 5000, 10000, 20000, 50000]");
            Console.Write("Input Jumlah Uang > ");

            while (Deposit < ItemPrice)
            {
                try
                {
                    double Input = Convert.ToDouble(Console.ReadLine());

                    while (!acceptedMoney.Contains(Input))
                    {
                        Console.WriteLine("Jumlah uang yang anda input tidak cocok. Coba Kembali...");
                        Console.Write("INPUT [2000, 5000, 10000, 20000, 50000] > ");
                        Input = Convert.ToDouble(Console.ReadLine());
                    }

                    if (Input >= ItemPrice)
                    {
                        Deposit += Input;
                        Change = Deposit - ItemPrice;
                        Console.WriteLine("Transaksi berhasil, selamat menikmati");
                        if (Change > 0)
                        {
                            Console.WriteLine("Uang Kembalian anda Rp.{0}", Change);
                        }
                        Console.WriteLine("----------------------------------------------------------");
                        result = true;
                    }
                    else
                    {
                        Deposit += Input;
                        if (Deposit >= ItemPrice)
                        {
                            Change = Deposit - ItemPrice;
                            Console.WriteLine("Transaksi berhasil, selamat menikmati");
                            if (Change > 0)
                            {
                                Console.WriteLine("Uang Kembalian anda Rp.{0}", Change);
                            }
                            Console.WriteLine("----------------------------------------------------------");
                            
                        }
                        else
                        {
                            Console.Write("Uang Anda Kurang, Tambah Uang > ");
                        }
                        result = true;
                    }  
                }
                catch (FormatException)
                {
                    Console.Write("Maaf Anda Salah Input, Input Ulang > ");
                }
            }

            return result;
        }
    }
}

