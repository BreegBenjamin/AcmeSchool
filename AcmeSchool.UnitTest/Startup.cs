using AcmeSchool.Core.Interfaces;
using AcmeSchool.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AcmeSchool.UnitTest
{
    public class Startup
    {
        public IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            // Configuring services required for dependency injection testing

            services.AddTransient<ICourseService, CourseService>();
            services.AddTransient<IStudentService, StudentService>();

            // other services...

            return services.BuildServiceProvider();
        }
    }
}
