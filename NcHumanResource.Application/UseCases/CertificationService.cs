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
    public class CertificationService
    {
        private readonly ICertificationRepository _repo;

        public CertificationService(ICertificationRepository repo)
        {
            _repo = repo;
        }

        public async Task AddCertificationAsync(string employeeId, CertificationDto dto)
        {
            var cert = new Certification
            {
                CertificationId = dto.CertificationId,
                Name = dto.Name,
                IssuingAuthority = dto.IssuingAuthority,
                IssueDate = dto.IssueDate,
                ExpiryDate = dto.ExpiryDate,
                isMembership = dto.isMembership
            };
            await _repo.AddCertificationAsync(employeeId, cert);
        }

        public async Task<IEnumerable<Certification>> GetCertificationsAsync(string employeeId)
            => await _repo.GetCertificationsAsync(employeeId);

        public async Task UpdateCertificationAsync(string employeeId, CertificationDto dto)
        {
            var updated = new Certification
            {
                CertificationId = dto.CertificationId,
                Name = dto.Name,
                IssuingAuthority = dto.IssuingAuthority,
                IssueDate = dto.IssueDate,
                ExpiryDate = dto.ExpiryDate,
                isMembership = dto.isMembership
            };
            await _repo.UpdateCertificationAsync(employeeId, updated);
        }

        public async Task DeleteCertificationAsync(string employeeId, string certificationId)
            => await _repo.DeleteCertificationAsync(employeeId, certificationId);
    }

}