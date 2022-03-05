<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebGato.aspx.cs" Inherits="WebGato.WebGato" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
<style>
    .btnClassGato {
  -webkit-border-radius: 4px;
  -moz-border-radius: 4px;
  border-radius: 4px;
  font-family: Arial;
  color: #000000;
  font-size: 20px;
  background: #ffffff;
  padding: 10px 20px 10px 20px;
  text-decoration: none;
}

.btnClassGato:hover {
  text-decoration: none;
}
#play-gat{
    margin:5px 0px 0px 0px;
}
body {
    background: #549ada;
}
.juegogato{
    color:#ffffff;
    text-align:center;
}

.container{
    margin: 0 auto;
    padding: 0;
    display: flex;
    flex-direction:column;
    flex-flow:wrap;
justify-content:center;
width:60rem;
height:50vh;
}

.controls-play{
     margin:0 auto;
    /* align-items:center;*/
    text-align:center;
}
#container-info-play{
    margin:-25px 0px 0px 0px;
}
#btn_x,
#btn_o{
    background: #549ada;
    border: none;
    color:#000000;
    font-weight:bold;
}
.fichaSeleccionada{
    color:red !important;
}
#textSelect{
    color:#ffffff;
     font-weight:bold;
     font-family:Arial;
}

.playbotton{
   -webkit-border-radius: 4px;
  -moz-border-radius: 4px;
  border-radius: 4px;
  font-family: Arial;
  color:#000000;
  font-size: 20px;
  background:#ffffff;
  padding: 10px 20px 10px 20px;
  text-decoration: none;
  font-weight:400;
}
</style>
</head>
<body>
        <h1 class="juegogato">JUEGO GATO</h1>
    
    <form id="form1" runat="server">
        <div class="container">
        <div style="height: 400px; margin-left: 0px; width: 400px; margin-top: 26px;">

        <div style="height: 82px; margin-left: 0px; width: 471px; margin-top: 26px;">
            <asp:Button ID="btn_1" CssClass="btnClassGato" runat="server" Height="82px" OnClick="btn_1_Click" Text=" " Width="124px" />
            <asp:Button ID="btn_2" runat="server" CssClass="btnClassGato" Height="82px"  Text=" " Width="124px" OnClick="btn_2_Click"/>
            <asp:Button ID="btn_3" runat="server" CssClass="btnClassGato" Height="82px"  Text=" " Width="124px" OnClick="btn_3_Click"/>
           
        </div>
         <div style="height: 91px;  width: 471px; margin-top: 10px;">
            <asp:Button ID="btn_6" runat="server" CssClass="btnClassGato" Height="89px" Text=" " Width="124px" OnClick="btn_6_Click"/>
            <asp:Button ID="btn_5" runat="server" CssClass="btnClassGato" Height="89px" Text=" " Width="124px" OnClick="btn_5_Click"/>
              <asp:Button ID="btn_4" runat="server" CssClass="btnClassGato" Height="89px" Text=" " Width="124px" OnClick="btn_4_Click" />
        </div>
         <div style="height: 91px; width: 472px; margin-top: 10px;">
             <asp:Button ID="btn_9" runat="server" CssClass="btnClassGato" Height="89px" Text=" " Width="124px" OnClick="btn_9_Click"/>
             <asp:Button ID="btn_8" runat="server" CssClass="btnClassGato" Height="89px" Text=" " Width="124px" OnClick="btn_8_Click"/>
            <asp:Button ID="btn_7" runat="server" CssClass="btnClassGato" Height="89px" Text=" " Width="124px" OnClick="btn_7_Click" />
            
        </div>
            </div>
    
    <div class="controls-play" style="height: 400px; margin-left: 0px; width: 400px; margin-top: 26px;">
        <div id="container-gato">
        <img alt="Imagen de un gato" src="images/gato.png"/>
        </div>
        <div id="container-info-play">
            <asp:Label Text="Seleccione la ficha" ID="textSelect" runat="server" />
            <div id="botton-piece">
                <div id="botton-type">
                <asp:Button Text="X" ID="btn_x" OnClick="btn_x_Click" runat="server" />
                <asp:Button Text="O" ID="btn_o" OnClick="btn_o_Click" runat="server" />
                </div>
                <div id="play-gat">
                    <asp:Button Text="Jugar" ID="btn_play" CssClass="playbotton" OnClick="btn_play_Click" runat="server" />
                </div>
            </div>
            
        </div>

    </div>
         </div>
        </form>
       
</body>
</html>
