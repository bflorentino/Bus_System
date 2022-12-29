using Bus_System.Models.View;
using Bus_System.Models.BindingModel;
using System.Threading.Tasks;
using System;
using Data_Tier.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Bus_System.Services
{
    public class DriverServices:IDriverServices
    {
        private readonly Bus_SystemContext _context;

        public DriverServices(Bus_SystemContext context)
        {
            _context = context;
        }

        public async Task<bool> AddDriver(DriverBinding driver)
        {
            Chofere chofer = new Chofere
            {
                Nombre = driver.Nombre,
                Apellido = driver.Apellido,
                FechaNacimiento = DateTime.Parse(driver.FechaNacimiento),
                FechaContratado = DateTime.Parse(driver.FechaContratado),
                Cedula = driver.Cedula,
            };

            try
            {
                await _context.AddAsync(chofer);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex) {

                return false;
            }
            
            return true;
        }

        public async Task<List<DriversView>> GetAllDrivers()
        {
            try
            {
                List<DriversView>driversFetchedMapped = new List<DriversView>();

                var dataFetched = await (from driver in _context.Choferes select driver).ToListAsync();

                foreach (var driver in dataFetched)
                {
                    driversFetchedMapped.Add(new DriversView
                    {
                        Nombre = driver.Nombre,
                        Apellido = driver.Apellido,
                        Cedula = driver.Cedula,
                        FechaContratado = driver.FechaContratado.ToString(),
                        FechaNacimiento = driver.FechaNacimiento.ToString(),
                    });
                }

                return driversFetchedMapped;

            }
            catch(Exception ex)
            {
                return null;
            }
        }
    }
}
