/*\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\PROYECTO FINAL//////////////////////////////////////////////*/
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
/******DECLARACIONES DE VARIABLES*******/
int opciones, opcion1, opcion2, opcion3, subopcion, opcionT, subopcion1, subopcion2, posicion;

//Lista
List<Contacto> contactos = new List<Contacto>();

//Objeto


string miJson = (File.ReadAllText("ListaContacto.json"));
contactos = JsonSerializer.Deserialize<List<Contacto>>(miJson);


////// LISTA EVENTO
List<string[]> Eventos = new List<string[]>();
////MENU PRINCIPAL/////
try
{
    do
    {
        Console.Clear();
        Console.WriteLine("Eliga la opcion que desea:");
        System.Console.Write("[1]Agenda Electronica\n[2]Conversores\n[3]Calculadora\n[4]Salir\nOpcion:");
        opciones = int.Parse(Console.ReadLine()!);
        switch (opciones)
        {
            ///OPCION 1 MENU PRINCIPAL///
            case 1:
                //// ***INICIO MENU SECUNDARIO***/////
                do
                {
                    Console.Clear();
                    Console.WriteLine("[1]contactos\n[2]Eventos\n[3]Volver al menu principal");
                    Console.Write("Opcion:");
                    opcion1 = int.Parse(Console.ReadLine()!);
                    switch (opcion1)
                    {
                        case 1:
                            do
                            {
                                Console.Clear();
                                Console.WriteLine("[1]Agregar contactos\n[2]Editar contactos\n[3]Eliminar contactos\n[4]Buscar contactos\n[5]Lista de contactos\n[6]Volver al menu anterior\n[7]Salir");
                                Console.Write("Opcion:");
                                subopcion1 = int.Parse(Console.ReadLine()!);
                                switch (subopcion1)
                                {
                                    case 1://INSERTAR
                                        Console.Clear();
                                        System.Console.WriteLine("Digite su nombre:");
                                        string nombre = Console.ReadLine()!;
                                        System.Console.WriteLine("Digite su apellido:");
                                        string apellido = Console.ReadLine()!;
                                        System.Console.WriteLine("Digite su telefono:");
                                        string telefono = Console.ReadLine()!;
                                        System.Console.WriteLine("Digite su direccion:");
                                        string direccion = Console.ReadLine()!;
                                        System.Console.WriteLine("Digite su email:");
                                        string email = Console.ReadLine()!;
                                        //Creo un nuevo objeto
                                        Contacto c1 = new Contacto();
                                        c1.Nombre = nombre;
                                        c1.Apellido = apellido;
                                        c1.Telefono = telefono;
                                        c1.Direccion = direccion;
                                        c1.Email = email;
                                        contactos.Add(c1);

                                       

                                        //Aqui guardo los cambios de la lista
                                        string miJson2 = JsonSerializer.Serialize(contactos);
                                        File.WriteAllText("ListaContacto.json", miJson2);
                                        Console.Clear();
                                        break;
                                    case 2:
                                    
                                    case 3://ELIMINAR

                                        //Verificar que la lista no esta vacia
                                        if (contactos.Count == 0)
                                        {
                                            System.Console.Write("No existe ningun contacto");
                                            Thread.Sleep(1500);
                                            break;
                                        }

                                        //Declare variables importantes
                                        int contador = 0, posicion1 = 0;


                                        System.Console.WriteLine("Seleccione un usuario para borrar");

                                        //Mostrando los usuarios
                                        
                                        foreach (var contacto in contactos)
                                        {
                                            contador++;
                                            System.Console.WriteLine($"{contador}. {contacto.Nombre} {contacto.Apellido}");
                                        }

                                        //se pide la posicion
                                        posicion1 = int.Parse(Console.ReadLine()!);

                                        //Se elimina el usuario de acuerdo al a posicion
                                        contactos.RemoveAt(posicion1 - 1);

                                        //Se guarda en el JSON
                                        miJson2 = JsonSerializer.Serialize(contactos);
                                        File.WriteAllText("ListaContacto.json", miJson2);
                                        break;

                               
                                    case 4://BUSCAR
                                        string? vBusqueda;
                                        vBusqueda = Console.ReadLine();
                                        var query = contactos.Where(x => x.Nombre == vBusqueda || x.Email == vBusqueda || x.Direccion == vBusqueda || x.Apellido == vBusqueda || x.Telefono == vBusqueda).ToList();
                                        if (query.Count == 0)
                                        {
                                            Console.WriteLine("No existen contactos...");
                                            break;
                                        }

                                        foreach (var item in query)
                                        {
                                            Console.WriteLine($"| {item.Nombre} | {item.Apellido} | {item.Email} | {item.Telefono} |");
                                        }
                                      
                                        break;
                                    case 5://LISTA
                                        if (contactos.Count == 0)
                                        {
                                            Console.WriteLine("No hay contactos guardados");
                                            break;
                                        }

                                        foreach (var item in contactos)
                                        {
                                            Console.WriteLine($"| {item.Nombre} | {item.Apellido} | {item.Email} | {item.Telefono} |");
                                        }
                                        break;

                                      
                                        
                                }
                            } while (subopcion1 != 6);
                            break;
                        case 2:
                            do
                            {
                                Console.Clear();
                                Console.WriteLine("[1]Agregar Eventos\n[2]Editar Eventos\n[3]Eliminar Eventos\n[4]Buscar Eventos\n[5]Lista de Eventos\n[6]Volver al menu anterior\n[7]Salir");
                                Console.Write("Opcion:");
                                subopcion2 = int.Parse(Console.ReadLine()!);
                                switch (subopcion2)
                                {
                                    case 1:
                                        Console.Clear();
                                        System.Console.WriteLine("Nombre del Evento:");
                                        string nombre = Console.ReadLine()!;
                                        System.Console.WriteLine("Fecha del Evento:");
                                        string fecha = Console.ReadLine()!;
                                        System.Console.WriteLine("Hora del Evento:");
                                        string hora = Console.ReadLine()!;
                                        System.Console.WriteLine("Lugar del Evento:");
                                        string lugar = Console.ReadLine()!;
                                    
                                        Console.Clear();
                                        break;
                                    case 2:
                                        if (Eventos.Count < 1)
                                        {
                                            System.Console.Write("No existe ningun Evento");
                                            Thread.Sleep(1500);
                                            break;
                                        }
                                        else if (Eventos.Count > 0)
                                        {
                                            System.Console.WriteLine("Eliga el Evento a editar:");
                                            for (int i = 0; i < Eventos.Count; i++)
                                            {
                                                System.Console.WriteLine("[" + i + "]" + Eventos[i][0]);
                                            }
                                        }
                                        System.Console.Write("Introduzca Posicion del Evento a editar:");
                                        posicion = int.Parse(Console.ReadLine()!);
                                        if (Eventos.Count <= posicion)
                                        {
                                            System.Console.WriteLine("Este Evento no existe");
                                            Thread.Sleep(500);
                                            break;
                                        }
                                        else
                                        {
                                            Console.Clear();
                                            System.Console.WriteLine("------Evento:" + Eventos[posicion][0] + "-------");
                                            System.Console.WriteLine("¿Que desea editar?:");
                                            System.Console.WriteLine("Nombre Del Evento:" + Eventos[posicion][0]);
                                            System.Console.WriteLine("Fecha del Evento:" + Eventos[posicion][1]);
                                            System.Console.WriteLine("Hora del Evento:" + Eventos[posicion][2]);
                                            System.Console.WriteLine("Lugar del Evento:" + Eventos[posicion][3]);
                                            System.Console.Write("Introduzca informacion a editar (Pulse Enter para volver):");
                                            string Eleccion = Console.ReadLine()!;
                                            if (Eleccion == "Nombre" || Eleccion == "nombre")
                                            {
                                                System.Console.WriteLine("Digite nuevo Nombre de Evento:");
                                                string Respuesta = Console.ReadLine()!;
                                                System.Console.Write("Editando contacto"); Thread.Sleep(850); Console.Write("."); Thread.Sleep(850); Console.Write("."); Thread.Sleep(850); Console.Write(".");
                                                Console.Clear();
                                                System.Console.WriteLine("Contacto editado exitosamente");
                                                Eventos[posicion][0] = Respuesta;
                                            }
                                            else if (Eleccion == "Fecha" || Eleccion == "fecha")
                                            {
                                                System.Console.WriteLine("Digite nueva Fecha de Evento:");
                                                string Respuesta = Console.ReadLine()!;
                                                System.Console.Write("Editando Evento"); Thread.Sleep(850); Console.Write("."); Thread.Sleep(850); Console.Write("."); Thread.Sleep(850); Console.Write(".");
                                                Console.Clear();
                                                System.Console.WriteLine("Evento editado exitosamente");
                                                Eventos[posicion][1] = Respuesta;
                                            }
                                            else if (Eleccion == "Hora" || Eleccion == "hora")
                                            {
                                                System.Console.WriteLine("Digite nueva Hora de Evento:");
                                                string Respuesta = Console.ReadLine()!;
                                                System.Console.Write("Editando Evento"); Thread.Sleep(850); Console.Write("."); Thread.Sleep(850); Console.Write("."); Thread.Sleep(850); Console.Write(".");
                                                Console.Clear();
                                                System.Console.WriteLine("Evento editado exitosamente");
                                                Eventos[posicion][2] = Respuesta;
                                            }
                                            else if (Eleccion == "Lugar" || Eleccion == "lugar")
                                            {
                                                System.Console.WriteLine("Digite nuevo Lugar de Evento:");
                                                string Respuesta = Console.ReadLine()!;
                                                System.Console.Write("Editando Evento"); Thread.Sleep(850); Console.Write("."); Thread.Sleep(850); Console.Write("."); Thread.Sleep(850); Console.Write(".");
                                                Console.Clear();
                                                System.Console.WriteLine("Evento editado exitosamente");
                                                Eventos[posicion][3] = Respuesta;
                                            }
                                            else
                                            {
                                                System.Console.WriteLine("Tiene que introducir un Dato Valido");
                                                break;
                                            }
                                        }
                                        Console.Write("Pulse Enter para volver al menu..."); Console.ReadKey();
                                        break;
                                    case 3:
                                        if (Eventos.Count < 1)
                                        {
                                            System.Console.Write("No existe ningun Evento");
                                            Thread.Sleep(1500); ;
                                            break;
                                        }
                                        else if (Eventos.Count > 0)
                                        {
                                            System.Console.WriteLine("Eliga el Evento a Eliminar:");
                                            for (int i = 0; i < Eventos.Count; i++)
                                            {
                                                System.Console.WriteLine("[" + i + "]" + Eventos[i][0]);
                                            }
                                        }
                                        posicion = int.Parse(Console.ReadLine()!);
                                        if (Eventos.Count <= posicion)
                                        {
                                            System.Console.WriteLine("Este Evento no existe");
                                        }
                                        else
                                        {
                                            Eventos.RemoveAt(posicion);
                                            Console.Clear();
                                            Thread.Sleep(700);
                                            System.Console.WriteLine("Evento Eliminado Exitosamente");

                                        }
                                        break;
                                    case 4:
                                        if (Eventos.Count < 1)
                                        {
                                            System.Console.Write("No existe ningun Evento");
                                            Thread.Sleep(1500);
                                            break;
                                        }
                                        else if (Eventos.Count > 0)
                                        {
                                            System.Console.WriteLine("====Buscador de Eventos====");
                                            System.Console.Write("Buscar Evento:");
                                            string Buscador = Console.ReadLine()!;
                                            for (int i = 0; i < Eventos.Count; i++)
                                            {
                                                if (Buscador == Eventos[i][0])
                                                {
                                                    System.Console.WriteLine("------ Informacion del Evento:" + Eventos[i][0] + "-------");
                                                    System.Console.WriteLine("Nombre del Evento:" + Eventos[i][0]);
                                                    System.Console.WriteLine("Fecha del Evento:" + Eventos[i][1]);
                                                    System.Console.WriteLine("Hora del Evento:" + Eventos[i][2]);
                                                    System.Console.WriteLine("Lugar del Evento:" + Eventos[i][3]);
                                                }
                                                else
                                                {
                                                    System.Console.WriteLine("No se ha encontrado ningun Evento");
                                                    Thread.Sleep(700);
                                                    break;
                                                }
                                            }
                                        }
                                        break;
                                    case 5:
                                        if (Eventos.Count < 1)
                                        {
                                            System.Console.Write("No existe ningun Evento");
                                            Thread.Sleep(1500);
                                            break;
                                        }
                                        else if (Eventos.Count > 0)
                                        {
                                            System.Console.WriteLine("=====Lista De Eventos=====");
                                            for (int i = 0; i < Eventos.Count; i++)
                                            {
                                                System.Console.WriteLine("[" + i + "]" + Eventos[i][0]);
                                            }
                                        }
                                        System.Console.Write("Pulse Enter para cerrar la lista:"); Console.ReadKey();
                                        break;
                                    case 6:
                                        break;
                                    case 7:
                                        Environment.Exit(0);
                                        break;
                                    default:
                                        Console.Clear();
                                        System.Console.WriteLine("¡!Ha introducido una Opcion Incorrecta. Vuelva a Intentarlo¡!");
                                        Thread.Sleep(2000);
                                        break;
                                }
                            } while (subopcion2 != 6);
                            break;
                        case 3:
                            break;
                        default:
                            Console.Clear();
                            System.Console.WriteLine("¡!Ha introducido una Opcion Incorrecta. Vuelva a Intentarlo¡!");
                            Thread.Sleep(2000);
                            break;
                    }
                } while (opcion1 != 3);
                ////***FIN MENU SECUNDARIO***/////
                break;
            ///OPCION 2 MENU PRINCIPAL///
            case 2:
                //// ***INICIO MENU SECUNDARIO***/////
                do
                {
                    Console.Clear();
                    Console.WriteLine("[1]Convertir Temperaturas\n[2]Convertir Monedas\n[3]Volver al Menu Principal");
                    Console.Write("Opcion:");
                    opcion2 = int.Parse(Console.ReadLine()!);
                    switch (opcion2)
                    {
                        case 1:
                            do
                            {
                                Console.Clear();
                                Console.WriteLine("Conversor de temperaturas:\n");
                                Console.WriteLine("Menu de opciones:\n");
                                Console.WriteLine("[1] De Fahrenheit a Celcius.");
                                Console.WriteLine("[2] De Celcius a Fahrenheit.");
                                Console.WriteLine("[3] De Fahrenheit a Kelvin. ");
                                Console.WriteLine("[4] De Kelvin a Fahrenheit.");
                                Console.WriteLine("[5] De Celsius a Kelvin.");
                                Console.WriteLine("[6] De Kelvin a Celcius.");
                                Console.WriteLine("[7] Volver al menu anterior");
                                Console.WriteLine("[8] Salir...");
                                Console.Write("Opcion:");
                                opcionT = Convert.ToInt32(Console.ReadLine());
                                Console.Clear();
                                switch (opcionT)
                                {
                                    case 1:
                                        //De Fahrenheit a celcius :)
                                        Console.WriteLine("Convertidor de grados Fahrenheit a grados Celsius. \n");
                                        Console.WriteLine("Ingrese los grados Fahrenheit: ");
                                        double Fahrenheit = Convert.ToDouble(Console.ReadLine());
                                        Console.WriteLine(fahrenheitCelsius(Fahrenheit));
                                        Console.Write("Pulse una tecla para volver al menu anterior..."); Console.ReadKey();
                                        break;
                                    case 2:
                                        //De Celsius a Fahrenheit :)
                                        Console.WriteLine("Convertidor de grados Celsius a grados Fahrenheit . \n");
                                        Console.WriteLine("Ingrese los grados Celsius: ");
                                        double celsius2 = Convert.ToDouble(Console.ReadLine());
                                        Console.WriteLine(celsiusFahrenheit(celsius2));
                                        Console.Write("Pulse una tecla para volver al menu anterior..."); Console.ReadKey();
                                        break;
                                    case 3:
                                        //De Fahrenheit a kelvin 
                                        Console.WriteLine("Convertidor de grados Fahrenheit a grados Kelvin. \n");
                                        Console.WriteLine("Ingrese los grados Fahrenheit: ");
                                        double fahrenheit3 = Convert.ToDouble(Console.ReadLine());
                                        Console.WriteLine(fahrenheitKelvin(fahrenheit3));
                                        Console.Write("Pulse una tecla para volver al menu anterior..."); Console.ReadKey();
                                        break;
                                    case 4:
                                        //De Kelvin a Fahrenheit
                                        Console.WriteLine("Convertidor de grados Kelvin a grados Fahrenheit. \n");
                                        Console.Write("Ingrese los grados Kelvin: ");
                                        double kelvin2 = Convert.ToDouble(Console.ReadLine());
                                        Console.WriteLine(kelvinFahrenheit(kelvin2));
                                        Console.Write("Pulse una tecla para volver al menu anterior..."); Console.ReadKey();
                                        break;
                                    case 5:
                                        //De Celsius a Kelvin
                                        Console.WriteLine("Convertidor de grados Celsius a grados Kelvin. \n");
                                        Console.WriteLine("Ingrese los grados Kelvin: ");
                                        double celsius3 = Convert.ToDouble(Console.ReadLine());
                                        Console.WriteLine(celsiusKelvin(celsius3));
                                        Console.Write("Pulse una tecla para volver al menu anterior..."); Console.ReadKey();
                                        break;
                                    case 6:
                                        //De kelvin a celcius
                                        Console.WriteLine("Convertidor de grados Kelvin a grados celcius. \n");
                                        Console.WriteLine("Ingrese los grados Kelvin: ");
                                        double kelvin4 = Convert.ToDouble(Console.ReadLine());
                                        Console.WriteLine(kelvinCelsius(kelvin4));
                                        Console.Write("Pulse una tecla para volver al menu anterior..."); Console.ReadKey();
                                        break;
                                    case 7:
                                        break;
                                    case 8:
                                        Environment.Exit(0);
                                        break;
                                    default:
                                        Console.Clear();
                                        System.Console.WriteLine("¡!Ha introducido una Opcion Incorrecta. Vuelva a Intentarlo¡!");
                                        Thread.Sleep(2000);
                                        break;
                                }
                            } while (opcionT != 7);
                            break;
                        case 2:
                            do
                            {
                                Console.Clear();
                                Console.WriteLine("Elija la opcion que desea");
                                Console.WriteLine("[1]Dolar a Euro");
                                Console.WriteLine("[2]Euro a Dolar");
                                Console.WriteLine("[3]Peso a Dolar");
                                Console.WriteLine("[4]Dolar a Peso");
                                Console.WriteLine("[5]Euro a Peso");
                                Console.WriteLine("[6]Peso a Euro");
                                Console.WriteLine("[7]Volver al Menu Anterior");
                                Console.WriteLine("[8]Salir");
                                Console.Write("Opcion:");
                                subopcion = Convert.ToInt32(Console.ReadLine());
                                switch (subopcion)
                                {
                                    case 1:
                                        Console.Clear();
                                        Console.WriteLine("Convertir de Dolar a Euro");
                                        dolareuro();
                                        Thread.Sleep(500); Console.Write("Espere unos segundos..."); Thread.Sleep(3000);
                                        Console.Clear();
                                        break;
                                    case 2:
                                        Console.Clear();
                                        Console.WriteLine("Convertir de Euro a Dolar");
                                        eurodolar();
                                        Console.Write("Espere unos segundos...");
                                        Thread.Sleep(2000); Console.Clear();
                                        break;
                                    case 3:
                                        Console.Clear();
                                        Console.WriteLine("Convertir de Peso a Dolar");
                                        pesodolar();
                                        Console.Write("Espere unos segundos...");
                                        Thread.Sleep(2000); Console.Clear();
                                        break;
                                    case 4:
                                        Console.Clear();
                                        Console.WriteLine("Convertir de Dolar a Peso");
                                        dolarpeso();
                                        Console.Write("Espere unos segundos...");
                                        Thread.Sleep(2000); Console.Clear();
                                        break;
                                    case 5:
                                        Console.Clear();
                                        Console.WriteLine("Convertir de Euro a Peso");
                                        europeso();
                                        Console.Write("Espere unos segundos...");
                                        Thread.Sleep(2000); Console.Clear();
                                        break;
                                    case 6:
                                        Console.Clear();
                                        Console.WriteLine("Convertir de Peso a Euro");
                                        pesoeuro();
                                        Console.Write("Espere unos segundos...");
                                        Thread.Sleep(2000); Console.Clear();
                                        break;
                                    case 7:
                                        break;
                                    case 8:
                                        Environment.Exit(0);
                                        break;
                                    default:
                                        Console.Clear();
                                        System.Console.WriteLine("¡!Ha introducido una Opcion Incorrecta. Vuelva a Intentarlo¡!");
                                        Thread.Sleep(2000);
                                        break;
                                }
                            } while (subopcion != 7);
                            break;
                        case 3:
                            break;
                        default:
                            Console.Clear();
                            System.Console.WriteLine("¡!Ha introducido una Opcion Incorrecta. Vuelva a Intentarlo¡!");
                            Thread.Sleep(2000);
                            break;
                    }
                } while (opcion2 != 3);
                ////***FIN MENU SECUNDARIO***/////
                break;
            ///OPCION 3 MENU PRINCIPAL///        
            case 3:
                //// ***INICIO MENU SECUNDARIO***/////
                do
                {
                    Console.Clear();
                    Console.WriteLine("Elija la opcion que desea");
                    Console.Write("[1]Suma\n[2]Resta\n[3]Multiplicacion\n[4]Division\n[5]Volver al Menu Principal\n[6]Salir\n");
                    Console.Write("Opcion:");
                    opcion3 = int.Parse(Console.ReadLine()!);
                    switch (opcion3)
                    {
                        case 1:
                            Console.Clear();
                            Console.WriteLine("Digite 2 numeros:");
                            int n1 = int.Parse(Console.ReadLine()!);
                            int n2 = int.Parse(Console.ReadLine()!);
                            Suma(n1, n2);
                            Thread.Sleep(1000);
                            Console.Write("Espere unos segundos...");
                            Thread.Sleep(2000); Console.Clear();
                            break;
                        case 2:
                            Console.Clear();
                            Console.WriteLine("Digite 2 numeros:");
                            int N1 = int.Parse(Console.ReadLine()!);
                            int N2 = int.Parse(Console.ReadLine()!);
                            Resta(N1, N2);
                            Console.Write("Espere unos segundos...");
                            Thread.Sleep(2000); Console.Clear();
                            break;
                        case 3:
                            Console.Clear();
                            Console.WriteLine("Digite 2 numeros:");
                            int num1 = int.Parse(Console.ReadLine()!);
                            int num2 = int.Parse(Console.ReadLine()!);
                            Multiplicacion(num1, num2);
                            Console.Write("Espere unos segundos...");
                            Thread.Sleep(2000); Console.Clear();
                            break;
                        case 4:
                            Console.Clear();
                            Console.WriteLine("Digite 2 numeros:");
                            int Num1 = int.Parse(Console.ReadLine()!);
                            int Num2 = int.Parse(Console.ReadLine()!);
                            Division(Num1, Num2);
                            Console.Write("Espere unos segundos...");
                            Thread.Sleep(2000); Console.Clear();
                            break;
                        case 5:
                            break;
                        case 6:
                            Environment.Exit(0);
                            break;
                        default:
                            Console.Clear();
                            System.Console.WriteLine("¡!Ha introducido una Opcion Incorrecta. Vuelva a Intentarlo¡!");
                            Thread.Sleep(2000);
                            break;
                    }
                } while (opcion3 != 5);
                ////***FIN MENU SECUNDARIO***/////
                break;
            ///OPCION 4 MENU PRINCIPAL/// 
            case 4:
                Environment.Exit(0);
                break;
            ///DIFOLT MENU PRINCIPAL/// 
            default:
                Console.Clear();
                System.Console.WriteLine("¡!Ha introducido una Opcion Incorrecta. Vuelva a Intentarlo¡!");
                Thread.Sleep(2000);
                break;
        }
    } while (opciones != 4);
}
catch (FormatException e)
{
    Console.WriteLine(e.Message);
}
/*\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\FUNCIONES////////////////////////////////////////////////*/

