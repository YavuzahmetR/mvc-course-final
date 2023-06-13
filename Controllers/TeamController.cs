using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace AgricultureUI.Controllers
{
    public class TeamController : Controller
    {
        private readonly ITeamService _teamservice;

        public TeamController(ITeamService teamservice)
        {
            _teamservice = teamservice;
        }

        public IActionResult Index()
        {
            var result = _teamservice.GetListAll();
            return View(result);
        }
        [HttpGet]
        public IActionResult AddTeam() 
        { 
            return View();
        }
        [HttpPost]
        public IActionResult AddTeam(Team team)
        {
            TeamValidator validationRules = new TeamValidator();
            ValidationResult result = validationRules.Validate(team);
            if(result.IsValid)
            {
                _teamservice.Insert(team);
                return RedirectToAction("Index");
            }
            else
            {
                foreach(var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        public IActionResult DeleteTeam(int id)
        {
            var values = _teamservice.GetById(id);
            _teamservice.Delete(values);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult EditTeam(int id)
        {
            var values = _teamservice.GetById(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult EditTeam(Team team)
        {
            TeamValidator validationRules = new TeamValidator();
            ValidationResult result = validationRules.Validate(team);
            if (result.IsValid)
            {
                _teamservice.Update(team);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();            
        }
    }
}
