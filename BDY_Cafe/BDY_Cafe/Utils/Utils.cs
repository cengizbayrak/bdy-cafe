using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDY_Cafe.Utils {
    // util operations
    public static class Utils {
        public static void readSqlConnectionSettings() {
            const string debugTag = "readSqlConnectionSettings";
            try {
                using (StreamReader reader = new StreamReader("server.txt")) {
                    String line = reader.ReadToEnd();
                    String[] conParams = line.Split('|');
                    DefaultValues.SQLConnection.SERVER_NAME = conParams[0];
                    DefaultValues.SQLConnection.DATABASE_NAME = conParams[1];
                    DefaultValues.SQLConnection.USERNAME = conParams[2];
                    DefaultValues.SQLConnection.PASSWORD = conParams[3];
                }
            } catch (Exception ex) {
                Debug.WriteLine(debugTag + " ex: " + ex.Message);
            }
        }
    }
}