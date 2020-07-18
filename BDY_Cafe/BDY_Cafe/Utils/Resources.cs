using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDY_Cafe.Utils {
    /// <summary>
    /// Uygulama genelindeki değerleri tutacak
    /// </summary>
    public static class Resources {

        /// <summary>
        /// Uygulama genelinde kullanılacak string değerlerini tutacak
        /// </summary>
        public static class StringResources {
            public const string APP_NAME = "Cafe - BDY";
            public const string APP_VERSION = "1.0.0";

            //public const string APP_TITLE = APP_NAME + " v" + APP_VERSION;
            public const string APP_TITLE = "Arjantin Cafe";

            public const string ADD_TABLE = "Masa Ekle";
            public const string EDIT_TABLE = "Masa Düzenle";
            public const string DELETE_TABLE = "Masa Sil";

            public const string CHOOSE_TABLE_DIRECTION = "Masa Yönü seçin...";
            public const string ENTER_VALID_TABLE_NUMBER = "Geçerli bir masa numarası girin!";
            public const string CHOOSE_VALID_DIRECTION_INFO_FOR_TABLE = "Masa için geçerli bir yön bilgisi seçin!";
            public const string TABLE_NUMBER_MUST_CONTAIN_DIGITS_ONLY = "Masa numarası yalnızca rakamlardan oluşmalıdır!";

            public const string TABLE_ADDED_SUCCESSFULLY = "Masa başarıyla eklendi.";
            public const string TABLE_EDITED_SUCCESSFULLY = "Masa başarıyla düzenlendi.";
            public const string TABLE_DELETED_SUCCESSFULLY = "Masa başarıyla silindi.";

            public const string ARE_YOU_SURE_TO_DELETE_TABLE = "Masayı silmek istediğinize emin misiniz?";
            public const string TABLE_NOT_ADDED = "Masa eklenemedi!";

            /// <summary>
            /// Use this const with "string.Format(this,additionNumber)"
            /// <para>Starts with {0} placeholder for addition number</para>
            /// </summary>
            public const string ARE_YOU_SURE_TO_HANDLE_ADDITION = "{0} numaralı adisyonu kapatmak istediğinize emin misiniz?";
            public const string HANDLE_ADDITION = "Adisyon Kapatma";

            public const string ADDITION_NO = "Adisyon No";
            public const string TABLE_NO = "Masa No";
            public const string OPERATION_TIME = "İşlem Zamanı";
            public const string TABLE_CHANGE = "Masa Değişimi";
            public const string ORDER_DELIVERY = "Sipariş Teslimi";

            public const string TABLE_NUMBER = "Masa numarası";
            public const string ENTER_NEW_TABLE_NUMBER = "Yeni masa numarasını girin";

            /// <summary>
            /// Use this const with "string.Format(this, additionNumber, tableNumber)"
            /// <para>Starts with {0} placeholder for addition number, {1} placeholder for table number</para>
            /// </summary>
            public const string ADDITION_TABLE_CHANGED_SUCCESSFULLY = "{0} numaralı adisyonun masa bilgisi {1} olarak değiştirildi.";

            public const string ADDITION_TABLE_CHANGE = "Adisyon - Masa Değişimi";
        }
    }
}