using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace enquiryMaster
{
    class CONNECT
    {
        //public static bool isAdmin;
        //public static bool bypass;
        //public static bool changeQuantity;
        //public static double newQuantity;


        public const string ConnectionString = "user id=sa;" +

            "password=Dodid1;Network Address=192.168.0.150\\sqlexpress;" +

            "Trusted_Connection=no;" +

            "database=EnquiryLog;" +

            "connection timeout=30";

        public const string ConnectionStringUser = "user id=sa;" +

                               "password=Dodid1;Network Address=192.168.0.150\\sqlexpress;" +

                               "Trusted_Connection=no;" +

                               "database=user_info; " +

                               "connection timeout=30";

    }
}
