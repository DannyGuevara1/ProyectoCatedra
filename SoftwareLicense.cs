using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCatedra
{
    internal class SoftwareLicense
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Tipo { get; set; }
        public string? Fabricante { get; set; }
        public double Precio { get; set; }
        public string? ClaveInstalacion { get; set; }
        public int CantidadUsuarios { get; set; }
        public int Años { get; set; }
    }
}
