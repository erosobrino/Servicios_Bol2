using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejer4
{
    enum Estilo
    {
        Otro = 1,
        Arcade = 2,
        VideoAventura = 3,
        Shootemup = 4,
        Estrategia = 5,
        Deportivo = 6
    }
    class Juego
    {
        public int año;
        public Estilo estilo;
        public string fab;

        public Juego()
        {
            Nombre = "Nombre";
            this.año = 0000;
            this.estilo = 0;
            Fabricante = "Fabricante";
        }

        public Juego(String nombre, int año, int estilo, String fabricante)
        {
            Nombre = nombre;
            this.año = año;
            this.estilo = (Estilo)estilo;
            Fabricante = fabricante;
        }
        private string nombre;
        public string Nombre
        {
            set
            {
                nombre = value.Trim().ToUpper();
            }
            get
            {
                return nombre;
            }
        }
        private string fabricante;
        public string Fabricante
        {
            set
            {
                fabricante = value.Trim().ToUpper();
            }
            get
            {
                return fabricante;
            }
        }
    }
}
