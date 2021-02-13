using System;
using System.Collections.Generic;
using System.Linq;
using Business.Concrete;
using Business.Constants;
using ConsoleTables;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace ConsoleUI
{
    
    class Program
    {
        
        static int indexMainMenu = 0;
        static void Main(string[] args)
        {
            

            //CarManager carManager = new CarManager(new InMemoryCarDal());
            //BrandManager brandManager = new BrandManager(new InMemoryBrandDal());

            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());
            UserManager userManager = new UserManager(new EfUserDal());
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            ListRental(rentalManager);
            Console.Clear();

            List<string> menuItems = new List<string>()
            {
                "Yeni Kullanıcı Ekle",
                "Yeni Müşteri Ekle",
                "Kiralık Araç Ekle",
                "Araç Kirala",
                "Araç Teslim Et",
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
                if (selectedMenuItem == "Yeni Kullanıcı Ekle")
                {
                    AddUser(userManager);
                }
                else if (selectedMenuItem == "Yeni Müşteri Ekle")
                {
                    AddCustomer(customerManager);
                }
                else if (selectedMenuItem == "Kiralık Araç Ekle")
                {
                    AddRental(rentalManager,customerManager,carManager);
                }
                else if (selectedMenuItem == "Araç Kirala")
                {
                    UpdateRental(rentalManager, customerManager, carManager);
                }
                else if (selectedMenuItem == "Araç Teslim Et")
                {
                    UpdateRental2(rentalManager, customerManager, carManager);
                }
                else if (selectedMenuItem == "Yeni Araç Kayıt")
                {
                    AddCar(carManager,brandManager,colorManager);
                }
                else if (selectedMenuItem == "Araç Silme İşlemi")
                {
                    DeleteCar(carManager, brandManager);
                }
                else if (selectedMenuItem == "Tüm Araçları Listele")
                {
                    ListCars(carManager);
                }
                else if (selectedMenuItem == "Araç Bilgisi Güncelle")
                {
                    UpdateCar(carManager, brandManager);
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
                    ListByModelYear(carManager,brandManager);
                }
                else if (selectedMenuItem == "Fiyatına Göre Listele")
                {
                    ListByPrice(carManager,brandManager);
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
            Console.WriteLine(@"        ____________________          ");
            Console.WriteLine(@"       /                    \");
            Console.WriteLine(@"      / Araç Kiralama Sistemi\");
            Console.WriteLine(@"_____/                        \______");
            Console.WriteLine(@"|O O                             O O \");
            Console.WriteLine(@"|        ****            ****        |");
            Console.WriteLine(@"|_______* ** *__________* ** *_______/");
            Console.WriteLine(@"        * ** *          * ** *");
            Console.WriteLine(@"         ****            ****");
        }
        private static void ListRental(RentalManager rentalManager)
        {
            Console.Clear();
            foreach (var rental in rentalManager.GetAllRentalDetail().Data)
            {
                var table = new ConsoleTable("Kiralama Id", "Musteri Adi", "Musteri Soyadi", "Arac Markasi", "Arac Modeli", "Açıklama","Kiralama Tarihi","Teslim Tarihi");
                table.AddRow(rental.Id,rental.CustomerFirstName,rental.CustomerLastName,rental.CarBrand,rental.CarModel,rental.CarDescription
                ,rental.RentDate,rental.ReturnDate);
                table.Write();
            }
        }
        private static void AddRental(RentalManager rentalManager,CustomerManager customerManager,CarManager carManager)
        {
            Console.Clear();
            Console.WriteLine("Lütfen Yeni Kiralik Arac Eklemek İçin Aşağıda ki Bilgileri Sırası İle Eksiksiz Giriniz.");
            ListCars(carManager);
            Console.Write("Lutfen kiralik aracin Id: ");
            int CarId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Musteri Id no: ");
            int CustomerId = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            Console.WriteLine(rentalManager.Add(new Rental{CarId = CarId,CustomerId = CustomerId,RentDate = Convert.ToDateTime(null), ReturnDate = Convert.ToDateTime(null) }).Message);
        }
        private static void UpdateRental(RentalManager rentalManager, CustomerManager customerManager, CarManager carManager)
        {
            Console.Clear();
            ListRental(rentalManager);
            Console.Write("Lutfen kiralamak istediginiz aracin Id: ");
            int RentId = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            Console.WriteLine(rentalManager.Update(new Rental { Id = RentId,RentDate = DateTime.Now}).Message);
        }
        private static void UpdateRental2(RentalManager rentalManager, CustomerManager customerManager, CarManager carManager)
        {
            Console.Clear();
            ListRental(rentalManager);
            Console.Write("Teslim etmek istediginiz aracin id:  ");
            int RentId = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            Console.WriteLine(rentalManager.Update(new Rental { Id = RentId, ReturnDate = DateTime.Now }).Message);
        }



        private static void AddCustomer(CustomerManager customerManager)
        {
            Console.Clear();
            Console.WriteLine("Lütfen Yeni Müşteri Kaydı İçin Aşağıda ki Bilgileri Sırası İle Eksiksiz Giriniz.");
            Console.Write("Şirket Adı: ");
            string CompanyName = Console.ReadLine();
            Console.Clear();
            Console.WriteLine(customerManager.Add(new Customer {CompanyName = CompanyName}).Message);
        }

        private static void AddUser(UserManager userManager)
        {
            Console.WriteLine("Lütfen Yeni Kullanıcı Kaydı İçin Aşağıda ki Bilgileri Sırası İle Eksiksiz Giriniz.");
            Console.Write("İsim: ");
            string UserName = Console.ReadLine();
            Console.Clear();
            Console.Write("Soyisim: ");
            string UserLastName = Console.ReadLine();
            Console.Clear();
            Console.Write("Email: ");
            string UserEmail = Console.ReadLine();
            Console.Clear();
            Console.Write("Password: ");
            int UserPassword = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            Console.WriteLine(userManager.Add(new User{FirstName = UserName,LastName = UserLastName,Email = UserEmail,Password = UserPassword}).Message);
        }
        private static void AddCar(CarManager carManager,BrandManager brandManager,ColorManager colorManager)
        {
            //Araç Ekleme Fonksiyonu
            Console.WriteLine("Lütfen Yeni Araç Girişi İçin Aşağıda ki Bilgileri Sırası İle Eksiksiz Giriniz.");
            ListBrands(brandManager);
            Console.Write("Araç Marka Id:");
            int BrandId = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            ListColor(colorManager);
            Console.Write("Araç Renk Id:");
            int ColorId = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            Console.Write("Araç Model Yılı:");
            int ModelYear = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            Console.Write("Araç Günlük Kira Bedeli:");
            decimal DailyPrice = Convert.ToDecimal(Console.ReadLine());
            Console.Clear();
            Console.Write("Araç Açıklaması:");
            string Description = Console.ReadLine();
            Console.Clear();
            Console.WriteLine(carManager.Add(new Car { BrandId = BrandId, ColorId = ColorId, ModelYear = ModelYear, DailyPrice = DailyPrice, Description = Description }).Message);
        }

        private static void DeleteCar(CarManager carManager,BrandManager brandManager)
        {
            ListCars(carManager);
            Console.Write("\nLütfen Sistemden Silinmesini İstediğiniz Aracın Id Numarasını Yukarıda Ki Listeden Seçerek Giriniz:");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            carManager.Delete(new Car { Id = id });
        }
        private static void ListCars(CarManager carManager)
        {
            Console.Clear();
            foreach (var car in carManager.GetCarDetails().Data)
            {
                var table = new ConsoleTable("Araba Id", "Marka", "Yıl","Günlük Kira Ücreti","Renk", "Açıklama");
                    table.AddRow(car.CarId,car.BrandName,car.ModelYear,car.DailyPrice,car.ColorName,car.Description);
                    table.Write();
            }
        }


        private static void UpdateCar(CarManager carManager, BrandManager brandManager)
        {

            ListCars(carManager);
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
            Console.Write("Lutfen Markanın Id Numarasini Giriniz:");
            int brandId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Lutfen Markanın Adını Giriniz:");
            string brandName = Console.ReadLine();
            brandManager.Add(new Brand { Id = brandId,Name = brandName });
        }

        public static void DeleteBrand(BrandManager brandManager)
        {
            Console.Clear();
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine($"{brand.Id}. {brand.Name}");
            }
            Console.Write("Lütfen Sistemden Silmek Istediğiniz Markanın Id sini Giriniz:");
            int brandId = Convert.ToInt32(Console.ReadLine());
            brandManager.Delete(new Brand { Id = brandId });
        }

        public static void ListBrands(BrandManager brandManager)
        {
            Console.Clear();
            Console.WriteLine("--Tüm Markalar--");
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine($"{brand.Id}. {brand.Name}");
            }
        }

        public static void ListColor(ColorManager colorManager)
        {
            Console.Clear();
            Console.WriteLine("--Tüm Renkler--");
            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine($"{color.Id}. {color.Name}");
            }
        }

        public static void ListByModelYear(CarManager carManager,BrandManager brandManager)
        {
            Console.Clear();
            foreach (var car in carManager.GetAll().Data)
            {
                foreach (var brand in brandManager.GetAll().Data.Where(p => p.Id == car.BrandId))
                {
                    Console.WriteLine(" Marka:{0} Çıkış Yılı:{1} Fiyat:{2}\n",brand.Name, car.ModelYear, car.DailyPrice);
                }
            }
        }

        public static void ListByPrice(CarManager carManager,BrandManager brandManager)
        {
            Console.Clear();
            foreach (var car in carManager.GetAll().Data)
            {
                foreach (var brand in brandManager.GetAll().Data.Where(p => p.Id == car.BrandId))
                {
                    Console.WriteLine(" Marka:{0} Çıkış Yılı:{1} Fiyat:{2}\n", brand.Name, car.ModelYear, car.DailyPrice);
                }
            }
        }
    }

}
