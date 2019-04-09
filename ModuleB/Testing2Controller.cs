using System.ComponentModel.Composition;
using System.Web.Http;
using System.Web.Http.Controllers;
using SharedDependency.Common;

namespace ModuleB
{
    [Export(typeof(IHttpController))]
    public class Testing2Controller : ApiController
    {
        [Import]
        public IDoSomething Something { get; set; }
        
        [HttpGet]
        [Route("Test2/doSomething")]
        public IHttpActionResult DoSomething()
        {
            return Ok(Something.DoSomething(2));
        }
    }
}
