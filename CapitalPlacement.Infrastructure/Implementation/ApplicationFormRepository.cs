using CapitalPlacement.Domain.Data;
using CapitalPlacement.Domain.Models;
using CapitalPlacement.Infrastructure.Interface;
using Microsoft.Azure.Cosmos;
using System;
using System.Threading.Tasks;

namespace CapitalPlacement.Infrastructure.Implementation
{
    public class ApplicationFormRepository : IApplicationFormRepository
    {
        private readonly DataAccess _dataAccess;
        private readonly string _containerId = "applicationforms"; 

        public ApplicationFormRepository(DataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public async Task<ApplicationForm> CreateApplicationFormAsync(ApplicationForm applicationForm)
        {
            try
            {
                ItemResponse<ApplicationForm> response = await _dataAccess.CreateItemAsync(applicationForm, _containerId);
                return response.Resource;
            }
            catch (CosmosException ex)
            {
                throw ex;
            }
        }

        public async Task<ApplicationForm> GetApplicationFormAsync(string applicationFormId)
        {
            try
            {
                ItemResponse<ApplicationForm> response = await _dataAccess.ReadItemAsync<ApplicationForm>(applicationFormId, _containerId);
                return response.Resource;
            }
            catch (CosmosException ex)
            {
                throw ex;
            }
        }

        public async Task<ApplicationForm> UpdateApplicationFormAsync(ApplicationForm applicationForm)
        {
            try
            {
                ItemResponse<ApplicationForm> response = await _dataAccess.UpsertItemAsync(applicationForm, _containerId);
                return response.Resource;
            }
            catch (CosmosException ex)
            {
                throw ex;
            }
        }

        public async Task DeleteApplicationFormAsync(string applicationFormId)
        {
            try
            {
                await _dataAccess.DeleteItemAsync<ApplicationForm>(applicationFormId, _containerId);
            }
            catch (CosmosException ex)
            {
                throw ex;
            }
        }
    }
}
