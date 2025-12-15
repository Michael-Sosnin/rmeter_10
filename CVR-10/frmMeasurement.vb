Imports System.BitConverter

Public Class frmMeasurement

    Private dw As New clsDataWorks 'Экземпляр класса clsDataWorks

    Private Structure GeneralSettings
        Public intContRecInterval As Integer 'Интервал непрерывной записи (в мсек.)
        Public intGraphSpeed As Integer 'Скорость изменения данных на графиках (в мсек.)
        Public intKgStep As Integer 'Интервал перемещения РО КР (в мм.)
        Public intCoreTypeId As Integer 'Номер проекта а.з.
        Public strComPort As String 'Номер ComPort-a
    End Structure
    Private usrGS As New GeneralSettings

    Private Structure CvrValue
        Public CurValue As Single
        Public RoValue As Single
    End Structure
    Private usrCvrVal As New CvrValue 'Хранит данные принятые от ЦВР-10

    Private strP, strT, strNmant, strNpwr As String
    Private dsWork, dsSystem As DataSet 'Рабочий и системный DataSet (запрашиваются из clsDataWorks)
    Private blnIsAvgRec As Boolean = False 'False - усредненная запись не идет
    Private lngSampleCount As Long = 0 'Число отсчетов при усреднении


    'Процедура урезает память, реально «отъедаемую» нашим приложением
    <DllImport("kernel32.dll")> _
    Public Shared Function SetProcessWorkingSetSize(ByVal handle As IntPtr, ByVal minimumWorkingSetSize As Integer, _
                                                    ByVal maximumWorkingSetSize As Integer) As Boolean
    End Function

#Region "Действия при загрузке формы/завершении работы"
    Public Sub New()
        InitializeComponent()


        'Урезаем до необходимого минимума оперативку, ввыделяемую на наше приложение
        SetProcessWorkingSetSize(System.Diagnostics.Process.GetCurrentProcess().Handle, -1, -1)

        Me.Icon = My.Resources.Radiation 'Изменяем иконку

        Call subGetDataFromRegistry() 'Считываем данные из реестра
        dsSystem = dw.GetSystemDataSet 'Запросили системный DataSet
        Call subInitMenuStrip() 'Заполняем пункты меню


        'Изменяем параметры контролов
        Me.tmrContRec.Interval = usrGS.intContRecInterval
        Me.tmrGraph.Interval = usrGS.intGraphSpeed
        Me.nudKgChange.Increment = usrGS.intKgStep

        'Изменение пределов графиков
        With kspReactance
            .MaxVal = Convert.ToDouble(Me.txtKspReactMaxVal.Text)
            .MinVal = Convert.ToDouble(Me.txtKspReactMinVal.Text)
        End With
        With kspCurrent
            .MaxVal = Convert.ToDouble(Me.txtKspCurrentMaxVal.Text)
            .MinVal = Convert.ToDouble(Me.txtKspCurrentMinVal.Text)
        End With

        'Thread.Sleep(0)

    End Sub

    Private Sub frmMeasurement_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Call subSetDataToRegistry()
    End Sub

#End Region

#Region "Чтение/Запись данных в реестр"

    Private Sub subSetDataToRegistry()
        Dim key As RegistryKey
        key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("CVR-10_PhysNet_OKBM") 'Запись данных в реестр

        key.SetValue("ContRecInterval", usrGS.intContRecInterval)
        key.SetValue("KgStep", usrGS.intKgStep)
        key.SetValue("GraphSpeed", usrGS.intGraphSpeed)
    End Sub
    Private Sub subGetDataFromRegistry()
        Dim key As Microsoft.Win32.RegistryKey
        key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("CVR-10_PhysNet_OKBM") 'Настройки соединения с SQL
        If key Is Nothing Then
            usrGS.intContRecInterval = 100
            usrGS.intKgStep = 5
            usrGS.intGraphSpeed = 100
        ElseIf usrGS.intContRecInterval = 0 Or usrGS.intKgStep = 0 Or usrGS.intGraphSpeed = 0 Then
            usrGS.intContRecInterval = 100
            usrGS.intKgStep = 5
            usrGS.intGraphSpeed = 100
        Else
            usrGS.intContRecInterval = CType(key.GetValue("ContRecInterval"), Integer)
            usrGS.intKgStep = CType(key.GetValue("KgStep"), Integer)
            usrGS.intGraphSpeed = CType(key.GetValue("GraphSpeed"), Integer)
        End If
    End Sub

#End Region

