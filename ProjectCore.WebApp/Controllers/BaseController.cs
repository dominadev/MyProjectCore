using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectCore.Ultility.Emum;

namespace ProjectCore.WebApp.Controllers
{
    public class BaseController : Controller
    {
        protected dynamic Data { get; set; }
        protected int Status { get; set; }
        protected int TotalRow { get; set; }
        public IActionResult GetActionResult()
        {
            return Json(new { Data ,Status,TotalRow});
        }
        public IActionResult CreateActionResult( Func<IActionResult> func)
        {
            try
            {                
                return func.Invoke();
            }
            catch (Exception ex)
            {

                WriteLog(ex.Message, (int)LogTypeEnum.Error);
                Status = -1;
                return GetActionResult();
            }
            
        }
        public IActionResult CreateActionResult(string logString ,Func<IActionResult> func)
        {
            try
            {
                WriteLog(logString, (int)LogTypeEnum.Action);
                return func.Invoke();
            }
            catch (Exception ex)
            {

                WriteLog(ex.Message, (int)LogTypeEnum.Error);
                Status = -1;
                return GetActionResult();
            }
           
        }
        private void WriteLog(string logString, int logType)
        {

        }
    }
}