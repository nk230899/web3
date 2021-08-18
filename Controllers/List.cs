using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models;
using System.Data.SqlClient;

namespace WebApplication3.Controllers
{
    public class List : Controller
    {

        static IList<Employee> Elist = new List<Employee>(){
                                        new Employee() { Id = 1, first_name = "Nikhil",last_name = "Kumar"}
        };
        public IActionResult Index()
        {
            string cs = "data source=(local); database=webapp ; integrated security=SSPI";
            using(var con = new SqlConnection(cs))
            {

            }

            return View(Elist);
        }

        
        public IActionResult Edit(Employee std)
        {
            var id = std.Id;
            var fname = std.first_name;
            var lname = std.last_name;
           

         

            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee std)
        {
            var id = std.Id;
            var fname = std.first_name;
            var lname = std.last_name;
            //var standardName = std.standard.StandardName;
            string cs = "Data source=(local); database=webapp ; integrated security=SSPI";
            using (var con = new SqlConnection(cs))
            {
                var cmd = new SqlCommand("addnewemployee", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@eid", id);
                cmd.Parameters.AddWithValue("@fname", fname);
                cmd.Parameters.AddWithValue("@lname", lname);
                con.Open();
                int i= (int)cmd.ExecuteNonQuery();
            }
            Elist.Add(std);

            return RedirectToAction("Index");
        }

        // [NonAction]
        //
        public IActionResult Delete(int id)
        {
          // var id = std.Id;
            //var fname = std.first_name;
            //var lname = std.last_name;
            //var standardName = std.standard.StandardName;
            string cs = "Data source=(local); database=webapp ; integrated security=SSPI";
            using (var con = new SqlConnection(cs))
            {
                var cmd = new SqlCommand("delemployee", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@eid", id);
                con.Open();
                int i = (int)cmd.ExecuteNonQuery();
            }
            Elist.Clear();//change this to delete only the one

            return RedirectToAction("Index");
        }

       
    }
}
