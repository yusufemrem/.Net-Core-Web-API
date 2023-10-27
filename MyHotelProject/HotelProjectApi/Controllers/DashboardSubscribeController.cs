using MHDtoLayer.FollowersDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace HotelProjectApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardSubscribeController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> instagramFolowersApi()
        {

            //var client = new HttpClient();
            //var request = new HttpRequestMessage
            //{
            //    Method = HttpMethod.Get,
            //    RequestUri = new Uri("https://instagram-profile1.p.rapidapi.com/getprofileinfo/yusuf.emrm"),
            //    Headers =
            //{
            //    { "X-RapidAPI-Key", "c066126ffemsh54d2ec7f46235c6p16302djsn545c83f8e3c1" },
            //    { "X-RapidAPI-Host", "instagram-profile1.p.rapidapi.com" },
            //},
            //};
            //using (var response = await client.SendAsync(request))
            //{
            //    response.EnsureSuccessStatusCode();
            //    var body = await response.Content.ReadAsStringAsync();
            //    ResultInstagramFollowersDto resultInstagramFollowersDtos = JsonConvert.DeserializeObject<ResultInstagramFollowersDto>(body);
            //    return Ok(resultInstagramFollowersDtos);
            //}


            //var client2 = new HttpClient();
            //var request2 = new HttpRequestMessage
            //{
            //    Method = HttpMethod.Get,
            //    RequestUri = new Uri("https://fresh-linkedin-profile-data.p.rapidapi.com/get-linkedin-profile?linkedin_url=https%3A%2F%2Fwww.linkedin.com%2Fin%2Fyusuf-emrem-b6b375225%2F"),
            //    Headers =
            //{
            //    { "X-RapidAPI-Key", "c066126ffemsh54d2ec7f46235c6p16302djsn545c83f8e3c1" },
            //    { "X-RapidAPI-Host", "fresh-linkedin-profile-data.p.rapidapi.com" },
            //},
            //};
            //using (var response2 = await client2.SendAsync(request2))
            //{
            //    response2.EnsureSuccessStatusCode();
            //    var body2 = await response2.Content.ReadAsStringAsync();
            //    ResultLinkedinFollowersDto resultLinkedinFollowersDtos = JsonConvert.DeserializeObject<ResultLinkedinFollowersDto>(body2);
            //    return Ok(resultLinkedinFollowersDtos);
            //    return Ok();
            //}
           
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://instagram-profile1.p.rapidapi.com/getprofile/yusuf.emrm"),
                Headers =
    {
        { "X-RapidAPI-Key", "d96df42134msh4f8a5f94272b8a4p1c3db3jsn605af9a43b22" },
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





         
            var client2 = new HttpClient();
            var request2 = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://fresh-linkedin-profile-data.p.rapidapi.com/get-linkedin-profile?linkedin_url=https%3A%2F%2Fwww.linkedin.com%2Fin%2Fyusuf-emrem-b6b375225%2F"),
                Headers =
    {
        { "X-RapidAPI-Key", "d96df42134msh4f8a5f94272b8a4p1c3db3jsn605af9a43b22" },
        { "X-RapidAPI-Host", "fresh-linkedin-profile-data.p.rapidapi.com" },
    },
            };
            using (var response2 = await client2.SendAsync(request2))
            {
                response2.EnsureSuccessStatusCode();
                var body2 = await response2.Content.ReadAsStringAsync();
                ResultLinkedinFollowersDto resultLinkedinFollowersDtos = JsonConvert.DeserializeObject<ResultLinkedinFollowersDto>(body2);
                return Ok(resultLinkedinFollowersDtos);
                 
            }
            return Ok();
        }
    }
}