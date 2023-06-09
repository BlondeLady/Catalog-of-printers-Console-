using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Catalog_of_printers
{
    [Serializable]
    [XmlInclude(typeof(Printer))]
    public class Inkjet_printer : Printer
    {
        private bool duplex;

        public Printer Printer { get; set; }
        public bool Duplex { get => duplex; set => duplex = value; }

        public override bool Equals(object obj)
        {
            return obj is Inkjet_printer inkjet_printer &&
                   base.Equals(obj) &&
                   Id == inkjet_printer.Id &&
                   Model == inkjet_printer.Model &&
                   Manufacturer == inkjet_printer.Manufacturer &&
                   Appointment == inkjet_printer.Appointment &&
                   Print_size == inkjet_printer.Print_size &&
                   Price == inkjet_printer.Price &&
                   Duplex == inkjet_printer.Duplex;
        }
        public Inkjet_printer(int id, string model, string manufacturer, string appointment, string print_size, double price, bool duplex)
           : base(id, model, manufacturer, appointment, print_size, price)
        {
            Duplex = duplex;
        }

        public override int GetHashCode()
        {
            int hashCode = -1181832783;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + Duplex.GetHashCode();
            return hashCode;
        }
        public override int Cost_calculation()
        {
            string price_message = "до сплати: " + Price + " а також картредж у подарунок! ";
            double pri = Price;
            int pric = Convert.ToInt32(pri);
           Console.WriteLine( price_message);
            Console.WriteLine("===================================");
            return pric;
        }
    }

}
