[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Web.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Web.App_Start.NinjectWebCommon), "Stop")]

namespace Web.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using DAL;
    using Interfaces;
    using DAL.Repositories;
    using BAL.Services.UserService;
    using BAL.Factories;
    using BAL.DTOs;
    using Domain;
    using BAL.Services.TicketService;
    using BAL.Services.ProductService;
    using BAL.Services.RolePermissionService;
    using BAL.Services.ReplyService;
    using BAL.Services.TicketHistoryService;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IAppDbContext>().To<AppDbContext>().InRequestScope();

            kernel.Bind<IUserRepository>().To<UserRepository>().InRequestScope();
            kernel.Bind<IUserFactory>().To<UserFactory>().InRequestScope();
            kernel.Bind<IUserService>().To<UserService>().InRequestScope();
            kernel.Bind<IFactory<UserDTO, User>>().To<UserFactory>().InRequestScope();
            kernel.Bind<IRepository<User>>().To<UserRepository>().InRequestScope();

            kernel.Bind<ITicketRepository>().To<TicketRepository>().InRequestScope();
            kernel.Bind<ITicketFactory>().To<TicketFactory>().InRequestScope();
            kernel.Bind<ITicketService>().To<TicketService>().InRequestScope();
            kernel.Bind<IFactory<TicketDTO, Ticket>>().To<TicketFactory>().InRequestScope();
            kernel.Bind<IRepository<Ticket>>().To<TicketRepository>().InRequestScope();

            kernel.Bind<IProductRepository>().To<ProductRepository>().InRequestScope();
            kernel.Bind<IProductFactory>().To<ProductFactory>().InRequestScope();
            kernel.Bind<IProductService>().To<ProductService>().InRequestScope();
            kernel.Bind<IFactory<ProductDTO, Product>>().To<ProductFactory>().InRequestScope();
            kernel.Bind<IRepository<Product>>().To<ProductRepository>().InRequestScope();

            kernel.Bind<IRolePermissionRepository>().To<RolePermissionRepository>().InRequestScope();
            kernel.Bind<IRolePermissionFactory>().To<RolePermissionFactory>().InRequestScope();
            kernel.Bind<IRolePermissionService>().To<RolePermissionService>().InRequestScope();
            kernel.Bind<IFactory<RolePermissionDTO, RolePermission>>().To<RolePermissionFactory>().InRequestScope();
            kernel.Bind<IRepository<RolePermission>>().To<RolePermissionRepository>().InRequestScope();

            kernel.Bind<IReplyRepository>().To<ReplyRepository>().InRequestScope();
            kernel.Bind<IReplyFactory>().To<ReplyFactory>().InRequestScope();
            kernel.Bind<IReplyService>().To<ReplyService>().InRequestScope();
            kernel.Bind<IFactory<ReplyDTO, Reply>>().To<ReplyFactory>().InRequestScope();
            kernel.Bind<IRepository<Reply>>().To<ReplyRepository>().InRequestScope();

            kernel.Bind<ITicketHistoryRepository>().To<TicketHistoryRepository>().InRequestScope();
            kernel.Bind<ITicketHistoryFactory>().To<TicketHistoryFactory>().InRequestScope();
            kernel.Bind<ITicketHistoryService>().To<TicketHistoryService>().InRequestScope();
            kernel.Bind<IFactory<TicketHistoryDTO, TicketHistory>>().To<TicketHistoryFactory>().InRequestScope();
            kernel.Bind<IRepository<TicketHistory>>().To<TicketHistoryRepository>().InRequestScope();

        }        
    }
}
