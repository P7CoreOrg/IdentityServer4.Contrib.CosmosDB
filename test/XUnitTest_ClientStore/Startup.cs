using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;
using Xunit.DependencyInjection;
using Xunit.DependencyInjection.Demystifier;
using Xunit.DependencyInjection.Logging;

[assembly: TestFramework("XUnitTest_ClientStore.Startup", "XUnitTest_ClientStore")]

namespace XUnitTest_ClientStore
{
    public class Startup : DependencyInjectionTestFramework
    {
        public Startup(IMessageSink messageSink) : base(messageSink) { }

        protected override void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IDependency, DependencyClass>();
            services.AddSingleton<IAsyncExceptionFilter, DemystifyExceptionFilter>();
        }
        protected override void Configure(IServiceProvider provider)
        {
            provider.GetRequiredService<ILoggerFactory>()
               .AddProvider(new XunitTestOutputLoggerProvider(provider.GetRequiredService<ITestOutputHelperAccessor>()));


        }
    }
}
