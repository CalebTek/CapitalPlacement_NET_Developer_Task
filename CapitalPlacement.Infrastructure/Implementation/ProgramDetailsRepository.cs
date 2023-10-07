using System;
using System.Threading.Tasks;
using CapitalPlacement.Domain.Data;
using CapitalPlacement.Domain.Models;
using CapitalPlacement.Infrastructure.Interfaces;
using Microsoft.Azure.Cosmos;

namespace CapitalPlacement.Infrastructure.Implementation
{
    public class ProgramDetailsRepository : IProgramDetailsRepository
    {
        private readonly DataAccess _dataAccess;
        private readonly string _containerId = "programdetails";

        public ProgramDetailsRepository(DataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public async Task<ProgramDetails> CreateProgramDetailsAsync(ProgramDetails programDetails)
        {
            try
            {
                ItemResponse<ProgramDetails> response = await _dataAccess.CreateItemAsync(programDetails, _containerId);
                return response.Resource;
            }
            catch (CosmosException ex)
            {
                throw ex;
            }
        }

        public async Task<ProgramDetails> GetProgramDetailsAsync(string programDetailsId)
        {
            try
            {
                ItemResponse<ProgramDetails> response = await _dataAccess.ReadItemAsync<ProgramDetails>(programDetailsId, _containerId);
                return response.Resource;
            }
            catch (CosmosException ex)
            {
                throw ex;
            }
        }

        public async Task<ProgramDetails> UpdateProgramDetailsAsync(ProgramDetails programDetails)
        {
            try
            {
                ItemResponse<ProgramDetails> response = await _dataAccess.UpsertItemAsync(programDetails, _containerId);
                return response.Resource;
            }
            catch (CosmosException ex)
            {
                throw ex;
            }
        }

        public async Task DeleteProgramDetailsAsync(string programDetailsId)
        {
            try
            {
                await _dataAccess.DeleteItemAsync<ProgramDetails>(programDetailsId, _containerId);
            }
            catch (CosmosException ex)
            {
                throw ex;
            }
        }
    }
}
