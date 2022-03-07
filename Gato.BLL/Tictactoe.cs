using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gato.BLL
{
    public class Tictactoe
    {
        private int[,] areaJuego = new int[3, 3];
        private int jugadorGanoPartida = -1;

        private int[] maquinaUltimoMovimiento = new int[2];

        public int[,] MatrizGato { get => areaJuego; set => areaJuego = value; }
        public int GanoPartida { get => jugadorGanoPartida; set => jugadorGanoPartida = value; }
        public int[] MaquinaMovimientoFinal { get => maquinaUltimoMovimiento; set => maquinaUltimoMovimiento = value; }

  
        /// <summary>
        /// se inicializa la el area de juego en -1.
        /// </summary>
        public void InicioPartida()
        {
            try
            {
                for (int i = 0; i < areaJuego.GetLength(0); i++)
                    for (int j = 0; j < areaJuego.GetLength(1); j++)
                        areaJuego[i, j] = -1;
                GanoPartida = -1;
            }
            catch (Exception ex)
            {

                registrarErrorLog(ex);
            }
            
        }


        /// <summary>
        /// se obtiene la posicion que el jugador selecciono y se llena con valor y se verifica
        /// si con ese movimiento existe un ganador, se prepara para movimento de la maquina
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void LlenarPosicionJuego(int x, int y)
        {
            try
            {
                if (x >= 0 && x < 3 && y >= 0 && y < 3 && areaJuego[x, y] == -1 && GanoPartida == -1)
                {
                    areaJuego[x, y] = 0;
                    GanoPartida = VerificaExisteGanador();
                    MovimientoMaquina();
                }
            }
            catch (Exception ex)
            {

                registrarErrorLog(ex);
            }
            
        }

        /// <summary>
        /// Se verifica si existe algun ganador en la partida.
        /// </summary>
        /// <returns></returns>
        public int VerificaExisteGanador()
        {
            int banderaposicion = -1;
            try
            {
                //Diagonales
                if (areaJuego[0, 0] != -1 && areaJuego[0, 0] == areaJuego[1, 1] && areaJuego[0, 0] == areaJuego[2, 2])
                    banderaposicion = areaJuego[0, 0];

                if (areaJuego[0, 2] != -1 && areaJuego[0, 2] == areaJuego[1, 1] && areaJuego[0, 2] == areaJuego[2, 0])
                    banderaposicion = areaJuego[0, 2];

                //horizontal y vertical
                for (int i = 0; i < areaJuego.GetLength(0); i++)
                {
                    if (areaJuego[i, 0] != -1 && areaJuego[i, 0] == areaJuego[i, 1] && areaJuego[i, 0] == areaJuego[i, 2])
                        banderaposicion = areaJuego[i, 0];

                    if (areaJuego[0, i] != -1 && areaJuego[0, i] == areaJuego[1, i] && areaJuego[0, i] == areaJuego[2, i])
                        banderaposicion = areaJuego[0, i];
                }


                /*
                 Diagonales
                areaJuego[0, 0] --boton 1     areaJuego[0, 0] --boton 3
                         areaJuego[0, 0]   --boton 5  
                                  areaJuego[2, 2] --boton 7
                areaJuego[0, 0] --boton 9
                 */
            }
            catch (Exception ex)
            {

                registrarErrorLog(ex);
            }
      

            return banderaposicion;
        }

        /// <summary>
        /// Vefica si el area de juego esta llena.
        /// </summary>
        /// <returns></returns>
        public bool AreaDeJuegoLlena()
        {
            bool areaLlena = true;
            try
            {
                for (int i = 0; i < areaJuego.GetLength(0); i++)
                    for (int j = 0; j < areaJuego.GetLength(1); j++)
                        if (areaJuego[i, j] == -1)
                            areaLlena = false;
            }
            catch (Exception ex)
            {

                registrarErrorLog(ex);
            }



            return areaLlena;
        }

        public bool TerminarJuego()
        {
            bool fin = false;
            if (AreaDeJuegoLlena() || VerificaExisteGanador() != -1)
                fin = true;

            return fin;

        }

        public void MovimientoMaquina()
        {

            try
            {
                if (!TerminarJuego())
                {
                    int f = 0;
                    int c = 0;
                    int v = -1;
                    int banderaposicion;

                    for (int i = 0; i < areaJuego.GetLength(0); i++)
                        for (int j = 0; j < areaJuego.GetLength(1); j++)
                            if (areaJuego[i, j] == -1)
                            {
                                areaJuego[i, j] = 1;
                                banderaposicion = MovimientoMinimo();
                                if (banderaposicion > v)
                                {
                                    v = banderaposicion;
                                    f = i;
                                    c = j;
                                }

                                areaJuego[i, j] = -1;
                            }
                    areaJuego[f, c] = 1;
                    maquinaUltimoMovimiento[0] = f;
                    maquinaUltimoMovimiento[1] = c;
                }
            }
            catch (Exception ex)
            {

                registrarErrorLog(ex);
            }




        }


        private int MovimientoMaximo()
        {
            int v = -1;
            int banderaposicion;
            try
            {
                if (TerminarJuego())
                {
                    if (VerificaExisteGanador() != -1)
                        return -1;
                    else
                        return 0;
                } 
                for (int i = 0; i < areaJuego.GetLength(0); i++)
                    for (int j = 0; j < areaJuego.GetLength(1); j++)
                        if (areaJuego[i, j] == -1)
                        {
                            areaJuego[i, j] = 1;
                            banderaposicion = MovimientoMinimo();
                            if (banderaposicion > v)
                                v = banderaposicion;

                            areaJuego[i, j] = -1;
                        }
            }
            catch (Exception ex)
            {

                registrarErrorLog(ex);
            }

            

            return v;
        }

        private int MovimientoMinimo()
        {
            int v = 1;
            int banderaposicion;
            try
            {
                if (TerminarJuego())
                {
                    if (VerificaExisteGanador() != -1)
                        return 1;
                    else
                        return 0;
                }

                for (int i = 0; i < areaJuego.GetLength(0); i++)
                    for (int j = 0; j < areaJuego.GetLength(1); j++)
                        if (areaJuego[i, j] == -1)
                        {
                            areaJuego[i, j] = 0;
                            banderaposicion = MovimientoMaximo();
                            if (banderaposicion < v)
                                v = banderaposicion;

                            areaJuego[i, j] = -1;
                        }
            }
            catch (Exception ex)
            {

                registrarErrorLog(ex);
            }
            

            return v;
        }



        public void registrarErrorLog( Exception e)
        {
            StringBuilder sb = new StringBuilder();
            string path = !string.IsNullOrEmpty(ConfigurationManager.AppSettings["RutaLog"]) ? ConfigurationManager.AppSettings["RutaLog"] :
                           @"C:\GatoError\";
            try
            {
                sb.Append("Ocurrió el siguiente error ");
                sb.Append(e);

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                
               
                using (StreamWriter log = new StreamWriter(path + $"LogGato{DateTime.Now.ToString("yyyMMdd")}.txt",true))
                {
                    log.WriteLine(sb.ToString());
                }

            }
            catch (Exception ex)
            {

                // no se hace nada.
            }
        }

    }
}
