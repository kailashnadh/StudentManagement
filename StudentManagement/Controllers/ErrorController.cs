using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace StudentManagement.Controllers
{
    public class ErrorController : Controller
    {
        private readonly ILogger<ErrorController> logger;

        public ErrorController(ILogger<ErrorController> logger)
        {
            this.logger = logger;
        }
        [Route("/Error/{statuscode}")]
        public IActionResult HttpErrorResult(int statuscode)
        {
            switch (statuscode)
            {
                case 404:
                    ViewBag.ErrorMessage = "Requested Page could not be found";
                    break;
                case 500:
                    ViewBag.ErrorMessage = "Requested Page could not be found";
                    break;
            }
            return View("pagenotfound");
        }
        [AllowAnonymous]
        [Route("/Error")]
       public IActionResult errorResult()
        {
            var exceptionHandle = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            /*          ViewBag.ExceptionPath = exceptionHandle.Path;
                      ViewBag.Message = exceptionHandle.Error.Message;
                      ViewBag.StackTrace = exceptionHandle.Error.StackTrace;*/
            logger.LogError($"path{exceptionHandle.Path} and error is {exceptionHandle.Error}"); 
            return View("Error");
        }
    }
}