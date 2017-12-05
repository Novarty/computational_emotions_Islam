using Islam.DAL;
using Islam.DAL.Entities;
using Islam.Models.Requests;
using Islam.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var result = analyzator.Analyze(request.Text);
			return Ok();
		}
	}
}