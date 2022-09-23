﻿using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Modules.EmployeeManagement.Core.Abstractions;
using Modules.EmployeeManagement.Core.Entities;
using Shared.Core.EventLogging;
using Shared.Core.Interfaces.Serialization;
using Shared.Core.Settings;
using Shared.Infrastructure.Persistence;

namespace Modules.EmployeeManagement.Infrastructure.Persistence
{
    public class EmployeeManagementDbContext : ModuleDbContext, IStaffManagementDbContext
    {
        public EmployeeManagementDbContext(DbContextOptions options, IMediator mediator, IEventLogger eventLogger, IOptions<PersistenceSettings> persistenceOptions, IJsonSerializer json) : base(options, mediator, eventLogger, persistenceOptions, json)
        {
        }

        protected override string Schema => "StaffManagement";


        public DbSet<StaffMember> StaffMemebers { get; set; }

        public StaffTask StaffTasks { get; set; }
    }
}