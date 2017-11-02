using Islam.Models;
using System.Web.Http;

namespace Islam.Controllers
{
	[RoutePrefix("analyzer")]
	public class AnalyzerController : ApiController
	{

		[HttpPost]
		[Route("analyze")]
		public IHttpActionResult Analyze([FromBody]AnalyzeRequest request)
		{
			AnalyzeResponse response = new AnalyzeResponse();
			return Ok(response);
		}

		[HttpPost]
		[Route("add_to_db")]
		public IHttpActionResult AddToDb([FromBody]AddToDbRequest request)
		{

			return Ok();
		}
	}
}