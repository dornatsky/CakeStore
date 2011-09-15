using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;

namespace CakeStore.Infrastructure
{

    //http://blog.maartenballiauw.be/post/2010/07/27/ASPNET-MVC-3-and-MEF-sitting-in-a-tree.aspx
    [Export(typeof(IControllerFactory))]
    public class MefControllerFactory : DefaultControllerFactory
    {
        private IDependencyResolver _resolver;
        private CompositionContainer _container;

        [ImportingConstructor]
        public MefControllerFactory(IDependencyResolver dependencyResolver, CompositionContainer container)
        {
            _resolver = dependencyResolver;
            _container = container;
        }

        public override IController CreateController(RequestContext requestContext, string controllerName)
        {
            var controllerType = GetControllerType(requestContext, controllerName);
            if (controllerType != null)
            {
                return _resolver.GetService(controllerType) as IController;
            }

            return base.CreateController(requestContext, controllerName);
        }
    }
}