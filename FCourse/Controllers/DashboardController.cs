using FCourse.Data;
using FCourse.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FCourse.Controllers
{
    public class DashboardController : Controller
    {
        private DBContext db = new DBContext();

        public ActionResult Index(int? year)
        {
            ViewBag.BreadCrumb = "Dashboard";
            List<DataPoint> dataPoints = new List<DataPoint>();
            List<long> revenueByYear = new List<long>();
            for (int i = 1; i < 13; i++)
            {
                var revenueByMonth = db.Orders.Where(s => s.CreatedAt.Month == i && s.CreatedAt.Year == year).Sum(s => s.TotalPrice);
                revenueByYear.Add((long)revenueByMonth);
            }
            dataPoints.Add(new DataPoint("January", revenueByYear[0]));
            dataPoints.Add(new DataPoint("February ", revenueByYear[1]));
            dataPoints.Add(new DataPoint("March", revenueByYear[2]));
            dataPoints.Add(new DataPoint("April ", revenueByYear[3]));
            dataPoints.Add(new DataPoint("May", revenueByYear[4]));
            dataPoints.Add(new DataPoint("June", revenueByYear[5]));
            dataPoints.Add(new DataPoint("July", revenueByYear[6]));
            dataPoints.Add(new DataPoint("August", revenueByYear[7]));
            dataPoints.Add(new DataPoint("September", revenueByYear[8]));
            dataPoints.Add(new DataPoint("October", revenueByYear[9]));
            dataPoints.Add(new DataPoint("November", revenueByYear[10]));
            dataPoints.Add(new DataPoint("December", revenueByYear[11]));
            ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);
            return View();
        }
    }
}