using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Catalog_of_printers
{
    class Server
    {
        enum EditPrinterParametrs { Id, Model, Manufacturer, Appointment, Print_size, Price }
        //public  List<Laser_printer> Laser_printers { get; set; }
        //public List<Inkjet_printer> Inkjet_printers { get; set; }

        List<Laser_printer> Laser_printers = new List<Laser_printer>(100)
        {
            new Laser_printer(11111882, "T22", "Toshiba", "for student", "A4", 3000, "blue"),
             new Laser_printer(3422, "RE19", "Toshiba", "for student", "A5", 1200, "pink"),
              new Laser_printer(46889, "RW45", "Samsung", "for student", "A3", 6550, "white"),
               new Laser_printer(6753, "RG69", "Samsung", "for student", "A5", 2300, "black"),
               new Laser_printer(3134, "FR56", "Toshiba", "for student", "A4", 7000, "yellow"),
                new Laser_printer(55577, "Z34", "Toshiba", "for student", "A4", 4500, "black")
        };
        List<Inkjet_printer> Inkjet_printers = new List<Inkjet_printer>(100)
        {
            new Inkjet_printer(1149, "BC34", "Samsung", "for home", "A4", 4300, true ),
             new Inkjet_printer(1140, "BC37", "Toshiba", "for home", "A3", 4500, true ),
             new Inkjet_printer(45566, "H67", "Samsung", "for home", "A4", 6900, true ),
              new Inkjet_printer(5441, "YT54", "Samsung", "for home", "A4", 4211, true ),
               new Inkjet_printer(4355, "BC38", "Samsung", "for home", "A4", 3600, true ),
                new Inkjet_printer(3521, "BA4", "Toshiba", "for home", "A4", 5700, true ),
                 new Inkjet_printer(6890, "AW23", "Toshiba", "for home", "A4", 3000, true )
        };


        public List<Laser_printer> DeserializeLaser()
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

        public List<Inkjet_printer> DeserializeInkjet()
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
        public void SerializeLaser()
        {
            using (FileStream fs = new FileStream("laser_printer.xml", FileMode.Create))
            {
                XmlSerializer xml = new XmlSerializer(typeof(List<Laser_printer>));
                xml.Serialize(fs, Laser_printers);
            }
        }

        public void SerializeInkjet()
        {
            using (FileStream fs = new FileStream("inkjet_printer.xml", FileMode.Create))
            {
                XmlSerializer xml = new XmlSerializer(typeof(List<Inkjet_printer>));
                xml.Serialize(fs, Inkjet_printers);
            }
        }
        /* public  void DeleteLaser(Laser_printer laser_print)
         {
             List<Laser_printer> laser_printer = Laser_printers.Where(a => a.Printer.Equals(laser_print)).ToList();
             int i = 0;
             Laser_printers.Remove(laser_printer[i]);
         }


         public  void DeleteInkjet(Inkjet_printer inkjet_print)
         {
             List<Inkjet_printer> inkjet_printers = Inkjet_printers.Where(a => a.Printer.Equals(inkjet_print)).ToList();
             for (int i = 0; i < inkjet_printers.Count; i++)
             {
                 Inkjet_printers.Remove(inkjet_printers[i]);
             }
         }*/
        public void AddLaser()
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
            Console.ReadKey();
        }
        public void AddInkjet()
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
        public void ShowLaser()
        {
            for (int i = 0; i < Laser_printers.Count; i++)
            {
                Console.WriteLine("The laser printer: " + Laser_printers[i].Id);
                Console.WriteLine("His model: " + Laser_printers[i].Model);
                Console.WriteLine("Manufacture: " + Laser_printers[i].Manufacturer);
                Console.WriteLine("Appointment for printer: " + Laser_printers[i].Appointment);
                Console.WriteLine("Print size: " + Laser_printers[i].Print_size);
                Console.WriteLine("Price: " + Laser_printers[i].Price);
                Console.WriteLine("Color of printer: " + Laser_printers[i].Color);
                Console.WriteLine("============================================");
                Console.ReadKey();
            }
        }
        public void ShowInkjet()
        {
            for (int i = 0; i < Inkjet_printers.Count; i++)
            {
                Console.WriteLine("The inkjet printer: " + Inkjet_printers[i].Id);
                Console.WriteLine("His model: " + Inkjet_printers[i].Model);
                Console.WriteLine("Manufacture: " + Inkjet_printers[i].Manufacturer);
                Console.WriteLine("Appointment for printer: " + Inkjet_printers[i].Appointment);
                Console.WriteLine("Print size: " + Inkjet_printers[i].Print_size);
                Console.WriteLine("Price: " + Inkjet_printers[i].Price);
                Console.WriteLine("This printer has duplex: " + Inkjet_printers[i].Duplex);
                Console.WriteLine("============================================");
                Console.ReadKey();
            }
        }
        public void DeleteLaser()
        {
            ShowLaser();
            Console.WriteLine("Choose a printer:");
            if (int.TryParse(Console.ReadLine(), out int numer))
            {
                Laser_printers.Remove(Laser_printers[numer - 1]);
                Console.WriteLine("Printer deleted!");
            }
            else
            {
                Console.WriteLine("Eror!");
            }
            Console.ReadKey();
        }
        public void DeleteInkjet()
        {
            ShowInkjet();
            Console.WriteLine("Choose a printer:");
            if (int.TryParse(Console.ReadLine(), out int numer))
            {
                Inkjet_printers.Remove(Inkjet_printers[numer - 1]);
                Console.WriteLine("Printer deleted!");
            }
            else
            {
                Console.WriteLine("Eror!");
            }
            Console.ReadKey();
        }
        public void EditLaser()

        {
            ShowLaser();
            Console.WriteLine("Choose a printer:");
            int.TryParse(Console.ReadLine(), out int numer);

            Console.WriteLine("Choose parameter that you want edit:");
            for (int i = 0; i < Enum.GetValues(typeof(EditPrinterParametrs)).Length; i++)
            {
                Console.WriteLine($"{i + 1}) {(EditPrinterParametrs)i}\n");
            }
            switch (Console.ReadLine())
            {
                case "1":
                    Console.WriteLine("Write Id:");
                    Laser_printers[numer - 1].Id = int.Parse(Console.ReadLine());
                    Console.Clear();
                    break;
                case "2":
                    Console.WriteLine("Write model:");
                    Laser_printers[numer - 1].Model = Console.ReadLine();
                    Console.Clear();
                    break;
                case "3":
                    Console.WriteLine("Write manufacturer:");
                    Laser_printers[numer - 1].Manufacturer = Console.ReadLine();
                    Console.Clear();
                    break;
                case "4":
                    Console.WriteLine("Write appointment:");
                    Laser_printers[numer - 1].Appointment = Console.ReadLine();
                    Console.Clear();
                    break;
                case "5":
                    Console.WriteLine("Write print size:");
                    Laser_printers[numer - 1].Print_size = Console.ReadLine();
                    Console.Clear();
                    break;
                case "6":
                    Console.WriteLine("Write a price:");
                    Laser_printers[numer - 1].Price = int.Parse(Console.ReadLine());
                    break;

                    /*default:
                        Console.WriteLine("Incorrect input, try again!");
                        Thread.Sleep(2000);
                        Console.Clear();
                        EditLaser();
                        break;*/
            }


        }
        public void EditInkjet()

        {
            ShowInkjet();
            Console.WriteLine("Choose a printer:");
            int.TryParse(Console.ReadLine(), out int numer);

            Console.WriteLine("Choose parameter that you want edit:");
            for (int i = 0; i < Enum.GetValues(typeof(EditPrinterParametrs)).Length; i++)
            {
                Console.WriteLine($"{i + 1}) {(EditPrinterParametrs)i}\n");
            }
            switch (Console.ReadLine())
            {
                case "1":
                    Console.WriteLine("Write Id:");
                    Inkjet_printers[numer - 1].Id = int.Parse(Console.ReadLine());
                    Console.Clear();
                    break;
                case "2":
                    Console.WriteLine("Write model:");
                    Inkjet_printers[numer - 1].Model = Console.ReadLine();
                    Console.Clear();
                    break;
                case "3":
                    Console.WriteLine("Write manufacturer:");
                    Inkjet_printers[numer - 1].Manufacturer = Console.ReadLine();
                    Console.Clear();
                    break;
                case "4":
                    Console.WriteLine("Write appointment:");
                    Inkjet_printers[numer - 1].Appointment = Console.ReadLine();
                    Console.Clear();
                    break;
                case "5":
                    Console.WriteLine("Write print size:");
                    Inkjet_printers[numer - 1].Print_size = Console.ReadLine();
                    Console.Clear();
                    break;
                case "6":
                    Console.WriteLine("Write a price:");
                    Inkjet_printers[numer - 1].Price = int.Parse(Console.ReadLine());
                    break;
                    /*default:
                        Console.WriteLine("Incorrect input, try again!");
                        Thread.Sleep(2000);
                        Console.Clear();
                        EditLaser();
                        break;*/
            }

        }
        public void SortLaserPrice()
        {

            //int s = 1;  
            //for (int j = 0; j < Laser_printers.Count; j++) 
            for (int i = 0; i < Laser_printers.Count - 1; i++)
            {
                if (Laser_printers[i].Price > Laser_printers[i + 1].Price)
                {
                    Laser_printer tmp = Laser_printers[i];
                    Laser_printers[i] = Laser_printers[i + 1];
                    Laser_printers[i + 1] = tmp;

                }
            }
            ShowLaser();
        }
        static void Swap(ref int e1, ref int e2)
        {
            var temp = e1;
            e1 = e2;
            e2 = temp;
        }
        public void SortLaserPrice2()
        {
            {
               
                    var show = Laser_printers.OrderBy(f => +1 * f.Cost_calculation()); // По убыванию зарпллаты
                foreach (var w in show) 
                {
                    Console.WriteLine(w);
                }

                  
            }


             

        }
    }
}
