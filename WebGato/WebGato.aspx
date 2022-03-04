<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebGato.aspx.cs" Inherits="WebGato.WebGato" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
<style>
    .btnClassGato {
  -webkit-border-radius: 4;
  -moz-border-radius: 4;
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
body {
    background: #549ada;
}
.juegogato{
    color:#ffffff;
    text-align:center;
}

.container{
    margin: 0;
    padding: 0;
    display: flex;
flex-direction:column;
flex-flow:wrap;
justify-content:space-evenly;
border:solid red;
}

.controls-play{
     border: solid black;
     align-items:center;
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
</style>
</head>
<body>
        <h1 class="juegogato">JUEGO GATO</h1>
    
    <form id="form1" runat="server">
        <div class="container">
        <div style="height: 340px; margin-left: 0px; width: 559px; margin-top: 26px; border: solid black;">

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
    
    <div class="controls-play" style="height: 340px; margin-left: 0px; width: 559px; margin-top: 26px;">
        <div id="container-gato">
        <img alt="Imagen de un gato" src="images/gato.PNG" />
        </div>
        <div id="container-info-play">
            <asp:Label Text="Seleccione la ficha" runat="server" />
            <div id="botton-piece">
                <div id="botton-type">
                <asp:Button Text="X" ID="btn_x" OnClick="btn_x_Click" runat="server" />
                <asp:Button Text="O" ID="btn_o" OnClick="btn_o_Click" runat="server" />
                </div>
                <div id="play-gat">
                    <asp:Button Text="Jugar" ID="btn_play" OnClick="btn_play_Click" runat="server" />
                </div>
            </div>
            
        </div>

    </div>
         </div>
        </form>
       
</body>
</html>
