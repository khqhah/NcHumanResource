using MongoDB.Driver;
using NcHumanResource.Application.DTOs;
using NcHumanResource.Domain.Entities;
using NcHumanResource.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZstdSharp.Unsafe;

namespace NcHumanResource.Application.UseCases
{
    public class DepartmentService
    {
        private readonly IDepartmentRepository _repo;

        public DepartmentService(IDepartmentRepository repo)
        {
            _repo = repo;
        }

        public async Task AddAsync(DepartmentDto dto)
        {
            var department = new Department {DepartmentID = dto.DepartmentID ,Name = dto.Name };
            await _repo.AddAsync(department);
        }
        public async Task DeleteAsync(string id)
        {
            await _repo.DeleteAsync(id);
        }
        public async Task<List<Department>> GetAllAsync()
        {
            return await _repo.GetAllAsync();
        }
        public async Task<Department> GetByIdAsync(string id)
        {
            return await _repo.GetByIdAsync(id);
        }
        public async Task UpdateAsync(string id, DepartmentDto dto)
        {
            var updated = new Department
            {
                DepartmentID = dto.DepartmentID,
                Name = dto.Name
            };

            await _repo.UpdateAsync(id, updated);
        }        
    }
}