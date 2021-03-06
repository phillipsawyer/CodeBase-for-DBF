Option Strict Off
Option Explicit On
Module EXAMPLE
	'EX64.VB
	
	Public lf As String 'Line Feed
	Public fPath As String 'Full path name to db files
	
	Public Const MB_OK As Short = 0
	Public Const MB_YESNO As Short = 4
	Public Const MB_ICONQUESTION As Short = 32
	Public Const IDYES As Short = 6
	
    Sub ExCode(ByRef frm As Form1)
        Dim nameTag, cb, db, nameField As Integer
        Dim rc As Short

        cb = code4init()

        'Specify full path if stand-alone
        If u4switch() And &H80S Then fPath = VB6.GetPath & "\"

        db = d4open(cb, fPath & "INFO")
        nameTag = d4tag(db, "INF_NAME")
        nameField = d4field(db, "NAME")

        Call error4exitTest(cb)
        rc = d4lockAll(db)
        Call d4tagSelect(db, nameTag)

        rc = d4seek(db, "John")
        Do While rc = r4success
            If StrComp(f4str(nameField), "John                ") = 0 Then
                'UPGRADE_ISSUE: Form method Form1.Print was not upgraded. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup2064"'
                frm.ListBox1.Items.Add("John in record " & Str(d4recNo(db)))
            Else
                Exit Do
            End If
            rc = d4skip(db, 1)
        Loop

        rc = d4unlock(db)
        rc = d4close(db)
        rc = code4initUndo(cb)
    End Sub
End Module