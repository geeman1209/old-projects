using SGBank.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.BLL
{
   public static class AccountManagerFactory
    {
        public static AccountManager Create()
        {
        string path = @"C:\Users\gabreu\Documents\BitBucket\gabriel-abreu-individual-work\SGBank";
        string mode = ConfigurationManager.AppSettings["Mode"].ToString();

            switch(mode)
            {
                case "FreeTest":
                    return new AccountManager(new FreeAccountTestRepository());
                case "BasicTest":
                    return new AccountManager(new BasicAccountTestRepository());
                case "PremiumTest":
                    return new AccountManager(new PremiumAccountTestRepository());
                case "FileAccountRepository":
                    return new AccountManager(new FileAccountRepository(path));
                default:
                    throw new Exception("Mode value in app config is not valid");
            }
        }
    }
}
