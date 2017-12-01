Public Class WebForm1
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        System.Threading.Thread.Sleep(2000)

        Me.lblWait.Visible = True

        If Not Me.IsPostBack() Then
            System.Threading.Thread.Sleep(2000)

            Me.lblWait.Visible = False
        End If


        Dim res = ConfigurationSettings.AppSettings.Get("TestTranform")
        ' Me.Label1.Text = res

        ScriptManager.RegisterStartupScript(Me.Page, Me.Page.GetType, "LoadUpdate", GetPostBackEventReference(hiddenAsyncTrigger, String.Empty), True)

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        System.Threading.Thread.Sleep(5000)  'wait 5 seconds so I can see the page change
        imgSpinner.Visible = False
        lblWait.Text = "Content is now loaded."
        'udpCheckout.Update()
    End Sub
End Class