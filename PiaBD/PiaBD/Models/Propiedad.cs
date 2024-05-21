namespace PiaBD.Models
{
    public class Propiedad
    {
        public int IDPropiedad { get; set; }
        public int TerrenoM2 { get; set; }
        public string Descripcion { get; set; }
        public int CantCuartos { get; set; }
        public int CantBanhos { get; set; }
        public int CantDormitorios { get; set; }
        public string NotasExtra { get; set; }
        public decimal Precio { get; set; }
        public string FechaDeCompra { get; set; }
        public int IDDireccionPropiedadesP { get; set; }
        public int IDEstatusPropiedadP { get; set; }
        public int IDPropietarioP { get; set; }
    }
}
