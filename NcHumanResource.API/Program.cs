using NcHumanResouce.Infrastructure.Mongo;
using NcHumanResouce.Infrastructure.Repositories;
using NcHumanResource.Application.UseCases;
using NcHumanResource.Domain.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<MongoSettings>(
    builder.Configuration.GetSection("MongoSettings"));





// Add services to the container.

// Register services
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IEmergencyContactRepository, EmergencyContactRepository>();
builder.Services.AddScoped<ICertificationRepository, CertificationRepository>();
builder.Services.AddScoped<ITaskRepository, TaskRepository>();
builder.Services.AddScoped<ITalentRepository, TalentRepository>();
builder.Services.AddScoped<IBenefitRepository, BenefitRepository>();
builder.Services.AddScoped<IBankRepository, BankRepository>();
builder.Services.AddScoped<IEmployeeDocumentRepository, EmployeeDocumentRepository>();
builder.Services.AddScoped<ITodoListRepository, TodoListRepository>();
builder.Services.AddScoped<IVacationRepository, VacationRepository>();
builder.Services.AddScoped<IExpenseRequestRepository, ExpenseRequestRepository>();
builder.Services.AddScoped<ITravelRequestRepository, TravelRequestRepository>();


builder.Services.AddScoped<DepartmentService>();
builder.Services.AddScoped<EmployeeService>();
builder.Services.AddScoped<EmergencyContactService>();
builder.Services.AddScoped<CertificationService>();
builder.Services.AddScoped<TaskService>();
builder.Services.AddScoped<TalentService>();
builder.Services.AddScoped<BenefitService>();
builder.Services.AddScoped<BankService>();
builder.Services.AddScoped<EmployeeDocumentService>();
builder.Services.AddScoped<TodoListService>();
builder.Services.AddScoped<VacationService>();
builder.Services.AddScoped<ExpenseRequestService>();
builder.Services.AddScoped<TravelRequestService>();





builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
