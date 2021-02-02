using System;
using System.Collections.Generic;
using System.Linq;
using Business.Concrete;
using ConsoleTables;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleUI
{
    
    class Program
    {
        
        static int indexMainMenu = 0;
        static void Main(string[] args)
        {
            
            CarManager carManager = new CarManager(new InMemoryCarDal());
            CarDataTransferManager carDataTransferManager = new CarDataTransferManager(new InMemoryCarDataTransferDal());
            BrandManager brandManager = new BrandManager(new InMemoryBrandDal());
            

            Console.Clear();
            
            List<string> menuItems = new List<string>()
            {
                "Yeni Araç Kayıt",
                "Araç Silme İşlemi",
                "Tüm Araçları Listele",
                "Araç Bilgisi Güncelle",
                "Yeni Marka Girişi",
                "Marka Silme İşlemi",
                "Tüm Markaları Listele",
                "Model Yıllarına Göre Listele",
                "Fiyatına Göre Listele",
                "Çıkış"
            };

            Console.CursorVisible = false;
            while (true)
            {
                
                
                string selectedMenuItem = drawMainMenu(menuItems);
                if (selectedMenuItem == "Yeni Araç Kayıt")
                {
                    AddCar(carManager);
                }
                else if (selectedMenuItem == "Araç Silme İşlemi")
                {
                    DeleteCar(carDataTransferManager, carManager, brandManager);
                }
                else if (selectedMenuItem == "Tüm Araçları Listele")
                {
                    ListCars(carDataTransferManager, carManager, brandManager);
                }
                else if (selectedMenuItem == "Araç Bilgisi Güncelle")
                {
                    UpdateCar(carDataTransferManager, carManager, brandManager);
                }
                else if (selectedMenuItem == "Yeni Marka Girişi")
                {
                    AddBrand(brandManager);
                }
                else if (selectedMenuItem == "Marka Silme İşlemi")
                {
                    DeleteBrand(brandManager);
                }
                else if (selectedMenuItem == "Tüm Markaları Listele")
                {
                    ListBrands(brandManager);
                }
                else if (selectedMenuItem == "Model Yıllarına Göre Listele")
                {
                    ListByModelYear(carManager);
                }
                else if (selectedMenuItem == "Fiyatına Göre Listele")
                {
                    ListByPrice(carManager);
                }
                else if (selectedMenuItem == "Çıkış")
                {
                    Environment.Exit(0);
                }
                
            }
            
        }
        public static string drawMainMenu(List<string> items)
        {
            CarDesign();
            for (int i = 0; i < items.Count; i++)
            {
                if (i == indexMainMenu)
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine(items[i]);
                }
                else
                {
                    Console.WriteLine(items[i]);
                }
                Console.ResetColor();
            }

            ConsoleKeyInfo ckey = Console.ReadKey();
            if (ckey.Key == ConsoleKey.DownArrow)
            {
                if (indexMainMenu == items.Count - 1) { }
                else { indexMainMenu++; }
            }
            else if (ckey.Key == ConsoleKey.UpArrow)
            {
                if (indexMainMenu <= 0) { }
                else { indexMainMenu--; }
            }
            else if (ckey.Key == ConsoleKey.LeftArrow)
            {
                Console.Clear();
            }
            else if (ckey.Key == ConsoleKey.RightArrow)
            {
                Console.Clear();
            }
            else if (ckey.Key == ConsoleKey.Enter)
            {
                return items[indexMainMenu];
            }
            else
            {
                return "";
            }

            Console.Clear();
            return "";
        }

        private static void CarDesign()
        {
            Console.WriteLine(@"          ____________________          ");
            Console.WriteLine(@"        /                     \");
            Console.WriteLine(@"       /                       \");
            Console.WriteLine(@"      /    sahipsizinden.com    \");
            Console.WriteLine(@"_____/                           \______");
            Console.WriteLine(@"|O O                                O O \");
            Console.WriteLine(@"|        ****            ****           |");
            Console.WriteLine(@"|_______* ** *__________* ** *__________/");
            Console.WriteLine(@"        * ** *          * ** *");
            Console.WriteLine(@"         ****            ****");
        }

        private static void AddCar(CarManager carManager)
        {
            //Araç Ekleme Fonksiyonu
            Console.WriteLine("Lütfen Yeni Araç Girişi İçin Aşağıda ki Bilgileri Sırası İle Eksiksiz Giriniz.");
            Console.Write("Araç Marka Id:");
            int BrandId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Araç Renk Id:");
            int ColorId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Araç Model Yılı:");
            int ModelYear = Convert.ToInt32(Console.ReadLine());
            Console.Write("Araç Günlük Kira Bedeli:");
            decimal DailyPrice = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Araç Açıklaması:");
            string Description = Console.ReadLine();
            Console.Clear();
            carManager.Add(new Car { BrandId = BrandId, ColorId = ColorId, ModelYear = ModelYear, DailyPrice = DailyPrice, Description = Description });
        }

        private static void DeleteCar(CarDataTransferManager carDataTransferManager, CarManager carManager,
            BrandManager brandManager)
        {
            ListCars(carDataTransferManager, carManager, brandManager);
            Console.Write("\nLütfen Sistemden Silinmesini İstediğiniz Aracın Id Numarasını Yukarıda Ki Listeden Seçerek Giriniz:");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            carManager.Delete(new Car { Id = id });
        }
        private static void ListCars(CarDataTransferManager carDataTransferManager, CarManager carManager, BrandManager brandManager)
        {
            Console.Clear();
            foreach (var car in carDataTransferManager.GetCarDataTransfer(carManager.GetAll(), brandManager.GetAllBrands()))
            {
                var table = new ConsoleTable("Araba Id", "Marka", "Günlük Ücret", "Açıklama");
                table.AddRow(car.Id, car.BrandName, car.DailyPrice, car.Description);
                table.Write();

            }
        }

        private static void UpdateCar(CarDataTransferManager carDataTransferManager, CarManager carManager, BrandManager brandManager)
        {
            
            ListCars(carDataTransferManager, carManager, brandManager);
            Console.Write("\nLütfen Güncellenmesini İstediğiniz Aracın Id Numarasını Giriniz:");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Araç Marka Id:");
            int BrandId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Araç Renk Id:");
            int ColorId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Araç Model Yılı:");
            int ModelYear = Convert.ToInt32(Console.ReadLine());
            Console.Write("Araç Günlük Kira Bedeli:");
            decimal DailyPrice = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Araç Açıklaması:");
            string Description = Console.ReadLine();
            Console.Clear();
            carManager.Update(new Car { Id = id, BrandId = BrandId, ColorId = ColorId, ModelYear = ModelYear, DailyPrice = DailyPrice, Description = Description });
        }

        private static void AddBrand(BrandManager brandManager)
        {
            Console.Write("Lutfen Markanın Adını Giriniz:");
            string brandName = Console.ReadLine();
            brandManager.Add(new Brand { BrandName = brandName });
        }

        public static void DeleteBrand(BrandManager brandManager)
        {
            Console.Clear();
            foreach (var brand in brandManager.GetAllBrands())
            {
                Console.WriteLine($"{brand.BrandId}. {brand.BrandName}");
            }
            Console.Write("Lütfen Sistemden Silmek Istediğiniz Markanın Id sini Giriniz:");
            int brandId = Convert.ToInt32(Console.ReadLine());
            brandManager.Delete(new Brand { BrandId = brandId });
        }

        public static void ListBrands(BrandManager brandManager)
        {
            Console.Clear();
            foreach (var brand in brandManager.GetAllBrands())
            {
                Console.WriteLine($"{brand.BrandId}. {brand.BrandName}");
            }
        }

        public static void ListByModelYear(CarManager carManager)
        {
            foreach (var car in carManager.GetByModelYear())
            {
                Console.WriteLine(" Çıkış Yılı:{0} Fiyat:{1}\n",car.ModelYear,car.DailyPrice);
            }
        }

        public static void ListByPrice(CarManager carManager)
        {
            foreach (var car in carManager.GetByPrice())
            {
                Console.WriteLine(" Çıkış Yılı:{0} Fiyat:{1}\n", car.ModelYear, car.DailyPrice);
                
            }
        }
    }

}
