using System.Threading.Tasks;
using Bus_System.Models.Binding_Models;
using Bus_System.Models.View;
using System.Collections.Generic;

namespace Bus_System.Services
{
    public interface IBusServices
    {
       Task<bool>AddBus(BusBinding busModel);
        Task<List<BusesView>> GetAllBuses();
    }
}
