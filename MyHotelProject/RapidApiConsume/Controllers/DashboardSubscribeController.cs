using MHDtoLayer.FollowersDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace RapidApiConsume.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardSubscribeController : ControllerBase
    {
        public async Task<IActionResult> instagramFolowersApi()
        {
			
			var client = new HttpClient();
			var request = new HttpRequestMessage
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri("https://instagram-profile1.p.rapidapi.com/getprofileinfo/yusuf.emrm"),
				Headers =
	{
		{ "X-RapidAPI-Key", "c066126ffemsh54d2ec7f46235c6p16302djsn545c83f8e3c1" },
		{ "X-RapidAPI-Host", "instagram-profile1.p.rapidapi.com" },
	},
			};
			using (var response = await client.SendAsync(request))
			{
				response.EnsureSuccessStatusCode();
				var body = await response.Content.ReadAsStringAsync();
				ResultInstagramFollowersDto resultInstagramFollowersDtos = JsonConvert.DeserializeObject<ResultInstagramFollowersDto>(body);
				return Ok(resultInstagramFollowersDtos);
			}
			
		}
    }
}
