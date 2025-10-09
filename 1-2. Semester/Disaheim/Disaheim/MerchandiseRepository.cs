using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disaheim
{
    public class MerchandiseRepository
    {
        private List<Merchandise> merchandises = new List<Merchandise>();

        public void AddMerchandise(Merchandise merchandise)
        {
            merchandises.Add(merchandise);
        }

        public Merchandise? GetMerchandise(string itemId)
        {
            Merchandise merchandise = null;
            for (int i = 0; i < merchandises.Count; i++)
            {
                if (merchandises[i].ItemId == itemId)
                {
                    merchandise = merchandises[i];
                    break;
                }
            }
            return merchandise;
        }

        public double GetTotalValue()
        {
            Utility util = new Utility();
            double total = 0;
            for (int i = 0; i < merchandises.Count; i++)
            {
                total += util.GetValueOfMerchandise(merchandises[i]);
            }
            return total;
        }


    }
}
