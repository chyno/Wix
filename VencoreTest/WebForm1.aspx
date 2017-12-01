<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WebForm1.aspx.vb" Inherits="VencoreTest.WebForm1" Async="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>

<body onload="DoPostLoad();">

    <script type="text/javascript">
        function DoPostLoad() {
            if (IsPostBack() !== true) // ***This is NEW and ESSENTIAL! ***
            {
                var res = document.getElementById("lblWait");
                alert(res);
                if (res)
                {
                    document.getElementById("hiddenAsyncTrigger").click();
                }
              
            }
        
        }

        function IsPostBack() { // Ref. https://stackoverflow.com/questions/26978112/execute-javascript-only-on-page-load-not-postback-sharepoint
             var ret = '<%= Page.IsPostBack%>' == 'True';
             return ret;
        }
       
    </script>


    <form id="form1" runat="server">
         
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="udpCheckout" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <asp:Image ID="imgSpinner" runat="server" Visible="true" ImageUrl="~/images/ajax-loader.gif" />
            <br />
            <asp:Label ID="xxx" ClientIDMode="Predictable" runat="server" Visible="true" Text="Please wait..."></asp:Label>
            <asp:Button ID="hiddenAsyncTrigger" runat="server" Text="AsyncUpdate" style="display:none;" />
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="hiddenAsyncTrigger" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>



    <%--<form id="form1" runat="server">--%>
        <div>Hello from Web form John 2
        </div>
        <asp:Label ID="lblWait" runat="server" Text="Label"></asp:Label>
        <asp:Button ID="Button1" runat="server" Text="Button" />
    </form>
    
        </body>
</html>
