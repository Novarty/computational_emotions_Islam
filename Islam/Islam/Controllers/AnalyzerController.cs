using Islam.DAL;
using Islam.DAL.Entities;
using Islam.Models.Requests;
using Islam.Models.Responses;
using System;
using System.Linq;
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
			context.Vectors.Add(new Vector { Word = request.Text });
			context.SaveChanges();
			AnalyzeResponse response = new AnalyzeResponse
			{
				Items = context.Emotions.Select(e => new AnalyzeResponseItem
				{
					Emotion = e.Enum,
					//Value = random.NextDouble()
				})
			};
			return Ok(response);
		}
	}
}