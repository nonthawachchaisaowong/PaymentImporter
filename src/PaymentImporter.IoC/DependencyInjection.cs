using Autofac;
using PaymentImporter.Core.Domain.Entities.Logs;
using PaymentImporter.Core.Domain.Entities.Transactions;
using PaymentImporter.Core.Dto;
using PaymentImporter.Core.Domain.Repositories;
using PaymentImporter.Infrastructure.Data.EntityFramework.Repositories;
using PaymentImporter.Services.Helpers;
using PaymentImporter.Services.Importings;
using PaymentImporter.Services.Logging;
using PaymentImporter.Services.Transactions;

namespace PaymentImporter.Ioc
{
    public class DependencyInjection : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //Generics
            builder.RegisterGeneric(typeof(EfRepository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();

            //Reprsitories       
            builder.RegisterType<EfRepository<Transaction>>().As<IRepository<Transaction>>().InstancePerLifetimeScope();
            builder.RegisterType<EfRepository<TransactionStatus>>().As<IRepository<TransactionStatus>>().InstancePerLifetimeScope();
            builder.RegisterType<EfRepository<Currency>>().As<IRepository<Currency>>().InstancePerLifetimeScope();
            builder.RegisterType<EfRepository<Log>>().As<IRepository<Log>>().InstancePerLifetimeScope();

            //Services
            builder.RegisterType<TransactionService>().As<ITransactionService>().InstancePerLifetimeScope();
            builder.RegisterType<TransactionStatusService>().As<ITransactionStatusService>().InstancePerLifetimeScope();
            builder.RegisterType<CurrencyService>().As<ICurrencyService>().InstancePerLifetimeScope();
            builder.RegisterType<ImportingService>().As<IImportingService>().InstancePerLifetimeScope(); 
            builder.RegisterType<TransactionApiService>().As<ITransactionApiService>().InstancePerLifetimeScope();            
            builder.RegisterType<DtoHelper>().As<IDtoHelpers>().InstancePerLifetimeScope();
            builder.RegisterType<Logger>().As<ILogger>().InstancePerLifetimeScope(); 
        }
    }
}
