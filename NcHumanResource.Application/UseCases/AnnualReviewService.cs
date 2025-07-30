using NcHumanResource.Application.DTOs;
using NcHumanResource.Domain.Entities;
using NcHumanResource.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NcHumanResource.Application.UseCases
{
    public class AnnualReviewService
    {
        private readonly IAnnualReviewRepository _repo;

        public AnnualReviewService(IAnnualReviewRepository repo)
        {
            _repo = repo;
        }

        public async Task AddAsync(string employeeId, AnnualReviewDto dto)
        {
            var review = new AnnualReview
            {
                Id = dto.Id,
                ReviewDate = dto.ReviewDate,
                Reviewer = dto.Reviewer,
                Comments = dto.Comments,
                Rating = dto.Rating
            };

            await _repo.AddReviewAsync(employeeId, review);
        }

        public async Task<IEnumerable<AnnualReview>> GetAsync(string employeeId)
            => await _repo.GetReviewsAsync(employeeId);

        public async Task UpdateAsync(string employeeId, AnnualReviewDto dto)
        {
            var review = new AnnualReview
            {
                Id = dto.Id,
                ReviewDate = dto.ReviewDate,
                Reviewer = dto.Reviewer,
                Comments = dto.Comments,
                Rating = dto.Rating
            };

            await _repo.UpdateReviewAsync(employeeId, review);
        }

        public async Task DeleteAsync(string employeeId, string reviewId)
            => await _repo.DeleteReviewAsync(employeeId, reviewId);
    }
}
