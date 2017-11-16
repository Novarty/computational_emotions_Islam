﻿using Islam.DAL;
using Islam.Models.Requests;
using Islam.Models.Responses;
using System.Web.Http;

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