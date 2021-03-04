using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        //Crud
        public static string Added = "Ekleme işlemi başarıyla gerçekleştirildi.";
        public static string Updated = "Güncelleme işlemi başarıyla gerçekleştirildi.";
        public static string Delete = "Silme işlemi başarıyla gerçekleştirildi.";
        public static string Listed = "Listeleme işlemi başarıyla gerçekleştirildi";
        public static string ImagesAdded = "Resim ekleme islemi basariyla gerceklestirildi.";
        public static string AddedImageLimit = "Resim ekleme limiti dolmustur.";
        //Check
        public static string NameInvalid = "Girilen isim geçersiz.";
        //General
        public static string Undelivered = "Teslim edilmemis arac.";

        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Şifre hatalı";
        public static string SuccessfulLogin = "Sisteme giriş başarılı";
        public static string UserAlreadyExists = "Bu kullanıcı zaten mevcut";
        public static string UserRegistered = "Kullanıcı başarıyla kaydedildi";
        public static string AccessTokenCreated = "Access token başarıyla oluşturuldu";

        public static string AuthorizationDenied = "Yetkiniz yok";
        public static string ProductNameAlreadyExists = "Ürün ismi zaten mevcut";

    }
}
