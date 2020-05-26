using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace LocalizationSetting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IStringLocalizer<ValuesController> _localizer;
        public ValuesController(IStringLocalizer<ValuesController> localizer)
        {
            _localizer = localizer;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<string> Get()
        {
            /*使用Request请求参数获取语言
             ?culture=zh-CN(等价于culture=zh-CN&ui-culture=zh-CN)
             ?culture=zh-CN&ui-culture=en-US
             */
            return Content(_localizer["Hello"]);
        }

        // GET api/values/5
        [Route("set")]
        [HttpGet]
        public ActionResult<string> Set()
        {
            //設置語言
            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName, CookieRequestCultureProvider.MakeCookieValue(new RequestCulture("en-US")));
            return "设置成功";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
