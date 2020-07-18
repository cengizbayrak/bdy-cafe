using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDY_Cafe.Utils
{
    /// <summary>
    /// For default values throughout the application
    /// </summary>
    public static class DefaultValues
    {
        /// <summary>
        /// SQL Connection parameters with default values, but can be changed if necessary
        /// </summary>
        public static class SQLConnection
        {
            public static string SERVER_NAME;
            public static string DATABASE_NAME;
            public static string USERNAME;
            public static string PASSWORD;

            private const string CONNECTION_STRING_FORMAT = 
                "Data Source={0};" +
                "Initial Catalog={1};" +
                "User Id={2};" +
                "Password={3};";
            public static string CONNECTION_STRING;

            public static void constructConnectionString()
            {
                CONNECTION_STRING = string.Format(CONNECTION_STRING_FORMAT, SERVER_NAME, DATABASE_NAME, USERNAME, PASSWORD);
            }
        }

        /// <summary>
        /// SQL Queries to be executed
        /// </summary>
        public static class SQLQueries
        {
            /// <summary>
            /// Bugüne ait kapanmamış adisyon masa ilişkileri sayısı toplamı
            /// <para>&#160;</para>
            /// ALANLAR
            /// <para/>
            /// TOPLAM - int
            /// </summary>
            public const string unhandledCount = @"SELECT COUNT(*) AS TOPLAM
                                                 FROM AdditionTable  AS AT
                                                 INNER JOIN Tables AS T ON AT.TableNumber=T.Number 
                                                 WHERE Handled=0 AND 
                                                    DATEADD(DAY, 0, DATEDIFF(DAY, 0, MatchDate))=DATEADD(DAY, 0, DATEDIFF(DAY, 0, GETDATE()))";

            /// <summary>
            /// Bugüne ait kapanmamış adisyon masa ilişkileri listesi
            /// <para>&#160;</para>
            /// ALANLAR
            /// <para/>
            /// Id - int
            /// <para/>
            /// AdditionNumber - int
            /// <para/>
            /// TableNumber - int
            /// <para/>
            /// Direction - varchar
            /// <para/>
            /// MatchDate - datetime
            /// </summary>
            public const string unhandledList = @"SELECT T.Direction, AT.Id, AT.AdditionNumber, AT.TableNumber, AT.MatchDate 
                                                FROM AdditionTable AS AT
                                                INNER JOIN Tables AS T ON AT.TableNumber=T.Number
                                                WHERE Handled=0 AND 
                                                    DATEADD(DAY, 0, DATEDIFF(DAY, 0, AT.MatchDate))=DATEADD(DAY, 0, DATEDIFF(DAY, 0, GETDATE())) 
                                                ORDER BY AT.AdditionNumber DESC";

            public const string reportList = @"SELECT AT.Id, AT.AdditionNumber, AT.TableNumber, T.Direction, AT.MatchDate 
                                             FROM AdditionTable AS AT 
                                             INNER JOIN Tables AS T ON AT.TableNumber=T.Number 
                                             ORDER BY AT.Id DESC";

            /// <summary>
            /// Listedeki bir adisyonu kapatmak için
            /// <para>&#160;</para>
            /// PARAMETRELER
            /// <para/>
            /// @id - kayıt Id 
            /// </summary>
            public const string closeAddition = "UPDATE AdditionTable SET Handled=1 WHERE Id=@id";

            /// <summary>
            /// Masa düzenlemek için
            /// <para>&#160;</para>
            /// PARAMETRELER
            /// <para/>
            /// @id - kayıt id
            /// <para/>
            /// @name - masa adı
            /// <para/>
            /// @number - masa numarası
            /// <para/>
            /// @direction - masa yönü
            /// </summary>
            public const string updateTable = "UPDATE Tables SET Name=@name, Number=@number, Direction=@direction WHERE Id=@id";

            /// <summary>
            /// Masa bulmak için
            /// <para>&#160;</para>
            /// PARAMETRELER
            /// <para/>
            /// @number - masa numarası
            /// </summary>
            public const string findTable = "SELECT * FROM Tables WHERE Number=@number";

            /// <summary>
            /// Adisyon masa eşleşmesini değiştirmek için
            /// <para>&#160;</para>
            /// PARAMETRELER
            /// <para/>
            /// @id - kayıt id (AdditionTable)
            /// <para/>
            /// @number - masa numarası
            /// </summary>
            public const string changeAdditionTable = @"IF EXISTS(SELECT * FROM Tables WHERE Number=@number)
                                                      BEGIN
                                                        UPDATE AdditionTable SET TableNumber=@number WHERE Id=@id
                                                      END";


            /// <summary>
            /// Adisyonun otomatik kapanması için işlem zamanından sonra geçecek zaman süresini almak için
            /// <para>&#160;</para>
            /// Alan adı: Value
            /// <para/>
            /// Alan değeri: varchar
            /// <para/>
            /// Uygulamada kullanılacak tür: int
            /// </summary>
            public const string getAutoHandleInterval = "SELECT Value FROM Settings WHERE Id=1";

            /// <summary>
            /// Adisyonun otomatik kapanması için
            /// <para>&#160;</para>
            /// PARAMETRELER
            /// <para/>
            /// @minute - adisyonun kapanması için üzerinden geçmesi gereken dakika, autoHandleInterval
            /// </summary>
            public const string autoHandleAddition = @"UPDATE AdditionTable 
                                                     SET Handled=1 
                                                     WHERE Handled=0 AND dateadd(minute, @minute, MatchDate)<getdate()";

            /// <summary>
            /// Adisyonun otomatik kapanması için gereken dakika değerini güncellemek için
            /// <para>&#160;</para>
            /// <para/>
            /// @value - dakika değeri
            /// </summary>
            public const string updateAutoHandleInterval = "UPDATE Settings SET Value=@value WHERE Id=1";

            /// <summary>
            /// Bugünden eski tarihli kapanmamış adisyonları kapatmak için
            /// </summary>
            public const string closeOldAdditions = @"UPDATE AdditionTable 
                                                    SET Handled=1 
                                                    WHERE Handled=0 AND MatchDate<DATEADD(DAY, 0, DATEDIFF(DAY, 0, GETDATE()))";

        }

        /// <summary>
        /// For date, time, etc. formats
        /// </summary>
        public static class Formatting
        {
            public const string TIME_FORMAT = "HH:mm:ss";
        }
    }
}