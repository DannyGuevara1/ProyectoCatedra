using ProyectoCatedra;

internal class Program
{
    public static int idContador = 0;
    private static void Main(string[] args)
    {
        
        LicensesManager licensesManager = new LicensesManager();
        bool salir = false;
        while (!salir)
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Agregar datos de los programas");
            Console.WriteLine("2. Mostrar listado de programas");
            Console.WriteLine("3. Buscar programas");
            Console.WriteLine("4. Modificar datos de una licencia");
            Console.WriteLine("5. Eliminar una licencia");
            Console.WriteLine("6. Guardar datos en un archivo");
            Console.WriteLine("7. Salir");
            Console.WriteLine();

            Console.Write("Ingrese la opción deseada: ");
            int opcion = int.Parse(Console.ReadLine());
            Console.WriteLine();

            switch (opcion)
            {
                case 1:
                    AgregarLicencias(licensesManager);
                    break;
                case 2:
                    MostrarLicencias(licensesManager);
                    break;
                case 3:
                    BuscarLicencias(licensesManager);
                    break;
                case 4:
                    ModificarLicencia(licensesManager);
                    break;
                case 5:
                    EliminarLicencia(licensesManager);
                    break;
                case 6:
                    GuardarEnArchivo(licensesManager);
                    break;
                case 7:
                    salir = true;
                    break;
                default:
                    Console.WriteLine("Opción inválida. Por favor, elige una opción válida.");
                    break;
            }
        }
    }
    static void AgregarLicencias(LicensesManager licensesManager)
    {
        
        Console.WriteLine("Agregar datos de los programas:");
        Console.WriteLine();

        Console.Write("Ingrese el nombre del software: ");
        string nombre = Console.ReadLine();
        Console.Write("Ingrese el tipo del software: ");
        string tipo = Console.ReadLine();
        Console.Write("Ingrese el fabricante del software: ");
        string fabricante = Console.ReadLine();
        Console.Write("Ingrese el precio del software: ");
        double precio = double.Parse(Console.ReadLine());
        Console.Write("Ingrese la clave de instalación del software: ");
        string claveInstalacion = Console.ReadLine();
        Console.Write("Ingrese la cantidad de usuarios del software: ");
        int cantidadUsuarios = int.Parse(Console.ReadLine());
        Console.Write("Ingrese los años de licencia: ");
        int años = int.Parse(Console.ReadLine());

        SoftwareLicense license = new SoftwareLicense()
        {
            Id = idContador + 1,
            Nombre = nombre,
            Tipo = tipo,
            Fabricante = fabricante,
            Precio = precio,
            ClaveInstalacion = claveInstalacion,
            CantidadUsuarios = cantidadUsuarios,
            Años = años
        };

        licensesManager.AgregarLicencia(license);
        idContador++;

        Console.WriteLine("Datos del programa agregados correctamente.");
    }
    static void MostrarLicencias(LicensesManager licensesManager)
    {
        List<SoftwareLicense> licencias = licensesManager.ObtenerLicencias();

        if (licencias.Count == 0)
        {
            Console.WriteLine("No hay licencias de software registradas.");
        }
        else
        {
            Console.WriteLine("Listado de programas:");
            Console.WriteLine();

            foreach (SoftwareLicense licencia in licencias)
            {
                Console.WriteLine($"ID: {licencia.Id}");
                Console.WriteLine($"Nombre: {licencia.Nombre}");
                Console.WriteLine($"Tipo: {licencia.Tipo}");
                Console.WriteLine($"Fabricante: {licencia.Fabricante}");
                Console.WriteLine($"Precio: {licencia.Precio}");
                Console.WriteLine($"Clave de Instalación: {licencia.ClaveInstalacion}");
                Console.WriteLine($"Cantidad de usuarios: {licencia.CantidadUsuarios}");
                Console.WriteLine($"Años de licencia: {licencia.Años}");
                Console.WriteLine();
            }
        }
    }
    static void BuscarLicencias(LicensesManager licensesManager)
    {
        Console.WriteLine("Buscar programas:");
        Console.WriteLine();
        Console.WriteLine("1. Buscar por nombre");
        Console.WriteLine("2. Buscar por año");
        Console.WriteLine("3. Buscar por fabricante");
        Console.WriteLine("4. Buscar por tipo");
        Console.WriteLine();

        Console.Write("Ingrese la opción de búsqueda deseada: ");
        int opcion = int.Parse(Console.ReadLine());
        Console.WriteLine();

        switch (opcion)
        {
            case 1:
                Console.Write("Ingrese el nombre del programa a buscar: ");
                string nombre = Console.ReadLine();
                List<SoftwareLicense> licenciasPorNombre = licensesManager.BuscarLicenciaPorNombre(nombre);
                MostrarLicenciasEncontradas(licenciasPorNombre);
                break;
            case 2:
                Console.Write("Ingrese el año a buscar: ");
                int año = int.Parse(Console.ReadLine());
                List<SoftwareLicense> licenciasPorAño = licensesManager.BuscarLicenciaPorAño(año);
                MostrarLicenciasEncontradas(licenciasPorAño);
                break;
            case 3:
                Console.Write("Ingrese el fabricante a buscar: ");
                string fabricante = Console.ReadLine();
                List<SoftwareLicense> licenciasPorFabricante = licensesManager.BuscarLicenciaPorFabricante(fabricante);
                MostrarLicenciasEncontradas(licenciasPorFabricante);
                break;
            case 4:
                Console.Write("Ingrese el tipo a buscar: ");
                string tipo = Console.ReadLine();
                List<SoftwareLicense> licenciasPorTipo = licensesManager.BuscarLicenciaPorTipo(tipo);
                MostrarLicenciasEncontradas(licenciasPorTipo);
                break;
            default:
                Console.WriteLine("Opción inválida. Por favor, elige una opción válida.");
                break;
        }
    }
    static void MostrarLicenciasEncontradas(List<SoftwareLicense> licencias)
    {
        if (licencias.Count == 0)
        {
            Console.WriteLine("No se encontraron licencias de software.");
        }
        else
        {
            Console.WriteLine("Licencias encontradas:");
            Console.WriteLine();

            foreach (SoftwareLicense licencia in licencias)
            {
                Console.WriteLine($"ID: {licencia.Id}");
                Console.WriteLine($"Nombre: {licencia.Nombre}");
                Console.WriteLine($"Tipo: {licencia.Tipo}");
                Console.WriteLine($"Fabricante: {licencia.Fabricante}");
                Console.WriteLine($"Precio: {licencia.Precio}");
                Console.WriteLine($"Clave de Instalación: {licencia.ClaveInstalacion}");
                Console.WriteLine($"Cantidad de usuarios: {licencia.CantidadUsuarios}");
                Console.WriteLine($"Años de licencia: {licencia.Años}");
                Console.WriteLine();
            }
        }
    }
    static void ModificarLicencia(LicensesManager licensesManager)
    {
        Console.WriteLine("Modificar datos de una licencia:");
        Console.WriteLine();

        Console.Write("Ingrese el ID de la licencia a modificar: ");
        int id = int.Parse(Console.ReadLine());
        Console.WriteLine();

        Console.WriteLine("Ingrese los nuevos datos de la licencia:");
        Console.WriteLine();

        Console.Write("Ingrese el nombre del software: ");
        string nombre = Console.ReadLine();
        Console.Write("Ingrese el tipo del software: ");
        string tipo = Console.ReadLine();
        Console.Write("Ingrese el fabricante del software: ");
        string fabricante = Console.ReadLine();
        Console.Write("Ingrese el precio del software: ");
        double precio = double.Parse(Console.ReadLine());
        Console.Write("Ingrese la clave de instalación del software: ");
        string claveInstalacion = Console.ReadLine();
        Console.Write("Ingrese la cantidad de usuarios del software: ");
        int cantidadUsuarios = int.Parse(Console.ReadLine());
        Console.Write("Ingrese los años de licencia: ");
        int años = int.Parse(Console.ReadLine());

        SoftwareLicense license = new SoftwareLicense()
        {
            Nombre = nombre,
            Tipo = tipo,
            Fabricante = fabricante,
            Precio = precio,
            ClaveInstalacion = claveInstalacion,
            CantidadUsuarios = cantidadUsuarios,
            Años = años
        };

        licensesManager.ModificarLicencia(id, license);

        Console.WriteLine("Datos del programa modificados correctamente.");
    }
    static void EliminarLicencia(LicensesManager licensesManager)
    {
        Console.WriteLine("Eliminar una licencia:");
        Console.WriteLine();

        Console.Write("Ingrese el ID de la licencia a eliminar: ");
        int id = int.Parse(Console.ReadLine());
        Console.WriteLine();

        licensesManager.EliminarLicencia(id);

        Console.WriteLine("Licencia eliminada correctamente.");
    }
    static void GuardarEnArchivo(LicensesManager licensesManager)
    {
        Console.Write("Ingrese la ruta del archivo donde desea guardar los datos: ");
        string rutaArchivo = Console.ReadLine();
        Console.WriteLine();

        licensesManager.GuardarDatosEnArchivo(rutaArchivo);

        Console.WriteLine("Datos guardados correctamente en el archivo.");
    }
}