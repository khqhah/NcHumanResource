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
    public class TodoListRepository : ITodoListRepository
    {
        private readonly IMongoCollection<Employee> _collection;

        public TodoListRepository(IOptions<MongoSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            var db = client.GetDatabase(settings.Value.DatabaseName);
            _collection = db.GetCollection<Employee>("Employees");
        }

        public async Task AddTaskAsync(string employeeId, TodoItem item)
        {
            var filter = Builders<Employee>.Filter.Eq(e => e.NcEmployeeID, employeeId);
            var update = Builders<Employee>.Update.Push(e => e.TodoList, item);
            await _collection.UpdateOneAsync(filter, update);
        }

        public async Task<IEnumerable<TodoItem>> GetTasksAsync(string employeeId)
        {
            var employee = await _collection.Find(e => e.NcEmployeeID == employeeId).FirstOrDefaultAsync();
            return employee?.TodoList ?? new List<TodoItem>();
        }

        public async Task UpdateTaskAsync(string employeeId, TodoItem updatedItem)
        {
            var filter = Builders<Employee>.Filter.And(
                Builders<Employee>.Filter.Eq(e => e.NcEmployeeID, employeeId),
                Builders<Employee>.Filter.ElemMatch(e => e.TodoList, t => t.TaskId == updatedItem.TaskId)
            );

            var update = Builders<Employee>.Update.Set("TodoList.$", updatedItem);
            await _collection.UpdateOneAsync(filter, update);
        }

        public async Task DeleteTaskAsync(string employeeId, string taskId)
        {
            var filter = Builders<Employee>.Filter.Eq(e => e.NcEmployeeID, employeeId);
            var update = Builders<Employee>.Update.PullFilter(e => e.TodoList,
                Builders<TodoItem>.Filter.Eq(t => t.TaskId, taskId));
            await _collection.UpdateOneAsync(filter, update);
        }
    }

}
