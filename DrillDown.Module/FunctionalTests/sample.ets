;#DropDB DrillDownEasyTest

#Application DrillDownWin
;#Application DrillDownWeb

*FillForm
 User Name = Admin
*Action Log In

#IfDef DrillDownWin

*Action About...
 
*Action OK

#EndIf

#IfDef DrillDownWeb
*Action Navigation(My Details)
#EndIf
