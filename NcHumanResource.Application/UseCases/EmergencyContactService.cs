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
    
    public class EmergencyContactService
    {
        private readonly IEmergencyContactRepository _repo;
        public EmergencyContactService(IEmergencyContactRepository repo)
        {
            _repo = repo;
        }

        public async Task AddEmergencyContactAsync(string employeeId, EmergencyContactDto dto)
        {
            var ec = new EmergencyContact { 
                ContactId = dto.ContactId, 
                Email = dto.Email, 
                Name = dto.Name, 
                PhoneNumber = dto.PhoneNumber, 
                Relationship = dto.Relationship 
            };
            await _repo.AddEmergencyContactAsync(employeeId, ec);
        }
        public async Task<IEnumerable<EmergencyContact>> GetEmergencyContactsAsync(string employeeId)
        {
            return await _repo.GetEmergencyContactsAsync(employeeId);
        }
        public async Task UpdateEmergencyContactAsync(string employeeId, EmergencyContactDto dto)
        {
            var updatedContact = new EmergencyContact
            {
                ContactId = dto.ContactId,
                Name = dto.Name,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                Relationship = dto.Relationship
            };

            await _repo.UpdateEmergencyContactAsync(employeeId, updatedContact);
        }

        public async Task DeleteEmergencyContactAsync(string employeeId, string contactId)
        {
            await _repo.DeleteEmergencyContactAsync(employeeId, contactId);
        }
    }
}