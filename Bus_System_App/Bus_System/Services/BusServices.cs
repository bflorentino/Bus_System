using System.Threading.Tasks;
using System;
using Data_Tier.Models;
using Bus_System.Models.Binding_Models;
using Bus_System.Models.View;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Bus_System.Services

{
    public class BusServices: IBusServices
    {
        private readonly Bus_SystemContext _context;

        public BusServices(Bus_SystemContext context)
        {
            _context = context;
        }

        public async Task<bool> AddBus(BusBinding busModel)
        {
            Autobuse newBus = new Autobuse
            {
                Marca = busModel.Marca,
                Modelo = busModel.Modelo,
                Anio = busModel.Anio,
                Capacidad = busModel.Capacidad,
                FechaAdquisicion = DateTime.Parse(busModel.Fecha_comprado)
            };

            try
            {
                await _context.AddAsync(newBus);
                await _context.SaveChangesAsync();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<BusesView>> GetAllBuses()
        {
            try
            {
                var dataFetched = await (from bus in _context.Autobuses select bus).ToListAsync();
                var dataFetchedMapped = new List<BusesView>();

                foreach (Autobuse bus in dataFetched)
                {

                    dataFetchedMapped.Add(new BusesView
                    {
                        Marca = bus.Marca,
                        Modelo = bus.Modelo,
                        Anio = bus.Anio,
                        Capacidad = bus.Capacidad,
                        FechaComprado = bus.FechaAdquisicion.ToString()
                    });
                }

                return dataFetchedMapped;
            }
            catch(Exception ex)
            {
                return null;
            }
        }
    }
}