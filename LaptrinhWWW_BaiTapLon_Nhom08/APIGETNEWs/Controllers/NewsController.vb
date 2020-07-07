Imports System.Web.Mvc

Namespace Controllers
    Public Class NewsController
        Inherits Controller

        ' GET: News
        Function Index() As ActionResult
            Return View()
        End Function
    End Class
End Namespace