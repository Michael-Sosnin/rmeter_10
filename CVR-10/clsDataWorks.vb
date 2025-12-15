Public Class clsDataWorks
    Private strSystemPath As String 'Путь к системной БД Access. Расположена в корневом каталоге программы.
    Private strWorkPath As String 'Путь к рабочей БД Access. Указывает пользователь.
    Private dsSys, ds As DataSet 'Системный/рабочий DataSet

    Public Sub New()
        strSystemPath = strSystemPath1 + "\SysDb.usr"
        If Not prInitSystemDataSet() Then
            MessageBox.Show("Не удалось создать системный DataSet", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
    End Sub

    ''' <summary>
    ''' Свойство устанавливает значение локальной переменной strPathToWorkDb
    ''' </summary>
    ''' <remarks></remarks>
    Public Property PathToWorkDb() As String
        Get
            Return strWorkPath
        End Get
        Set(ByVal value As String)
            strWorkPath = value
        End Set
    End Property

#Region "Возвращает запрашиваемый объект DataSet или DataTable"
    Public Function GetDataSet() As DataSet
        Dim dsAll As New DataSet
        dsAll.Merge(dsSys)
        dsAll.Merge(ds)
        Return dsAll
    End Function
    Public Function GetWorkDataSet() As DataSet
        Return ds
    End Function
    Public Function GetSystemDataSet() As DataSet
        Return dsSys
    End Function
    Public Function GetWorkDataTable(ByVal strTblName As String) As DataTable
        Return ds.Tables(strTblName)
    End Function
    Public Function GetSystemDataTable(ByVal strTblName As String) As DataTable
        Return dsSys.Tables(strTblName)
    End Function
#End Region

    ''' <summary>
    ''' Функция инициирует системный DataSet
    ''' </summary>
    ''' <returns>true - DataSet успешно создан</returns>
    ''' <remarks></remarks>
    Public Function prInitSystemDataSet() As Boolean
        Dim str As String
        Dim cmd As OleDbCommand
        Dim da As OleDbDataAdapter

        'Microsoft.ACE.OLEDB.12.0
        Dim oleCnn As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + strSystemPath + ";")
        'Dim oleCnn As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + strSystemPath + ";")
        Try
            dsSys = New DataSet 'Очищаем DataSet

            'ActionTypes
            str = "SELECT ActionTypeId,Details FROM ActionTypes"
            cmd = oleCnn.CreateCommand()
            With cmd
                .CommandText = str
                .CommandType = CommandType.Text
            End With
            da = New OleDbDataAdapter(cmd)
            da.Fill(dsSys, "ActionTypes")
            da.FillSchema(dsSys.Tables("ActionTypes"), SchemaType.Mapped)
            'Устанавливаем начальное значание инкремента
            If dsSys.Tables("ActionTypes").Rows.Count = 0 Then
                dsSys.Tables("ActionTypes").Columns("ActionTypeId").AutoIncrementSeed = 1
            Else
                dsSys.Tables("ActionTypes").Columns("ActionTypeId").AutoIncrementSeed = dsSys.Tables("ActionTypes").Rows(dsSys.Tables("ActionTypes").Rows.Count - 1).Item("ActionTypeId") + 1
            End If


            'CoreTypeKgPosition
            str = "SELECT CoreTypeKgPositionId,CoreTypeId,KgTypeId,X,Y FROM CoreTypeKgPosition"
            cmd = oleCnn.CreateCommand()
            With cmd
                .CommandText = str
                .CommandType = CommandType.Text
            End With
            da = New OleDbDataAdapter(cmd)
            da.Fill(dsSys, "CoreTypeKgPosition")
            da.FillSchema(dsSys.Tables("CoreTypeKgPosition"), SchemaType.Mapped)
            'Устанавливаем начальное значание инкремента
            If dsSys.Tables("CoreTypeKgPosition").Rows.Count = 0 Then
                dsSys.Tables("CoreTypeKgPosition").Columns("CoreTypeKgPositionId").AutoIncrementSeed = 1
            Else
                dsSys.Tables("CoreTypeKgPosition").Columns("CoreTypeKgPositionId").AutoIncrementSeed = dsSys.Tables("CoreTypeKgPosition").Rows(dsSys.Tables("CoreTypeKgPosition").Rows.Count - 1).Item("CoreTypeKgPositionId") + 1
            End If

            'CoreTypes
            str = "SELECT CoreTypeId,CoreName FROM CoreTypes"
            cmd = oleCnn.CreateCommand()
            With cmd
                .CommandText = str
                .CommandType = CommandType.Text
            End With
            da = New OleDbDataAdapter(cmd)
            da.Fill(dsSys, "CoreTypes")
            da.FillSchema(dsSys.Tables("CoreTypes"), SchemaType.Mapped)
            'Устанавливаем начальное значание инкремента
            If dsSys.Tables("CoreTypes").Rows.Count = 0 Then
                dsSys.Tables("CoreTypes").Columns("CoreTypeId").AutoIncrementSeed = 1
            Else
                dsSys.Tables("CoreTypes").Columns("CoreTypeId").AutoIncrementSeed = dsSys.Tables("CoreTypes").Rows(dsSys.Tables("CoreTypes").Rows.Count - 1).Item("CoreTypeId") + 1
            End If

            'KgTypes
            str = "SELECT KgTypeId,KgName FROM KgTypes"
            cmd = oleCnn.CreateCommand()
            With cmd
                .CommandText = str
                .CommandType = CommandType.Text
            End With
            da = New OleDbDataAdapter(cmd)
            da.Fill(dsSys, "KgTypes")
            da.FillSchema(dsSys.Tables("KgTypes"), SchemaType.Mapped)
            'Устанавливаем начальное значание инкремента
            If dsSys.Tables("KgTypes").Rows.Count = 0 Then
                dsSys.Tables("KgTypes").Columns("KgTypeId").AutoIncrementSeed = 1
            Else
                dsSys.Tables("KgTypes").Columns("KgTypeId").AutoIncrementSeed = dsSys.Tables("KgTypes").Rows(dsSys.Tables("KgTypes").Rows.Count - 1).Item("KgTypeId") + 1
            End If

            'ActionDetails
            str = "SELECT ActionDetailId,CoreTypeId,ActionTypeId,Details FROM ActionDetails"
            cmd = oleCnn.CreateCommand()
            With cmd
                .CommandText = str
                .CommandType = CommandType.Text
            End With
            da = New OleDbDataAdapter(cmd)
            da.Fill(dsSys, "ActionDetails")
            da.FillSchema(dsSys.Tables("ActionDetails"), SchemaType.Mapped)
            'Устанавливаем начальное значание инкремента
            If dsSys.Tables("ActionDetails").Rows.Count = 0 Then
                dsSys.Tables("ActionDetails").Columns("ActionDetailId").AutoIncrementSeed = 1
            Else
                dsSys.Tables("ActionDetails").Columns("ActionDetailId").AutoIncrementSeed = dsSys.Tables("ActionDetails").Rows(dsSys.Tables("ActionDetails").Rows.Count - 1).Item("ActionDetailId") + 1
            End If

            'MovedKg
            str = "SELECT MovedKgId,ActionDetailId,KgTypeId FROM MovedKg"
            cmd = oleCnn.CreateCommand()
            With cmd
                .CommandText = str
                .CommandType = CommandType.Text
            End With
            da = New OleDbDataAdapter(cmd)
            da.Fill(dsSys, "MovedKg")
            da.FillSchema(dsSys.Tables("MovedKg"), SchemaType.Mapped)
            'Устанавливаем начальное значание инкремента
            If dsSys.Tables("MovedKg").Rows.Count = 0 Then
                dsSys.Tables("MovedKg").Columns("MovedKgId").AutoIncrementSeed = 1
            Else
                dsSys.Tables("MovedKg").Columns("MovedKgId").AutoIncrementSeed = dsSys.Tables("MovedKg").Rows(dsSys.Tables("MovedKg").Rows.Count - 1).Item("MovedKgId") + 1
            End If


            'Устанавливаем связи между таблицами
            Dim pCol, cCol As DataColumn
            Dim rel As DataRelation
            Dim fkc As ForeignKeyConstraint
            Dim strRelationName As String

            '1. CoreTypes->CoreTypeKgPosition
            pCol = dsSys.Tables("CoreTypes").Columns("CoreTypeId")
            cCol = dsSys.Tables("CoreTypeKgPosition").Columns("CoreTypeId")

            strRelationName = pCol.Table.TableName.ToString + "_" + cCol.Table.TableName.ToString

            fkc = New ForeignKeyConstraint(pCol, cCol)
            fkc.DeleteRule = Rule.Cascade
            fkc.UpdateRule = Rule.Cascade
            fkc.AcceptRejectRule = AcceptRejectRule.Cascade

            cCol.Table.Constraints.Add(fkc)

            rel = New DataRelation(strRelationName, pCol, cCol)
            dsSys.Relations.Add(rel)

            '2. KgTypes->CoreTypeKgPosition
            pCol = dsSys.Tables("KgTypes").Columns("KgTypeId")
            cCol = dsSys.Tables("CoreTypeKgPosition").Columns("KgTypeId")

            strRelationName = pCol.Table.TableName.ToString + "_" + cCol.Table.TableName.ToString

            fkc = New ForeignKeyConstraint(pCol, cCol)
            fkc.DeleteRule = Rule.Cascade
            fkc.UpdateRule = Rule.Cascade
            fkc.AcceptRejectRule = AcceptRejectRule.Cascade

            cCol.Table.Constraints.Add(fkc)

            rel = New DataRelation(strRelationName, pCol, cCol)
            dsSys.Relations.Add(rel)

            '3. KgTypes->MovedKg
            pCol = dsSys.Tables("KgTypes").Columns("KgTypeId")
            cCol = dsSys.Tables("MovedKg").Columns("KgTypeId")

            strRelationName = pCol.Table.TableName.ToString + "_" + cCol.Table.TableName.ToString

            fkc = New ForeignKeyConstraint(pCol, cCol)
            fkc.DeleteRule = Rule.Cascade
            fkc.UpdateRule = Rule.Cascade
            fkc.AcceptRejectRule = AcceptRejectRule.Cascade

            cCol.Table.Constraints.Add(fkc)

            rel = New DataRelation(strRelationName, pCol, cCol)
            dsSys.Relations.Add(rel)

            '4. CoreTypes->ActionDetails
            pCol = dsSys.Tables("CoreTypes").Columns("CoreTypeId")
            cCol = dsSys.Tables("ActionDetails").Columns("CoreTypeId")

            strRelationName = pCol.Table.TableName.ToString + "_" + cCol.Table.TableName.ToString

            fkc = New ForeignKeyConstraint(pCol, cCol)
            fkc.DeleteRule = Rule.Cascade
            fkc.UpdateRule = Rule.Cascade
            fkc.AcceptRejectRule = AcceptRejectRule.Cascade

            cCol.Table.Constraints.Add(fkc)

            rel = New DataRelation(strRelationName, pCol, cCol)
            dsSys.Relations.Add(rel)

            '5. ActionTypes->ActionDetails
            pCol = dsSys.Tables("ActionTypes").Columns("ActionTypeId")
            cCol = dsSys.Tables("ActionDetails").Columns("ActionTypeId")

            strRelationName = pCol.Table.TableName.ToString + "_" + cCol.Table.TableName.ToString

            fkc = New ForeignKeyConstraint(pCol, cCol)
            fkc.DeleteRule = Rule.Cascade
            fkc.UpdateRule = Rule.Cascade
            fkc.AcceptRejectRule = AcceptRejectRule.Cascade

            cCol.Table.Constraints.Add(fkc)

            rel = New DataRelation(strRelationName, pCol, cCol)
            dsSys.Relations.Add(rel)

            '6. ActionDetails->MovedKg
            pCol = dsSys.Tables("ActionDetails").Columns("ActionDetailId")
            cCol = dsSys.Tables("MovedKg").Columns("ActionDetailId")

            strRelationName = pCol.Table.TableName.ToString + "_" + cCol.Table.TableName.ToString

            fkc = New ForeignKeyConstraint(pCol, cCol)
            fkc.DeleteRule = Rule.Cascade
            fkc.UpdateRule = Rule.Cascade
            fkc.AcceptRejectRule = AcceptRejectRule.Cascade

            cCol.Table.Constraints.Add(fkc)

            rel = New DataRelation(strRelationName, pCol, cCol)
            dsSys.Relations.Add(rel)

            Return True
        Catch ex As Exception

            Return False
        Finally
            str = Nothing
            cmd = Nothing
            da = Nothing
            oleCnn.Close()
            oleCnn = Nothing
        End Try
    End Function
    ''' <summary>
    ''' Функция создает новую рабочую БД Access по адресу, хранящемуся в strWorkPath
    ''' </summary>
    ''' <returns>true/false - БД создана успешно/Не удалось создать БД</returns>
    ''' <remarks></remarks>
    Public Function prCreateNewDb() As Boolean
        Dim adoxCat As New ADOX.Catalog
        Dim tbl As ADOX.Table
        Dim col As ADOX.Column

        Try
            'Создали пустую БД
            adoxCat.Create("Provider='Microsoft.Jet.OLEDB.4.0'; Data Source= " + strWorkPath + ";")

            'Создаем 4 таблицы в БД
            tbl = New ADOX.Table
            tbl.Name = "ContinuousData"
            adoxCat.Tables.Append(tbl)

            tbl = New ADOX.Table
            tbl.Name = "CvrData"
            adoxCat.Tables.Append(tbl)

            tbl = New ADOX.Table
            tbl.Name = "KgData"
            adoxCat.Tables.Append(tbl)

            tbl = New ADOX.Table
            tbl.Name = "CoreType"
            adoxCat.Tables.Append(tbl)

            'Добавляем столбцы в таблицы 
            'ContinuousData
            col = New ADOX.Column
            With col
                .ParentCatalog = adoxCat
                .Name = "ContinuousDataId"
                .Type = DataTypeEnum.adInteger
                .Properties("AutoIncrement").Value = True
                .Properties("Nullable").Value = False
            End With
            adoxCat.Tables("ContinuousData").Columns.Append(col, ADOX.DataTypeEnum.adInteger)
            adoxCat.Tables("ContinuousData").Columns.Append("Created", ADOX.DataTypeEnum.adDate)
            adoxCat.Tables("ContinuousData").Columns.Append("Ro", ADOX.DataTypeEnum.adDouble)
            adoxCat.Tables("ContinuousData").Columns.Append("I", ADOX.DataTypeEnum.adDouble)

            'CvrData
            col = New ADOX.Column
            With col
                .ParentCatalog = adoxCat
                .Name = "CvrDataId"
                .Type = DataTypeEnum.adInteger
                .Properties("AutoIncrement").Value = True
                .Properties("Nullable").Value = False
            End With
            adoxCat.Tables("CvrData").Columns.Append(col, ADOX.DataTypeEnum.adInteger)
            adoxCat.Tables("CvrData").Columns.Append("StartRec", ADOX.DataTypeEnum.adDate)
            adoxCat.Tables("CvrData").Columns.Append("StopRec", ADOX.DataTypeEnum.adDate)
            adoxCat.Tables("CvrData").Columns.Append("SampleCount", ADOX.DataTypeEnum.adInteger)
            adoxCat.Tables("CvrData").Columns.Append("RoAngle", ADOX.DataTypeEnum.adDouble)
            adoxCat.Tables("CvrData").Columns.Append("RoStop", ADOX.DataTypeEnum.adDouble)
            adoxCat.Tables("CvrData").Columns.Append("I", ADOX.DataTypeEnum.adDouble)
            adoxCat.Tables("CvrData").Columns.Append("T", ADOX.DataTypeEnum.adDouble)
            adoxCat.Tables("CvrData").Columns.Append("N", ADOX.DataTypeEnum.adDouble)
            adoxCat.Tables("CvrData").Columns.Append("P", ADOX.DataTypeEnum.adDouble)
            adoxCat.Tables("CvrData").Columns.Append("NfiNo", ADOX.DataTypeEnum.adInteger)
            adoxCat.Tables("CvrData").Columns.Append("ActionTypeId", ADOX.DataTypeEnum.adInteger)
            adoxCat.Tables("CvrData").Columns.Append("ActionDetailId", ADOX.DataTypeEnum.adInteger)
            adoxCat.Tables("CvrData").Keys.Append("PrimaryKey", KeyTypeEnum.adKeyPrimary, "CvrDataId")

            'KgData
            col = New ADOX.Column
            With col
                .ParentCatalog = adoxCat
                .Name = "KgDataId"
                .Type = DataTypeEnum.adInteger
                .Properties("AutoIncrement").Value = True
                .Properties("Nullable").Value = False
            End With
            adoxCat.Tables("KgData").Columns.Append(col, ADOX.DataTypeEnum.adInteger)
            adoxCat.Tables("KgData").Columns.Append("CvrDataId", ADOX.DataTypeEnum.adInteger)
            adoxCat.Tables("KgData").Columns.Append("KgTypeId", ADOX.DataTypeEnum.adInteger)
            adoxCat.Tables("KgData").Columns.Append("KgValue", ADOX.DataTypeEnum.adVarWChar)
            adoxCat.Tables("KgData").Keys.Append("PrimaryKey", KeyTypeEnum.adKeyPrimary, "KgDataId")

            'ExterCoreType
            adoxCat.Tables("CoreType").Columns.Append("CoreTypeId", ADOX.DataTypeEnum.adInteger)

            'создаем ключи
            Dim kyForeign As New ADOX.Key
            kyForeign.Name = "CustOrder" ' Дадим ему имя
            kyForeign.Type = KeyTypeEnum.adKeyForeign ' Установим тип
            kyForeign.RelatedTable = "CvrData"
            kyForeign.Columns.Append("CvrDataId")
            kyForeign.Columns("CvrDataId").RelatedColumn = "CvrDataId"
            kyForeign.UpdateRule = RuleEnum.adRICascade
            kyForeign.DeleteRule = RuleEnum.adRICascade
            adoxCat.Tables("KgData").Keys.Append(kyForeign)

            Return True
        Catch ex As Exception

            Return False
        Finally

            col = Nothing
            tbl = Nothing
            adoxCat.ActiveConnection = Nothing
            adoxCat = Nothing
        End Try
    End Function
    ''' <summary>
    ''' Функция инициирует рабочий DataSet
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function prInitWorkDataSet() As Boolean
        Dim str As String
        Dim cmd As OleDbCommand
        Dim da As OleDbDataAdapter

        Dim oleCnn As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + strWorkPath + ";")

        Try
            ds = New DataSet 'Очищаем DataSet

            'CvrData
            str = "SELECT CvrDataId,StartRec,StopRec,SampleCount,RoAngle,RoStop,I,T,N,P,NfiNo,ActionTypeId,ActionDetailId FROM CvrData"
            cmd = oleCnn.CreateCommand()
            With cmd
                .CommandText = str
                .CommandType = CommandType.Text
            End With
            da = New OleDbDataAdapter(cmd)
            da.Fill(ds, "CvrData")
            da.FillSchema(ds.Tables("CvrData"), SchemaType.Mapped)
            'Устанавливаем начальное значание инкремента
            If ds.Tables("CvrData").Rows.Count = 0 Then
                ds.Tables("CvrData").Columns("CvrDataId").AutoIncrementSeed = 0
            Else
                ds.Tables("CvrData").Columns("CvrDataId").AutoIncrementSeed = ds.Tables("CvrData").Rows(ds.Tables("CvrData").Rows.Count - 1).Item("CvrDataId") + 1
            End If

            'KgData
            str = "SELECT KgDataId,CvrDataId,KgTypeId,KgValue FROM KgData"
            cmd = oleCnn.CreateCommand()
            With cmd
                .CommandText = str
                .CommandType = CommandType.Text
            End With
            da = New OleDbDataAdapter(cmd)
            da.Fill(ds, "KgData")
            da.FillSchema(ds.Tables("KgData"), SchemaType.Mapped)
            'Устанавливаем начальное значание инкремента
            If ds.Tables("KgData").Rows.Count = 0 Then
                ds.Tables("KgData").Columns("KgDataId").AutoIncrementSeed = 1
            Else
                ds.Tables("KgData").Columns("KgDataId").AutoIncrementSeed = ds.Tables("KgData").Rows(ds.Tables("KgData").Rows.Count - 1).Item("KgDataId") + 1
            End If

            'CoreType
            str = "SELECT CoreTypeId FROM CoreType"
            cmd = oleCnn.CreateCommand()
            With cmd
                .CommandText = str
                .CommandType = CommandType.Text
            End With
            da = New OleDbDataAdapter(cmd)
            da.Fill(ds, "CoreType")
            da.FillSchema(ds.Tables("CoreType"), SchemaType.Mapped)


            'Устанавливаем связи между таблицами
            Dim pCol, cCol As DataColumn
            'CvrData->KgData
            pCol = ds.Tables("CvrData").Columns("CvrDataId")
            cCol = ds.Tables("KgData").Columns("CvrDataId")

            Dim rel As DataRelation
            Dim fkc As ForeignKeyConstraint
            Dim strRelationName As String

            strRelationName = pCol.Table.TableName.ToString + "_" + cCol.Table.TableName.ToString

            fkc = New ForeignKeyConstraint(pCol, cCol)
            fkc.DeleteRule = Rule.Cascade
            fkc.UpdateRule = Rule.Cascade
            fkc.AcceptRejectRule = AcceptRejectRule.Cascade

            cCol.Table.Constraints.Add(fkc)

            rel = New DataRelation(strRelationName, pCol, cCol)
            ds.Relations.Add(rel)

            Return True
        Catch ex As Exception

            Return False
        Finally

            str = Nothing
            cmd = Nothing
            da = Nothing
            oleCnn.Close()
            oleCnn = Nothing
        End Try
    End Function
    ''' <summary>
    ''' Функция добавляет в рабочий DataSet таблицу ContinuousData
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function prAddContinuousDataToWorkDataSet() As Boolean
        Dim str As String
        Dim cmd As OleDbCommand
        Dim da As OleDbDataAdapter

        Dim oleCnn As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + strWorkPath + ";")

        Try
            'ContinuousData
            str = "SELECT ContinuousDataId,Created,Ro,I FROM ContinuousData"
            cmd = oleCnn.CreateCommand()
            With cmd
                .CommandText = str
                .CommandType = CommandType.Text
            End With
            da = New OleDbDataAdapter(cmd)
            da.Fill(ds, "ContinuousData")
            da.FillSchema(ds.Tables("ContinuousData"), SchemaType.Mapped)

            Return True
        Catch ex As Exception

            Return False
        Finally

            str = Nothing
            cmd = Nothing
            da = Nothing
            oleCnn.Close()
            oleCnn = Nothing
        End Try
    End Function

    ''' <summary>
    ''' Функция вносит изменения в талицу рабочей БД Access
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function UpdateWorkTable(ByVal dtName As String) As Boolean
        Dim str As String
        Dim cmd As OleDbCommand
        Dim da As OleDbDataAdapter

        Dim oleCnn As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + strWorkPath + ";")
        Try

            str = "Select * From " + dtName
            cmd = oleCnn.CreateCommand()
            cmd.CommandText = str

            da = New OleDbDataAdapter
            da.SelectCommand = cmd

            'автоматически генерируем команды для операций update, insert и delete
            Dim cmd_builder As New OleDbCommandBuilder(da)

            da.DeleteCommand = cmd_builder.GetDeleteCommand()
            da.UpdateCommand = cmd_builder.GetUpdateCommand()
            da.InsertCommand = cmd_builder.GetInsertCommand()

            da.Update(ds.Tables(dtName))


            Return True
        Catch ex As Exception
            Return False

        Finally
            str = Nothing
            cmd = Nothing
            da = Nothing
            oleCnn = Nothing
        End Try
    End Function
    ''' <summary>
    ''' Функция вносит изменения в талицу системной БД Access
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function UpdateSystemTable(ByVal dtName As String) As Boolean
        Dim str As String
        Dim cmd As OleDbCommand
        Dim da As OleDbDataAdapter

        Dim oleCnn As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + strSystemPath + ";")
        Try

            str = "Select * From " + dtName
            cmd = oleCnn.CreateCommand()
            cmd.CommandText = str

            da = New OleDbDataAdapter
            da.SelectCommand = cmd

            'автоматически генерируем команды для операций update, insert и delete
            Dim cmd_builder As New OleDbCommandBuilder(da)

            da.DeleteCommand = cmd_builder.GetDeleteCommand()
            da.UpdateCommand = cmd_builder.GetUpdateCommand()
            da.InsertCommand = cmd_builder.GetInsertCommand()

            da.Update(ds.Tables(dtName))


            Return True
        Catch ex As Exception
            Return False

        Finally
            str = Nothing
            cmd = Nothing
            da = Nothing
            oleCnn = Nothing
        End Try
    End Function

    ''' <summary>
    ''' Запросы к рабочей БД не возвращаюшие записей 
    ''' </summary>
    ''' <param name="str">SQL запрос к БД</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ExecuteNonQueryToWorkDb(ByVal str As String) As Boolean
        Dim cmd As OleDbCommand
        Dim oleCnn As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + strWorkPath + ";")

        Try
            oleCnn.Open()
            cmd = oleCnn.CreateCommand()
            cmd.CommandText = str
            cmd.ExecuteNonQuery()

            Return True
        Catch ex As Exception
            Return False

        Finally
            str = Nothing
            cmd = Nothing
            oleCnn.Close()
            oleCnn = Nothing
        End Try

    End Function
    ''' <summary>
    ''' Запросы к системной БД не возвращаюшие записей 
    ''' </summary>
    ''' <param name="str">SQL запрос к БД</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ExecuteNonQueryToSysDb(ByVal str As String) As Boolean
        Dim cmd As OleDbCommand
        Dim oleCnn As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + strWorkPath + ";")

        Try
            oleCnn.Open()
            cmd = oleCnn.CreateCommand()
            cmd.CommandText = str
            cmd.ExecuteNonQuery()

            Return True
        Catch ex As Exception
            Return False
        Finally
            str = Nothing
            cmd = Nothing
            oleCnn.Close()
            oleCnn = Nothing
        End Try

    End Function


End Class
