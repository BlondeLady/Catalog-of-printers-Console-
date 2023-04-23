using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Catalog_of_printers
{
    class Server
    {
        public static List<Laser_printer> Laser_printers { get; set; }
        public static List<Inkjet_printer> Inkjet_printers { get; set; }

        List<Laser_printer> laser_Printers = new List<Laser_printer>(100);
            //{(new Laser_printer(11111882, "T22", "Toshiba", "for student", "A4", 3000, "blue"))};

        public static List<Laser_printer> DeserializeLaser()
        {
            if (File.Exists("laser_printer.xml"))
            {
                using (FileStream fs = new FileStream("laser_printer.xml", FileMode.Open))
                {
                    XmlSerializer xml = new XmlSerializer(typeof(List<Laser_printer>));
                    Laser_printers = (List<Laser_printer>)xml.Deserialize(fs);
                }
                return Laser_printers;
            }
            return new List<Laser_printer>();
        }

        public static List<Inkjet_printer> DeserializeInkjet()
        {
            if (File.Exists("inkjet_printer.xml"))
            {
                using (FileStream fs = new FileStream("inkjet_printer.xml", FileMode.Open))
                {
                    XmlSerializer xml = new XmlSerializer(typeof(List<Inkjet_printer>));
                    Inkjet_printers = (List<Inkjet_printer>)xml.Deserialize(fs);
                }
                return Inkjet_printers;
            }
            return new List<Inkjet_printer>();
        }
        public static void SerializeLaser()
        {
            using (FileStream fs = new FileStream("laser_printer.xml", FileMode.Create))
            {
                XmlSerializer xml = new XmlSerializer(typeof(List<Laser_printer>));
                xml.Serialize(fs, Laser_printers);
            }
        }

        public static void SerializeInkjet()
        {
            using (FileStream fs = new FileStream("inkjet_printer.xml", FileMode.Create))
            {
                XmlSerializer xml = new XmlSerializer(typeof(List<Inkjet_printer>));
                xml.Serialize(fs, Inkjet_printers); 
            }
        }
        public static void DeleteLaser(Printer printer)
        {
            List<Laser_printer> laser_printer = Laser_printers.Where(a => a.Printer.Equals(printer)).ToList();
            for (int i = 0; i < laser_printer.Count; i++)
            {
                Laser_printers.Remove(laser_printer[i]);
            }
        }

        public static void DeleteInkjet(Printer printer)
        {
            List<Inkjet_printer> inkjet_printers = Inkjet_printers.Where(a => a.Printer.Equals(printer)).ToList();
            for (int i = 0; i < inkjet_printers.Count; i++)
            {
                Inkjet_printers.Remove(inkjet_printers[i]);
            }
        }
        public static void AddLaser()
        {
            Console.WriteLine("Write id"); 
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Write model of printer");
            string model = Console.ReadLine();
            Console.WriteLine("Write manufacturer");
            string manufacturer = Console.ReadLine();
            Console.WriteLine("Write appointment");
            string appointment = Console.ReadLine();
            Console.WriteLine("Write print_size");
            string print_size = Console.ReadLine();
            Console.WriteLine("Write price");
            double price = int.Parse(Console.ReadLine());
            Console.WriteLine("Write color of printer");
            string color = Console.ReadLine();
            Laser_printer laser_printer1 = new Laser_printer(id, model, manufacturer, appointment, print_size, price, color);
            Laser_printers.Add(laser_printer1);
            Console.WriteLine("Printer added successfully!");
        }
        public static void AddInkjet()
        {
            Console.WriteLine("Write id");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Write model of printer");
            string model = Console.ReadLine();
            Console.WriteLine("Write manufacturer");
            string manufacturer = Console.ReadLine();
            Console.WriteLine("Write appointment");
            string appointment = Console.ReadLine();
            Console.WriteLine("Write print_size");
            string print_size = Console.ReadLine();
            Console.WriteLine("Write price");
            double price = int.Parse(Console.ReadLine());
            bool duplex = true;
            Inkjet_printer inkjet_printer1 = new Inkjet_printer(id, model, manufacturer, appointment, print_size, price, duplex);
            Inkjet_printers.Add(inkjet_printer1);
            Console.WriteLine("Printer added successfully!");
        }


    }
}
