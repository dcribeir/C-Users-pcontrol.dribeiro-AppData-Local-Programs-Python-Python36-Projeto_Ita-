Imports Automation.Framework.LibraryGlobal.LibGlobal
Namespace test_Digital_Criar_Produto
    Public Class test_Digital_Criar_Produto
        Public Sub New()
        End Sub
        Public Function Run() As Boolean
            Try
                If StartTest() Then
                    Do While p_CountTest <> 0
                        Try
                            If CBool(vIsOpenSystem) Then 'if true open system else load new test without open system
								p_pathUrlApp = "http://localhost:8000/admin"'xml.Read("urlLocal") 'Create urlLocal element in XML
								If Not Test.StartTests Then Return False
								Test.Open(p_pathUrlApp)
								Test.TestLog("Acessar o sistema Digital", "Sistema deve apresentar a funcionalidadeCriar Produto", "Sistema apresentou a funcionalidade Criar Produto com sucesso", typelog.Passed)
							End If
							Test.TestLog("Informar valores", "Sistema deve solicitar os valores conforme critérios de entrada", "Sistema permitiu a inclusão de valores com sucesso", typelog.Passed)
							Test.Set("id_username", vUsuario,"", typeIdentification.id) 'type Usuário
							Test.Set("id_password", vSenha,"", typeIdentification.id) 'type Senha
							If CBool(vbtnAcessar) Then
								Test.TestLog("Clicar em Acessar", "Clicar em Acessar e verificar o resultado esperado", "Clique em Acessar com sucesso", typelog.Passed)
								Test.Click("//*[@id='login-form']/div[3]/input", vbtnAcessar) 'click Acessar
								Test.TestLog("Resultado após clique em Acessar", "Resultado após clique em Acessar", "Resultado verificado com sucesso", typelog.Passed)
							End If
							If CBool(vbtnAdicionar_Produto) Then
								Test.TestLog("Clicar em Adicionar Produto", "Clicar em Adicionar Produto e verificar o resultado esperado", "Clique em Adicionar Produto com sucesso", typelog.Passed)
								Test.Click("//*[@id='content-main']/div[2]/table/tbody/tr[2]/td[1]/a", vbtnAdicionar_Produto) 'click Adicionar Produto
								Test.TestLog("Resultado após clique em Adicionar Produto", "Resultado após clique em Adicionar Produto", "Resultado verificado com sucesso", typelog.Passed)
							End If
							Test.TestLog("Informar valores", "Sistema deve solicitar os valores conforme critérios de entrada", "Sistema permitiu a inclusão de valores com sucesso", typelog.Passed)
							Test.Set("id_name", vNome,"", typeIdentification.id) 'type Nome
							Test.Set("id_slug", vIdentificador,"", typeIdentification.id) 'type Identificador
							If CBool(vbtnCategoria) Then
								Test.TestLog("Clicar em Categoria", "Clicar em Categoria e verificar o resultado esperado", "Clique em Categoria com sucesso", typelog.Passed)
								Test.Click("//*[@id='id_category']/option[2]", vbtnCategoria) 'click Categoria
								Test.TestLog("Resultado após clique em Categoria", "Resultado após clique em Categoria", "Resultado verificado com sucesso", typelog.Passed)
							End If
							Test.TestLog("Informar valores", "Sistema deve solicitar os valores conforme critérios de entrada", "Sistema permitiu a inclusão de valores com sucesso", typelog.Passed)
							Test.Set("id_description", vDescricao,"", typeIdentification.id) 'type Descrição
							Test.Set("id_price", vPreco,"", typeIdentification.id) 'type Preço
							If CBool(vbtnSalvar) Then
								Test.TestLog("Clicar em Salvar", "Clicar em Salvar e verificar o resultado esperado", "Clique em Salvar com sucesso", typelog.Passed)
								Test.Click("_save", vbtnSalvar, typeIdentification.name) 'click Salvar
								Test.TestLog("Resultado após clique em Salvar", "Resultado após clique em Salvar", "Resultado verificado com sucesso", typelog.Passed)
							End If
							Test.TestLog("Informar valores", "Sistema deve solicitar os valores conforme critérios de entrada", "Sistema permitiu a inclusão de valores com sucesso", typelog.Passed)
							Test.Set("q", vPesquisar1,"", typeIdentification.name) 'type Pesquisar1
							If CBool(vbtnPesquisar2) Then
								Test.TestLog("Clicar em Pesquisar2", "Clicar em Pesquisar2 e verificar o resultado esperado", "Clique em Pesquisar2 com sucesso", typelog.Passed)
								Test.Click("//*[@id='changelist-search']/div/input[2]", vbtnPesquisar2) 'click Pesquisar2
								Test.TestLog("Resultado após clique em Pesquisar2", "Resultado após clique em Pesquisar2", "Resultado verificado com sucesso", typelog.Passed)
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
				HandlerError("test_Digital_Criar_Produto.test_Digital_Criar_Produto.Run: " & ex.Message)
                Test.TestLog("Execução do teste", "Teste executado com sucesso", "Teste executado com falha! Message: " & p_errorDescription, typelog.Failed)
                Return False
            End Try
        End Function

        '*********************************************************************************************************************************
        'STARTTEST
        Public Shared p_ExpectedResult, p_CheckPoint1 As String
        Public Shared vUsuario, vSenha, vbtnAcessar, vbtnAdicionar_Produto, vNome, vIdentificador, vbtnCategoria, vDescricao, vPreco, vbtnSalvar, vPesquisar1, vbtnPesquisar2, vIsOpenSystem As String

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
                    vUsuario = pc_db.Fieldt("vUsuario")
					vSenha = pc_db.Fieldt("vSenha")
					vbtnAcessar = pc_db.Fieldt("vbtnAcessar")
					vbtnAdicionar_Produto = pc_db.Fieldt("vbtnAdicionar_Produto")
					vNome = pc_db.Fieldt("vNome")
					vIdentificador = pc_db.Fieldt("vIdentificador")
					vbtnCategoria = pc_db.Fieldt("vbtnCategoria")
					vDescricao = pc_db.Fieldt("vDescricao")
					vPreco = pc_db.Fieldt("vPreco")
					vbtnSalvar = pc_db.Fieldt("vbtnSalvar")
					vPesquisar1 = pc_db.Fieldt("vPesquisar1")
					vbtnPesquisar2 = pc_db.Fieldt("vbtnPesquisar2")
					vIsOpenSystem = pc_db.Fieldt("vIsOpenSystem")
					
                    
                    pc_db.StartExecution(p_TableTest, p_IDTest)
                    If p_PublishQC Then CreateStructureQC()
                    Return True
                Else
                    Return False
                End If
            Catch ex As Exception
                HandlerError("test_Digital_Criar_Produto.test_Digital_Criar_Produto.StartTest" & ex.StackTrace & " - " & ex.Message)
                Return False
            End Try
        End Function
    End Class
End Namespace
