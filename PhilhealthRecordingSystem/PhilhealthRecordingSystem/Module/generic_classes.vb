Public Class ComboListData

    Private sName As String
    Private iID As Long

    Public Sub New()
        sName = ""
        iID = 0
    End Sub

    Public Sub New(ByVal Name As String, ByVal ID As Long)
        sName = Name
        iID = ID
    End Sub

    Public Property Name() As String
        Get
            Return sName
        End Get

        Set(ByVal sValue As String)
            sName = sValue
        End Set
    End Property

    Public Property ItemData() As Long
        Get
            Return iID
        End Get

        Set(ByVal iValue As Long)
            iID = iValue
        End Set
    End Property

    Public Overrides Function ToString() As String
        Return sName
    End Function

    Private CallingForm_ As String

    Public Property CallingForm_SETGET() As String
        Get
            Return CallingForm_
        End Get
        Set(ByVal value As String)
            CallingForm_ = value
        End Set
    End Property

End Class
