Imports System.Globalization

Public Class frmCalculation
    Private intCoreTypeId As Integer 'Номер проекта а.з.

    Private strPathToExcelWorkBook As String

    Private dw As New clsDataWorks
    Private dsWork, dsSystem As DataSet
    Private sngTCold, sngdT, sngXMajorUnit, sngXMinorUnit As Single 'Погрешность Нкг и Т. Сетка графиков

    'Процедура урезает память, реально «отъедаемую» нашим приложением
    <DllImport("kernel32.dll")> _
    Public Shared Function SetProcessWorkingSetSize(ByVal handle As IntPtr, ByVal minimumWorkingSetSize As Integer, _
                                                    ByVal maximumWorkingSetSize As Integer) As Boolean
    End Function

    Public Sub New()
        InitializeComponent()

        'Урезаем до необходимого минимума оперативку, ввыделяемую на наше приложение
        SetProcessWorkingSetSize(System.Diagnostics.Process.GetCurrentProcess().Handle, -1, -1)


        Me.Icon = My.Resources.Radiation 'Изменяем иконку
        Call subGetDataFromRegistry()

        dsSystem = dw.GetSystemDataSet 'Запросили системный DataSet

        Me.ttxt_dT.Text = CStr(sngdT)
        Me.ttxt_TCold.Text = CStr(sngTCold)

        Me.ttxtXMinorUnit.Text = CStr(sngXMinorUnit)
        Me.ttxtXMajorUnit.Text = CStr(sngXMajorUnit)

    End Sub
    Private Sub frmCalculation_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Call subSetDataToRegistry()
    End Sub


#Region "Чтение/Запись данных в реестр"

    Private Sub subSetDataToRegistry()
        Dim key As RegistryKey
        key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("CVR-10_PhysNet_OKBM") 'Запись данных в реестр

        key.SetValue("dH", sngTCold)
        key.SetValue("dT", sngdT)
        key.SetValue("XMajorUnit", sngXMajorUnit)
        key.SetValue("XMinorUnit", sngXMinorUnit)
    End Sub
    Private Sub subGetDataFromRegistry()
        Dim key As Microsoft.Win32.RegistryKey
        key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("CVR-10_PhysNet_OKBM") 'Настройки соединения с SQL
        If key Is Nothing Then
            sngTCold = 5
            sngdT = 2
            sngXMajorUnit = 1
            sngXMinorUnit = 10
        Else
            sngTCold = CType(key.GetValue("dH"), Single)
            sngdT = CType(key.GetValue("dT"), Single)
            sngXMajorUnit = CType(key.GetValue("XMajorUnit"), Single)
            sngXMinorUnit = CType(key.GetValue("XMinorUnit"), Single)
        End If
    End Sub

#End Region

