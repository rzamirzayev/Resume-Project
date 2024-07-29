using Autofac;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class PersistenceRegisterModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterAssemblyTypes(this.GetType().Assembly).AsImplementedInterfaces().InstancePerLifetimeScope();
        }
    }
}
