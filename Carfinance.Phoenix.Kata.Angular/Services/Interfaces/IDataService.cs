using Carfinance.Phoenix.Kata.Angular.Models;
using System.Collections.Generic;

namespace Carfinance.Phoenix.Kata.Angular.Services.Interfaces
{
    public interface IDataService
    {
        IList<Booking> Initialize();
    }
}