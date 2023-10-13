namespace Unidad2Practica2.Models.ViewModels
{
    public class PaisOrigenViewModel
    {
        public string Nombre { get; set; } = null!;
        public ICollection<RazasPaisModel> Razasperros { get; set; } = null!;
    }
    public class RazasPaisModel
    {
        public uint Id { get; set; }
        public string Nombre { get; set; } = null!;
    }
}