//////////////////////////*SOBRE AGENDA ELECTRONICA*////////////////////////
//////////////////////////*SOBRE CONVERSORES*////////////////////////

/////***CONVERSOR TEMPERATURA***/////

///*FUNCION FAHRENHEIT A CELSIUS*///
static string fahrenheitCelsius(double fahrenheit)
{
    double celsius = (fahrenheit - 32) * 5 / 9;
    return ("El resultado es de: " + celsius + "°C");
}
///*FUNCION CELSIUS A FAHRENHEIT*///
static string celsiusFahrenheit(double celsius2)
{
    double fahrenheit2 = (celsius2 * 9 / 5) + 32;
    return ("El resultado es de: " + fahrenheit2 + "°F");
}
///*FUNCION FAHRENHEIT A KELVIN*///
static string fahrenheitKelvin(double fahrenheit3)
{
    double kelvin = (fahrenheit3 - 32) * 5 / 9 + 273.15;
    return ("El resultado es de: " + kelvin + "°K");
}
///*FUNCION KELVIN A FAHRENHEIT*///
static string kelvinFahrenheit(double kelvin2)
{
    double fahrenheit4 = (kelvin2 - 273.15) * 9 / 5 + 32;
    return ("El resultado es de: " + fahrenheit4 + "°F");
}
///*FUNCION CELSIUS A KELVIN*///
static string celsiusKelvin(double celsius3)
{
    double kelvin3 = celsius3 + 273.15;
    return ("El resultado es de: " + kelvin3 + "°K");
}
///*FUNCION KELVIN A CELSIUS*///
static string kelvinCelsius(double kelvin4)
{
    double celsius4 = kelvin4 - 273.15;
    return ("El resultado es de: " + celsius4 + "°C");
}

