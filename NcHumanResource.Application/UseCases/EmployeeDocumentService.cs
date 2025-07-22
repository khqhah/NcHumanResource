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
    public class EmployeeDocumentService
    {
        private readonly IEmployeeDocumentRepository _repo;

        public EmployeeDocumentService(IEmployeeDocumentRepository repo)
        {
            _repo = repo;
        }

        public async Task AddDocumentAsync(string employeeId, EmployeeDocumentDto dto)
        {
            var doc = new EmployeeDocument
            {
                DocumentId = dto.DocumentId,
                Title = dto.Title,
                FileName = dto.FileName,
                FilePath = dto.FilePath,
                FileType = dto.FileType,
                UploadedDate = dto.UploadedDate
            };
            await _repo.AddDocumentAsync(employeeId, doc);
        }

        public async Task<IEnumerable<EmployeeDocument>> GetDocumentsAsync(string employeeId)
            => await _repo.GetDocumentsAsync(employeeId);

        public async Task UpdateDocumentAsync(string employeeId, EmployeeDocumentDto dto)
        {
            var doc = new EmployeeDocument
            {
                DocumentId = dto.DocumentId,
                Title = dto.Title,
                FileName = dto.FileName,
                FilePath = dto.FilePath,
                FileType = dto.FileType,
                UploadedDate = dto.UploadedDate
            };
            await _repo.UpdateDocumentAsync(employeeId, doc);
        }

        public async Task DeleteDocumentAsync(string employeeId, string documentId)
            => await _repo.DeleteDocumentAsync(employeeId, documentId);
    }

}
