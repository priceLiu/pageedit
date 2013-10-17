using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Peanut;
namespace Clay.Web.App.Code.Controllers
{
    public class AjaxStatus:Peanut.IResult
    {
        public Exception Error
        {
            get;
            set;
        }
        public void Execute()
        {
            if (Error != null)
            {
                WebContext.Current.Response.Write(Error.Message);
            }
            else
            {
                WebContext.Current.Response.Write("Success");
                
            }
            WebContext.Current.Response.Flush();
            WebContext.Current.Response.End();
        }
    }
}