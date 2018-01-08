using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESChatConsoleClient.Data
{
    //Náhrada za database - drží všechna data
    public class DataContext
    {
        protected DataContext()
        {

        }
        public static DataContext _Instance { get; set; }
        public static DataContext GetInstance()
        {
            if (DataContext._Instance == null)
                DataContext._Instance = new DataContext();
            return DataContext._Instance;
        }
    }
}
