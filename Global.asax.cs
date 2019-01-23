using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.WebHost;
using System.Web.Routing;
using System.Web.SessionState;

namespace WebApplication1
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
        //public override void Init()
        //{
        //    this.PostAuthenticateRequest += MvcApplication_PostAuthenticateRequest;
        //    base.Init();
        //}

        //void MvcApplication_PostAuthenticateRequest(object sender, EventArgs e)
        //{
        //    if (HttpContext.Current.Session == null) {
        //        System.Web.HttpContext.Current.SetSessionStateBehavior(SessionStateBehavior.Required);
        //    }

        //}


        private const string _WebApiPrefix = "api";

        private static string _WebApiExecutionPath = String.Format("~/{0}", _WebApiPrefix);

        protected void Application_PostAuthorizeRequest()
        {

            if (IsWebApiRequest())
            {

                HttpContext.Current.SetSessionStateBehavior(SessionStateBehavior.Required);

            }

        }

        private static bool IsWebApiRequest()
        {

            return HttpContext.Current.Request.AppRelativeCurrentExecutionFilePath.StartsWith(_WebApiExecutionPath);

        }

    }
}