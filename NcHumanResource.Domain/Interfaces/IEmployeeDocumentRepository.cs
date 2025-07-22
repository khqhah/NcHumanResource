using NcHumanResource.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NcHumanResource.Domain.Interfaces
{
    public interface IEmployeeDocumentRepository
    {
        Task AddDocumentAsync(string employeeId, EmployeeDocument document);
        Task<IEnumerable<EmployeeDocument>> GetDocumentsAsync(string employeeId);
        Task UpdateDocumentAsync(string employeeId, EmployeeDocument updatedDocument);
        Task DeleteDocumentAsync(string employeeId, string documentId);
    }
}
