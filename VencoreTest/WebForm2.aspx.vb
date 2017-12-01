Imports System.Threading.Tasks

Public Class WebForm2
    Inherits System.Web.UI.Page

    Public Property FooBar As BeginEventHandler

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' Define the asynchronuous task.
        Dim slowTask1 As New SlowTask()
        Dim slowTask2 As New SlowTask()
        Dim slowTask3 As New SlowTask()

        Dim asyncTask1 As New PageAsyncTask(AddressOf slowTask1.OnBegin, AddressOf slowTask1.OnEnd, AddressOf slowTask1.OnTimeout, "Async1", True)
        Dim asyncTask2 As New PageAsyncTask(AddressOf slowTask2.OnBegin, AddressOf slowTask2.OnEnd, AddressOf slowTask2.OnTimeout, "Async2", True)
        Dim asyncTask3 As New PageAsyncTask(AddressOf slowTask3.OnBegin, AddressOf slowTask3.OnEnd, AddressOf slowTask3.OnTimeout, "Async3", True)

        ' Register the asynchronous task.
        Page.RegisterAsyncTask(asyncTask1)
        Page.RegisterAsyncTask(asyncTask2)
        Page.RegisterAsyncTask(asyncTask3)

        ' Execute the register asynchronous task.
        Page.ExecuteRegisteredAsyncTasks()

        TaskMessage.InnerHtml = slowTask1.GetAsyncTaskProgress() + "<br />" + slowTask2.GetAsyncTaskProgress() + "<br />" + slowTask3.GetAsyncTaskProgress()


    End Sub


End Class