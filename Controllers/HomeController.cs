using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    public class HomeController : ApiController
    {
       // = (List<int>)Session["test"];
        List<clsOwnerModelData> OwnerList = new List<clsOwnerModelData>();
        // POST: api/Home
        [HttpPost]
        public string Post([FromBody] clsOwnerModelData obj)
        {
            string SessionKey = "Owner";
            //if (HttpContext.Current.Session[SessionKey]==null)
            //{
               

            //};
            //else
            //{
            //    OwnerList = (List<clsOwnerModelData>)HttpContext.Current.Session["SessionKey"];


            //}
            if (HttpContext.Current.Session!=null)
                HttpContext.Current.Session[SessionKey] = obj;

            string myObj = "Success";
            return myObj.ToString();
        }

        // GET: api/Home/5
        [HttpGet]
        public string Get(int id)
        {
            //for bonus
            //change return parametr to List<clsOwnerModelData>
            OwnerList = (List<clsOwnerModelData>)HttpContext.Current.Session["SessionKey"];
            string myObj = "[{\"Status\":\"Team Work Rocks\"},[{\"ProjectA\":\"1\"},{\"ProjectB\":\"2\"},{\"ProjectC\":\"3\"}]]";
            return myObj.ToString();            
        }
                
        // PUT: api/Home/1
        public void Put(int id, [FromBody] putModelData putModelObj)
        {
            string myObj = putModelObj.DataVar1 + " " + putModelObj.DataVar2;
        }

        // DELETE: api/Home/2
        public void Delete(int id)
        {
            //Delete Logic
        }
    }
}

public class postModelData
{
    public string FstVarValue;
    public string SndVarValue;    
}

public class putModelData
{
    public string DataVar1;
    public string DataVar2;
}
public class clsOwnerModelData
{
 public int id;
 public string Name ;
 public string Url;
}
