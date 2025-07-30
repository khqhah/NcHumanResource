using NcHumanResource.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NcHumanResource.Domain.Interfaces
{
    public interface IAnnualReviewRepository
    {
        Task AddReviewAsync(string employeeId, AnnualReview review);
        Task<IEnumerable<AnnualReview>> GetReviewsAsync(string employeeId);
        Task UpdateReviewAsync(string employeeId, AnnualReview updated);
        Task DeleteReviewAsync(string employeeId, string reviewId);
    }
}
