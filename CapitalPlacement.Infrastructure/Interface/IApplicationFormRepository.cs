using CapitalPlacement.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitalPlacement.Infrastructure.Interface
{
    public interface IApplicationFormRepository
    {
        Task<ApplicationForm> CreateApplicationFormAsync(ApplicationForm applicationForm);
        Task<ApplicationForm> GetApplicationFormAsync(string applicationFormId);
        Task<ApplicationForm> UpdateApplicationFormAsync(ApplicationForm applicationForm);
        Task DeleteApplicationFormAsync(string applicationFormId);
    }
}
