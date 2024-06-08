using CURDwithCoreWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Policy;
using System.Text;

namespace CURDwithCoreWebAPI.Controllers
{
    public class StudentController : Controller
    {

        private string url = "https://localhost:7094/api/StudentAPI/";
        private HttpClient client = new HttpClient();
        [HttpGet]
        public IActionResult Index()
        {
            List<Student> students = new List<Student>();
            HttpResponseMessage response = client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                string stdData = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<List<Student>>(stdData);
                if (data != null)
                {
                    students = data;
                }
            }
            return View(students);
        }

        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(Student std)
        {
            string data = JsonConvert.SerializeObject(std);
            StringContent Content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(url, Content).Result;
            if (response.IsSuccessStatusCode)
            {
                TempData["InsertMessage"] = "Student Added..";
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Student students = new Student();

            HttpResponseMessage response = client.GetAsync(url + id).Result;
            if (response.IsSuccessStatusCode)
            {
                string stdData = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<Student>(stdData);
                if (data != null)
                {
                    students = data;
                }
            }
            return View(students);
        }

        [HttpPost]
        public IActionResult Edit(Student std)
        {
            string data = JsonConvert.SerializeObject(std);
            StringContent Content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PutAsync(url + std.id, Content).Result;
            if (response.IsSuccessStatusCode)
            {
                TempData["UpdateMessage"] = "Student Updated!!";
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            Student students = new Student();

            HttpResponseMessage response = client.GetAsync(url + id).Result;
            if (response.IsSuccessStatusCode)
            {
                string stdData = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<Student>(stdData);
                if (data != null)
                {
                    students = data;
                }
            }
            return View(students);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Student students = new Student();

            HttpResponseMessage response = client.GetAsync(url + id).Result;
            if (response.IsSuccessStatusCode)
            {
                string stdData = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<Student>(stdData);
                if (data != null)
                {
                    students = data;
                }
            }
            return View(students);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirm(int id)
        {          
            HttpResponseMessage response = client.DeleteAsync(url + id).Result;
            if (response.IsSuccessStatusCode)
            {
                TempData["DeleteMessage"] = "Student Deleted!!";
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}
