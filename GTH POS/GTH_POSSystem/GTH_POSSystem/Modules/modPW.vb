Module modPW

    Public Function Decrypt_PWord(ByVal strEncrypt As String) As String
        Dim strNative As String
        Dim strI As Integer, temp1 As Integer, temp2 As Integer
        Dim intLen As Integer
        Dim intAve As Integer
        On Error GoTo badpwd

        If Len(strEncrypt) = 0 Then
            Decrypt_PWord = ""
            Exit Function
        End If
        intAve = Asc(Left(strEncrypt, 1))
        'strEncrypt = Mid(strEncrypt, 2)
        intLen = Len(strEncrypt)
        strNative = ""
        For strI = 1 To intLen
            temp1 = Asc(Mid(strEncrypt, strI, 1)) - (intLen - strI + 1) '- intAve
            strNative = Chr(temp1) & strNative
        Next strI
        Decrypt_PWord = strNative
        Exit Function
badpwd:
        Decrypt_PWord = ""
    End Function

    Public Function Encrypt_PWord(ByVal strNative As String) As String
        Dim strEncrypt As String
        Dim strI As Integer, temp1 As Integer
        Dim intLen As Integer
        Dim intAve As Integer

        If Len(strNative) = 0 Then
            Encrypt_PWord = ""
            Exit Function
        End If
        strEncrypt = ""
        intLen = Len(strNative)
        intAve = 0
        For strI = 1 To intLen
            intAve = intAve + Asc(Mid(strNative, strI, 1))
        Next strI
        intAve = (intAve / intLen) + intLen
        For strI = 1 To intLen
            temp1 = Asc(Mid(strNative, strI, 1)) + strI '+ intAve
            strEncrypt = Chr(temp1) & strEncrypt
        Next strI
        strEncrypt = strEncrypt 'Chr(intAve) & strEncrypt
        Encrypt_PWord = strEncrypt
    End Function

End Module
