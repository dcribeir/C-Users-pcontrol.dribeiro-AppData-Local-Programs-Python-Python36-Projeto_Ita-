﻿Imports Automation.Framework.LibraryGlobal.LibGlobal
Namespace test_Digital_Pesquisar_produto_e_Ordenar_por_Valor
    Public Class test_Digital_Pesquisar_produto_e_Ordenar_por_Valor
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
								Test.TestLog("Acessar o sistema Digital", "Sistema deve apresentar a funcionalidadePesquisar produto e Ordenar por Valor", "Sistema apresentou a funcionalidade Pesquisar produto e Ordenar por Valor com sucesso", typelog.Passed)
							End If
							If CBool(vbtnEntrar) Then
								Test.TestLog("Clicar em Entrar", "Clicar em Entrar e verificar o resultado esperado", "Clique em Entrar com sucesso", typelog.Passed)
								Test.Click("//*[@id='navbar-main']/ul[2]/li[2]/a", vbtnEntrar) 'click Entrar
								Test.TestLog("Resultado após clique em Entrar", "Resultado após clique em Entrar", "Resultado verificado com sucesso", typelog.Passed)
							End If
							Test.TestLog("Informar valores", "Sistema deve solicitar os valores conforme critérios de entrada", "Sistema permitiu a inclusão de valores com sucesso", typelog.Passed)
							Test.Set("id_username", vUsuario,"", typeIdentification.id) 'type Usuário
							Test.Set("id_password", vSenha,"", typeIdentification.id) 'type Senha
							If CBool(vbtnLogar) Then
								Test.TestLog("Clicar em Logar", "Clicar em Logar e verificar o resultado esperado", "Clique em Logar com sucesso", typelog.Passed)
								Test.Click("/html/body/div[2]/div/div/form/fieldset/div[3]/div/button", vbtnLogar) 'click Logar
								Test.TestLog("Resultado após clique em Logar", "Resultado após clique em Logar", "Resultado verificado com sucesso", typelog.Passed)
							End If
							Test.TestLog("Informar valores", "Sistema deve solicitar os valores conforme critérios de entrada", "Sistema permitiu a inclusão de valores com sucesso", typelog.Passed)
							Test.Set("//*[@id='navbar-main']/form/div/input", vPor_valor,"") 'type Por valor
							Test.SendKey("{ENTER}") 'SendKey {ENTER}
							If CBool(vbtnProduto) Then
								Test.TestLog("Clicar em Produto", "Clicar em Produto e verificar o resultado esperado", "Clique em Produto com sucesso", typelog.Passed)
								Test.Click("/html/body/div[2]/div[2]/div[1]/div/div/p[2]/a[2]", vbtnProduto) 'click Produto
								Test.TestLog("Resultado após clique em Produto", "Resultado após clique em Produto", "Resultado verificado com sucesso", typelog.Passed)
							End If
							Test.GetTextAndSave("R$ 9000,00", "vValidar_valor_out", typeIdentification.linkText) 'GetTextAndSave Validar valor
							
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
				HandlerError("test_Digital_Pesquisar_produto_e_Ordenar_por_Valor.test_Digital_Pesquisar_produto_e_Ordenar_por_Valor.Run: " & ex.Message)
                Test.TestLog("Execução do teste", "Teste executado com sucesso", "Teste executado com falha! Message: " & p_errorDescription, typelog.Failed)
                Return False
            End Try
        End Function

        '*********************************************************************************************************************************
        'STARTTEST
        Public Shared p_ExpectedResult, p_CheckPoint1 As String
        Public Shared vbtnEntrar,vUsuario, vSenha, vbtnLogar,vPor_valor, vbtnProduto, vIsOpenSystem As String

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
                    vbtnEntrar = pc_db.Fieldt("vbtnEntrar")
					vUsuario = pc_db.Fieldt("vUsuario")
					vSenha = pc_db.Fieldt("vSenha")
					vbtnLogar = pc_db.Fieldt("vbtnLogar")
					vPor_valor = pc_db.Fieldt("vPor_valor")
					vbtnProduto = pc_db.Fieldt("vbtnProduto")
					vIsOpenSystem = pc_db.Fieldt("vIsOpenSystem")
					
                    
                    pc_db.StartExecution(p_TableTest, p_IDTest)
                    If p_PublishQC Then CreateStructureQC()
                    Return True
                Else
                    Return False
                End If
            Catch ex As Exception
                HandlerError("test_Digital_Pesquisar_produto_e_Ordenar_por_Valor.test_Digital_Pesquisar_produto_e_Ordenar_por_Valor.StartTest" & ex.StackTrace & " - " & ex.Message)
                Return False
            End Try
        End Function
    End Class
End Namespace
