using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Octokit;
using Newtonsoft.Json;

namespace Git4Me.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public string Get()
        {
            try
            {
                var conn = new Octokit.Connection(new ProductHeaderValue("GVTCJon"));

                var x = new Octokit.GitHubClient(conn);

                // could build resources to consume Linux and Git repos

                IRepositoriesClient cl = x.Repository;
                var dd = x.User.Get("GVTCJon");

                // var lst =  cl.GetAllForUser("GVTCJon").Result;
                var lst = cl.GetAllForUser("torvalds").Result.ToList();
                //var gitproj = cl.Get("git", "git").Result;

                return JsonConvert.SerializeObject(lst);
                //return JsonConvert.SerializeObject(gitproj);  // uncomment to release the hounds!
            }
            catch (Exception e)
            {
                return null;
            }
        }

        // GET api/values/5
        public string Get(string searchword)
        {
            try
            {
                var conn = new Octokit.Connection(new ProductHeaderValue("GVTCJon"));

                var x = new Octokit.GitHubClient(conn);

                IRepositoriesClient cl = x.Repository;

                // var lst =  cl.GetAllForUser("GVTCJon").Result;
                var lst = cl.GetAllForUser("torvalds").Result.Where(w => w.Description.Contains(searchword)).ToList();
                // var gitproj = cl.Get("git", "git").Result;

                return JsonConvert.SerializeObject(lst);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        // POST api/values
        public string Post([FromBody]string searchword)
        {
            return Get(searchword);          
        }

        // PUT api/values/5
        public HttpResponseMessage Put(int id, [FromBody]string value)
        {
            // Put not available to muggles, only Torvaldx
            HttpResponseMessage res = new HttpResponseMessage();
            res.StatusCode = HttpStatusCode.NotImplemented;
            return res;
        }

        // DELETE api/values/5
        public HttpResponseMessage Delete(int id)
        {
            // Delete not available to mortals
            HttpResponseMessage res = new HttpResponseMessage();
            res.StatusCode = HttpStatusCode.NotImplemented;
            return res;
        }
    }
}
