using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Catalog_of_printers
{
	class Program
	{
		 
		static void Main(string[] args)
		{
			
			Server server = new Server();

			while (true)
			{


				Console.WriteLine("1) Add \n2) Edit\n3) Delete\n4) Show All \n5) Show only Laser printers\n6) Show only Inkjet printers\n7)");// Главное меню

				int choice = int.Parse(Console.ReadLine());
				Console.Clear();
				switch (choice) // В зависимости от выбора пользователя, обращаемся к методу
				{
					case 1:
						Console.WriteLine("1) Add laser printer 2) Add inkjet printer");
						int choice1 = int.Parse(Console.ReadLine());
						 
						if (choice1 == 1)
						{
							server.AddLaser();
							Console.WriteLine("Printer added successfully!");

						}
						else if (choice1 == 2)
						{
							server.AddInkjet();
						}
						else
						{
							Console.WriteLine("Error! You should try again!");
						}

						break;
				case 2:
						Console.WriteLine("Chose a type of printer: 1)Laser printer; 2)Inkjet printer");
						int choice2 = int.Parse(Console.ReadLine());

						if (choice2 == 1)
						{
							server.EditLaser();
						}
						else if (choice2 == 2) 
						{
							server.EditInkjet();
						}
                        else
                        {
							Console.WriteLine("Eror");
                        }
						break;
					case 3:
						Console.WriteLine("1) Delete laser printer 2) Delete inkjet printer");
						int choice3 = int.Parse(Console.ReadLine());
						 
						if (choice3 == 1)
						{
							server.DeleteLaser();
						}
						else if(choice3 == 2)
						{
							server.DeleteInkjet();
                        }
                        else
                        {
							Console.WriteLine("Eror");
                        }
							 // Удаление из листа и файла
						break;
					case 4:
						server.ShowLaser();
						server.ShowInkjet();// Отображение всех кто есть в базе
						break;
					case 5:
					server.ShowLaser(); // Поиск по критериям
					break;
				    case 6:
						server.ShowInkjet();
						break;
					case 7:
						server.SortLaserPrice2();
						break;
					//goto exit; // Закрыть программу
						//Console.ReadKey();
				}
			}
			exit:
			;



		}

	}
}
  
