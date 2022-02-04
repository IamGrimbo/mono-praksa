using University.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;


namespace University.Model
{
    public class ModelDIModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Student>()
                       .As<IStudent>()
                       .InstancePerRequest();

            builder.RegisterType<Person>()
                       .As<IPerson>()
                       .InstancePerRequest();
        }
    }
}