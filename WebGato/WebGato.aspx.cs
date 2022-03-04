using Gato.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebGato
{
    public partial class WebGato : System.Web.UI.Page
    {
        static Random rand = new Random();
       static  string[] jugadores = { "P", "M" };
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                limpiarBotontesGato();
                deshabilitarBotones();
                reinciarElementoMatriz();
            }


        }


        protected void btn_1_Click(object sender, EventArgs e)
        {
            clicboton(0, 0, btn_1);
        }

        protected void btn_2_Click(object sender, EventArgs e)
        {
            clicboton(0, 1, btn_2);
        }

        protected void btn_3_Click(object sender, EventArgs e)
        {
            clicboton(0, 2, btn_3);
        }

        protected void btn_6_Click(object sender, EventArgs e)
        {
            clicboton(1, 0, btn_6);
        }

        protected void btn_5_Click(object sender, EventArgs e)
        {
            clicboton(1, 1, btn_5);
        }

        protected void btn_4_Click(object sender, EventArgs e)
        {
            clicboton(1, 2, btn_4);
        }

        protected void btn_9_Click(object sender, EventArgs e)
        {
            clicboton(2, 0, btn_9);
        }

        protected void btn_8_Click(object sender, EventArgs e)
        {
            clicboton(2, 1, btn_8);
        }

        protected void btn_7_Click(object sender, EventArgs e)
        {
            clicboton(2, 2, btn_7);
        }


        protected void btn_x_Click(object sender, EventArgs e)
        {
            complementGato.FichaUsaUsuario = "X";
            btn_x.CssClass = "fichaSeleccionada";
            btn_o.CssClass = "";
        }

        protected void btn_o_Click(object sender, EventArgs e)
        {
            complementGato.FichaUsaUsuario = "O";
            btn_o.CssClass = "fichaSeleccionada";
            btn_x.CssClass = "";
        }

        protected void btn_play_Click(object sender, EventArgs e)
        {

            try
            {
                #region  Carga defecto elementos de la ventana
                limpiarBotontesGato();
                reinciarElementoMatriz();
                habilitaDeshabilitaBotonesFicha();
                #endregion

                if (!string.IsNullOrEmpty(complementGato.FichaUsaUsuario))
                {
                    if (jugadores[rand.Next(jugadores.Length)] == "M")
                    {
                        mensaje("Juega Maquina");
                        complementGato.clasePrincipal.MovimientoMaquina();
                        complementGato.jugadorGanoPartida = complementGato.clasePrincipal.VerificaExisteGanador();
                        comprobarGanoPartida();
                    }
                    else
                    {
                        mensaje($"Juega Usuario");
                    }
                    habilitarBotones();


                }
                else
                {

                    mensaje("Seleccione la ficha con la que desea juegar");
                }
            }
            catch (Exception ex)
            {

                mensaje($"Ocurrió un error  {ex.Message}");
            }
            
            
        }

        protected void clicboton(int x, int y, Button boton)
        {

            try
            {
                if (complementGato.areaJuego[x, y] == -1)
                {
                    complementGato.clasePrincipal.LlenarPosicionJuego(x, y);
                    complementGato.jugadorGanoPartida = complementGato.clasePrincipal.VerificaExisteGanador();
                    comprobarGanoPartida();
                    boton.Text = complementGato.FichaUsaUsuario;
                    if (complementGato.jugadorGanoPartida != -1 || complementGato.clasePrincipal.AreaDeJuegoLlena())
                    {
                        complementGato.FichaUsaUsuario = "";
                        //quitamos la clase que pone la letra en rojo.
                         btn_x.CssClass =
                         btn_o.CssClass = "";
                        habilitaDeshabilitaBotonesFicha();
                    }

                }
            }
            catch (Exception ex)
            {

                mensaje($"Ocurrió un error {ex.Message}");
            }

        }

        private void comprobarGanoPartida()
        {
            string FichaMaquina = complementGato.FichaUsaUsuario == "X" ? "O" : complementGato.FichaUsaUsuario == "O" ? "X" : "O";
            try
            {
                int[] ultMov = complementGato.clasePrincipal.MaquinaMovimientoFinal;

                if (ultMov[0] == 0 && ultMov[1] == 0)
                    btn_1.Text = FichaMaquina;
                if (ultMov[0] == 0 && ultMov[1] == 1)
                    btn_2.Text = FichaMaquina;
                if (ultMov[0] == 0 && ultMov[1] == 2)
                    btn_3.Text = FichaMaquina;

                if (ultMov[0] == 1 && ultMov[1] == 0)
                    btn_6.Text = FichaMaquina;
                if (ultMov[0] == 1 && ultMov[1] == 1)
                    btn_5.Text = FichaMaquina;
                if (ultMov[0] == 1 && ultMov[1] == 2)
                    btn_4.Text = FichaMaquina;


                if (ultMov[0] == 2 && ultMov[1] == 0)
                    btn_9.Text = FichaMaquina;
                if (ultMov[0] == 2 && ultMov[1] == 1)
                    btn_8.Text = FichaMaquina;
                if (ultMov[0] == 2 && ultMov[1] == 2)
                    btn_7.Text = FichaMaquina;

                if (complementGato.jugadorGanoPartida == 0)
                { //gano usuario
                    mensaje($"Ganó el jugador  {complementGato.FichaUsaUsuario}");
                    deshabilitarBotones();
                }


                if (complementGato.jugadorGanoPartida == 1)
                { //gano maquina

                    mensaje($"Ganó el jugador {FichaMaquina}");
                    deshabilitarBotones();
                }


                if (complementGato.jugadorGanoPartida == -1 && complementGato.clasePrincipal.AreaDeJuegoLlena())
                { //empate
                    mensaje("La partida queda en empate");
                    deshabilitarBotones();

                }
            }
            catch (Exception ex)
            {

                mensaje($"Ocurrió un error al comprobarPartida {ex.Message}");
            }

        }


        private void deshabilitarBotones()
        {
                btn_1.Enabled =
                btn_2.Enabled =
                btn_3.Enabled =
                btn_4.Enabled =
                btn_5.Enabled =
                btn_6.Enabled =
                btn_7.Enabled =
                btn_8.Enabled =
                btn_9.Enabled =false;
        }

        private void habilitarBotones()
        {
            btn_1.Enabled =
            btn_2.Enabled =
            btn_3.Enabled =
            btn_4.Enabled =
            btn_5.Enabled =
            btn_6.Enabled =
            btn_7.Enabled =
            btn_8.Enabled =
            btn_9.Enabled = true;
        }


        private void reinciarElementoMatriz()
        {
            complementGato.clasePrincipal = new Tictactoe();
            complementGato.clasePrincipal.InicioPartida();
            complementGato.areaJuego = complementGato.clasePrincipal.MatrizGato;
        }

        private void limpiarBotontesGato()
        {
            btn_1.Text =
                btn_2.Text =
                btn_3.Text =
                btn_4.Text =
                btn_5.Text =
                btn_6.Text =
                btn_7.Text =
                btn_8.Text =
                btn_9.Text = " ";
        }


        private void mensaje(string mensaje)
        {

            string script = @"<script language='javascript'>setTimeout(function(){ alert('"+mensaje+"'); },150);</script>";
            if (!ClientScript.IsStartupScriptRegistered("TimerScript"))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "TimerScript", script);
            }
        }

        private void habilitaDeshabilitaBotonesFicha()
        {
            if ((btn_x.CssClass== "fichaSeleccionada" || btn_o.CssClass == "fichaSeleccionada"))
            {
                btn_x.Enabled =
                btn_o.Enabled = false;
            }
            else
            {
                btn_x.Enabled =
                btn_o.Enabled = true;
            }
        }

  
    }
}