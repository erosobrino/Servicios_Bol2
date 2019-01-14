using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejer4
{
    class BinWriterJuego : BinaryWriter
    {
        public BinWriterJuego(Stream str) : base(str)
        {

        }
        public void Write(Juego j)
        {
            base.Write(j.Nombre);
            base.Write(j.año);
            base.Write((int)j.estilo);
            base.Write(j.Fabricante);
        }
    }
    class BinReaderJuego : BinaryReader
    {
        public BinReaderJuego(Stream str) : base(str)
        {

        }
        public List<Juego> ReadVideojuego()
        {
            List<Juego> juegos = new List<Juego>();
            Juego j;
            try
            {
                while (true)
                {
                    j = new Juego();
                    j.Nombre = base.ReadString();
                    j.año = base.ReadInt32();
                    j.estilo = (Estilo)base.ReadInt32();
                    j.Fabricante = base.ReadString();
                    juegos.Add(j);
                }
            }
            catch (EndOfStreamException e)
            {
            }
            return juegos;
        }
    }

    class Ejer4
    {
        DateTime fechaActual = DateTime.Today;
        static void Main(string[] args)
        {
            Ejer4 ejer = new Ejer4();
            int eleccion = -1;
            List<Juego> Juegos = new List<Juego>();
            Juegos = ejer.leer();
            do
            {
                Console.WriteLine("1.Insertar juego");
                Console.WriteLine("2.Eliminar juego");
                Console.WriteLine("3.Confirmar si exite un juego");
                Console.WriteLine("4.Visualizar lista juegos");
                Console.WriteLine("5.Visualizar juegos de un año y estilo");
                Console.WriteLine("6.Modificar juego");
                Console.WriteLine("7.Borrar lista de juegos");
                Console.WriteLine("8.Salir");
                eleccion = ejer.pedirNumero(8);
                switch (eleccion)
                {
                    case 1:
                        Juegos = ejer.introducirJuego(Juegos, true, 0);
                        break;
                    case 2:
                        ejer.borrarElemento(Juegos);
                        break;
                    case 3:
                        ejer.comprobarJuego(Juegos);
                        break;
                    case 4:
                        ejer.muestraBiblioteca(Juegos);
                        break;
                    case 5:
                        ejer.juegoporAño(Juegos);
                        break;
                    case 6:
                        ejer.modificarJuego(Juegos);
                        break;
                    case 7:
                        ejer.borraTodosElementos(Juegos);
                        break;
                    case 8:
                        ejer.guardar(Juegos);
                        break;
                    default:
                        //Console.WriteLine("Opcion invalida\n");
                        break;
                }
            } while (eleccion != 8);
        }


        public List<Juego> introducirJuego(List<Juego> Juegos, bool introducir, int pos)
        {
            int valorEstilo;
            try
            {
                Juego juego = new Juego();
                Console.WriteLine("Introduce el nombre del juego");
                juego.Nombre = Console.ReadLine();
                do
                {
                    Console.WriteLine("Introduce el año");
                    juego.año = pedirNumero(fechaActual.Year);
                } while (juego.año == -1);
                do
                {
                    Console.WriteLine("Introduce el Estilo");
                    Console.WriteLine(" Otro = 1, Arcade = 2,VideoAventura = 3,Shootemup = 4,Estrategia = 5,Deportivo = 6");
                    valorEstilo = pedirNumero(6);
                } while (valorEstilo == -1);
                juego.estilo = (Estilo)valorEstilo;
                Console.WriteLine("Introduce el fabricante");
                juego.Fabricante = Console.ReadLine();
                if (introducir)
                {
                    if (Juegos.Count() > 0)
                    {
                        int eleccion;
                        Console.WriteLine("Pulsa 1 para ponerlo en el inicio, otro para ponerlo en el final");
                        eleccion = pedirNumero(1);
                        if (eleccion == 1)
                        {
                            Juegos.Insert(0, juego);
                        }
                        else
                        {
                            Juegos.Add(juego);
                        }
                    }
                    else
                    {
                        Juegos.Add(juego);
                    }
                }
                else
                {
                    Juegos.Insert(pos, juego);
                }
            }
            catch (Exception e)
            {
                //Console.WriteLine(e.StackTrace);
                Console.WriteLine("Se ha producido un error al introducir los datos");
            }
            Console.WriteLine();
            return Juegos;
        }

        public void borrarElemento(List<Juego> Juegos)
        {
            int borrado = -1;
            if (Juegos.Count() > 0)
            {
                do
                {
                    Console.WriteLine("Escribe el id del juego a borrar (1-" + Juegos.Count() + ")");
                    borrado = pedirNumero(Juegos.Count());
                    borrado--;
                } while (borrado == -2);
                Juegos.RemoveAt(borrado);
            }
            else
            {
                Console.WriteLine("No hay juegos");
            }
            Console.WriteLine();
        }

        private void borraTodosElementos(List<Juego> Juegos)
        {
            if (Juegos.Count() > 0)
            {
                Console.WriteLine("Estas seguro de que deseas borralos");
                Console.WriteLine("Pulsa 1 para borrarlo, otro para cancelar");
                int confirmacion;
                confirmacion = pedirNumero(1);
                if (confirmacion == 1)
                {
                    Juegos.Clear();
                }
            }
            else
            {
                Console.WriteLine("No hay juegos");
            }
        }

        public List<Juego> modificarJuego(List<Juego> Juegos)
        {
            if (Juegos.Count() > 0)
            {
                Console.WriteLine("Introduce el id a modificar (1-" + Juegos.Count() + ")");
                int eleccion = -1;
                do
                {
                    eleccion = pedirNumero(Juegos.Count()) - 1;
                } while (eleccion == -1);
                Juegos = introducirJuego(Juegos, false, (eleccion));
                Juegos.RemoveAt(eleccion + 1);
            }
            else
            {
                Console.WriteLine("No hay juegos");
            }
            return Juegos;
        }

        public void muestraBiblioteca(List<Juego> Juegos)
        {
            int cont = 0;
            int cont2 = 0;
            foreach (Juego juego in Juegos)
            {
                cont++;
                cont2++;
                if (cont2 >= 11)
                {
                    Console.WriteLine("Pulsa una tecla para continuar");
                    Console.ReadKey(true);
                    cont2 = 0;
                }
                Console.WriteLine("{0,2} Titulo:{1,12} Año:{2,5} Estilo: {3,14} Fabricante:{4,10}", cont, juego.Nombre, juego.año, juego.estilo, juego.Fabricante);
            }
            Console.WriteLine("Hay " + Juegos.Count() + " juegos\n");
        }

        public void comprobarJuego(List<Juego> Juegos)
        {
            if (Juegos.Count() > 0)
            {
                int cont = 0;
                Console.WriteLine("Que juego deseas comprobar, se puede escribir un trozo del nombre");
                String comprobarNombre = Console.ReadLine().Trim().ToUpper();
                foreach (Juego juego in Juegos)
                {
                    String nombreJuego = juego.Nombre;
                    if (nombreJuego.StartsWith(comprobarNombre))
                    {
                        cont++;
                        Console.WriteLine("{0} Titulo:{1,8} Año:{2,5} Estilo:{3,8} Fabricante:{4,8}\n", cont, juego.Nombre, juego.año, juego.estilo, juego.Fabricante);
                    }
                }
                Console.WriteLine("Hay " + cont + " juegos\n");
            }
            else
            {
                Console.WriteLine("No hay juegos en la coleccion\n");
            }
        }

        private void juegoporAño(List<Juego> Juegos)
        {
            if (Juegos.Count() > 0)
            {
                int valorEstilo;
                int cont = 0;
                int añoComprobar = -1;
                do
                {
                    Console.WriteLine("Introduce el año a comprobar el juego");
                    añoComprobar = pedirNumero(fechaActual.Year);
                } while (añoComprobar == -1);
                do
                {
                    Console.WriteLine("Introduce el Estilo");
                    Console.WriteLine(" Otro = 1, Arcade = 2,VideoAventura = 3,Shootemup = 4,Estrategia = 5,Deportivo = 6");
                    valorEstilo = pedirNumero(6);
                } while (valorEstilo == -1);
                Estilo estilo = (Estilo)valorEstilo;
                foreach (Juego juego in Juegos)
                {
                    if (añoComprobar == juego.año && estilo == juego.estilo)
                    {
                        cont++;
                        Console.WriteLine("{0} Titulo:{1,8} Año:{2,5} Estilo:{3,8} Fabricante:{4,8}\n", cont, juego.Nombre, juego.año, juego.estilo, juego.Fabricante);
                    }
                }
                Console.WriteLine("Hay " + cont + " juegos");

            }
            else
            {
                Console.WriteLine("No hay juegos en la coleccion");
            }
        }
        public int pedirNumero(int max)
        {
            int eleccion = -1;
            try
            {
                eleccion = Convert.ToInt32(Console.ReadLine());
                if (eleccion < 1 || eleccion > max)
                {
                    Console.WriteLine("El valor no esta en el rango");
                    eleccion = -1;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Debes introducir un valor valido\n");
            }
            catch (OverflowException)
            {
                Console.WriteLine("El valor es demasiado alto");
            }
            return eleccion;
        }

        private void guardar(List<Juego> juegos)
        {
            string directory = Environment.GetEnvironmentVariable("homedrive") + "\\" + Environment.GetEnvironmentVariable("homepath");
            BinWriterJuego bwj = new BinWriterJuego(new FileStream(directory + "\\games.dat", FileMode.OpenOrCreate));
            foreach (Juego j in juegos)
            {
                bwj.Write(j);
            }
            bwj.Dispose();

        }

        private List<Juego> leer()
        {
            List<Juego> juegos = new List<Juego>();
            string directory = Environment.GetEnvironmentVariable("homedrive") + "\\" + Environment.GetEnvironmentVariable("homepath");
            BinReaderJuego brj;
            try
            {
                brj = new BinReaderJuego(new FileStream(directory + "\\games.dat", FileMode.Open));
                juegos = brj.ReadVideojuego();
                brj.Dispose();
            }
            catch (FileNotFoundException) { }
            return juegos;
        }
    }
}