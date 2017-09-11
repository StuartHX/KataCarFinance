using Carfinance.Phoenix.Kata.Angular.Services.Interfaces;
using System.Collections.Generic;
using System.Web;
using Carfinance.Phoenix.Kata.Angular.Models;
using Newtonsoft.Json;
using System.IO;

namespace Carfinance.Phoenix.Kata.Angular.Services
{

    /// <summary>
    /*
        This is not the file you're looking for.

                         .==.
                        ()''()-.
             .---.       ;--; /
           .'_:___". _..'.  __'.
           |__ --==|'-''' \'...;
           [  ]  :[|       |---\
           |__| I=[|     .'    '.
           / / ____|     :       '._
          |-/.____.'      | :       :
         /___\ /___\      '-'._----'

     */
    /// </summary>
    public class DataService : IDataService
    {
        private static IList<Booking> bookings;

        public IList<Booking> Initialize()
        {
            if (bookings == null)
            {
                using (StreamReader r = new StreamReader(HttpContext.Current.Server.MapPath("~/json/bookings.json")))
                {
                    string json = r.ReadToEnd();
                    bookings = JsonConvert.DeserializeObject<List<Booking>>(json);
                }
            }
          
            return bookings;
        }
    }
}