Option Strict Off
Option Explicit On
Module EXAMPLE
    'EX27.VB
	
	Public lf As String 'Line Feed
	Public fPath As String 'Full path name to db files
	
	Public Const MB_OK As Short = 0
	Public Const MB_YESNO As Short = 4
	Public Const MB_ICONQUESTION As Short = 32
	Public Const IDYES As Short = 6
	
    Sub ExCode(ByRef frm As Form1)
        Dim cb, db As Integer
        Dim rc As Short

        cb = code4init()

        'Specify full path if stand-alone
        If u4switch() And &H80S Then fPath = VB6.GetPath & "\"

        db = d4open(cb, fPath & "INFO")
        'Blanks out all records in the data file
        rc = d4top(db)
        Do While d4eof(db) = 0
            Call d4blank(db)
            rc = d4skip(db, 1)
        Loop

        rc = code4initUndo(cb) 'close all files and release any memory
    End Sub
End Module