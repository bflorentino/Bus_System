using System.Threading.Tasks;
using Bus_System.Models.BindingModel;
using Bus_System.Models.View;
using System.Collections.Generic;

namespace Bus_System.Services
{
    public interface IDriverServices
    {
        Task<bool> AddDriver(DriverBinding driver);
        Task<List<DriversView>>GetAllDrivers();
    }
}
