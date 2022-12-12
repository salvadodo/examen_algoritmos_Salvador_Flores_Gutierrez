using consumirWebService.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;
//using System.Text.Json;

namespace consumirWebService.Controllers
{
    public class UsuariosController : Controller
    {
        // GET: Casas
        [HttpGet]
        public ActionResult Index()
        {
            using (HttpClient Cliente = new HttpClient())
            {
                Cliente.BaseAddress = new Uri("https://localhost:44363/");
                var request = Cliente.GetAsync("api/Usuarios").Result;
                if (request.IsSuccessStatusCode)
                {
                    var respuesta = request.Content.ReadAsStringAsync().Result;
                    var listadoUsuarios = JsonConvert.DeserializeObject<List<Usuarios>>(respuesta);
                    return View(listadoUsuarios);
                }
                //Si la petición es incorrecta regresa la vista con una lista de casas vacía
                return View(new List<Usuarios>());
            }
        }
        [HttpGet]
        public ActionResult Nuevo()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Nuevo(Usuarios insertarUsuarios)
        {
            using (HttpClient Cliente = new HttpClient())
            {
                Cliente.BaseAddress = new Uri("https://localhost:44363/");
                //var casaSerializada = System.Text.Json.JsonSerializer.Serialize<Usuarios>(insertarUsuarios);
                var usuarioSerializada = JsonConvert.SerializeObject(insertarUsuarios);
                //HttpContent es una clase abstracta que no se puede instanciar y se le asigna valor a traves de una clase no abstracta que hereda de HttpContent
                HttpContent content = new StringContent(usuarioSerializada, Encoding.UTF8, "application/json");
                var request = Cliente.PostAsync("api/Usuarios", content).Result;
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
                    return View(insertarUsuarios);
                }
                //Si la petición es incorrecta regresa la vista con los datos de la casa para corregirlos
                return View(insertarUsuarios);
            }
        }
        [HttpGet]
        public ActionResult Actualizar(int id)
        {
            using (HttpClient Cliente = new HttpClient())
            {
                Cliente.BaseAddress = new Uri("https://localhost:44363/");
                //var request = Cliente.GetAsync("api/Casas?modCasas=" + id).Result;
                var request = Cliente.GetAsync("api/Usuarios/" + id).Result;
                //var request = Cliente.GetAsync("api/Casas?id="+id+"&nombre="+nombre).Result;
                if (request.IsSuccessStatusCode)
                {
                    var respuesta = request.Content.ReadAsStringAsync().Result;
                    var usuarioSeleccionada = JsonConvert.DeserializeObject<Usuarios>(respuesta);
                    return View(usuarioSeleccionada);
                }
            }
            return View();
        }
        [HttpPost]
        public ActionResult Actualizar(Usuarios actualizarUsuario)
        {
            using (HttpClient Cliente = new HttpClient())
            {
                Cliente.BaseAddress = new Uri("https://localhost:44363/");
                //var casaSerializada=System.Text.Json.JsonSerializer.Serialize<Casas>(actualizarCasa);
                var usuarioSerializada = JsonConvert.SerializeObject(actualizarUsuario);
                HttpContent content = new StringContent(usuarioSerializada, Encoding.UTF8, "application/json");
                var request = Cliente.PutAsync("api/Usuarios/{id}", content).Result;
                if (request.IsSuccessStatusCode)
                {
                    var respuesta = request.Content.ReadAsStringAsync().Result;
                    var resBool = JsonConvert.DeserializeObject<bool>(respuesta);
                    if (resBool)
                    {
                        return RedirectToAction("Index");
                    }
                    return View(actualizarUsuario);
                }
                return View(actualizarUsuario);
            }
        }
        [HttpGet]
        public ActionResult Eliminar(int id)
        {
            using (HttpClient Cliente = new HttpClient())
            {
                Cliente.BaseAddress = new Uri("https://localhost:44363/");
                var request = Cliente.DeleteAsync("api/Usuarios?id=" + id).Result;
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
                var request = Cliente.GetAsync("api/Usuarios/" + id).Result;
                //var request = Cliente.GetAsync("api/Casas?id="+id+"&nombre="+nombre).Result;
                if (request.IsSuccessStatusCode)
                {
                    var respuesta = request.Content.ReadAsStringAsync().Result;
                    var usuarioSeleccionada = JsonConvert.DeserializeObject<Usuarios>(respuesta);
                    return View(usuarioSeleccionada);
                }
            }
            return View();
        }
    }
}