#Region "Подключение БД Access, вспомогательные функции"
    'Открыть базу данных Access
    Private Sub tbtnDbConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbtnDbConnect.Click
        Me.ofdOpenDb.ShowDialog()
    End Sub
    Private Sub tmnuDbConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmnuDbConnect.Click
        Me.ofdOpenDb.ShowDialog()
    End Sub
    Private Sub ofdOpenDb_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ofdOpenDb.FileOk


        dw.PathToWorkDb = sender.FileName 'Передаем в clsDataWorks путь для создания рабочей БД Access

        'Открываем существующую БД Access
        If Not dw.prInitWorkDataSet() Or Not dw.prAddContinuousDataToWorkDataSet Then
            MessageBox.Show("Не удалось открыть БД Access (Unable to open Access Database)", "Ошибка базы данных (Database error)", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        dsWork = dw.GetWorkDataSet 'Возвращаем DataSet содержащие информацию о рабочей БД Access

        intCoreTypeId = dsWork.Tables("CoreType").Rows(0).Item(0) 'Устанавливаем проект а.з.

        'Процедура открытия сущ-ей БД
        Call subOpenDb()


        'Узнаем название выбранного проекта а.з.
        Dim dv As New DataView
        With dv
            .Table = dsSystem.Tables("CoreTypes")
            .RowFilter = "CoreTypeId=" + CStr(intCoreTypeId)
        End With
        Me.lblCoreType.Text = dv.Item(0).Item(1)

        'Устанавливаем количества записей в таблицах CvrData и ContinuousData
        Me.lblContDataRecCount.Text = Me.dsWork.Tables("ContinuousData").Rows.Count
        Me.lblCvrDataRecCount.Text = Me.dsWork.Tables("CvrData").Rows.Count

        'Устанавливаем время первой и последней записей в таблицах CvrData и ContinuousData
        If Me.dsWork.Tables("ContinuousData").Rows.Count = 0 Then
            Me.lblContDataTStart.Text = "-"
            Me.lblContDataTStop.Text = "-"
        Else
            Me.lblContDataTStart.Text = Me.dsWork.Tables("ContinuousData").Rows(0).Item("Created")
            Me.lblContDataTStop.Text = Me.dsWork.Tables("ContinuousData").Rows(Me.dsWork.Tables("ContinuousData").Rows.Count - 1).Item("Created")
        End If

        If Me.dsWork.Tables("CvrData").Rows.Count = 0 Then
            Me.lblCvrDataTStart.Text = "-"
            Me.lblCvrDataTStop.Text = "-"
        Else
            Me.lblCvrDataTStart.Text = Me.dsWork.Tables("CvrData").Rows(0).Item("StartRec")
            Me.lblCvrDataTStop.Text = Me.dsWork.Tables("CvrData").Rows(Me.dsWork.Tables("CvrData").Rows.Count - 1).Item("StopRec")
        End If

        'Выравниваем Label-ы
        Dim p As Point
        p.Y = Me.lblCvrDataTStart.Location.Y
        p.X = CInt(Me.Label7.Location.X + Me.Label7.Width * 0.5 - Me.lblCvrDataTStart.Width * 0.5)
        Me.lblCvrDataTStart.Location = p

        p.Y = Me.lblCvrDataTStop.Location.Y
        p.X = CInt(Me.Label7.Location.X + Me.Label7.Width * 0.5 - Me.lblCvrDataTStop.Width * 0.5)
        Me.lblCvrDataTStop.Location = p

        p.Y = Me.lblContDataTStart.Location.Y
        p.X = CInt(Me.Label6.Location.X + Me.Label6.Width * 0.5 - Me.lblContDataTStart.Width * 0.5)
        Me.lblContDataTStart.Location = p

        p.Y = Me.lblContDataTStop.Location.Y
        p.X = CInt(Me.Label6.Location.X + Me.Label6.Width * 0.5 - Me.lblContDataTStop.Width * 0.5)
        Me.lblContDataTStop.Location = p


        Me.Text = "ЦВР-10 (Обработка результатов): " + sender.FileName

        Me.tmnuDbConnect.Enabled = False
        Me.tbtnDbConnect.Enabled = False
        Me.tbtnDbDisable.Enabled = True
        Me.tmnuDbDisable.Enabled = True
        Me.tbtnCalculate.Enabled = True
        Me.cmdCalculate.Enabled = True
    End Sub
    'Отключиться от БД Access
    Private Sub tbtnDbDisable_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbtnDbDisable.Click
        dsSystem = Nothing
        dsWork = Nothing

        Me.dgvAverageData.Columns.Clear() 'Очистили от данных DataGridView
        Me.dgvKgPosition.Columns.Clear()

        Me.tmnuDbConnect.Enabled = True
        Me.tbtnDbConnect.Enabled = True
        Me.tbtnDbDisable.Enabled = False
        Me.tmnuDbDisable.Enabled = False
        Me.tbtnCalculate.Enabled = False
        Me.cmdCalculate.Enabled = False

        Me.lblContDataRecCount.Text = "-"
        Me.lblCvrDataRecCount.Text = "-"
        Me.lblCoreType.Text = "-"
        Me.lblCvrDataTStart.Text = "-"
        Me.lblCvrDataTStop.Text = "-"
        Me.lblContDataTStart.Text = "-"
        Me.lblContDataTStop.Text = "-"
    End Sub
    Private Sub tmnuDbDisable_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmnuDbDisable.Click
        dsSystem = Nothing
        dsWork = Nothing

        Me.dgvAverageData.Columns.Clear() 'Очистили от данных DataGridView
        Me.dgvKgPosition.Columns.Clear()

        Me.tmnuDbConnect.Enabled = True
        Me.tbtnDbConnect.Enabled = True
        Me.tbtnDbDisable.Enabled = False
        Me.tmnuDbDisable.Enabled = False
        Me.tbtnCalculate.Enabled = False
        Me.cmdCalculate.Enabled = False

        Me.lblContDataRecCount.Text = "-"
        Me.lblCvrDataRecCount.Text = "-"
        Me.lblCoreType.Text = "-"
        Me.lblCvrDataTStart.Text = "-"
        Me.lblCvrDataTStop.Text = "-"
        Me.lblContDataTStart.Text = "-"
        Me.lblContDataTStop.Text = "-"
    End Sub

    'Процедура открытия сущ-ей БД
    Private Sub subOpenDb()
        'События, происходящие при изменении данных в рабочем DataSet-e
        AddHandler dsWork.Tables("CvrData").RowChanged, New DataRowChangeEventHandler(AddressOf CvrData_Row_Changed)
        AddHandler dsWork.Tables("KgData").RowChanged, New DataRowChangeEventHandler(AddressOf KgData_Row_Changed)
        'События, происходящие при удалении данных в рабочем DataSet-e
        AddHandler dsWork.Tables("CvrData").RowDeleted, New DataRowChangeEventHandler(AddressOf CvrData_Row_Deleted)

        'Инициируем структуру DataGridView
        Call InitCvrDataStructure()
        Call InitKgDataStructure()

        'Подключаем DataGridView к источникам данных
        With Me.dgvAverageData
            .DataSource = dsWork
            .DataMember = "CvrData"
        End With

        With Me.dgvKgPosition
            .DataSource = dsWork
            .DataMember = "CvrData.CvrData_KgData"
        End With
    End Sub
    'Изменение/удаление данных из таблиц рабочего DataSet (dsWork)
    Private Sub CvrData_Row_Changed()
        Me.Cursor = Cursors.WaitCursor
        If Not dw.UpdateWorkTable("CvrData") Then MessageBox.Show("Не удалось изменить данные в таблице CvrData БД Access", "Ошибка базы данных (Database error)", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub KgData_Row_Changed()
        Me.Cursor = Cursors.WaitCursor
        If Not dw.UpdateWorkTable("KgData") Then MessageBox.Show("Не удалось изменить данные в таблице KgData БД Access", "Ошибка базы данных (Database error)", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub CvrData_Row_Deleted()
        Me.Cursor = Cursors.WaitCursor
        If Not dw.UpdateWorkTable("KgData") Then MessageBox.Show("Не удалось удалить данные из таблицы KgData БД Access", "Ошибка базы данных (Database error)", MessageBoxButtons.OK, MessageBoxIcon.Error)
        If Not dw.UpdateWorkTable("CvrData") Then MessageBox.Show("Не удалось удалить данные из таблицы CvrData БД Access", "Ошибка базы данных (Database error)", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Me.Cursor = Cursors.Default
    End Sub

    'Инициируем структуру DataGridView
    Private Sub InitCvrDataStructure()
        Dim c1, c2, c3, c4, c5, c6, c7, c8, c9, c10, c11 As DataGridViewTextBoxColumn
        Dim c12, c13 As DataGridViewComboBoxColumn

        c1 = New DataGridViewTextBoxColumn
        With c1
            .HeaderText = "№"
            .Name = "CvrDataId"
            .DataPropertyName = "CvrDataId"
            .ReadOnly = True
            .Width = 20
            .Visible = True
        End With
        c2 = New DataGridViewTextBoxColumn
        With c2
            .HeaderText = "Начало записи (Start Time)"
            .Name = "StartRec"
            .DataPropertyName = "StartRec"
            .ReadOnly = False
            .Width = 100
        End With
        c3 = New DataGridViewTextBoxColumn
        With c3
            .HeaderText = "Конец записи (End Time)"
            .Name = "StopRec"
            .DataPropertyName = "StopRec"
            .ReadOnly = False
            .Width = 100
        End With
        c4 = New DataGridViewTextBoxColumn
        With c4
            .HeaderText = "Отсч. (Count)"
            .Name = "SampleCount"
            .DataPropertyName = "SampleCount"
            .ReadOnly = False
            .Width = 40
        End With
        c5 = New DataGridViewTextBoxColumn
        With c5
            .HeaderText = "RoAngle"
            .Name = "RoAngle"
            .DataPropertyName = "RoAngle"
            .ReadOnly = False
            .DefaultCellStyle.Format = "#0.0###"
            .Visible = True
            .Width = 60
        End With
        c6 = New DataGridViewTextBoxColumn
        With c6
            .HeaderText = "Ro"
            .Name = "RoStop"
            .DataPropertyName = "RoStop"
            .DefaultCellStyle.Format = "#0.0###"
            .ReadOnly = False
            .Width = 60
        End With
        c7 = New DataGridViewTextBoxColumn
        With c7
            .HeaderText = "I,A"
            .Name = "I"
            .DataPropertyName = "I"
            .DefaultCellStyle.Format = "0.0## e-0"
            .ReadOnly = False
            .Width = 60
        End With
        c8 = New DataGridViewTextBoxColumn
        With c8
            .HeaderText = "T,°C"
            .Name = "T"
            .DataPropertyName = "T"
            .ReadOnly = False
            .Width = 40
        End With
        c9 = New DataGridViewTextBoxColumn
        With c9
            .HeaderText = "N,%"
            .Name = "N"
            .DataPropertyName = "N"
            .DefaultCellStyle.Format = "0.0 e-0"
            .ReadOnly = False
            .Width = 60
        End With
        c10 = New DataGridViewTextBoxColumn
        With c10
            .HeaderText = "P, MPa"
            .Name = "P"
            .DataPropertyName = "P"
            .DefaultCellStyle.Format = "##0.0##"
            .ReadOnly = False
            .Width = 60
        End With
        c11 = New DataGridViewTextBoxColumn
        With c11
            .HeaderText = "№ НФИ"
            .Name = "NfiNo"
            .DataPropertyName = "NfiNo"
            .ReadOnly = False
            .Width = 40
        End With
        c12 = New DataGridViewComboBoxColumn
        With c12
            .HeaderText = "Описание (Algorithm)"
            .Name = "ActionTypeId"
            .DataPropertyName = "ActionTypeId"
            .DataSource = dsSystem.Tables("ActionTypes")
            .ValueMember = "ActionTypeId"
            .DisplayMember = "Details"
            .FlatStyle = FlatStyle.Flat
            .Width = 200
            .ReadOnly = False
        End With

        Dim dv As New DataView
        With dv
            .Table = dsSystem.Tables("ActionDetails")
            .RowFilter = "CoreTypeId = '" + CStr(intCoreTypeId) + "'"
        End With

        c13 = New DataGridViewComboBoxColumn
        With c13
            .HeaderText = "Детали (Details)"
            .Name = "ActionDetailId"
            .DataPropertyName = "ActionDetailId"
            .DataSource = dv
            .ValueMember = "ActionDetailId"
            .DisplayMember = "Details"
            .FlatStyle = FlatStyle.Flat
            .Width = 100
            .ReadOnly = False
        End With

        With Me.dgvAverageData
            If .Columns.Count > 0 Then .Columns.Clear()
            .AutoGenerateColumns = False
            .Columns.AddRange(c1, c2, c3, c4, c5, c6, c7, c8, c9, c10, c11, c12, c13)
            .ColumnHeadersHeight = 20
        End With
    End Sub
    Private Sub InitKgDataStructure()
        Dim c1 As DataGridViewComboBoxColumn
        Dim c2 As DataGridViewTextBoxColumn

        c1 = New DataGridViewComboBoxColumn
        With c1
            .HeaderText = "РО КР (CG)"
            .Name = "KgTypeId"
            .DataPropertyName = "KgTypeId"
            .DataSource = dsSystem.Tables("KgTypes")
            .ValueMember = "KgTypeId"
            .DisplayMember = "KgName"
            .FlatStyle = FlatStyle.Flat
            .Width = 70
            .ReadOnly = True
        End With
        c2 = New DataGridViewTextBoxColumn
        With c2
            .HeaderText = "Положение РО КР     (CG Pos.)"
            .Name = "KgValue"
            .DataPropertyName = "KgValue"
            .ReadOnly = False
            .Width = 80
        End With

        With Me.dgvKgPosition
            If .Columns.Count > 0 Then .Columns.Clear()
            .AutoGenerateColumns = False
            .Columns.AddRange(c1, c2)
            .ColumnHeadersHeight = 20
        End With
    End Sub
#End Region

#Region "Обработка БД Access"
    Private Sub cmdCalculate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCalculate.Click
        Call subCalculate()
    End Sub
    Private Sub tbtnCalculate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbtnCalculate.Click
        Call subCalculate()
    End Sub

    Private Sub subCalculate()
        Me.Cursor = Cursors.WaitCursor 'Изменил вид курсора

        Dim arrAzVal() As Integer = {0, 1} 'Для расчета эфективностей стержней АЗ 

        Dim xl As New Excel.Application
        Dim xlSheet As Excel.Worksheet
        Dim xlRange As Excel.Range
        Dim xlChart As Excel.Chart
        Dim strSheetName As String 'Название листа книги Excel


        Me.lblStatus.Text = "Идет обработка ... 0%"
        With Me.tpbrExcelProcessing
            .Visible = True
            .Value = 0
            .ToolTipText = "Идет обработка ... 0%"
        End With

        xl.Visible = True 'False 'Устанавливает видимость книги Excel
        xl.Workbooks.Add() 'Добавили новую книгу Excel

        '
        With xl.Sheets(1)
            .Cells(1, 1).Value = "Эксперимент (Experiment)"
            .Cells(1, 2).Value = "dRo/dH (EP)"
            .Cells(1, 3).Value = "Нкрит. (Hcrit)"
        End With


        'Создаем набор листов в созданной книге Excel
        Dim qry = From cvr In dsWork.Tables("CvrData"), at In dsSystem.Tables("ActionTypes"), ad In dsSystem.Tables("ActionDetails") _
          Where cvr!ActionTypeId = at!ActionTypeId And cvr!ActionDetailId = ad!ActionDetailId _
          Select T = RoundTValue(cvr!T), NfiNo = cvr!NfiNo, _
                 ActionTypeId = cvr!ActionTypeId, ActionDetailId = cvr!ActionDetailId, ActionDetailsDetail = ad!Details _
          Group By ActionTypeId, ActionDetailId, NfiNo, T Into Group


        'Цикл по группам записей с одинаковыми T,°С; ActionTypeId и ActionDetailId.
        For i1 As Integer = 0 To qry.Count - 1
            Dim q = qry(i1).Group(0)
            strSheetName = "T=" + CStr(q.T) + "°С; № НФИ= " + CStr(q.NfiNo) + "; " + ExcelSheetName(q.ActionTypeId) + " (" + CStr(q.ActionDetailsDetail) + ")"

            'Создал новый лист Excel
            xlSheet = xl.Sheets.Add(After:=xl.Sheets(i1 + 1), Count:=1, Type:=Excel.XlSheetType.xlWorksheet)

            xlRange = xlSheet.Range("A1:N1") 'Выделили ячейки
            xlRange.Merge() 'Объединение ячеек

            With xlSheet
                .Cells(1, 1).Value = strSheetName
                With xlRange.Font 'Изменяем шрифт надписи
                    .Bold = True
                    .Name = "Times New Roman"
                    .Size = 14
                    .Strikethrough = False
                    .Superscript = False
                    .Subscript = False
                    .OutlineFont = False
                    .Shadow = False
                    .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
                End With

                .Cells(2, 1).Value = "№"
                .Cells(2, 2).Value = "Начало зааписи (Start Time)"
                .Cells(2, 3).Value = "Конец записи (End Time)"
                .Cells(2, 4).Value = "Отсчётов (Counts)"
                .Cells(2, 5).Value = "Н КГ (CG pos), мм"
                .Cells(2, 6).Value = "RoAngle"
                .Cells(2, 7).Value = "RoStop"
                .Cells(2, 8).Value = "I, А"
                .Cells(2, 9).Value = "T,°С"
                .Cells(2, 10).Value = "N,%"
                .Cells(2, 11).Value = "P,МПа"
                .Cells(2, 12).Value = "№ НФИ"
                .Cells(2, 13).Value = "Algorithm"
                .Cells(2, 14).Value = "Details"

                xlRange = xlSheet.Range("A2:N2")
                With xlRange.Font 'Изменяем шрифт надписи
                    .Bold = True
                    .Name = "Times New Roman"
                    .Size = 12
                    .Strikethrough = False
                    .Superscript = False
                    .Subscript = False
                    .OutlineFont = False
                    .Shadow = False
                    .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic 'xlAutomatic
                End With

            End With


            'Выборка из CvrData
            Dim qryCvrData = From cvr In dsWork.Tables("CvrData"), at In dsSystem.Tables("ActionTypes"), ad In dsSystem.Tables("ActionDetails") _
                   Where cvr!ActionTypeId = at!ActionTypeId And cvr!ActionDetailId = ad!ActionDetailId _
                         And cvr!ActionTypeId = q.ActionTypeId And cvr!ActionDetailId = q.ActionDetailId _
                         And cvr!NfiNo = q.NfiNo _
                         And cvr!T > (q.T - sngdT) And cvr!T < (q.T + sngdT) _
                   Select CvrDataId = cvr!CvrDataId, StartRec = cvr!StartRec, StopRec = cvr!StopRec, SampleCount = cvr!SampleCount, _
                          RoAngle = cvr!RoAngle, RoStop = cvr!RoStop, Curent = cvr!I, T = RoundTValue(cvr!T), N = cvr!N, P = cvr!P, _
                          NfiNo = cvr!NfiNo, ActionTypeId = cvr!ActionTypeId, ActionDetailId = cvr!ActionDetailId, ActionTypeDetail = at!Details, ActionDetailsDetail = ad!Details

            Dim intCvrDataCount As Integer = qryCvrData.Count
            Dim intKgCount As Integer = 0
            Dim intContDataCount As Integer = 0

            'Цикл по записям таблицы CvrData
            Static index As Integer = 1
            For i2 As Integer = 0 To intCvrDataCount - 1
                Dim qCvr = qryCvrData(i2)

                'Выборка перемещаемых КГ для выбранной строки в CvrData
                Dim qryMovedKg = From kgType In dsSystem.Tables("KgTypes"), kgMoved In dsSystem.Tables("MovedKg") _
                                 Where kgMoved!KgTypeId = kgType!KgTypeId And kgMoved!ActionDetailId = qCvr.ActionDetailId _
                                 Select KgTypeId = kgMoved!KgTypeId, KgName = kgType!KgName

                'Переносим в Excel данные о положении ПЕРЕМЕЩАЕМЫХ РО КР, 
                xlSheet.Cells(i2 + 3, 16).Value = "Нкг="

                intKgCount = qryMovedKg.Count - 1  'Количество ПЕРЕМЕЩАЕМЫХ РО КР

                'Цикл по ПЕРЕМЕЩАЕМЫМ в данном эксперименте группам КР
                If q.ActionTypeId = 1 Then
                    For i3 As Integer = 0 To intKgCount
                        Dim qMKg = qryMovedKg(i3)

                        Dim qryKgVal = From kgVal In dsWork.Tables("KgData") _
                                       Where kgVal!CvrDataId = qCvr.CvrDataId And kgVal!KgTypeId = qMKg.KgTypeId _
                                       Select KgData = kgVal!KgValue

                        xlSheet.Cells(i2 + 3, i3 + 17).Value = qryKgVal(0)
                        xlSheet.Cells(2, i3 + 17).Value = qMKg.KgName

                    Next 'Конец цикла по ПЕРЕМЕЩАЕМЫМ в данном эксперименте группам КР
                ElseIf q.ActionTypeId = 2 Then
                    xlSheet.Cells(i2 + 3, 17).Value = arrAzVal(i2)
                    intKgCount = 0
                End If

                'Переносим в Excel данные из таблицы CvrData
                With xlSheet
                    .Cells(i2 + 3, 1).Value = qCvr.CvrDataId
                    .Cells(i2 + 3, 2).Value = qCvr.StartRec
                    .Cells(i2 + 3, 3).Value = qCvr.StopRec
                    .Cells(i2 + 3, 4).Value = qCvr.SampleCount
                    .Cells(i2 + 3, 5).Value = "=СРЗНАЧ(RC[12]:RC[" + CStr(12 + intKgCount) + "])"
                    If q.T > sngTCold Then .Cells(i2 + 4 + intCvrDataCount, 1).Value = "=E" + CStr(i2 + 3) '.Cells(i2 + 3, 5).Value
                    .Cells(i2 + 3, 6).Value = qCvr.RoAngle
                    .Cells(i2 + 3, 7).Value = qCvr.RoStop
                    .Cells(i2 + 3, 8).Value = qCvr.Curent
                    .Cells(i2 + 3, 9).Value = qCvr.T
                    .Cells(i2 + 3, 10).Value = qCvr.N
                    .Cells(i2 + 3, 11).Value = qCvr.P
                    .Cells(i2 + 3, 12).Value = qCvr.NfiNo
                    .Cells(i2 + 3, 13).Value = qCvr.ActionTypeDetail
                    .Cells(i2 + 3, 14).Value = qCvr.ActionDetailsDetail

                    'Данные для построения линий съема усредненных данных 
                    .Cells(i2 + 4 + intCvrDataCount, 4).Value = "=ОКРУГЛ((C" + CStr(3 + i2) + "-B" + CStr(3 + i2) + ")*86400;0)"
                    .Cells(i2 + 4 + intCvrDataCount, 3).Value = "=G" + CStr(3 + i2)
                    .Cells(i2 + 4 + intCvrDataCount, 2).Value = "=C" + CStr(i2 + 4 + intCvrDataCount) + "-D" + CStr(i2 + 4 + intCvrDataCount) + "*F" + CStr(3 + i2)




                    If q.T > sngTCold Then 'Если температура эксперимента больше установленной пользователем холодной Т
                        If intCvrDataCount Mod 2 = 0 Then 'Если количество записей в intCvrDataCount четное(т.е. можем разбить на пары)
                            If index = 1 Then
                                index = 2
                            ElseIf index = 2 Then
                                .Cells(i2 + 3 + intCvrDataCount, 5).Value = "=(C" + CStr(2 + i2) + "+B" + CStr(3 + i2) + ")/2"
                                .Cells(i2 + 3 + intCvrDataCount, 6).Value = "=(E" + CStr(i2 + 3 + intCvrDataCount) + "-C" + CStr(2 + i2) + ")*86400*F" + CStr(2 + i2) + "+G" + CStr(2 + i2)

                                .Cells(i2 + 4 + intCvrDataCount, 6).Value = "=G" + CStr(3 + i2) + "-(C" + CStr(3 + i2) + "-E" + CStr(i2 + 3 + intCvrDataCount) + ")*86400*F" + CStr(3 + i2)

                                index = 1
                            End If
                        Else 'Если количество записей в intCvrDataCount нечетное
                            If Not i2 = intCvrDataCount - 1 Then 'Исключаем последнюю запись
                                If index = 1 Then
                                    index = 2
                                ElseIf index = 2 Then
                                    .Cells(i2 + 3 + intCvrDataCount, 5).Value = "=(C" + CStr(2 + i2) + "+B" + CStr(3 + i2) + ")/2"
                                    .Cells(i2 + 3 + intCvrDataCount, 6).Value = "=(E" + CStr(i2 + 3 + intCvrDataCount) + "-C" + CStr(2 + i2) + ")*86400*F" + CStr(2 + i2) + "+G" + CStr(2 + i2)

                                    .Cells(i2 + 4 + intCvrDataCount, 6).Value = "=G" + CStr(3 + i2) + "-(C" + CStr(3 + i2) + "-E" + CStr(i2 + 3 + intCvrDataCount) + ")*86400*F" + CStr(3 + i2)

                                    index = 1
                                End If
                            End If
                        End If
                    End If
                End With
            Next 'Конец цикла по записям таблицы CvrData

            'Изменяем формат ячейки с датой (отображение секунд)
            xlRange = xlSheet.Range("E" + CStr(intCvrDataCount + 3) + ":E" + CStr(2 * intCvrDataCount + 3))
            xlRange.NumberFormat = "ДД.ММ.ГГ ч:мм:сс"




            With xlSheet
                .Cells(3 + intCvrDataCount, 4).Value = "t,s"
                .Cells(3 + intCvrDataCount, 3).Value = "Ro Stop"
                .Cells(3 + intCvrDataCount, 2).Value = "Ro Start"

                'Действия при работе на горячем реакторе
                If q.T > sngTCold Then 'Если температура эксперимента больше установленной пользователем холодной Т

                    .Cells(3 + intCvrDataCount, 5).Value = "t приведенное"
                    .Cells(3 + intCvrDataCount, 6).Value = "Ro приведенное"

                    .Cells(4 + intCvrDataCount, 7).Value = "Наклон"
                    .Cells(4 + intCvrDataCount, 8).Value = "=НАКЛОН(F" + CStr(4 + intCvrDataCount) + ":F" + CStr(2 * intCvrDataCount + 3) + ";E3:E" + CStr(intCvrDataCount + 2) + ")"
                    .Cells(5 + intCvrDataCount, 7).Value = "Отрезок"
                    .Cells(5 + intCvrDataCount, 8).Value = "=ОТРЕЗОК(F" + CStr(4 + intCvrDataCount) + ":F" + CStr(2 * intCvrDataCount + 3) + ";E3:E" + CStr(intCvrDataCount + 2) + ")"

                    .Cells(4 + intCvrDataCount, 12).Value = "dRo/dH="
                    .Cells(4 + intCvrDataCount, 13).Value = "=ABS(H" + CStr(4 + intCvrDataCount) + "*640)"
                    .Cells(5 + intCvrDataCount, 12).Value = "Hкрит.="
                    .Cells(5 + intCvrDataCount, 13).Value = "=ABS(H" + CStr(5 + intCvrDataCount) + "/H" + CStr(4 + intCvrDataCount) + ")"


                Else 'Если температура эксперимента меньше установленной пользователем холодной Т
                    .Cells(4 + intCvrDataCount, 7).Value = "Наклон"
                    .Cells(4 + intCvrDataCount, 8).Value = "=НАКЛОН(G3:G" + CStr(intCvrDataCount + 2) + ";E3:E" + CStr(intCvrDataCount + 2) + ")"
                    .Cells(5 + intCvrDataCount, 7).Value = "Отрезок"
                    .Cells(5 + intCvrDataCount, 8).Value = "=ОТРЕЗОК(G3:G" + CStr(intCvrDataCount + 2) + ";E3:E" + CStr(intCvrDataCount + 2) + ")"

                    .Cells(4 + intCvrDataCount, 12).Value = "dRo/dH="
                    .Cells(4 + intCvrDataCount, 13).Value = "=ABS(H" + CStr(4 + intCvrDataCount) + "*640)"
                    .Cells(5 + intCvrDataCount, 12).Value = "Hкрит.="
                    .Cells(5 + intCvrDataCount, 13).Value = "=ABS(H" + CStr(5 + intCvrDataCount) + "/H" + CStr(4 + intCvrDataCount) + ")"
                End If
            End With

            'Изменяем формат ячейки с датой (отображение секунд)
            xlRange = xlSheet.Range("B3:C" + CStr(intCvrDataCount + 2))
            xlRange.NumberFormat = "ДД.ММ.ГГ ч:мм:сс"

            'Делаем рамку для данных
            xlRange = xlSheet.Range(xlSheet.Cells(4 + intCvrDataCount, 12), xlSheet.Cells(5 + intCvrDataCount, 13)) 'Выделили ячейки
            With xlRange.Borders(Excel.XlBordersIndex.xlEdgeLeft)
                .LineStyle = Excel.XlLineStyle.xlContinuous
                .Weight = Excel.XlBorderWeight.xlMedium
                .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
            End With
            With xlRange.Borders(Excel.XlBordersIndex.xlEdgeRight)
                .LineStyle = Excel.XlLineStyle.xlContinuous
                .Weight = Excel.XlBorderWeight.xlMedium
                .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
            End With
            With xlRange.Borders(Excel.XlBordersIndex.xlEdgeTop)
                .LineStyle = Excel.XlLineStyle.xlContinuous
                .Weight = Excel.XlBorderWeight.xlMedium
                .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
            End With
            With xlRange.Borders(Excel.XlBordersIndex.xlEdgeBottom)
                .LineStyle = Excel.XlLineStyle.xlContinuous
                .Weight = Excel.XlBorderWeight.xlMedium
                .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
            End With
            With xlRange.Borders(Excel.XlBordersIndex.xlInsideVertical)
                .LineStyle = Excel.XlLineStyle.xlContinuous
                .Weight = Excel.XlBorderWeight.xlThin
                .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
            End With
            With xlRange.Borders(Excel.XlBordersIndex.xlInsideHorizontal)
                .LineStyle = Excel.XlLineStyle.xlContinuous
                .Weight = Excel.XlBorderWeight.xlThin
                .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
            End With

            'Делаем рамку для данных
            xlRange = xlSheet.Range("A1:N" + CStr(intCvrDataCount + 2)) 'Выделили ячейки
            With xlRange.Borders(Excel.XlBordersIndex.xlEdgeLeft)
                .LineStyle = Excel.XlLineStyle.xlContinuous
                .Weight = Excel.XlBorderWeight.xlMedium
                .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
            End With
            With xlRange.Borders(Excel.XlBordersIndex.xlEdgeRight)
                .LineStyle = Excel.XlLineStyle.xlContinuous
                .Weight = Excel.XlBorderWeight.xlMedium
                .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
            End With
            With xlRange.Borders(Excel.XlBordersIndex.xlEdgeTop)
                .LineStyle = Excel.XlLineStyle.xlContinuous
                .Weight = Excel.XlBorderWeight.xlMedium
                .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
            End With
            With xlRange.Borders(Excel.XlBordersIndex.xlEdgeBottom)
                .LineStyle = Excel.XlLineStyle.xlContinuous
                .Weight = Excel.XlBorderWeight.xlMedium
                .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
            End With
            With xlRange.Borders(Excel.XlBordersIndex.xlInsideVertical)
                .LineStyle = Excel.XlLineStyle.xlContinuous
                .Weight = Excel.XlBorderWeight.xlThin
                .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
            End With
            With xlRange.Borders(Excel.XlBordersIndex.xlInsideHorizontal)
                .LineStyle = Excel.XlLineStyle.xlContinuous
                .Weight = Excel.XlBorderWeight.xlThin
                .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
            End With

            xlRange = xlSheet.Range("A1:A1") 'Выделили ячейки
            With xlRange 'Выравнивание текста по центру ячейки
                .HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter
                .VerticalAlignment = Excel.XlHAlign.xlHAlignCenter
            End With

            'Отображение статуса обработки
            Me.lblStatus.Text = "Идет обработка ... " + CStr(Math.Round(((100 / (qry.Count)) * (i1 + 1) - 0.5) * 0.3)) + "%"
            With Me.tpbrExcelProcessing
                .Visible = True
                .Value = Math.Round(((100 / (qry.Count)) * (i1 + 1) - 0.5) * 0.3)
                .ToolTipText = "Идет обработка ... " + CStr(Math.Round(((100 / (qry.Count)) * (i1 + 1) - 0.5) * 0.3)) + "%"
            End With


            '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            'Обработка непрерывных данных

            With xlSheet
                .Cells(2, 19 + intKgCount).Value = "Дата (Date)"
                .Cells(2, 20 + intKgCount).Value = "Ток (I)"
                .Cells(2, 21 + intKgCount).Value = "Реактивность (Ro)"
            End With

            'Выборка непрерывных данных по времени записи
            Dim dv As New DataView

            Dim s1, s2 As String

            Dim d1 As DateTime = DateAdd(DateInterval.Second, -10, qryCvrData(0).StartRec)
            Dim d2 As DateTime = DateAdd(DateInterval.Second, 10, qryCvrData(intCvrDataCount - 1).StopRec)


            s1 = d1.ToString("dd.MM.yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture)
            s2 = d2.ToString("dd.MM.yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture)

            dv.Table = dsWork.Tables("ContinuousData")



            With dv
                .Table = dsWork.Tables("ContinuousData")
                .RowFilter = String.Format(CultureInfo.InvariantCulture.DateTimeFormat, "[Created] > #{0}#  and [Created] < #{1}# ", DateAdd(DateInterval.Second, -10, qryCvrData(0).StartRec), DateAdd(DateInterval.Second, 10, qryCvrData(intCvrDataCount - 1).StopRec))

                '.RowFilter = String.Format("[Created] > #{0}#  and [Created] < #{1}# ", _
                '                            DateAdd(DateInterval.Second, -10, qryCvrData(0).StartRec), DateAdd(DateInterval.Second, 10, qryCvrData(intCvrDataCount - 1).StopRec))

                '.RowFilter = String.Format("[Created] > #{0}#  and [Created] < #{1}# ", s1, s2)

            End With


            If dv.Count = 0 Then
                dv.RowFilter = Nothing
                dv.RowFilter = String.Format("[Created] > #{0}#  and [Created] < #{1}# ", s1, s2)
            End If


            If dv.Count = 0 Then
                intContDataCount = 1
            Else
                intContDataCount = dv.Count

            End If

            xlRange = xlSheet.Range(xlSheet.Cells(3, 19 + intKgCount), xlSheet.Cells(intContDataCount + 3, 21 + intKgCount))

            Dim a(intContDataCount, 2) As Object

            Dim i As Long = 0
            For Each r As DataRowView In dv
                a(i, 0) = r.Item("Created")
                a(i, 1) = r.Item("I")
                a(i, 2) = r.Item("Ro")
                i = i + 1
            Next
            xlRange.FormulaArray = a 'Переносимм массив данных в Excel

            'Изменяем формат ячейки с датой (отображение секунд)
            xlRange = xlSheet.Range(xlSheet.Cells(3, 19 + intKgCount), xlSheet.Cells(intContDataCount + 3, 19 + intKgCount))
            xlRange.NumberFormat = "ДД.ММ.ГГ ч:мм:сс"

            xlSheet.Columns("A:AZ").EntireColumn.AutoFit() 'Автоподбор ширины ячеек


            '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            'Построение графиков

            '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~Лента самописца~~~~~~~~~~~~~~~~~~~~~~~~~~~~

            xlChart = xl.Charts.Add()
            With xlChart
                'Формируем набор данных для графика
                Dim rngGraph = xlSheet.Range(xlSheet.Cells(3, 19 + intKgCount), xlSheet.Cells(2 + intContDataCount, 19 + intKgCount))
                Dim rngField = xlSheet.Range(xlSheet.Cells(3, 21 + intKgCount), xlSheet.Cells(2 + intContDataCount, 21 + intKgCount))

                rngGraph = xl.Union(rngGraph, rngField)

                'Установили данные для графика
                .SetSourceData(Source:=rngGraph, PlotBy:=Excel.XlRowCol.xlColumns)

                'Настройка графика
                .ChartType = Excel.XlChartType.xlXYScatter 'Тип графика - точечная диаграмма
                .HasLegend = False 'Нет легенды

                With .PlotArea.Border 'Граница графика
                    .ColorIndex = 57 'Черный цвет линии 
                    .Weight = Excel.XlBorderWeight.xlThick 'Толстая линия
                    .LineStyle = Excel.XlLineStyle.xlContinuous 'Простая линия
                End With

                With .PlotArea.Interior
                    .ColorIndex = 2 'Белый фон графика
                    .PatternColorIndex = 1
                    .Pattern = Excel.XlPattern.xlPatternAutomatic
                End With

                'ПОКАЗЫВАЕТ ВСЕ ЛИНИИ СЕТКИ
                With .Axes(Excel.XlAxisType.xlCategory)

                    Dim dtFrom As Date = xlSheet.Cells(3, 19 + intKgCount).value
                    Dim dtTo As Date = xlSheet.Cells(2 + intContDataCount, 19 + intKgCount).value

                    dtTo = DateAdd(DateInterval.Minute, 1, dtTo)

                    dtFrom = New System.DateTime(dtFrom.Year, dtFrom.Month, dtFrom.Day, dtFrom.Hour, dtFrom.Minute, 0)
                    dtTo = New System.DateTime(dtTo.Year, dtTo.Month, dtTo.Day, dtTo.Hour, dtTo.Minute, 0)


                    .MinimumScale = dtFrom
                    .MaximumScale = dtTo
                    .MajorUnit = (1 / (24 * 60)) * sngXMajorUnit
                    .MinorUnit = (1 / (24 * 60 * 60)) * sngXMinorUnit

                    .TickLabels.NumberFormat = "Ч:мм" 'Формат подписей оси X

                    .HasMajorGridlines = True 'Показываем основные линии сетки
                    .HasMinorGridlines = True 'Показываем дополнительные линии сетки

                End With
                With .Axes(Excel.XlAxisType.xlValue)
                    .HasMajorGridlines = True 'Показываем основные линии сетки
                    .HasMinorGridlines = True 'Показываем дополнительные линии сетки

                    'Пересечение с другой осью в минимальном значении
                    .Crosses = Excel.XlAxisCrosses.xlAxisCrossesCustom
                    .CrossesAt = xlChart.Axes(Excel.XlAxisType.xlValue).MinimumScale
                End With

                'ИЗМЕНЕНИЕ ВИДА ДОПОЛНИТЕЛЬНЫХ СЕТОК
                With .Axes(Excel.XlAxisType.xlCategory).MinorGridlines.Border
                    .ColorIndex = 15
                    .Weight = Excel.XlBorderWeight.xlHairline
                    .LineStyle = Excel.XlLineStyle.xlDash
                End With
                With .Axes(Excel.XlAxisType.xlValue).MinorGridlines.Border
                    .ColorIndex = 15
                    .Weight = Excel.XlBorderWeight.xlHairline
                    .LineStyle = Excel.XlLineStyle.xlDash
                End With

                'Настройка отображения данных на графике
                With .SeriesCollection(1)
                    .MarkerBackgroundColorIndex = Excel.XlColorIndex.xlColorIndexNone
                    .MarkerForegroundColorIndex = 1
                    .MarkerStyle = Excel.XlMarkerStyle.xlMarkerStyleX
                    .Smooth = False
                    .MarkerSize = 3
                    .Shadow = False
                    With .Border
                        .ColorIndex = 1
                        .Weight = Excel.XlBorderWeight.xlHairline
                        .LineStyle = Excel.XlLineStyle.xlLineStyleNone
                    End With
                End With

                'Добавляем линии когда шла уследненная запись
                For i5 As Integer = 0 To intCvrDataCount - 1
                    With xlChart.SeriesCollection.NewSeries()
                        .XValues = "=" + CStr(xlSheet.Name) + "!R" + CStr(3 + i5) + "C" + CStr(2) + ":R" + CStr(3 + i5) + "C" + CStr(3)
                        .Values = "=" + CStr(xlSheet.Name) + "!R" + CStr(intCvrDataCount + 4 + i5) + "C" + CStr(2) + ":R" + CStr(intCvrDataCount + 4 + i5) + "C" + CStr(3)

                        .MarkerStyle = Excel.XlMarkerStyle.xlMarkerStyleCircle
                        .MarkerBackgroundColorIndex = 3
                        .MarkerForegroundColorIndex = 3
                        .Smooth = False
                        .MarkerSize = 3
                        .Shadow = False
                        With .Border
                            .ColorIndex = 3
                            .Weight = Excel.XlBorderWeight.xlThick
                            .LineStyle = Excel.XlLineStyle.xlContinuous
                        End With
                    End With
                Next

                'Расположение графика (На отдельном листе или на листе с данными)
                .Location(Where:=Excel.XlChartLocation.xlLocationAsObject, Name:=xlSheet.Name)

                With xlSheet.ChartObjects(1)
                    .Left = 10
                    .Top = 80
                    .Height = 250
                    .Width = 400
                End With


            End With


            '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~Ro(H)~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            xlChart = xl.Charts.Add()
            With xlChart
                'Настройка графика
                .ChartType = Excel.XlChartType.xlXYScatter 'Тип графика - точечная диаграмма
                .HasLegend = False 'Нет легенды

                Dim rngGraph As Excel.Range
                Dim rngField As Excel.Range

                If q.T > sngTCold Then 'Т эксперимента > Т хол

                    If intCvrDataCount Mod 2 = 0 Then 'Если количество записей в intCvrDataCount четное(т.е. можем разбить на пары)

                        'Формируем набор данных для графика
                        rngGraph = xlSheet.Range(xlSheet.Cells(4 + intCvrDataCount, 1), xlSheet.Cells(3 + 2 * intCvrDataCount, 1))
                        rngField = xlSheet.Range(xlSheet.Cells(4 + intCvrDataCount, 6), xlSheet.Cells(3 + 2 * intCvrDataCount, 6))

                        'rngGraph = xl.Union(rngGraph, rngField)
                        ''Установили данные для графика
                        '.SetSourceData(Source:=rngGraph, PlotBy:=Excel.XlRowCol.xlColumns)

                    Else
                        'Формируем набор данных для графика
                        rngGraph = xlSheet.Range(xlSheet.Cells(4 + intCvrDataCount, 1), xlSheet.Cells(2 + 2 * intCvrDataCount, 1))
                        rngField = xlSheet.Range(xlSheet.Cells(4 + intCvrDataCount, 6), xlSheet.Cells(2 + 2 * intCvrDataCount, 6))

                        'rngGraph = xl.Union(rngGraph, rngField)
                        ''Установили данные для графика
                        '.SetSourceData(Source:=rngGraph, PlotBy:=Excel.XlRowCol.xlColumns)

                    End If
                Else 'Т эксперимента < Т хол

                    'Формируем набор данных для графика
                    rngGraph = xlSheet.Range(xlSheet.Cells(3, 5), xlSheet.Cells(2 + intCvrDataCount, 5))
                    rngField = xlSheet.Range(xlSheet.Cells(3, 7), xlSheet.Cells(2 + intCvrDataCount, 7))

                End If

                rngGraph = xl.Union(rngGraph, rngField)

                'Установили данные для графика
                .SetSourceData(Source:=rngGraph, PlotBy:=Excel.XlRowCol.xlColumns)

                'Добавили линию тренда
                Dim tl = xlChart.SeriesCollection(1).Trendlines.Add
                With tl
                    .Type = Excel.XlTrendlineType.xlLinear
                    .Forward = 1
                    .Backward = 1
                    .DisplayEquation = True
                    .DisplayRSquared = False

                    With .Border
                        .ColorIndex = 3
                        .Weight = Excel.XlBorderWeight.xlHairline
                        .LineStyle = Excel.XlLineStyle.xlContinuous
                    End With

                    With .DataLabel.Border
                        .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
                        .Weight = Excel.XlBorderWeight.xlHairline
                        .LineStyle = Excel.XlLineStyle.xlContinuous
                    End With

                    With .DataLabel.Interior
                        .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
                        .PatternColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
                        .Pattern = Excel.XlPattern.xlPatternAutomatic
                    End With
                End With


                With .PlotArea.Border 'Граница графика
                    .ColorIndex = 57 'Черный цвет линии 
                    .Weight = Excel.XlBorderWeight.xlThick 'Толстая линия
                    .LineStyle = Excel.XlLineStyle.xlContinuous 'Простая линия
                End With

                With .PlotArea.Interior
                    .ColorIndex = 2 'Белый фон графика
                    .PatternColorIndex = 1
                    .Pattern = Excel.XlPattern.xlPatternAutomatic
                End With

                'ПОКАЗЫВАЕТ ВСЕ ЛИНИИ СЕТКИ
                With .Axes(Excel.XlAxisType.xlCategory)
                    .HasMajorGridlines = True 'Показываем основные линии сетки
                    .HasMinorGridlines = True 'Показываем дополнительные линии сетки
                End With
                With .Axes(Excel.XlAxisType.xlValue)
                    .HasMajorGridlines = True 'Показываем основные линии сетки
                    .HasMinorGridlines = True 'Показываем дополнительные линии сетки

                    'Пересечение с другой осью в минимальном значении
                    .Crosses = Excel.XlAxisCrosses.xlAxisCrossesCustom
                    .CrossesAt = xlChart.Axes(Excel.XlAxisType.xlValue).MinimumScale
                End With

                'ИЗМЕНЕНИЕ ВИДА ДОПОЛНИТЕЛЬНЫХ СЕТОК
                With .Axes(Excel.XlAxisType.xlCategory).MinorGridlines.Border
                    .ColorIndex = 15
                    .Weight = Excel.XlBorderWeight.xlHairline
                    .LineStyle = Excel.XlLineStyle.xlDash
                End With
                With .Axes(Excel.XlAxisType.xlValue).MinorGridlines.Border
                    .ColorIndex = 15
                    .Weight = Excel.XlBorderWeight.xlHairline
                    .LineStyle = Excel.XlLineStyle.xlDash
                End With

                'Настройка отображения данных на графике
                With .SeriesCollection(1)
                    .MarkerBackgroundColorIndex = 1
                    .MarkerForegroundColorIndex = 1
                    .MarkerStyle = Excel.XlMarkerStyle.xlMarkerStyleDiamond
                    .Smooth = False
                    .MarkerSize = 3
                    .Shadow = False
                    With .Border
                        .ColorIndex = 1
                        .Weight = Excel.XlBorderWeight.xlHairline
                        .LineStyle = Excel.XlLineStyle.xlLineStyleNone
                    End With
                End With

                'Расположение графика (На отдельном листе или на листе с данными)
                .Location(Where:=Excel.XlChartLocation.xlLocationAsObject, Name:=xlSheet.Name)

                With xlSheet.ChartObjects(2)
                    .Left = 10
                    .Top = 330
                    .Height = 250
                    .Width = 700
                End With
            End With

            'Передаем данные на первый лист книги Excel
            With xl.Sheets(1)
                .Cells(i1 + 2, 1).Value = strSheetName
                .Cells(i1 + 2, 2).Value = "='" + CStr(xlSheet.Name) + "'!M" & 4 + intCvrDataCount
                If q.ActionTypeId = 1 Then
                    .Cells(i1 + 2, 3).Value = "='" + CStr(xlSheet.Name) + "'!M" & 5 + intCvrDataCount
                ElseIf q.ActionTypeId = 2 Then
                    .Cells(i1 + 2, 3).Value = "-"
                End If
            End With

            xlSheet.Name = Microsoft.VisualBasic.Left$(strSheetName, 31) 'Переименовали лист

            Me.lblStatus.Text = "Идет обработка ... " + CStr(Math.Round((100 / (qry.Count)) * (i1 + 1) - 0.5)) + "%"
            With Me.tpbrExcelProcessing
                .Visible = True
                .Value = Math.Round((100 / (qry.Count)) * (i1 + 1) - 0.5)
                .ToolTipText = "Идет обработка ... " + CStr(Math.Round((100 / (qry.Count)) * (i1 + 1) - 0.5)) + "%"
            End With
        Next 'Конец цикла по группам записей с одинаковыми T,°С; ActionTypeId и ActionDetailId.

        xl.Sheets(1).activate()
        xl.Sheets(1).Columns("A:C").EntireColumn.AutoFit() 'Автоподбор ширины ячеек

        'Делаем рамку для данных
        xlRange = xl.Sheets(1).Range("A1:C" + CStr(qry.Count + 1)) 'Выделили ячейки
        With xlRange.Borders(Excel.XlBordersIndex.xlEdgeLeft)
            .LineStyle = Excel.XlLineStyle.xlContinuous
            .Weight = Excel.XlBorderWeight.xlMedium
            .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
        End With
        With xlRange.Borders(Excel.XlBordersIndex.xlEdgeRight)
            .LineStyle = Excel.XlLineStyle.xlContinuous
            .Weight = Excel.XlBorderWeight.xlMedium
            .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
        End With
        With xlRange.Borders(Excel.XlBordersIndex.xlEdgeTop)
            .LineStyle = Excel.XlLineStyle.xlContinuous
            .Weight = Excel.XlBorderWeight.xlMedium
            .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
        End With
        With xlRange.Borders(Excel.XlBordersIndex.xlEdgeBottom)
            .LineStyle = Excel.XlLineStyle.xlContinuous
            .Weight = Excel.XlBorderWeight.xlMedium
            .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
        End With
        With xlRange.Borders(Excel.XlBordersIndex.xlInsideVertical)
            .LineStyle = Excel.XlLineStyle.xlContinuous
            .Weight = Excel.XlBorderWeight.xlThin
            .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
        End With
        With xlRange.Borders(Excel.XlBordersIndex.xlInsideHorizontal)
            .LineStyle = Excel.XlLineStyle.xlContinuous
            .Weight = Excel.XlBorderWeight.xlThin
            .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
        End With
        xl.Sheets(1).Name = "CvrData"
        xl.Visible = True 'Устанавливает видимость книги Excel

        'Грамотное завершение работы с Excel
        System.Runtime.InteropServices.Marshal.ReleaseComObject(xl)
        xl = Nothing
        GC.Collect()


        Me.lblStatus.Text = "Готово"
        With Me.tpbrExcelProcessing
            .Visible = False
            .Value = 0
            .ToolTipText = "Идет обработка ... 100%"
        End With

        Me.Cursor = Cursors.Default 'Изменил вид курсора
    End Sub

    'Округление температуры
    Private Function RoundTValue(ByVal TempVal As Double) As Double
        If sngdT = 0 Then
            RoundTValue = TempVal
        Else
            RoundTValue = sngdT * System.Math.Floor((TempVal / sngdT) + 0.5)
        End If
    End Function
    'Название листа Excel
    Private Function ExcelSheetName(ByVal ActionTypeId As Integer) As String
        Dim ans As String = ""

        Select Case ActionTypeId
            Case 1
                ans = "dRo_dH"
            Case 2
                ans = "AZ"
        End Select
        Return ans
    End Function

#End Region

#Region "Работа с пунктами меню/Проверка корректности вводимых пользователем данных"
    'Закрывает текущую форму и открывает стартовую
    Private Sub tmnuShowStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmnuShowStart.Click
        frmStart.Show()
        Me.Close()
    End Sub
    'Завершение работы
    Private Sub tmnuClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmnuClose.Click
        Me.Close()
    End Sub
    'Вызов помощи по программе
    Private Sub tbtnContent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbtnContent.Click
        MessageBox.Show("В настоящее время раздел находится в разработке (Section is under construction)", "ЦВР-10. Информационное сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
    Private Sub tmnuContent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmnuContent.Click
        MessageBox.Show("В настоящее время раздел находится в разработке (Section is under construction)", "ЦВР-10. Информационное сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
    'Открывает форму frmAbout
    Private Sub tmnuAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmnuAbout.Click
        frmAbout.ShowDialog()
    End Sub

    'Устанавливаем границы погрешности при определении Т и Н
    Private Sub ttxt_dH_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ttxt_TCold.KeyPress
        If Not Me.ttxt_TCold.Text = "" Then sngTCold = Me.ttxt_TCold.Text
    End Sub
    Private Sub ttxt_dH_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ttxt_TCold.LostFocus
        If Me.ttxt_TCold.Text = "" Then
            Me.ttxt_TCold.Text = "0"
        End If
    End Sub
    Private Sub ttxt_dH_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ttxt_TCold.TextChanged
        If Not Me.ttxt_TCold.Text = "" Then
            If IsNumeric(Me.ttxt_TCold.Text) Then
                If Not CSng(Me.ttxt_TCold.Text) < 0 Then
                    sngTCold = Me.ttxt_TCold.Text
                    Me.ttxt_TCold1.Text = Me.ttxt_TCold.Text
                Else
                    Me.ttxt_TCold.Text = sngTCold
                End If
            Else
                Me.ttxt_TCold.Text = sngTCold
            End If
        End If
    End Sub

    Private Sub ttxt_dH1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ttxt_TCold1.KeyPress
        If Not Me.ttxt_TCold1.Text = "" Then sngTCold = Me.ttxt_TCold1.Text
    End Sub
    Private Sub ttxt_dH1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ttxt_TCold1.LostFocus
        If Me.ttxt_TCold1.Text = "" Then
            Me.ttxt_TCold1.Text = "0"
        End If
    End Sub
    Private Sub ttxt_dH1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ttxt_TCold1.TextChanged
        If Not Me.ttxt_TCold1.Text = "" Then
            If IsNumeric(Me.ttxt_TCold1.Text) Then
                If Not CSng(Me.ttxt_TCold1.Text) < 0 Then
                    sngTCold = Me.ttxt_TCold1.Text
                    Me.ttxt_TCold.Text = Me.ttxt_TCold1.Text
                Else
                    Me.ttxt_TCold1.Text = sngTCold
                End If
            Else
                Me.ttxt_TCold1.Text = sngTCold
            End If
        End If
    End Sub

    Private Sub ttxt_dT_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ttxt_dT.KeyPress
        If Not Me.ttxt_dT.Text = "" Then sngdT = Me.ttxt_dT.Text
    End Sub
    Private Sub ttxt_dT_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ttxt_dT.LostFocus
        If Me.ttxt_dT.Text = "" Then
            Me.ttxt_dT.Text = "0"
        End If
    End Sub
    Private Sub ttxt_dT_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ttxt_dT.TextChanged
        If Not Me.ttxt_dT.Text = "" Then
            If IsNumeric(Me.ttxt_dT.Text) Then
                If Not CSng(Me.ttxt_dT.Text) < 0 Then
                    sngdT = Me.ttxt_dT.Text
                    Me.ttxt_dT1.Text = Me.ttxt_dT.Text
                Else
                    Me.ttxt_dT.Text = sngdT
                End If
            Else
                Me.ttxt_dT.Text = sngdT
            End If
        End If

    End Sub

    Private Sub ttxt_dT1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ttxt_dT1.KeyPress
        If Not Me.ttxt_dT1.Text = "" Then sngdT = Me.ttxt_dT1.Text
    End Sub
    Private Sub ttxt_dT1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ttxt_dT1.LostFocus
        If Me.ttxt_dT1.Text = "" Then
            Me.ttxt_dT1.Text = "0"
        End If
    End Sub
    Private Sub ttxt_dT1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ttxt_dT1.TextChanged
        If Not Me.ttxt_dT1.Text = "" Then
            If IsNumeric(Me.ttxt_dT1.Text) Then
                If Not CSng(Me.ttxt_dT1.Text) < 0 Then
                    sngdT = Me.ttxt_dT1.Text
                    Me.ttxt_dT.Text = Me.ttxt_dT1.Text
                Else
                    Me.ttxt_dT1.Text = sngdT
                End If
            Else
                Me.ttxt_dT1.Text = sngdT
            End If
        End If

    End Sub

    'Настройка оси Х графика "лента-самописец" 
    'Устанавливаем цену основных и вспомогательных делений
    Private Sub ttxtXMajorUnit_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ttxtXMajorUnit.KeyPress
        If Not Me.ttxtXMajorUnit.Text = "" Then sngXMajorUnit = Me.ttxtXMajorUnit.Text
    End Sub
    Private Sub ttxtXMajorUnit_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ttxtXMajorUnit.TextChanged
        If Not Me.ttxtXMajorUnit.Text = "" Then
            If IsNumeric(Me.ttxtXMajorUnit.Text) Then
                If Not CSng(Me.ttxtXMajorUnit.Text) < 0 Then
                    sngXMajorUnit = Me.ttxtXMajorUnit.Text
                Else
                    Me.ttxtXMajorUnit.Text = sngXMajorUnit
                End If
            Else
                Me.ttxtXMajorUnit.Text = sngXMajorUnit
            End If
        End If

    End Sub
    Private Sub ttxtXMinorUnit_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ttxtXMinorUnit.KeyPress
        If Not Me.ttxtXMinorUnit.Text = "" Then sngXMinorUnit = Me.ttxtXMinorUnit.Text
    End Sub
    Private Sub ttxtXMinorUnit_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ttxtXMinorUnit.TextChanged
        If Not Me.ttxtXMinorUnit.Text = "" Then
            If IsNumeric(Me.ttxtXMinorUnit.Text) Then
                If Not CSng(Me.ttxtXMinorUnit.Text) < 0 Then
                    sngXMinorUnit = Me.ttxtXMinorUnit.Text
                Else
                    Me.ttxtXMinorUnit.Text = sngXMinorUnit
                End If
            Else
                Me.ttxtXMinorUnit.Text = sngXMinorUnit
            End If
        End If
    End Sub

#End Region

End Class