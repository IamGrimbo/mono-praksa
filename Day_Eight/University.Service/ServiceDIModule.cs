using University.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;


namespace University.Service
{
    public class ServiceDIModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<StudentService>()
                       .As<IStudentService>()
                       .InstancePerRequest();

            builder.RegisterType<PersonService>()
                       .As<IPersonService>()
                       .InstancePerRequest();
        }
    }
}