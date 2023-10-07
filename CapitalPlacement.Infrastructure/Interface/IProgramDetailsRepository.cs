using CapitalPlacement.Domain.Models;

namespace CapitalPlacement.Infrastructure.Interfaces
{
    public interface IProgramDetailsRepository
    {
        Task<ProgramDetails> CreateProgramDetailsAsync(ProgramDetails programDetails);
        Task<ProgramDetails> GetProgramDetailsAsync(string programDetailsId);
        Task<ProgramDetails> UpdateProgramDetailsAsync(ProgramDetails programDetails);
        Task DeleteProgramDetailsAsync(string programDetailsId);
    }
}
