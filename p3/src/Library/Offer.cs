using System;
using System.Text;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Ucu.Poo.Defense
{
    public class Offer
    {
        public DateTime EndDate { get; set; }

        public IReadOnlyCollection<OfferItem> Items
        {
            get
            {
                return new ReadOnlyCollection<OfferItem>(this.items);
            }
        }

        private IList<OfferItem> items = new List<OfferItem>();

        public int Total { get; private set; }

        public Offer(DateTime endDate)
        {
            this.EndDate = endDate;
        }

        public void AddItem(OfferItem item)
        {
            this.Total += item.SubTotal;
            this.items.Add(item);
        }

        public void RemoveItem(OfferItem item)
        {
            this.items.Remove(item);
        }

        public string AsText() {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Fecha: " + this.EndDate.ToString("dd/MM/yyyy"));
            foreach (OfferItem item in this.items)
            {
                sb.AppendLine($"\t{item.AsText()}");
            }
            return sb.ToString();
        }
    }
}