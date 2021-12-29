using LabsLibrary;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PR5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PR5.Controllers
{
    [Authorize]
    public class LabsController : Controller
    {
        public IActionResult PR1()
        {
            return View();
        }
        [HttpPost]
        public IActionResult PR1(PR1Model Lab1Model)
        {
            try
            {
                Lab1Model.Response = new pr1()
                    .GetResult(Lab1Model.Data)
                    .ToString();
                Lab1Model.Calculated = true;
            }
            catch (Exception exception)
            {
                Lab1Model.ErrorValue = exception.Message;
            }
            return View(Lab1Model);
        }
        public IActionResult PR2()
        {
            return View();
        }
        [HttpPost]
        public IActionResult PR2(PR2Model Lab2Model)
        {
            try
            {
                Lab2Model.Response = new Lab2()
                    .GetResult(Lab2Model.N,Lab2Model.Q )
                    .ToString();
                Lab2Model.Calculated = true;
            }
            catch (Exception exception)
            {
                Lab2Model.ErrorValue = exception.Message;
            }
            return View(Lab2Model);
        }
    }
}
