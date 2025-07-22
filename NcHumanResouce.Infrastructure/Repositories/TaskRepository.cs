using Microsoft.Extensions.Options;
using MongoDB.Driver;
using NcHumanResouce.Infrastructure.Mongo;
using NcHumanResource.Domain.Entities;
using NcHumanResource.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NcHumanResouce.Infrastructure.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly IMongoCollection<Employee> _employeeCollection;

        public TaskRepository(IOptions<MongoSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            var db = client.GetDatabase(settings.Value.DatabaseName);
            _employeeCollection = db.GetCollection<Employee>("Employees");
        }

        public async Task AddTaskAsync(string employeeId, TaskItem task)
        {
            var filter = Builders<Employee>.Filter.Eq(e => e.NcEmployeeID, employeeId);
            var update = Builders<Employee>.Update.Push(e => e.Tasks, task);
            await _employeeCollection.UpdateOneAsync(filter, update);
        }

        public async Task<IEnumerable<TaskItem>> GetTasksAsync(string employeeId)
        {
            var employee = await _employeeCollection.Find(e => e.NcEmployeeID == employeeId).FirstOrDefaultAsync();
            return employee?.Tasks ?? new List<TaskItem>();
        }

        public async Task UpdateTaskAsync(string employeeId, TaskItem updatedTask)
        {
            var filter = Builders<Employee>.Filter.And(
                Builders<Employee>.Filter.Eq(e => e.NcEmployeeID, employeeId),
                Builders<Employee>.Filter.ElemMatch(e => e.Tasks, t => t.TaskId == updatedTask.TaskId)
            );

            var update = Builders<Employee>.Update.Set("Tasks.$", updatedTask);
            await _employeeCollection.UpdateOneAsync(filter, update);
        }

        public async Task DeleteTaskAsync(string employeeId, string taskId)
        {
            var filter = Builders<Employee>.Filter.Eq(e => e.NcEmployeeID, employeeId);
            var update = Builders<Employee>.Update.PullFilter(e => e.Tasks, Builders<TaskItem>.Filter.Eq(t => t.TaskId, taskId));
            await _employeeCollection.UpdateOneAsync(filter, update);
        }
    }
}