#Region "Работа с пунктами меню"
    'Вызов помощи по программе
    Private Sub tmnuContents_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmnuContents.Click
        MessageBox.Show("В настоящее время раздел находится в разработке (Section is under construction)", "ЦВР-10. Информационное сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
    Private Sub tbtnContents_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbtnContents.Click
        MessageBox.Show("В настоящее время раздел находится в разработке (Section is under construction)", "ЦВР-10. Информационное сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    'Закрывает текущую форму и открывает стартовую
    Private Sub tmnuShowStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmnuShowStart.Click
        frmStart.Show()
        Me.Close()
    End Sub

    'Завершение работы приложения
    Private Sub tmnuExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmnuExit.Click
        Me.Close()
    End Sub
    'Открывает форму "О Программе"
    Private Sub tmnuAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmnuAbout.Click
        frmAbout.ShowDialog()
    End Sub

    'Событие Click на динамически-созданных пунктах меню
    'Номер проекта а.з.
    Private Sub CoreTypeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Cursor = Cursors.WaitCursor

        Dim tmnu As ToolStripMenuItem = sender
        Dim strItemName As String = tmnu.Name

        usrGS.intCoreTypeId = CInt(strItemName) 'Записали в коллекцию номер выбранного проекта а.з.

        For Each d As ToolStripMenuItem In Me.tmnuCoreType.DropDownItems
            If d.CheckState = CheckState.Checked Then d.Checked = False
        Next
        tmnu = Me.tmnuCoreType.DropDownItems(strItemName)
        tmnu.Checked = True

        For Each d As ToolStripMenuItem In Me.tddbCoreType.DropDownItems
            If d.CheckState = CheckState.Checked Then d.Checked = False
        Next
        tmnu = Me.tddbCoreType.DropDownItems(strItemName)
        tmnu.Checked = True

        Me.tmnuCreateDb.Enabled = True 'Разрешаем пользователю создавать БД
        Me.tbtnCreateDb.Enabled = True 'Разрешаем пользователю создавать БД

        Call subDrawKg() 'Отрисовка органов КР на форме

        Me.Cursor = Cursors.Default
    End Sub
    'Номер Сом-порта
    Private Sub ComPortCanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Cursor = Cursors.WaitCursor

        Dim tmnu As ToolStripMenuItem = sender
        Dim strItemName As String = tmnu.Name

        For Each d As ToolStripMenuItem In Me.mnuComPort.DropDownItems
            If d.CheckState = CheckState.Checked Then d.Checked = False
        Next
        tmnu = Me.mnuComPort.DropDownItems(strItemName)
        tmnu.Checked = True

        For Each d As ToolStripMenuItem In Me.tddbComPort.DropDownItems
            If d.CheckState = CheckState.Checked Then d.Checked = False
        Next
        tmnu = Me.tddbComPort.DropDownItems(strItemName)
        tmnu.Checked = True

        usrGS.strComPort = tmnu.Name 'Записали в коллекцию номер выбранного COM-Port-a
        Me.tbtnCvrStart.Enabled = True 'Разрешаем пользователю запустить опрос ЦВР-10

        Me.Cursor = Cursors.Default
    End Sub

    'Изменение настроек программы
    Private Sub subApplySettings(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbtnApplySettings.Click, tmnuApplySettings.Click
        If Not CInt(Me.ttxtContRecInterval.Text) > 0 Or Not CInt(Me.ttxtGraphSpeed.Text) > 0 Then
            MessageBox.Show("Введено неверное значение параметра (incorrect value)" + Chr(13) + "Параметры не установлены!", "Ошибка ввода.", MessageBoxButtons.OK, MessageBoxIcon.Error)

            With usrGS
                Me.ttxtContRecInterval.Text = CStr(.intContRecInterval)
                Me.ttxtGraphSpeed.Text = CStr(.intGraphSpeed)
            End With

            Exit Sub
        End If
        With usrGS
            .intContRecInterval = CInt(Me.ttxtContRecInterval.Text)
            .intGraphSpeed = CInt(Me.ttxtGraphSpeed.Text)
            .intKgStep = CInt(Me.ttxtKgStep.Text)
        End With

        'Изменяем шаг КГ
        Me.nudKgChange.Increment = usrGS.intKgStep

        'Изменяем настройки таймеров
        If Me.tmrContRec.Enabled Then
            Me.tmrContRec.Enabled = False
            Me.tmrContRec.Interval = usrGS.intContRecInterval
            Me.tmrContRec.Enabled = True
        Else
            Me.tmrContRec.Interval = usrGS.intContRecInterval
        End If

        If Me.tmrGraph.Enabled Then
            Me.tmrGraph.Enabled = False
            Me.tmrGraph.Interval = usrGS.intGraphSpeed
            Me.tmrGraph.Enabled = True
        Else
            Me.tmrGraph.Interval = usrGS.intGraphSpeed
        End If
    End Sub
    'Запуск опроса ЦВР-10
    Private Sub tbtnCvrStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbtnCvrStart.Click
        'Устанавливаем свойства SerialPort-a
        Try
            With Me.sptCvr
                .ReceivedBytesThreshold = 32
                .PortName = usrGS.strComPort
                .BaudRate = 9600
                .Parity = Parity.None
                .DataBits = 8
                .StopBits = StopBits.One
                .Open() 'Запустили опрос реактиметра
                .DiscardInBuffer() 'Очистили буфер от данных
            End With

            Me.tmrGraph.Enabled = True 'Запустили отрисовку данных на графике в фоновом потоке

            Me.tbtnCvrStart.Enabled = False 'Запрещаем повторный запуск опроса ЦВР-10
            Me.tddbComPort.Enabled = False 'Запрещаем изменение номера COM-порта при запущенном опросе ЦВР-10
            Me.mnuComPort.Enabled = False
            Me.tbtnCvrStop.Enabled = True 'Разрешаем остановку опроса ЦВР-10
            Me.tmrCheckCvrConnection.Enabled = True 'Запустили таймер проверки соединения с ЦВР-10
        Catch ex As Exception
            MessageBox.Show("Не удалось начать опрос реактиметра ЦВР-10. (Communication error)", "Ошибка опроса оборудования.", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    'Остановка опроса ЦВР-10
    Private Sub tbtnCvrStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbtnCvrStop.Click
        Me.tmrGraph.Enabled = False 'Остановили отрисовку данных на графике

        Me.tmrCheckCvrConnection.Enabled = False 'Остановили проверку возможности соединения с ЦВР-10
        Me.tbtnCvrStart.Enabled = True 'Разрешаем запуск опроса ЦВР-10
        Me.tddbComPort.Enabled = True 'Разрешаем изменение номера COM-порта при запущенном опросе ЦВР-10
        Me.mnuComPort.Enabled = True
        Me.tbtnCvrStop.Enabled = False 'Запрещаем остановку опроса ЦВР-10

        Me.sptCvr.Close() 'Закрываем SerialPort опроса реактиметра ЦВР-10
    End Sub

    'Создать новую БД Access
    Private Sub tbtnCreateDb_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbtnCreateDb.Click
        Me.sfdCreateDb.ShowDialog()
    End Sub
    Private Sub tmnuCreateDb_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmnuCreateDb.Click
        Me.sfdCreateDb.ShowDialog()
    End Sub
    Private Sub sfdCreateDb_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles sfdCreateDb.FileOk
        Me.Cursor = Cursors.WaitCursor

        'Путь к создаваемому файлу БД Access
        Dim strPath As String = sender.FileName

        'Если файл уже существует - удаляем его
        If File.Exists(strPath) Then File.Delete(strPath)
        'Передаем в clsDataWorks путь для создания рабочей БД Access
        dw.PathToWorkDb = strPath
        'Создаем новую рабочую БД Access

        If Not dw.prCreateNewDb() Then
            MessageBox.Show("Не удалось создать новую БД Access", "Ошибка базы данных", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Cursor = Cursors.Default
            Exit Sub
        End If
        If Not dw.prInitWorkDataSet() Then
            MessageBox.Show("Не удалось создать рабочий DataSet", "Ошибка базы данных", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Cursor = Cursors.Default
            Exit Sub
        End If
        dsWork = dw.GetWorkDataSet 'Возвращаем DataSet содержащие информацию о рабочей БД Access
        Call subCreateOpenDb() 'общая процедуры для создания новой, или открытия сущ-ей БД

        'Записываем данные о типе активной зоны в CoreType
        dsWork.Tables("CoreType").Rows.Add(usrGS.intCoreTypeId)
        Dim str As String = "INSERT INTO CoreType (CoreTypeId) VALUES ('" + CStr(usrGS.intCoreTypeId) + "')"
        If Not dw.ExecuteNonQueryToWorkDb(str) Then
            MessageBox.Show("Не удалось записать тип проекта а.з. в БД Access", "Ошибка базы данных", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Cursor = Cursors.Default
            Exit Sub
        End If

        Me.Text = "ЦВР-10 (Измерения): " + strPath

        Me.tbtnCreateDb.Enabled = False 'Запрещаем создание новой БД Access, если существует рабочее подключение к БД
        Me.tmnuCreateDb.Enabled = False
        Me.tbtnOpenDb.Enabled = False 'Запрещаем открывать существующие БД Access, если существует рабочее подключение к БД
        Me.tmnuOpenDb.Enabled = False
        Me.tbtnDisableDb.Enabled = True 'Разрешаем отсоединиться от БД Access
        Me.tmnuDisableDb.Enabled = True
        Me.tddbCoreType.Enabled = False 'Запрещаем изменение тапа проекта а.з.
        Me.tmnuCoreType.Enabled = False
        Me.cmdContinuousValue.Enabled = True 'Кнопка начала непрерывной записи теперь активна

        Me.Cursor = Cursors.Default
    End Sub
    'Открыть имеющуюся БД Access
    Private Sub tbtnOpenDb_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbtnOpenDb.Click
        Me.ofdOpenDb.ShowDialog()
    End Sub
    Private Sub tmnuOpenDb_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmnuOpenDb.Click
        Me.ofdOpenDb.ShowDialog()
    End Sub
    Private Sub ofdOpenDb_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ofdOpenDb.FileOk
        Me.Cursor = Cursors.WaitCursor

        'Путь к открываемой БД Access
        Dim strPath As String = sender.FileName
        'Передаем в clsDataWorks путь к рабочей БД Access
        dw.PathToWorkDb = strPath
        'Открываем существующую БД Access
        If Not dw.prInitWorkDataSet() Then
            MessageBox.Show("Не удалось открыть БД Access", "Ошибка базы данных", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Cursor = Cursors.Default
            Exit Sub
        End If
        dsWork = dw.GetWorkDataSet 'Возвращаем DataSet содержащие информацию о рабочей БД Access

        'Записываем данные о типе активной зоны в intCoreTypeId
        Call CoreTypeChanged(Me.tmnuCoreType.DropDownItems.Item(CStr(dsWork.Tables("CoreType").Rows(0).Item(0))), e)
        'общая процедуры для создания новой, или открытия сущ-ей БД
        Call subCreateOpenDb()

        Me.Text = "ЦВР-10 (Измерения): " + strPath

        Me.tbtnCreateDb.Enabled = False 'Запрещаем создание новой БД Access, если существует рабочее подключение к БД
        Me.tmnuCreateDb.Enabled = False
        Me.tbtnOpenDb.Enabled = False 'Запрещаем открывать существующие БД Access, если существует рабочее подключение к БД
        Me.tmnuOpenDb.Enabled = False
        Me.tbtnDisableDb.Enabled = True 'Разрешаем отсоединиться от БД Access
        Me.tmnuDisableDb.Enabled = True
        Me.tddbCoreType.Enabled = False 'Запрещаем изменение тапа проекта а.з.
        Me.tmnuCoreType.Enabled = False
        Me.cmdContinuousValue.Enabled = True 'Кнопка начала непрерывной записи теперь активна

        Me.Cursor = Cursors.Default
    End Sub
    'Отключиться от БД Access
    Private Sub tbtnDisableDb_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbtnDisableDb.Click
        Me.dgvAverageData.Columns.Clear() 'Очистили от данных DataGridView
        Me.dgvKgPosition.Columns.Clear()

        Me.tbtnCreateDb.Enabled = True 'Разрешаем создание новой БД Access
        Me.tmnuCreateDb.Enabled = True
        Me.tbtnOpenDb.Enabled = True 'Разрешаем открывать существующие БД Access
        Me.tmnuOpenDb.Enabled = True
        Me.tbtnDisableDb.Enabled = False 'Запрещаем отсоединиться от БД Access
        Me.tmnuDisableDb.Enabled = False
        Me.tddbCoreType.Enabled = True 'Разрешаем изменение тапа проекта а.з.
        Me.tmnuCoreType.Enabled = True
        Me.cmdContinuousValue.Enabled = False 'Кнопка начала непрерывной записи теперь активна

        Me.Text = "ЦВР-10 (Измерения)"
    End Sub
    Private Sub tmnuDisableDb_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmnuDisableDb.Click
        Me.dgvAverageData.Columns.Clear() 'Очистили от данных DataGridView
        Me.dgvKgPosition.Columns.Clear()

        Me.tbtnCreateDb.Enabled = True 'Разрешаем создание новой БД Access
        Me.tmnuCreateDb.Enabled = True
        Me.tbtnOpenDb.Enabled = True 'Разрешаем открывать существующие БД Access
        Me.tmnuOpenDb.Enabled = True
        Me.tbtnDisableDb.Enabled = False 'Запрещаем отсоединиться от БД Access
        Me.tmnuDisableDb.Enabled = False
        Me.tddbCoreType.Enabled = True 'Разрешаем изменение тапа проекта а.з.
        Me.tmnuCoreType.Enabled = True
        Me.cmdContinuousValue.Enabled = False 'Кнопка начала непрерывной записи теперь активна

        Me.Text = "ЦВР-10 (Измерения)"
    End Sub

#End Region

#Region "Вспомогательные функции"
    'Отображаем системные данные на соответствующих эл-ах управления на форме
    Private Sub subInitMenuStrip()
        Dim tmnu, tmnu1 As ToolStripMenuItem

        'Номер проекта а.з.
        For Each row As DataRow In dsSystem.Tables("CoreTypes").Rows
            Dim text As String = row.Item("CoreName").ToString
            Dim name As String = row.Item("CoreTypeId").ToString

            tmnu = New ToolStripMenuItem(text)
            tmnu.Name = name
            AddHandler tmnu.Click, AddressOf CoreTypeChanged
            Me.tmnuCoreType.DropDownItems.Add(tmnu)

            tmnu1 = New ToolStripMenuItem(text)
            tmnu1.Name = name
            AddHandler tmnu1.Click, AddressOf CoreTypeChanged
            Me.tddbCoreType.DropDownItems.Add(tmnu1)
        Next

        'Отображаем список доступных COM-портов
        Dim availablePorts As String() = System.IO.Ports.SerialPort.GetPortNames()
        For Each port As String In availablePorts
            tmnu = New ToolStripMenuItem(port)
            tmnu.Name = port
            AddHandler tmnu.Click, AddressOf ComPortCanged
            Me.mnuComPort.DropDownItems.Add(tmnu)

            tmnu1 = New ToolStripMenuItem(port)
            tmnu1.Name = port
            AddHandler tmnu1.Click, AddressOf ComPortCanged
            Me.tddbComPort.DropDownItems.Add(tmnu1)
        Next

        Me.ttxtKgStep.Text = CStr(usrGS.intKgStep)
        Me.ttxtGraphSpeed.Text = CStr(usrGS.intGraphSpeed)
        Me.ttxtContRecInterval.Text = CStr(usrGS.intContRecInterval)

    End Sub

    'Отрисовка органов КР на форме и заполнение данными ComboBox-ов
    Private Sub subDrawKg()

        Me.pnlKgPosition.Controls.Clear() 'очистили панель

        Dim qwr = From kg In dsSystem.Tables("CoreTypeKgPosition"), tp In dsSystem.Tables("KgTypes") _
                  Where kg!CoreTypeId = usrGS.intCoreTypeId And tp!KgTypeId = kg!KgTypeId _
                  Select x = kg!x, y = kg!y, text = tp!KgName, id = kg!KgTypeId

        For Each r In qwr
            Dim uKG As New KG
            With uKG
                .Caption = r.text
                .Location = New Point(r.x, r.y)
                .Text = "0"
                .Name = r.id
                AddHandler uKG.CheckedChanged, AddressOf uKG_CheckedChanged
            End With
            Me.pnlKgPosition.Controls.Add(uKG)
        Next

        'ComboBox-ы:
        'combo_dRo_dH
        Dim dv1 As New DataView
        With dv1
            .Table = dsSystem.Tables("ActionDetails")
            .RowFilter = "CoreTypeId = '" + CStr(usrGS.intCoreTypeId) + "' AND ActionTypeId = '1'"
        End With

        With Me.combo_dRo_dH
            .DataSource = Nothing
            .Items.Clear()
            .DataSource = dv1
            .DisplayMember = "Details"
            .ValueMember = "ActionDetailId"
        End With

        'combo_AZ
        Dim dv2 As New DataView
        With dv2
            .Table = dsSystem.Tables("ActionDetails")
            .RowFilter = "CoreTypeId = '" + CStr(usrGS.intCoreTypeId) + "' AND ActionTypeId = '2'"
        End With

        With Me.combo_AZ
            .DataSource = Nothing
            .Items.Clear()
            .DataSource = dv2
            .DisplayMember = "Details"
            .ValueMember = "ActionDetailId"
        End With
    End Sub
    'Произошло событие - выделили какой-нибудь орган КГ
    Sub uKG_CheckedChanged(ByVal sender As System.Object)
        Dim uKG As New KG
        uKG = sender

        nudKgChange.Text = uKG.Text
    End Sub

    Private Sub sptCvr_DataReceived(ByVal sender As Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles sptCvr.DataReceived
        Try
            'Остановка таймера проверки наличия соединения с реактиметром ЦВР-10
            BeginInvoke(New EventHandler(AddressOf Me.CheckCvrCnnChange), New Object() {Me, EventArgs.Empty})


            If Not Me.sptCvr.BytesToRead = 32 Then Exit Sub

            Dim bytData As Byte() 'Массив байт, полученных от ЦВР
            bytData = New Byte(31) {}
            'Считали данные из буфера
            sptCvr.Read(bytData, 0, 32)

            Dim intStartIndex As Integer
            For i As Integer = 0 To 31 Step 1
                If bytData(i) = 255 And bytData(i + 1) = 0 And bytData(i + 2) = 255 And bytData(i + 3) = 0 Then
                    intStartIndex = i + 4
                    Exit For
                End If
            Next

            usrCvrVal.CurValue = ToSingle(bytData, intStartIndex)
            usrCvrVal.RoValue = ToSingle(bytData, intStartIndex + 4)

            'Если нажата кнопка усреднения данных
            If blnIsAvgRec Then
                Call AddSample(CDbl(usrCvrVal.RoValue), CDbl(Me.txtT.Text))
                BeginInvoke(New EventHandler(AddressOf Me.subAddSample), New Object() {Me, EventArgs.Empty})
            End If

            Me.sptCvr.DiscardInBuffer()

            'Обновление данных на форме
            BeginInvoke(New EventHandler(AddressOf Me.subUpdateFormElements), New Object() {Me, EventArgs.Empty})
        Catch ex As Exception
        Finally
            'Запуск таймера проверки наличия соединения с реактиметром ЦВР-10
            BeginInvoke(New EventHandler(AddressOf Me.CheckCvrCnnChange), New Object() {Me, EventArgs.Empty})
        End Try
    End Sub

    'общая процедуры для создания новой, или открытия сущ-ей БД
    Private Sub subCreateOpenDb()
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
        If Not dw.UpdateWorkTable("CvrData") Then MessageBox.Show("Не удалось изменить данные в таблице CvrData БД Access", "Ошибка базы данных", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub KgData_Row_Changed()
        Me.Cursor = Cursors.WaitCursor
        If Not dw.UpdateWorkTable("KgData") Then MessageBox.Show("Не удалось изменить данные в таблице KgData БД Access", "Ошибка базы данных", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub CvrData_Row_Deleted()
        Me.Cursor = Cursors.WaitCursor
        If Not dw.UpdateWorkTable("KgData") Then MessageBox.Show("Не удалось удалить данные из таблицы KgData БД Access", "Ошибка базы данных", MessageBoxButtons.OK, MessageBoxIcon.Error)
        If Not dw.UpdateWorkTable("CvrData") Then MessageBox.Show("Не удалось удалить данные из таблицы CvrData БД Access", "Ошибка базы данных", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            .HeaderText = "Отсч. (Counts)"
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
            .Visible = False
            .Width = 0
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
            .RowFilter = "CoreTypeId = '" + CStr(usrGS.intCoreTypeId) + "'"
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

    'Изменение пределов графиков
    Private Sub cmdKspReactLimitChange_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdKspReactLimitChange.Click
        With kspReactance
            .MaxVal = CDbl(Me.txtKspReactMaxVal.Text)
            .MinVal = CDbl(Me.txtKspReactMinVal.Text)
        End With
    End Sub
    Private Sub cmdKspCurrentLimitChange_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdKspCurrentLimitChange.Click
        With kspCurrent
            .MaxVal = CDbl(Me.txtKspCurrentMaxVal.Text)
            .MinVal = CDbl(Me.txtKspCurrentMinVal.Text)
        End With
    End Sub

#Region "Работа с элементами РО КР"
    'Выделить/снять выделение всех органов КР
    Private Sub cmdSelectOll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelectOll.Click

        Me.Cursor = Cursors.WaitCursor
        For Each uKG As KG In Me.pnlKgPosition.Controls
            uKG.Checked = True
        Next
        Me.Cursor = Cursors.Default

    End Sub
    Private Sub cmdUnSelectOll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUnSelectOll.Click
        Me.Cursor = Cursors.WaitCursor
        For Each uKG As KG In Me.pnlKgPosition.Controls
            uKG.Checked = False
        Next
        Me.Cursor = Cursors.Default

    End Sub

    'Изменение положения нескольких органов КР одновременно
    Private Sub nudKgChange_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudKgChange.ValueChanged
        For Each el As KG In pnlKgPosition.Controls
            If el.Checked = True Then el.Text = CStr(Me.nudKgChange.Value)
        Next
    End Sub
#End Region
#End Region

#Region "Запуск/остановка непрерывной и усредненной записи данных от ЦВР-10"
    'Кнопка запуска/остановки НЕПРЕРЫВНОЙ записи данных от ЦВР-10
    Private Sub cmdContinuousValue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdContinuousValue.Click
        Me.tbtnDisableDb.Enabled = Not Me.tbtnDisableDb.Enabled 'Запрещаем (разрешаем)отключение от БД Access при 
        Me.tmnuDisableDb.Enabled = Not Me.tmnuDisableDb.Enabled 'включенной непрерывной записи данных ЦВР-10

        Me.cmdAvarageValue.Enabled = Not Me.cmdAvarageValue.Enabled 'Усредненная запись разрешена/запрещена

        If Me.tmrContRec.Enabled Then 'Непрерывная запись не ведется
            Me.slblAction.Text = "Непрерывная запись остановлена "
            Me.slblDetails.Text = ""

            cmdContinuousValue.Text = "Начать непрерывную запись"
            cmdContinuousValue.ForeColor = Color.DarkRed
        Else
            Me.slblAction.Text = "Запущена непрерывная запись ... "
            Me.slblDetails.Text = ""

            'Установил период записи данных 
            Me.tmrContRec.Interval = usrGS.intContRecInterval

            cmdContinuousValue.Text = "Остановить непрерывную запись"
            cmdContinuousValue.ForeColor = Color.DarkGreen
        End If

        Me.tmrContRec.Enabled = Not Me.tmrContRec.Enabled 'Таймер напрерывной записи запущен/остановлен
    End Sub
    'Кнопка запускa/остановки УСРЕДНЕННОЙ записи данных от ЦВР-10
    Private Sub cmdAvarageValue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAvarageValue.Click
        Static StartRec As String 'Начало записи
        Dim udtSampleResult As udtLastSampleAvg

        Me.cmdContinuousValue.Enabled = Not Me.cmdContinuousValue.Enabled 'Запрещаем остановку непрерывной записи при запущенном усреднении данных
        blnIsAvgRec = Not blnIsAvgRec

        If Not blnIsAvgRec Then 'Закончили усреднение
            lngSampleCount = 0 'Обнулили счетчик количества отсчетов.
            Me.slblAction.Text = "Запущена непрерывная запись ... "
            Me.slblDetails.Text = ""

            Me.cmdAvarageValue.Text = "Начать усредненную запись"
            Me.cmdAvarageValue.ForeColor = Color.DarkRed

            Dim StopRec As String = Format(Now, "dd.MM.yyyy HH:mm:ss")

            Call CalcLastSample(udtSampleResult) 'ВЫЗЫВАЕМ ПРОЦЕДУРУ ОБРАБОТКИ
            'ЗАПИСАННЫХ ЗНАЧЕНИЙ Ro И T

            Dim SampleCount As Long = udtSampleResult.lngSamples
            Dim RoAngle As Double = udtSampleResult.dblKRo
            Dim RoStop As Double = udtSampleResult.dblBRo
            Dim I As Double = usrCvrVal.CurValue

            Dim T As Double = CDbl(Me.txtT.Text)
            Dim N As Double = CDbl(Me.txtPowerMant.Text) * 10 ^ CInt(Me.txtPowerPwr.Text)
            Dim P As Double = CDbl(Me.txtPressure.Text)

            Dim NfiNo As Integer = CInt(Me.nudExperNumb.Value)

            Dim ActionTypeId As Integer
            Dim ActionDetailId As Integer
            If Me.rbt_dRo_dH.Checked Then
                ActionTypeId = 1
                ActionDetailId = Me.combo_dRo_dH.SelectedValue
            ElseIf Me.rbtActiveGuard.Checked Then
                ActionTypeId = 2
                ActionDetailId = Me.combo_AZ.SelectedValue
            End If

            'Добавляем строку в DataSet в таблицу CvrData
            dsWork.Tables("CvrData").Rows.Add(Nothing, StartRec, StopRec, SampleCount, RoAngle, RoStop, I, T, N, P, NfiNo, ActionTypeId, ActionDetailId)

            'Номер новой записи в DataSet
            Dim CvrDataId As String = CStr(dsWork.Tables("CvrData").Rows(dsWork.Tables("CvrData").Rows.Count - 1).Item("CvrDataId"))

            'Добавляем данные в DataSet в таблицу KgData
            For Each kg1 As KG In pnlKgPosition.Controls
                Dim CoreTypeKgPositionId As String = CStr(kg1.Name)
                Dim KgValue As String = CStr(kg1.Text)
                dsWork.Tables("KgData").Rows.Add(Nothing, CvrDataId, CoreTypeKgPositionId, KgValue)
            Next

            Me.dgvAverageData.Rows(Me.dgvAverageData.Rows.Count - 1).Cells(0).Selected = True
        Else 'Начали усреднение

            Me.cmdAvarageValue.Text = "Остановить усреднение"
            Me.cmdAvarageValue.ForeColor = Color.DarkGreen

            StartRec = Format(Now, "dd.MM.yyyy HH:mm:ss")

            lngStartTime = Now.Ticks()

            'На StatusStrip отображаем информацие о числе отсчетов
            Me.slblAction.Text = "Запущена усредненная запись ... "
            Me.slblDetails.Text = "0 отсч."
        End If

    End Sub
#End Region

#Region "Работа с таймерами"
    'Проверка возможности установления соединения с реактиметром ЦВР-10
    Private Sub tmrCheckCvrConnection_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrCheckCvrConnection.Tick
        Me.tmrCheckCvrConnection.Enabled = False
        MessageBox.Show("Установить соединение с реактиметром ЦВР-10 не удалось." + Chr(13) + "Проверьте настройки соединения.", "Ошибка соединения с реактиметром ЦВР-10", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Me.sptCvr.Close() 'Закрываем SerialPort опроса реактиметра ЦВР-10
        Me.tbtnCvrStart.Enabled = True 'Разрешаем запуск опроса ЦВР-10
        Me.tddbComPort.Enabled = True 'Разрешаем изменение номера COM-порта при запущенном опросе ЦВР-10
        Me.mnuComPort.Enabled = True
        Me.tbtnCvrStop.Enabled = False 'Запрещаем остановку опроса ЦВР-10
        Me.tmrGraph.Enabled = False 'Остановили передачу данных на графики Ro и I
    End Sub

    'Передает графикам данные, полученные от реактиметра ЦВР-10 
    Private Sub tmrGraph_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrGraph.Tick
        Me.kspCurrent.InputVal = CDbl(Me.txtCurMant.Text)
        Me.kspReactance.InputVal = usrCvrVal.RoValue
    End Sub

    'Событие Tick таймера непрерывной записи
    Private Sub tmrContRec_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrContRec.Tick
        sender.Enabled = False 'Остановили таймер

        Dim str As String
        Dim Ro, I As String

        Ro = CStr(usrCvrVal.RoValue) 'Реактивность
        I = CStr(usrCvrVal.CurValue) 'Ток

        'Запрос на добавление данных в БД Access
        str = "INSERT INTO ContinuousData (Created,Ro,I) VALUES ('" + CStr(Now) + "','" + Ro + "','" + I + "')"

        If dw.ExecuteNonQueryToWorkDb(str) = False Then
            MessageBox.Show("Не удалось записать данные в таблицу ContinuousData.", "Ошибка базы данных", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Me.tbtnDisableDb.Enabled = True 'Pазрешаем отключение от БД Access  
            Me.tmnuDisableDb.Enabled = True

            Me.cmdAvarageValue.Enabled = False 'Усредненная запись запрещена
            cmdContinuousValue.Text = "Начать непрерывную запись"
            cmdContinuousValue.ForeColor = Color.DarkRed

            Exit Sub
        End If
        sender.Enabled = True 'Запустили таймер
    End Sub

#End Region

#Region "Изменение свойств контролов из другого потока"
    'Запуск/остановка таймера проверки наличия соединения с реактиметром ЦВР-10
    Private Sub CheckCvrCnnChange()
        Me.tmrCheckCvrConnection.Enabled = Not Me.tmrCheckCvrConnection.Enabled
    End Sub
    'Отображение на форме данных, полученных от реактиметра ЦВР-10
    Private Sub subUpdateFormElements()
        Me.txtCurMant.Text = Microsoft.VisualBasic.Left(Format(usrCvrVal.CurValue, "0.000E-00"), 5)
        Me.txtCurPwr.Text = Microsoft.VisualBasic.Right(Format(usrCvrVal.CurValue, "0.000E-00"), 3)
        Me.txtReact.Text = Format(usrCvrVal.RoValue, "#0.0000")
    End Sub
    'Изменение количества отсчетов
    Private Sub subAddSample()
        Me.slblDetails.Text = CStr(lngSampleCount) + " отсч."
        lngSampleCount = lngSampleCount + 1 'Увеличили число отсчетов на 1
    End Sub
#End Region

#Region "Проверка корректности вводимых пользователем данных"
    'Давление (P)
    Private Sub txtPressure_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPressure.KeyPress
        strP = Me.txtPressure.Text
    End Sub
    Private Sub txtPressure_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPressure.TextChanged
        If Not IsNumeric(Me.txtPressure.Text) Then Me.txtPressure.Text = strP
    End Sub
    'Темперкатура (Т)
    Private Sub txtT_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtT.KeyPress
        strT = Me.txtT.Text
    End Sub
    Private Sub txtT_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtT.TextChanged
        If Not IsNumeric(Me.txtT.Text) Then Me.txtT.Text = strT
    End Sub
    'Мощность мантисса (N)
    Private Sub txtPowerMant_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPowerMant.KeyPress
        strNmant = Me.txtPowerMant.Text
    End Sub
    Private Sub txtPowerMant_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPowerMant.TextChanged
        If Not IsNumeric(Me.txtPowerMant.Text) Then Me.txtPowerMant.Text = strNmant
    End Sub
    'Мощность степень (N)
    Private Sub txtPowerPwr_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPowerPwr.KeyPress
        If Not Me.txtPowerPwr.Text = "-" Then strNpwr = Me.txtPowerPwr.Text
    End Sub
    Private Sub txtPowerPwr_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPowerPwr.Leave
        If Not IsNumeric(Me.txtPowerPwr.Text) Then Me.txtPowerPwr.Text = strNpwr
    End Sub
    Private Sub txtPowerPwr_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPowerPwr.TextChanged
        If Not IsNumeric(Me.txtPowerPwr.Text) And Not Me.txtPowerPwr.Text = "-" Then Me.txtPowerPwr.Text = strNpwr
    End Sub

#End Region

End Class