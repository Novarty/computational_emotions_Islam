﻿using Islam.DAL;
using Islam.DAL.Entities;
using Islam.Models.Requests;
using Islam.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Islam.Service;
using Islam.Core;

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
			EmotionalVector result = analyzator.Analyze(request.Text);
			AnalyzeResponse response = new AnalyzeResponse
			{
				Items = result.EmotionalTone.Select(t => new AnalyzeResponseItem
				{
					Emotion = t.Emotion,
					Value = t.Value
				})
			};
			return Ok(response);
		}
	}
}