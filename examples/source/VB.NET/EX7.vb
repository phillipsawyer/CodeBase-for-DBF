Option Strict Off
Option Explicit On
Module EXAMPLE
    'EX7.VB
	
	Public lf As String 'Line Feed
	Public fPath As String 'Full path name to data files
	
	Public Const MB_OK As Short = 0
	Public Const MB_YESNO As Short = 4
	Public Const MB_ICONQUESTION As Short = 32
	Public Const IDYES As Short = 6
	
    Sub ExCode(ByRef frm As Form1)
        'ex7 example code
        Dim cb, db As Integer
        Dim rc As Short

        cb = code4init()

        'Specify full path if stand-alone
        If u4switch() And &H80S Then fPath = VB6.GetPath & "\"

        db = d4open(cb, fPath & "INFO")
        rc = d4go(db, d4recCount(db) + 1)
        MsgBox("An error message was displayed", MsgBoxStyle.OKOnly)

        rc = code4errorCode(cb, 0)
        rc = code4errGo(cb, 0)

        rc = d4go(db, d4recCount(db) + 1)
        MsgBox("No error message was displayed", MsgBoxStyle.OKOnly)

        rc = code4initUndo(cb)
    End Sub
End Module