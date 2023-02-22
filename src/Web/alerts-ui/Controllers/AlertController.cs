﻿using Dapr.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.MecSolutionAccelerator.AlertsUI.Models;
using Microsoft.MecSolutionAccelerator.AlertsUI.Pages;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Microsoft.MecSolutionAccelerator.AlertsUI.Controllers
{
    public class AlertController : Controller
    {
        public IEnumerable<Alert> Alerts;
        //public List<Alert> Alerts;
        private readonly DaprClient _daprClient;

        public AlertController(DaprClient daprClient)
        {
            _daprClient = daprClient;
        }

        // GET: /<controller>/
        public IEnumerable<Alert> Alert()
        {
            Alerts = new List<Alert>();
            ViewData["Alerts"] = Alerts;
            return Alerts;
        }

        public async Task<ActionResult> RefreshPage()
        {
            await RefreshData();
            IndexModel Model = new IndexModel();
            Model.Alerts = Alerts;
            return View("Alert", Model);
        }

        private async Task<string> RefreshData()
        {
            this.Alerts = await _daprClient.InvokeMethodAsync<IEnumerable<Alert>>(
                HttpMethod.Get,
                "alerts-api",
                "alerts");

            ViewData["Alerts"] = Alerts;
            return "New data added";
        }
    }
}