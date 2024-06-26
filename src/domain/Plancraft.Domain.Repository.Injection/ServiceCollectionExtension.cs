﻿using Microsoft.Extensions.DependencyInjection;
using Plancraft.Domain.Repository.Abstraction;
using Plancraft.Domain.Repository.Unit;
using Plancraft.Domain.Repository.Unit.Projects;

namespace Plancraft.Domain.Repository.Injection
{
    public static class ServiceCollectionExtension
    {
        public static void ConfigureRepositoryInjection(this IServiceCollection services)
        {
            services.AddSingleton<ProjectRepository>();
            services.AddSingleton(typeof(IRepositoryOptions<>), typeof(RepositoryOptions<>));
        }
    }
}
