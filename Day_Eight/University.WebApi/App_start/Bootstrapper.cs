using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace University.WebApi.App_start
{
    public class Bootstrapper
    {

        public static void Run()
        {

            AutofacWebapiConfig.Initialize(GlobalConfiguration.Configuration);
        }

    }
}