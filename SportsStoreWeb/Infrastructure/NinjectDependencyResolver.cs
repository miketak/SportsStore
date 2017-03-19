using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using Moq;
using SportsStoreDomain.Entities;
using SportsStoreDomain.Abstract;
using SportsStoreDomain.Concrete;

namespace SportsStoreWeb.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel _kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            _kernel = kernelParam;
            addBindings();
        }

        private void addBindings()
        {

            _kernel.Bind<IProductRepository>().To<EFProductRepository>();

            //Mock<IProductRepository> mock = new Mock<IProductRepository>();
            //mock.Setup(m => m.Products).Returns(new List<Product>{
            //    new Product { Name = "Football", Price = 25M },
            //    new Product { Name = "Surf Board", Price = 179M},
            //    new Product { Name = "Running Shoes", Price = 95M }
            //});

            //_kernel.Bind<IProductRepository>().ToConstant(mock.Object);

        }
        public object GetService(Type serviceType)
        {
            return _kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _kernel.GetAll(serviceType);
        }
    }
}