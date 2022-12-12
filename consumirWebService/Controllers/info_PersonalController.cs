using consumirWebService.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace consumirWebService.Controllers
{
    public class info_PersonalController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            using (HttpClient Cliente = new HttpClient())
            {
                Cliente.BaseAddress = new Uri("https://localhost:44363/");
                var request = Cliente.GetAsync("api/info_Personal").Result;
                if (request.IsSuccessStatusCode)
                {
                    var respuesta = request.Content.ReadAsStringAsync().Result;
                    var listadoinfo_Personal = JsonConvert.DeserializeObject<List<info_Personal>>(respuesta);
                    return View(listadoinfo_Personal);
                }
                //Si la petición es incorrecta regresa la vista con una lista de casas vacía
                return View(new List<info_Personal>());
            }
        }
        [HttpGet]
        public ActionResult Nuevo()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Nuevo(info_Personal insertarinfo_Personal)
        {
            using (HttpClient Cliente = new HttpClient())
            {
                Cliente.BaseAddress = new Uri("https://localhost:44363/");
                //var casaSerializada = System.Text.Json.JsonSerializer.Serialize<Usuarios>(insertarUsuarios);
                var info_PersonalSerializada = JsonConvert.SerializeObject(insertarinfo_Personal);
                //HttpContent es una clase abstracta que no se puede instanciar y se le asigna valor a traves de una clase no abstracta que hereda de HttpContent
                HttpContent content = new StringContent(info_PersonalSerializada, Encoding.UTF8, "application/json");
                var request = Cliente.PostAsync("api/info_Personal", content).Result;
                //PostAsJsonAsync se encuentra en el espacio de nombre System.Net.Http.Json y envia el uri y el objeto en formato json
                //var request = Client.PostAsJsonAsync("https://localhost:44363/", insertarCasa);
                if (request.IsSuccessStatusCode)
                {
                    var respuesta = request.Content.ReadAsStringAsync().Result;
                    var resBool = JsonConvert.DeserializeObject<bool>(respuesta);
                    if (resBool)
                    {
                        return RedirectToAction("Index");
                    }
                    return View(insertarinfo_Personal);
                }
                //Si la petición es incorrecta regresa la vista con los datos de la casa para corregirlos
                return View(insertarinfo_Personal);
            }
        }
        [HttpGet]
        public ActionResult Actualizar(int id)
        {
            using (HttpClient Cliente = new HttpClient())
            {
                Cliente.BaseAddress = new Uri("https://localhost:44363/");
                //var request = Cliente.GetAsync("api/Casas?modCasas=" + id).Result;
                var request = Cliente.GetAsync("api/info_Personal/" + id).Result;
                //var request = Cliente.GetAsync("api/Casas?id="+id+"&nombre="+nombre).Result;
                if (request.IsSuccessStatusCode)
                {
                    var respuesta = request.Content.ReadAsStringAsync().Result;
                    var info_PersonalSeleccionada = JsonConvert.DeserializeObject<info_Personal>(respuesta);
                    return View(info_PersonalSeleccionada);
                }
            }
            return View();
        }
        [HttpPost]
        public ActionResult Actualizar(Usuarios actualizarinfo_Personal)
        {
            using (HttpClient Cliente = new HttpClient())
            {
                Cliente.BaseAddress = new Uri("https://localhost:44363/");
                //var casaSerializada=System.Text.Json.JsonSerializer.Serialize<Casas>(actualizarCasa);
                var info_PersonalSerializada = JsonConvert.SerializeObject(actualizarinfo_Personal);
                HttpContent content = new StringContent(info_PersonalSerializada, Encoding.UTF8, "application/json");
                var request = Cliente.PutAsync("api/info_Personal/{id}", content).Result;
                if (request.IsSuccessStatusCode)
                {
                    var respuesta = request.Content.ReadAsStringAsync().Result;
                    var resBool = JsonConvert.DeserializeObject<bool>(respuesta);
                    if (resBool)
                    {
                        return RedirectToAction("Index");
                    }
                    return View(actualizarinfo_Personal);
                }
                return View(actualizarinfo_Personal);
            }
        }
        [HttpGet]
        public ActionResult Eliminar(int id)
        {
            using (HttpClient Cliente = new HttpClient())
            {
                Cliente.BaseAddress = new Uri("https://localhost:44363/");
                var request = Cliente.DeleteAsync("api/info_Personal?id=" + id).Result;
                if (request.IsSuccessStatusCode)
                {
                    var respuesta = request.Content.ReadAsStringAsync().Result;
                    var resBool = JsonConvert.DeserializeObject<bool>(respuesta);
                    if (resBool)
                    {
                        return RedirectToAction("Index");
                    }
                }
                return View();
            }
        }
        [HttpGet]
        public ActionResult Detalle(int id)
        {
            using (HttpClient Cliente = new HttpClient())
            {
                Cliente.BaseAddress = new Uri("https://localhost:44363/");
                //var request = Cliente.GetAsync("api/Casas/{id}").Result;
                var request = Cliente.GetAsync("api/info_Personal/" + id).Result;
                //var request = Cliente.GetAsync("api/Casas?id="+id+"&nombre="+nombre).Result;
                if (request.IsSuccessStatusCode)
                {
                    var respuesta = request.Content.ReadAsStringAsync().Result;
                    var info_PersonalSeleccionada = JsonConvert.DeserializeObject<info_Personal>(respuesta);
                    return View(info_PersonalSeleccionada);
                }
            }
            return View();
        }
    }
}