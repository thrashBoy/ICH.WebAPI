﻿using System.Collections.Generic;
using System.Threading.Tasks;
using ICH.Steward.Domain;
using ICH.Steward.Domain.Interfaces.Repositories;
using ICH.Util;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace ICH.Steward.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("CorsPolicy")]
    //[Authorize(Policy = "Token")]
    public class ValuesController : Controller
    {
        private IBaseUserRepository _baseUserRepository;
        public ValuesController(IBaseUserRepository baseUserRepository)
        {
            _baseUserRepository = baseUserRepository;
        }

        // GET api/values
        [HttpGet]
        public async Task<JsonResult> Get()
        {
            //bool r=  await _baseUserRepository.BatchSetOpenIdAsync(); //同步openid
            //int total = 0;
            var list =await _baseUserRepository.FindListAsync(t => true, "realname", true, 10, 1);
            return Json(ResponseResult.Execute(list));
            //return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
