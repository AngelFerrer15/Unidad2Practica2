using Microsoft.AspNetCore.Mvc;
using Unidad2Practica2.Models.Entities;
using Unidad2Practica2.Models.ViewModels;
using static Unidad2Practica2.Models.ViewModels.RazaPerroViewModel;

namespace Unidad2Practica2.Controllers
{
    public class HomeController : Controller
    {
        Random R = new();
        public HomeController()
        {
            LlenarAbece();
        }

        private readonly char[] abece = new char[26];
        List<OtrasClasesPerros> ListaPerros { get; set; } = new();
        private void LlenarAbece()
        {
            byte b = 65;
            for (int i = 0; i < 26; i++)
            {
                abece[i] += (char)b;
                b++;
            }
        }
        public IActionResult Index()
        {
            PerrosContext context = new();

            var datos = context.Razas.OrderBy(x => x.Nombre).Select(x => new RazaPerroModel
            {
                Id = x.Id,
                Nombre = x.Nombre
            }).ToList();

            IndexViewModel v = new()
            {
                RazasPerros = datos,
                ABC = abece
            };
            return View(v);
        }
        [Route("/Perro/{Id}")]
        public IActionResult Razas(string Id)
        {
            PerrosContext context = new();

            Id = Id.Replace("-", " ");
            var d = context.Razas.
                Where(x => x.Nombre == Id).Select(x => new RazaPerroViewModel
                {
                    Id = x.Id,
                    Nombre = x.Nombre,
                    OtrosNombres = x.OtrosNombres ?? "Sin nombre",
                    Descripcion = x.Descripcion ?? "Sin descripcion",
                    AlturaMaxima = x.AlturaMax,
                    AlturaMinima = x.AlturaMin,
                    EsperanzaVida = x.EsperanzaVida,
                    Pais = x.IdPaisNavigation != null ? (x.IdPaisNavigation.Nombre ?? "Sin pais") : "",
                    PesoMaximo = x.PesoMax,
                    PesoMinimo = x.PesoMin,

                    estadisticas = new EstadisticasPerroModel
                    {
                        AmistadDesconocidos = x.Estadisticasraza != null ? x.Estadisticasraza.AmistadDesconocidos : 0,
                        AmistadPerros = x.Estadisticasraza != null ? x.Estadisticasraza.AmistadPerros : 0,
                        EjercicioObligatorio = x.Estadisticasraza != null ? x.Estadisticasraza.EjercicioObligatorio : 0,
                        FacilidadEntrenamiento = x.Estadisticasraza != null ? x.Estadisticasraza.FacilidadEntrenamiento : 0,
                        NecesidadCepillado = x.Estadisticasraza != null ? x.Estadisticasraza.NecesidadCepillado : 0,
                        NivelEnergia = x.Estadisticasraza != null ? x.Estadisticasraza.NivelEnergia : 0
                    },
                    caracteristicas = new CaracteristicasPerroModel
                    {
                        Cola = x.Caracteristicasfisicas != null ? x.Caracteristicasfisicas.Cola ?? "" : "",
                        Color = x.Caracteristicasfisicas != null ? x.Caracteristicasfisicas.Color ?? "" : "",
                        Hocico = x.Caracteristicasfisicas != null ? x.Caracteristicasfisicas.Hocico ?? "" : "",
                        Patas = x.Caracteristicasfisicas != null ? x.Caracteristicasfisicas.Patas ?? "" : "",
                        Pelo = x.Caracteristicasfisicas != null ? x.Caracteristicasfisicas.Pelo ?? "" : "",
                    },
                    OtrosPerros = null!
                }).First();
            LlenarPerrrosAleatorios(Id);
            d.OtrosPerros = ListaPerros;
            return View(d);
        }

        public void LlenarPerrrosAleatorios(string nombre)
        {
            PerrosContext context = new();
            ListaPerros.Clear();
            var datos = context.Razas.Where(x => x.Nombre != nombre).Select(x => new OtrasClasesPerros
            {
                Id = x.Id,
                Nombre = x.Nombre
            }).ToList();

            for (int i = 0; i < 4; i++)
            {
                int a = R.Next(0, datos.Count);
                OtrasClasesPerros otros = datos[a];
                if (!ListaPerros.Contains(otros))
                {
                    ListaPerros.Add(otros);
                }

            }
        }

        [Route("/{filtrar}")]

        public IActionResult Index(string filtrar)
        {
            PerrosContext context = new();

            var datos = context.Razas.Where(x => x.Nombre.StartsWith(filtrar)).
                OrderBy(x => x.Nombre).Select(x => new RazaPerroModel
                {
                    Id = x.Id,
                    Nombre = x.Nombre
                }).ToList();

            IndexViewModel vm = new()
            {
                RazasPerros = datos,
                ABC = abece
            };
            return View(vm);
        }
        [Route("/Paises")]

        public IActionResult Pais() 
        {
            PerrosContext context = new();
            var datos = context.Paises.OrderBy(x => x.Nombre).Select(x => new PaisOrigenViewModel
            {
                Nombre = x.Nombre ?? "",
                Razasperros = x.Razas.OrderBy(r => r.Nombre).Select(r => new RazasPaisModel
                {
                    Id = r.Id,
                    Nombre = r.Nombre

                }).ToList()
            }).AsEnumerable();
            return View(datos);  
        }
    }
}
