Imports Automation.Framework.LibraryGlobal.LibGlobal
Namespace test_Digital_Criacao_de_Usuario
    Public Class test_Digital_Criacao_de_Usuario
        Public Sub New()
        End Sub
        Public Function Run() As Boolean
            Try
                If StartTest() Then
                    Do While p_CountTest <> 0
                        Try
                            If CBool(vIsOpenSystem) Then 'if true open system else load new test without open system
								p_pathUrlApp = "http://localhost:8000"'xml.Read("urlLocal") 'Create urlLocal element in XML
								If Not Test.StartTests Then Return False
								Test.Open(p_pathUrlApp)
								Test.TestLog("Acessar o sistema Digital", "Sistema deve apresentar a funcionalidadeCriação de Usuário", "Sistema apresentou a funcionalidade Criação de Usuário com sucesso", typelog.Passed)
							End If
							If CBool(vbtnRegistro) Then
								Test.TestLog("Clicar em Registro", "Clicar em Registro e verificar o resultado esperado", "Clique em Registro com sucesso", typelog.Passed)
								Test.Click("//*[@id='navbar-main']/ul[2]/li[3]/a", vbtnRegistro) 'click Registro
								Test.TestLog("Resultado após clique em Registro", "Resultado após clique em Registro", "Resultado verificado com sucesso", typelog.Passed)
							End If
							Test.TestLog("Informar valores", "Sistema deve solicitar os valores conforme critérios de entrada", "Sistema permitiu a inclusão de valores com sucesso", typelog.Passed)
							Test.Set("id_username", vUsuario,"", typeIdentification.id) 'type Usuário
							Test.Set("id_email", vEmail,"", typeIdentification.id) 'type Email
							Test.Set("id_password1", vSenha1,"", typeIdentification.id) 'type Senha1
							Test.Set("id_password2", vSenha2,"", typeIdentification.id) 'type Senha2
							If CBool(vbtnRegistrar) Then
								Test.TestLog("Clicar em Registrar", "Clicar em Registrar e verificar o resultado esperado", "Clique em Registrar com sucesso", typelog.Passed)
								Test.Click("/html/body/div[2]/div/div/form/fieldset/div[5]/div/button", vbtnRegistrar) 'click Registrar
								Test.TestLog("Resultado após clique em Registrar", "Resultado após clique em Registrar", "Resultado verificado com sucesso", typelog.Passed)
							End If
							
                            'Checkpoint
                            Test.CheckPointTest(p_CheckPoint1, p_ExpectedResult)
                            'end test                         
                            Test.EndTest(p_GenerateLogTest)
                            If p_IsLoop Then StartTest() Else p_CountTest = 0
                        Catch ex As Exception
							p_errorDescription = "Menssage error: " & ex.Message.ToString
							Test.TestLog("Passo executado", "Execução do passo com sucesso", "Passo executado com falha! Message: " & p_errorDescription, typelog.Failed)
							EndTestTable()
                       Test.EndTest(p_GenerateLogTest)
                            If p_IsLoop Then StartTest() Else p_CountTest = 0
                        End Try
                    Loop
                    EndTestTable()
                    Return True
                Else
                    Test.TestLog("Teste executado", "Teste executado com sucesso", "Teste executado com falha! StartTest = False", typelog.Failed)
                    EndTestTable()
                    Return False
                End If
            Catch ex As Exception
                p_errorDescription = "Menssage error: " & ex.Message.ToString
				HandlerError("test_Digital_Criacao_de_Usuario.test_Digital_Criacao_de_Usuario.Run: " & ex.Message)
                Test.TestLog("Execução do teste", "Teste executado com sucesso", "Teste executado com falha! Message: " & p_errorDescription, typelog.Failed)
                Return False
            End Try
        End Function

        '*********************************************************************************************************************************
        'STARTTEST
        Public Shared p_ExpectedResult, p_CheckPoint1 As String
        Public Shared vbtnRegistro,vUsuario, vEmail, vSenha1, vSenha2, vbtnRegistrar, vIsOpenSystem As String

        Private Function StartTest() As Boolean
            Dim strQueryOut1, strQueryOut2, strQueryOut3, strQueryOut4, strQueryOut5, strQueryOut6 as string
            Try
                p_CountTest = pc_db.OpenTestTable(p_TableTest, p_IDScenario) 'opening the test table containing all the test cases
                If p_CountTest <> 0 Then
                    p_IDScenario = pc_db.Fieldt("IDScenario") 'set IDSceario
                    p_IDTest = pc_db.Fieldt("IDTest") 'set IDTest
                    p_OrdemTest = pc_db.Fieldt("Ordem")
                    p_TestName = pc_db.Fieldt("TestName")
                    p_DescriptionTest = pc_db.Fieldt("Description")
                    p_IDRun = pc_db.Fieldt("IDRun")
                    p_ExpectedResult = pc_db.Fieldt("ExpectedResult")
                    p_IDTestInstance = pc_db.Fieldt("IDTool")
					p_CheckPoint1 = pc_db.Fieldt("CheckPoint1")

                    'Data Transfer Parameters
                    strQueryOut1 = pc_db.Fieldt("QueryInput1")
                    strQueryOut2 = pc_db.Fieldt("QueryInput2")
                    strQueryOut3 = pc_db.Fieldt("QueryInput3")
                    strQueryOut4 = pc_db.Fieldt("QueryInput4")
					strQueryOut5 = pc_db.Fieldt("QueryInput5")
					strQueryOut6 = pc_db.Fieldt("QueryInput6")
                   
                    'transfer values between tables
					If String.IsNullOrEmpty(strQueryOut1) Then pc_db.TransferDataInTablesArray(strQueryOut1, p_TableTest, p_IDScenario, p_IDTest)
                    If String.IsNullOrEmpty(strQueryOut2) Then pc_db.TransferDataInTablesArray(strQueryOut1, p_TableTest, p_IDScenario, p_IDTest)
                    If String.IsNullOrEmpty(strQueryOut3) Then pc_db.TransferDataInTablesArray(strQueryOut1, p_TableTest, p_IDScenario, p_IDTest)
                    If String.IsNullOrEmpty(strQueryOut4) Then pc_db.TransferDataInTablesArray(strQueryOut1, p_TableTest, p_IDScenario, p_IDTest)
                    If String.IsNullOrEmpty(strQueryOut5) Then pc_db.TransferDataInTablesArray(strQueryOut1, p_TableTest, p_IDScenario, p_IDTest)
                    If String.IsNullOrEmpty(strQueryOut6) Then pc_db.TransferDataInTablesArray(strQueryOut1, p_TableTest, p_IDScenario, p_IDTest)
					'
                    p_CountTest = pc_db.OpenTestTable(p_TableTest, p_IDScenario)
                    vbtnRegistro = pc_db.Fieldt("vbtnRegistro")
					vUsuario = pc_db.Fieldt("vUsuario")
					vEmail = pc_db.Fieldt("vEmail")
					vSenha1 = pc_db.Fieldt("vSenha1")
					vSenha2 = pc_db.Fieldt("vSenha2")
					vbtnRegistrar = pc_db.Fieldt("vbtnRegistrar")
					vIsOpenSystem = pc_db.Fieldt("vIsOpenSystem")
					
                    
                    pc_db.StartExecution(p_TableTest, p_IDTest)
                    If p_PublishQC Then CreateStructureQC()
                    Return True
                Else
                    Return False
                End If
            Catch ex As Exception
                HandlerError("test_Digital_Criacao_de_Usuario.test_Digital_Criacao_de_Usuario.StartTest" & ex.StackTrace & " - " & ex.Message)
                Return False
            End Try
        End Function
    End Class
End Namespace