/////***CONVERSOR MONEDA***/////

///*FUNCION DOLAR A EURO*///
static void dolareuro()
{
    Console.Title = "---Conversor de Dolar a Euro---";
    double cantdolares, tipocambio, canteuros;
    Console.WriteLine("Ingrese cantidad de dolares: ");
    cantdolares = double.Parse(Console.ReadLine()!);
    Console.Write("Digite Cuantos Euros es 1 Dolar (Actualmente):  ");
    tipocambio = double.Parse(Console.ReadLine()!);
    canteuros = cantdolares * tipocambio;
    Console.WriteLine("Equivalente en Euros: {0}$", canteuros);
}
///*FUNCION EURO A DOLAR*///
static void eurodolar()
{
    Console.Title = "---Conversor de Euro a Dolar--";
    double cantdolares, tipocambio, canteuros;
    Console.WriteLine("Ingrese cantidad de euros: ");
    canteuros = double.Parse(Console.ReadLine()!);
    Console.Write("Ingrese Cuantos Dolares es 1 Euro (Actualmente):  ");
    tipocambio = double.Parse(Console.ReadLine()!);
    cantdolares = canteuros * tipocambio;
    Console.WriteLine("Equivalente en Dolares: {0}$", cantdolares);
}
///*FUNCION PESO A DOLAR*///
static void pesodolar()
{
    Console.Title = "---Conversor de Peso a Dolar---";
    double cantdolares, tipocambio, cantpesos;
    Console.WriteLine("Ingrese cantidad de pesos: ");
    cantpesos = double.Parse(Console.ReadLine()!);
    Console.Write("Ingrese Cuantos Dolares es 1 Peso (Actualmente):  ");
    tipocambio = double.Parse(Console.ReadLine()!);
    cantdolares = cantpesos * tipocambio;
    Console.WriteLine("Equivalente en Dolares: {0}$", cantdolares);
}
///*FUNCION PESO A EURO*///
static void pesoeuro()
{
    Console.Title = "---Conversor de Peso a Euro---";
    double canteuros, tipocambio, cantpesos;
    Console.WriteLine("Ingrese cantidad de pesos: ");
    cantpesos = double.Parse(Console.ReadLine()!);
    Console.Write("Ingrese Cuantos Euros es 1 Peso (Actualmente):  ");
    tipocambio = double.Parse(Console.ReadLine()!);
    canteuros = cantpesos * tipocambio;
    Console.WriteLine("Equivalente en Euros: {0}$", canteuros);
}
///*FUNCION EURO A PESO*///
static void europeso()
{
    Console.Title = "---Conversor de Euro a Peso---";
    double canteuros, tipocambio, cantpesos;
    Console.WriteLine("Ingrese cantidad de euros: ");
    canteuros = double.Parse(Console.ReadLine()!);
    Console.Write("Ingrese Cuantos Pesos es 1 Euro (Actualmente):  ");
    tipocambio = double.Parse(Console.ReadLine()!);
    cantpesos = canteuros * tipocambio;
    Console.WriteLine("Equivalente en Euros: {0}", cantpesos);
}
///*FUNCION DOLAR A PESO*///
static void dolarpeso()
{
    Console.Title = "---Conversor de Dolar a Peso---";
    double cantdolares, tipocambio, cantpesos;
    Console.WriteLine("Ingrese cantidad de dolar (Actualmente): ");
    cantdolares = double.Parse(Console.ReadLine()!);
    Console.Write("Ingrese Cuantos Pesos es 1 Dolar:  ");
    tipocambio = double.Parse(Console.ReadLine()!);
    cantpesos = cantdolares * tipocambio;
    Console.WriteLine("Equivalente en Dolares: {0}", cantpesos);
}

//////////////////////////*SOBRE CALCULADORA*////////////////////////

///*FUNCION SUMA*///
static void Suma(int n1, int n2)
{
    int Suma = n1 + n2;
    System.Console.WriteLine("La suma es: " + Suma);
}
///*FUNCION RESTA*///
static void Resta(int N1, int N2)
{
    int Resta = N1 - N2;
    System.Console.WriteLine("La resta es: " + Resta);
}
///*FUNCION MULTIPLICACION*///
static void Multiplicacion(int numero1, int numero2)
{
    int Mult = numero1 * numero2;
    System.Console.WriteLine("La multiplicacion es: " + Mult);
}
///*FUNCION DIVISION*///
static void Division(int Numero1, int Numero2)
{
    int Div = Numero1 / Numero2;
    System.Console.WriteLine("La division es: " + Div);
}

//CLASES
public class Contacto
{
    public String? Nombre { get; set; }
    public String? Apellido { get; set; }
    public String? Telefono { get; set; }
    public String? Direccion { get; set; }
    public String? Email { get; set; }
}
