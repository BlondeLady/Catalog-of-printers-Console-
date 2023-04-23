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
			
			Console.WriteLine("1) Додати\n2) Змінити\n3) Видалити\n4) Показати всіх\n5) Пошук\n6) Вихід");// Главное меню

			int choice = int.Parse(Console.ReadLine());
			Console.Clear();
			switch (choice) // В зависимости от выбора пользователя, обращаемся к методу
			{
				case 1:
					Console.WriteLine("1) Додати Лазерний принтер 2) Додати струменевий принтер");
					int choice1 = int.Parse(Console.ReadLine());
					int k = 1;
					int m = 2;
					if (choice1 == k)
					{
						Server.AddLaser();

					}
					else if (choice1 == m)
					{
						Server.AddInkjet();
					}
                    else
                    {
						Console.WriteLine("Error! You should try again!");
                    }

					break;/*
				case 2:
					Change_delete(true); // Изменение в Листе и файле
					break;
				case 3:
					Change_delete(false); // Удаление из листа и файла
					break;
				case 4:
					Show(); // Отображение всех кто есть в базе
					break;
				case 5:
					Find(); // Поиск по критериям
					break;
				case 6:
					goto exit; // Закрыть программу*/
					Console.ReadKey();
			}
		}

	}


}
  
