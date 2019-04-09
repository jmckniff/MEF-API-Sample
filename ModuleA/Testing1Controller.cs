using System.ComponentModel.Composition;
using System.Web.Http;
using System.Web.Http.Controllers;
using SharedDependency.Common;

namespace ModuleA
{
    [Export(typeof(IHttpController))]
    public class Testing1Controller : ApiController
    {
        [Import]
        public IDoSomething Something { get; set; }
        
        [HttpGet]
        [Route("Test1/doSomething")]
        public IHttpActionResult DoSomething()
        {
            return Ok(Something.DoSomething(1));
        }
    }
}
