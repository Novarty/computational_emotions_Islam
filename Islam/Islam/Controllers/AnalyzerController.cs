using Islam.DAL;
using Islam.DAL.Entities;
using Islam.Models.Requests;
using Islam.Models.Responses;
using System;
using System.Linq;
using System.Web;
using System.Web.Http;
using Islam.Service;

namespace Islam.Controllers
{
	[RoutePrefix("analyzer")]
	public class AnalyzerController : ApiController
	{
		private Context context = new Context();
		
		[HttpPost]
		[Route("analyze")]
		public IHttpActionResult Analyze([FromBody]AnalyzeRequest request)
		{
            TextAnalyzator analyzator = new TextAnalyzator(context);
			var c = context.Vectors.ToList();
			context.SaveChanges();
			return Ok();
		}
	}
}