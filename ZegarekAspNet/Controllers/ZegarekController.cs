using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ZegarekLib;

namespace ZegarekAspNet.Controllers
{
    public class ZegarekController : ApiController
    {
		[HttpGet]
		[ActionName("angle")]
		public IHttpActionResult GetAngle(int hours, int minutes, int width, int height)
		{
			ClockFace clock = new ClockFace(width, height);
			clock.SetTime(new TimeSpan(hours, minutes, 0));
			return Ok(clock);
		}
    }
}
