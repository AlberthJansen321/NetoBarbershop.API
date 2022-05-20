using NetoBarbershop.Application.Interfaces;
using NetoBarbershop.Domain.Models;
using NetoBarbershop.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetoBarbershop.Application
{
    public class ServiceApplication : IServiceApplication
    {
        private readonly IGeralRepository _geralRepository;
        private readonly IServiceRepository _IServiceRepository;

        public ServiceApplication(IGeralRepository geralRepository, IServiceRepository IServiceRepository)
        {
           _geralRepository = geralRepository;
           _IServiceRepository = IServiceRepository;
        }
        public async Task<Service> AddService(Service model)
        {
            try
            {
                _geralRepository.Add<Service>(model);

                if(await _geralRepository.SaveChangesAsync())
                {
                    return await _IServiceRepository.GetServiceByIdAsync(model.Id,false);
                }

                return null;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }           
        }

        public async Task<bool> DeleteService(int serviceid)
        {
            try
            {
                var service = _IServiceRepository.GetServiceByIdAsync(serviceid, false);
              
                if (service == null) return false;

                _geralRepository.Delete<Service>(service.Result);
                return await _geralRepository.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<Service> UpdateService(int serviceid, Service model)
        {
            //criar um DTO e ultilizar altomapper
            try
            {
                var service = await _IServiceRepository.GetServiceByIdAsync(serviceid, false);
                
                if (service == null) return null;

                model.Id = service.Id;
                
                _geralRepository.Update<Service>(model);
                if (await _geralRepository.SaveChangesAsync())
                {
                    return await _IServiceRepository.GetServiceByIdAsync(model.Id, false);
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task<Service> GetServiceByIdAsync(int id, bool includeServiceDone = false)
        {
            try
            {
                var service = _IServiceRepository.GetServiceByIdAsync(id, includeServiceDone);
                if (service == null) return null;


                return service;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task<Service[]> GetServiceByNomeAsync(string nome, bool includeServiceDone = false)
        {
            try
            {
                var service = _IServiceRepository.GetServiceByNomeAsync(nome, includeServiceDone);
                if (service == null) return null;

                return service;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task<Service[]> GetAllServicesAsync(bool includeServiceDone = false)
        {
            try
            {
                var service = _IServiceRepository.GetAllServicesAsync(includeServiceDone);
                if (service == null) return null;

                return service;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
