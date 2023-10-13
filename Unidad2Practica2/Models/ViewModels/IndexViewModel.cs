namespace Unidad2Practica2.Models.ViewModels
{
    public class IndexViewModel
    {
        public char[] ABC { get; set; } = null!;

        public ICollection<RazaPerroModel> RazasPerros { get; set; } = null!;

    }
    public class RazaPerroModel
    {
        public uint Id { get; set; }
        public string Nombre { get; set; } = null!;
    }
}
