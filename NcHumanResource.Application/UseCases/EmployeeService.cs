using NcHumanResource.Application.DTOs;
using NcHumanResource.Domain.Entities;
using NcHumanResource.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NcHumanResource.Application.UseCases
{
    public class EmployeeService
    {
        private readonly IEmployeeRepository _repo;
        public EmployeeService(IEmployeeRepository repo)
        {
            _repo = repo;
        }

        public async Task AddAsync(EmployeeDto dto)
        {
            var employee = new Employee
            {
                NcEmployeeID = dto.NcEmployeeID,
                FirstName = dto.FirstName,
                MiddleInitials = dto.MiddleInitials,
                LastName = dto.LastName,
                Addresses = dto.Addresses,
                Department = dto.Department,
                DateOfBirth = dto.DateOfBirth,
                SalaryAmount = dto.SalaryAmount,
                SalaryType = dto.SalaryType,
                PaymentFrequency = dto.PaymentFrequency,
                EmploymentHistory = dto.EmploymentHistory,
                AnnualSalary = dto.AnnualSalary,
                Designation = dto.Designation,
                EmployeeType = dto.EmployeeType,
                IsArchived = dto.IsArchived,
                IsOncall = dto.IsOncall,
                IsRemote = dto.IsRemote,
                FirstDay = dto.FirstDay,
                LastDay = dto.LastDay,
                TerminationDate = dto.TerminationDate,
                RehireDate = dto.RehireDate,
                WorkEmail = dto.WorkEmail,
                PersonalEmail = dto.PersonalEmail,
                CellNumber = dto.CellNumber,
                WorkNumber = dto.WorkNumber,
                IsCellNumberOnBusinessCard = dto.IsCellNumberOnBusinessCard,
                RequiresBusinessCard = dto.RequiresBusinessCard,
                PrimaryNCOffice = dto.PrimaryNCOffice,
                VacationRate = dto.VacationRate,
                AccessCard = dto.AccessCard,
                Licenses = dto.Licenses,
                IsContractSigned = dto.IsContractSigned,
                ContractSignatureDate = dto.ContractSignatureDate
            };

            await _repo.AddAsync(employee);
        }
        
        public async Task DeleteAsync(string ncEmployeeId)
        {
            await _repo.DeleteAsync(ncEmployeeId);
        }

        public Task<bool> ExistsAsync(string ncEmployeeId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await _repo.GetAllAsync();
        }

        public async Task<Employee?> GetByIdAsync(string ncEmployeeId)
        {
            return await _repo.GetByIdAsync(ncEmployeeId);
        }

        public async Task UpdateAsync(string ncEmployeeId, EmployeeDto dto)
        {
            var updated = new Employee
            {
                NcEmployeeID = dto.NcEmployeeID,
                FirstName = dto.FirstName,
                MiddleInitials = dto.MiddleInitials,
                LastName = dto.LastName,
                Addresses = dto.Addresses,
                Department = dto.Department,
                DateOfBirth = dto.DateOfBirth,
                SalaryAmount = dto.SalaryAmount,
                SalaryType = dto.SalaryType,
                PaymentFrequency = dto.PaymentFrequency,
                EmploymentHistory = dto.EmploymentHistory,
                AnnualSalary = dto.AnnualSalary,
                Designation = dto.Designation,
                EmployeeType = dto.EmployeeType,
                IsArchived = dto.IsArchived,
                IsOncall = dto.IsOncall,
                IsRemote = dto.IsRemote,
                FirstDay = dto.FirstDay,
                LastDay = dto.LastDay,
                TerminationDate = dto.TerminationDate,
                RehireDate = dto.RehireDate,
                WorkEmail = dto.WorkEmail,
                PersonalEmail = dto.PersonalEmail,
                CellNumber = dto.CellNumber,
                WorkNumber = dto.WorkNumber,
                IsCellNumberOnBusinessCard = dto.IsCellNumberOnBusinessCard,
                RequiresBusinessCard = dto.RequiresBusinessCard,
                PrimaryNCOffice = dto.PrimaryNCOffice,
                VacationRate = dto.VacationRate,
                AccessCard = dto.AccessCard,
                Licenses = dto.Licenses,
                IsContractSigned = dto.IsContractSigned,
                ContractSignatureDate = dto.ContractSignatureDate
            };

            await _repo.UpdateAsync(ncEmployeeId, updated);
        }

        public async Task UpdateDepartmentAsync(string ncEmployeeId, string DepartmentID)
        {
            var updated = new Employee
            {
                NcEmployeeID = ncEmployeeId,
                Department = DepartmentID
            };

            await _repo.UpdateDepartmentAsync(ncEmployeeId, DepartmentID);
        }

    }
}
