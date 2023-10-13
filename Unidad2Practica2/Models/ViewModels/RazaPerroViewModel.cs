namespace Unidad2Practica2.Models.ViewModels
{
    public class RazaPerroViewModel
    {
        
            public uint Id { get; set; }
            public string Nombre { get; set; } = null!;
            public string Descripcion { get; set; } = null!;
            public string OtrosNombres { get; set; } = null!;
            public string Pais { get; set; } = null!;
            public float PesoMinimo { get; set; }
            public float PesoMaximo { get; set; }
            public float AlturaMinima { get; set; }
            public float AlturaMaxima { get; set; }
            public uint EsperanzaVida { get; set; }
            public EstadisticasPerroModel estadisticas { get; set; } = null!;
            public CaracteristicasPerroModel caracteristicas { get; set; } = null!;
            public ICollection<OtrasClasesPerros> OtrosPerros { get; set; } = null!;
        }
        public class EstadisticasPerroModel
        {
            public uint NivelEnergia { get; set; }
            public uint FacilidadEntrenamiento { get; set; }
            public uint EjercicioObligatorio { get; set; }
            public uint AmistadDesconocidos { get; set; }
            public uint AmistadPerros { get; set; }
            public uint NecesidadCepillado { get; set; }
        }
        public class CaracteristicasPerroModel
        {
            public string Patas { get; set; } = null!;
            public string Cola { get; set; } = null!;
            public string Hocico { get; set; } = null!;
            public string Pelo { get; set; } = null!;
            public string Color { get; set; } = null!;
        }
        public class OtrasClasesPerros
        {
            public uint Id { get; set; }
            public string Nombre { get; set; } = null!;
        
    }
}
