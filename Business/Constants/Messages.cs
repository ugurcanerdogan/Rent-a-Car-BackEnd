namespace Business.Constants
{
    public class Messages
    {
        public static string CarAdded = "Araba eklendi.";
        public static string CarDeleted = "Araba silindi.";
        public static string CarUpdated = "Araba güncellendi.";
        public static string CarsListed = "Arabalar listelendi.";
        public static string CarPriceInvalid = "Geçersiz araba fiyatı !";

        public static string BrandAdded = "Marka eklendi.";
        public static string BrandDeleted = "Marka silindi.";
        public static string BrandUpdated = "Marka güncellendi.";
        public static string BrandsListed = "Markalar listelendi.";

        public static string ColorAdded = "Renk eklendi.";
        public static string ColorDeleted = "Renk silindi.";
        public static string ColorUpdated = "Renk güncellendi.";
        public static string ColorsListed = "Renkler listelendi.";

        public static string RentalCarAvailable = "Araç kiralanabilir.";
        public static string RentalCarNotAvailable = "Araç kiralanamaz !";
        public static string RentalUpdated = "Kiralanan araç güncellendi.";
        public static string RentalAdded = "Araç kiralandı.";
        public static string RentalDeleted = "Kiralama silindi.";

        public static string UserAdded = "Kullanıcı eklendi.";
        public static string UserDeleted = "Kullanıcı silindi.";
        public static string UserListed = "Kullanıcı listelendi.";
        public static string UserUpdated = "Kullanıcı güncellendi.";
        public static string UsersListed = "Kullanıcılar listelendi.";

        public static string CustomerAdded = "Müşteri eklendi.";
        public static string CustomerDeleted = "Müşteri silindi.";
        public static string CustomerListed = "Müşteri listelendi.";
        public static string CustomerUpdated = "Müşteri güncellendi.";
        public static string CustomersListed = "Müşteriler listelendi.";

        public static string CarDailyPriceMinimumError = "Araba fiyatı 0'dan küçük girilemez!";
        public static string CarNameLengthError = "Araba ismi en az üç karakter girilmelidir!";

        public static string[] ValidImageFileTypes = { ".JPG", ".JPEG", ".PNG", ".TIF", ".TIFF", ".GIF", ".BMP", ".ICO" };
        public static string CarHaveNoImage = "Arabaya ait bir resim yok!";
        public static string ImageLimitExceededForCar = "Bir arabaya en fazla 5 fotoğraf eklenebilir!";
        public static string CarImageMustExist = "Böyle bir resim bulunamadı.";
        public static string InvalidImageExtension = "Geçersiz dosya uzantısı, fotoğraf için kabul edilen uzantılar : " + string.Join(",", ValidImageFileTypes);
        public static string AuthorizationDenied = "Yetkiniz yok!";

        public static string UserRegistered = "Kullanıcı kayıt oldu.";
        public static string UserNotFound = "Kullanıcı bulunamadı.";
        public static string PasswordError = "Parola hatalı";
        public static string SuccessfulLogin = "Başarılı giriş!";
        public static string UserAlreadyExists = "Kullanıcı mevcut.";
        public static string AccessTokenCreated = "Erişim tokeni oluşturuldu";

    }
}
