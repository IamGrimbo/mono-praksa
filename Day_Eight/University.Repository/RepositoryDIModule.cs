using University.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;


namespace University.Repository
{
    public class RepositoryDIModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<StudentRepository>()
                       .As<IStudentRepository>()
                       .InstancePerRequest();

            builder.RegisterType<PersonRepository>()
                       .As<IPersonRepository>()
                       .InstancePerRequest();
        }
    }
}