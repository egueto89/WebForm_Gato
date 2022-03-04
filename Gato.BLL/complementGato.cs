using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gato.BLL
{
    public static class complementGato
    {
        public static int[,] areaJuego = new int[2, 2];
        public static int jugadorGanoPartida = -1;
        private static string ficha = "";
        public static Tictactoe clasePrincipal { get; set; }

        public static string FichaUsaUsuario {get { return ficha; } set{ ficha = value; } }
    }
}
