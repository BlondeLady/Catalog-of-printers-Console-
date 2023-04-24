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
    public class Laser_printer : Printer
    {
        public string color;

        public Printer Printer { get; set; }

        
        public override bool Equals(object obj)
        {
            return obj is Laser_printer laser_printer &&
                   base.Equals(obj) &&
                   Id == laser_printer.Id &&
                   Model == laser_printer.Model &&
                   Manufacturer == laser_printer.Manufacturer &&
                   Appointment == laser_printer.Appointment &&
                   Print_size == laser_printer.Print_size &&
                   Price == laser_printer.Price &&
                   Color == laser_printer.Color;

        }
        public Laser_printer(int id, string model, string manufacturer, string appointment, string print_size, double price, string color)
            : base(id, model, manufacturer, appointment, print_size, price)
        {
            Color = color;
        }
        public string Color { get => color; set => color = value; }

        public override int GetHashCode()
        {
            int hashCode = 182849422;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Color);
            return hashCode;
        }
        public override int Cost_calculation()
        {
            string price_message;
            int sum = 5000;
            if (Price > sum)
            {
                Price = Price - (Price / 100) * 5;
            }
            price_message = "The price with 5% discount " + Price;
            Console.WriteLine(price_message);
            Console.WriteLine("===================================");
            double pri = Price;
            int pric = Convert.ToInt32(pri);
            return pric;
        }
    }
}
