using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCatedra
{
    internal class LicensesManager
    {
        private List<SoftwareLicense>? licenses;

        public LicensesManager()
        {
            licenses = new List<SoftwareLicense>();
        }

        public void AgregarLicencia(SoftwareLicense? license)
        {
            if (license != null)
            {
                licenses.Add(license);
            }
            else
            {
                Console.WriteLine("El objeto es nulo");
            }

        }
        public void ModificarLicencia(int id, SoftwareLicense license)
        {
            var existingLicense = licenses.FirstOrDefault(l => l.Id == id);
            if (existingLicense != null)
            {
                existingLicense.Nombre = license.Nombre;
                existingLicense.Tipo = license.Tipo;
                existingLicense.Fabricante = license.Fabricante;
                existingLicense.Precio = license.Precio;
                existingLicense.ClaveInstalacion = license.ClaveInstalacion;
                existingLicense.CantidadUsuarios = license.CantidadUsuarios;
                existingLicense.Años = license.Años;
            }

        }
        public void EliminarLicencia(int id)
        {
            var licenseToRemove = licenses.FirstOrDefault(l => l.Id == id);
            if (licenseToRemove != null)
            {
                licenses.Remove(licenseToRemove);
            }
        }
        public List<SoftwareLicense> BuscarLicenciaPorNombre(string nombre)
        {
            return licenses.Where(l => l.Nombre == nombre).ToList();
        }

        public List<SoftwareLicense> BuscarLicenciaPorAño(int año)
        {
            return licenses.Where(l => l.Años == año).ToList();
        }

        public List<SoftwareLicense> BuscarLicenciaPorFabricante(string fabricante)
        {
            return licenses.Where(l => l.Fabricante == fabricante).ToList();
        }

        public List<SoftwareLicense> BuscarLicenciaPorTipo(string tipo)
        {
            return licenses.Where(l => l.Tipo == tipo).ToList();
        }
        // Guardar datos en un archivo
        public void GuardarDatosEnArchivo(string rutaArchivo)
        {
            using (StreamWriter writer = new StreamWriter(rutaArchivo))
            {
                foreach (SoftwareLicense license in licenses)
                {
                    writer.WriteLine($"Id: {license.Id}");
                    writer.WriteLine($"Nombre: {license.Nombre}");
                    writer.WriteLine($"Tipo: {license.Tipo}");
                    writer.WriteLine($"Fabricante: {license.Fabricante}");
                    writer.WriteLine($"Precio: {license.Precio}");
                    writer.WriteLine($"Clave de Instalación: {license.ClaveInstalacion}");
                    writer.WriteLine($"Cantidad de Usuarios: {license.CantidadUsuarios}");
                    writer.WriteLine($"Años: {license.Años}");
                    writer.WriteLine(); // Separador entre licencias
                }
            }
        }

        internal List<SoftwareLicense> ObtenerLicencias()
        {
            List<SoftwareLicense> listaLicencias = licenses;

            return listaLicencias;
        }
    }
}
