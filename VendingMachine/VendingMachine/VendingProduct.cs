using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public class VendingProduct
    {
        public string NoItem;
        public string NamaItem;
        public double HargaItem;
        public int Stok;

        public VendingProduct(string ItemNo, string ItemName, double ItemPrice, int ItemStock)
        {
            NoItem = ItemNo;
            NamaItem = ItemName;
            HargaItem = ItemPrice;
            Stok = ItemStock;
        }

        public string ID
        {
            get
            {
                return NoItem;
            }
        }

        public string Name
        {
            get
            {
                return NamaItem;
            }
        }

        public double Price
        {
            get
            {
                return HargaItem;
            }
        }

        public int CurrentStok
        {
            get
            {
                return Stok;
            }
        }
    }
}
