using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition;

namespace CakeStore.Infrastructure
{
    //http://www.fidelitydesign.net/?p=259
    [Export(typeof(IDependencyResolver))]
    public class MefDependencyResolver : IDependencyResolver
    {
        private readonly CompositionContainer container;
        
        /// <summary>
        /// Initializes a new instance of <see cref="MEFDependencyResolver"/>.    
        /// </summary>    
        /// <param name="container">The current container.</param>    
        public MefDependencyResolver(CompositionContainer container)
        {
            Throw.IfArgumentNull(container, "container");
            this.container = container;
        }
        /// <summary>    
        /// Gets an instance of the service of the specified type.    
        /// </summary>    
        /// <param name="type">The type.</param>    
        /// <returns>An instance of the service of the specified type.</returns>    
        public object GetService(Type type)
        {
            Throw.IfArgumentNull(type, "type");
            string name = AttributedModelServices.GetContractName(type);
            
            try
            {
                return container.GetExportedValue<object>(name);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>    
        /// Gets all instances of the services of the specified type.    
        /// </summary>    
        /// <param name="type">The type.</param>    
        /// <returns>An enumerable of all instances of the services of the specified type.</returns>  
        public IEnumerable<object> GetServices(Type type)
        {
            Throw.IfArgumentNull(type, "type");
            string name = AttributedModelServices.GetContractName(type);
            try
            {
                return container.GetExportedValues<object>(name);
            }
            catch
            {
                return null;
            }
        }
    }
}