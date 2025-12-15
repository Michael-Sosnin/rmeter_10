<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMeasurement
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.sptCvr = New System.IO.Ports.SerialPort(Me.components)
        Me.mnuMeasurement = New System.Windows.Forms.MenuStrip()
        Me.mnuFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.tmnuShowStart = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.tmnuExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDataBase = New System.Windows.Forms.ToolStripMenuItem()
        Me.tmnuCreateDb = New System.Windows.Forms.ToolStripMenuItem()
        Me.tmnuOpenDb = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tmnuDisableDb = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuComPort = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTools = New System.Windows.Forms.ToolStripMenuItem()
        Me.tmnuCoreType = New System.Windows.Forms.ToolStripMenuItem()
        Me.tmnuContRecInterval = New System.Windows.Forms.ToolStripMenuItem()
        Me.ttxtContRecInterval = New System.Windows.Forms.ToolStripTextBox()
        Me.tmnuGraphSpeed = New System.Windows.Forms.ToolStripMenuItem()
        Me.ttxtGraphSpeed = New System.Windows.Forms.ToolStripTextBox()
        Me.tmnuKgStep = New System.Windows.Forms.ToolStripMenuItem()
        Me.ttxtKgStep = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tmnuApplySettings = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuHelp = New System.Windows.Forms.ToolStripMenuItem()
        Me.tmnuContents = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tmnuAbout = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolMeasurement = New System.Windows.Forms.ToolStrip()
        Me.tddbComPort = New System.Windows.Forms.ToolStripDropDownButton()
        Me.tddbCoreType = New System.Windows.Forms.ToolStripDropDownButton()
        Me.tbtnApplySettings = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.tbtnCreateDb = New System.Windows.Forms.ToolStripButton()
        Me.tbtnOpenDb = New System.Windows.Forms.ToolStripButton()
        Me.tbtnDisableDb = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.tbtnCvrStart = New System.Windows.Forms.ToolStripButton()
        Me.tbtnCvrStop = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.tbtnContents = New System.Windows.Forms.ToolStripButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmdSelectOll = New System.Windows.Forms.Button()
        Me.nudKgChange = New System.Windows.Forms.NumericUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmdUnSelectOll = New System.Windows.Forms.Button()
        Me.pnlKgPosition = New System.Windows.Forms.Panel()
        Me.cmdContinuousValue = New System.Windows.Forms.Button()
        Me.cmdAvarageValue = New System.Windows.Forms.Button()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.nudExperNumb = New System.Windows.Forms.NumericUpDown()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.combo_dRo_dH = New System.Windows.Forms.ComboBox()
        Me.combo_AZ = New System.Windows.Forms.ComboBox()
        Me.rbtActiveGuard = New System.Windows.Forms.RadioButton()
        Me.rbt_dRo_dH = New System.Windows.Forms.RadioButton()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.tmrContRec = New System.Windows.Forms.Timer(Me.components)
        Me.tmrGraph = New System.Windows.Forms.Timer(Me.components)
        Me.tmrCheckCvrConnection = New System.Windows.Forms.Timer(Me.components)
        Me.sfdCreateDb = New System.Windows.Forms.SaveFileDialog()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtReact = New System.Windows.Forms.TextBox()
        Me.txtPressure = New System.Windows.Forms.TextBox()
        Me.txtT = New System.Windows.Forms.TextBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.txtPowerPwr = New System.Windows.Forms.TextBox()
        Me.txtPowerMant = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtCurPwr = New System.Windows.Forms.TextBox()
        Me.txtCurMant = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmdKspCurrentLimitChange = New System.Windows.Forms.Button()
        Me.cmdKspReactLimitChange = New System.Windows.Forms.Button()
        Me.txtKspReactMaxVal = New System.Windows.Forms.TextBox()
        Me.txtKspCurrentMinVal = New System.Windows.Forms.TextBox()
        Me.txtKspCurrentMaxVal = New System.Windows.Forms.TextBox()
        Me.txtKspReactMinVal = New System.Windows.Forms.TextBox()
        Me.ofdOpenDb = New System.Windows.Forms.OpenFileDialog()
        Me.dgvAverageData = New System.Windows.Forms.DataGridView()
        Me.dgvKgPosition = New System.Windows.Forms.DataGridView()
        Me.statMeasure = New System.Windows.Forms.StatusStrip()
        Me.slblAction = New System.Windows.Forms.ToolStripStatusLabel()
        Me.slblDetails = New System.Windows.Forms.ToolStripStatusLabel()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer5 = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer6 = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer7 = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer3 = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer4 = New System.Windows.Forms.SplitContainer()
        Me.kspCurrent = New CVR_10.KSP()
        Me.kspReactance = New CVR_10.KSP()
        Me.mnuMeasurement.SuspendLayout()
        Me.toolMeasurement.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.nudKgChange, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        CType(Me.nudExperNumb, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvAverageData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvKgPosition, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.statMeasure.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.SplitContainer5.Panel1.SuspendLayout()
        Me.SplitContainer5.Panel2.SuspendLayout()
        Me.SplitContainer5.SuspendLayout()
        Me.SplitContainer6.Panel1.SuspendLayout()
        Me.SplitContainer6.Panel2.SuspendLayout()
        Me.SplitContainer6.SuspendLayout()
        Me.SplitContainer7.Panel1.SuspendLayout()
        Me.SplitContainer7.Panel2.SuspendLayout()
        Me.SplitContainer7.SuspendLayout()
        Me.SplitContainer3.Panel1.SuspendLayout()
        Me.SplitContainer3.Panel2.SuspendLayout()
        Me.SplitContainer3.SuspendLayout()
        Me.SplitContainer4.Panel1.SuspendLayout()
        Me.SplitContainer4.Panel2.SuspendLayout()
        Me.SplitContainer4.SuspendLayout()
        Me.SuspendLayout()
        '
        'sptCvr
        '
        Me.sptCvr.DtrEnable = True
        Me.sptCvr.ReceivedBytesThreshold = 16
        '
        'mnuMeasurement
        '
        Me.mnuMeasurement.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.mnuMeasurement.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuFile, Me.mnuDataBase, Me.mnuComPort, Me.mnuTools, Me.mnuHelp})
        Me.mnuMeasurement.Location = New System.Drawing.Point(0, 0)
        Me.mnuMeasurement.Name = "mnuMeasurement"
        Me.mnuMeasurement.Size = New System.Drawing.Size(1615, 30)
        Me.mnuMeasurement.TabIndex = 0
        Me.mnuMeasurement.Text = "MenuStrip1"
        '
        'mnuFile
        '
        Me.mnuFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tmnuShowStart, Me.ToolStripSeparator7, Me.tmnuExit})
        Me.mnuFile.Name = "mnuFile"
        Me.mnuFile.Size = New System.Drawing.Size(59, 26)
        Me.mnuFile.Text = "Файл"
        '
        'tmnuShowStart
        '
        Me.tmnuShowStart.Name = "tmnuShowStart"
        Me.tmnuShowStart.Size = New System.Drawing.Size(214, 26)
        Me.tmnuShowStart.Text = "Стартовая форма"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(211, 6)
        '
        'tmnuExit
        '
        Me.tmnuExit.Image = Global.CVR_10.My.Resources.Resources.delete2
        Me.tmnuExit.Name = "tmnuExit"
        Me.tmnuExit.Size = New System.Drawing.Size(214, 26)
        Me.tmnuExit.Text = "Выход"
        '
        'mnuDataBase
        '
        Me.mnuDataBase.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tmnuCreateDb, Me.tmnuOpenDb, Me.ToolStripSeparator1, Me.tmnuDisableDb})
        Me.mnuDataBase.Name = "mnuDataBase"
        Me.mnuDataBase.Size = New System.Drawing.Size(116, 26)
        Me.mnuDataBase.Text = "Базы Данных"
        '
        'tmnuCreateDb
        '
        Me.tmnuCreateDb.Enabled = False
        Me.tmnuCreateDb.Image = Global.CVR_10.My.Resources.Resources.data_add
        Me.tmnuCreateDb.Name = "tmnuCreateDb"
        Me.tmnuCreateDb.Size = New System.Drawing.Size(239, 26)
        Me.tmnuCreateDb.Text = "Создать БД"
        '
        'tmnuOpenDb
        '
        Me.tmnuOpenDb.Image = Global.CVR_10.My.Resources.Resources.data_find
        Me.tmnuOpenDb.Name = "tmnuOpenDb"
        Me.tmnuOpenDb.Size = New System.Drawing.Size(239, 26)
        Me.tmnuOpenDb.Text = "Открыть БД"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(236, 6)
        '
        'tmnuDisableDb
        '
        Me.tmnuDisableDb.Enabled = False
        Me.tmnuDisableDb.Image = Global.CVR_10.My.Resources.Resources.data_delete
        Me.tmnuDisableDb.Name = "tmnuDisableDb"
        Me.tmnuDisableDb.Size = New System.Drawing.Size(239, 26)
        Me.tmnuDisableDb.Text = "Отсоединиться от БД"
        '
        'mnuComPort
        '
        Me.mnuComPort.Name = "mnuComPort"
        Me.mnuComPort.Size = New System.Drawing.Size(88, 26)
        Me.mnuComPort.Text = "COM-Port"
        '
        'mnuTools
        '
        Me.mnuTools.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tmnuCoreType, Me.tmnuContRecInterval, Me.tmnuGraphSpeed, Me.tmnuKgStep, Me.ToolStripSeparator2, Me.tmnuApplySettings})
        Me.mnuTools.Name = "mnuTools"
        Me.mnuTools.Size = New System.Drawing.Size(98, 26)
        Me.mnuTools.Text = "Настройки"
        '
        'tmnuCoreType
        '
        Me.tmnuCoreType.Name = "tmnuCoreType"
        Me.tmnuCoreType.Size = New System.Drawing.Size(364, 26)
        Me.tmnuCoreType.Text = "Номер проекта а.з."
        '
        'tmnuContRecInterval
        '
        Me.tmnuContRecInterval.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ttxtContRecInterval})
        Me.tmnuContRecInterval.Name = "tmnuContRecInterval"
        Me.tmnuContRecInterval.Size = New System.Drawing.Size(364, 26)
        Me.tmnuContRecInterval.Text = "Интервал непрерывной записи (мсек.)"
        '
        'ttxtContRecInterval
        '
        Me.ttxtContRecInterval.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ttxtContRecInterval.Name = "ttxtContRecInterval"
        Me.ttxtContRecInterval.Size = New System.Drawing.Size(100, 27)
        Me.ttxtContRecInterval.Text = "100"
        '
        'tmnuGraphSpeed
        '
        Me.tmnuGraphSpeed.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ttxtGraphSpeed})
        Me.tmnuGraphSpeed.Name = "tmnuGraphSpeed"
        Me.tmnuGraphSpeed.Size = New System.Drawing.Size(364, 26)
        Me.tmnuGraphSpeed.Text = "Скорость отрисовки графиков (мсек.)"
        '
        'ttxtGraphSpeed
        '
        Me.ttxtGraphSpeed.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ttxtGraphSpeed.Name = "ttxtGraphSpeed"
        Me.ttxtGraphSpeed.Size = New System.Drawing.Size(152, 27)
        Me.ttxtGraphSpeed.Text = "100"
        '
        'tmnuKgStep
        '
        Me.tmnuKgStep.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ttxtKgStep})
        Me.tmnuKgStep.Name = "tmnuKgStep"
        Me.tmnuKgStep.Size = New System.Drawing.Size(364, 26)
        Me.tmnuKgStep.Text = "Шаг РО КГ (мм.)"
        '
        'ttxtKgStep
        '
        Me.ttxtKgStep.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ttxtKgStep.Name = "ttxtKgStep"
        Me.ttxtKgStep.Size = New System.Drawing.Size(100, 27)
        Me.ttxtKgStep.Text = "5"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(361, 6)
        '
        'tmnuApplySettings
        '
        Me.tmnuApplySettings.Image = Global.CVR_10.My.Resources.Resources.gear_ok
        Me.tmnuApplySettings.Name = "tmnuApplySettings"
        Me.tmnuApplySettings.Size = New System.Drawing.Size(364, 26)
        Me.tmnuApplySettings.Text = "Применить настройки"
        '
        'mnuHelp
        '
        Me.mnuHelp.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tmnuContents, Me.ToolStripSeparator3, Me.tmnuAbout})
        Me.mnuHelp.Name = "mnuHelp"
        Me.mnuHelp.Size = New System.Drawing.Size(83, 26)
        Me.mnuHelp.Text = "Помощь"
        '
        'tmnuContents
        '
        Me.tmnuContents.Image = Global.CVR_10.My.Resources.Resources.help2
        Me.tmnuContents.Name = "tmnuContents"
        Me.tmnuContents.Size = New System.Drawing.Size(187, 26)
        Me.tmnuContents.Text = "Описание"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(184, 6)
        '
        'tmnuAbout
        '
        Me.tmnuAbout.Name = "tmnuAbout"
        Me.tmnuAbout.Size = New System.Drawing.Size(187, 26)
        Me.tmnuAbout.Text = "О программе"
        '
        'toolMeasurement
        '
        Me.toolMeasurement.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.toolMeasurement.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tddbComPort, Me.tddbCoreType, Me.tbtnApplySettings, Me.ToolStripSeparator4, Me.tbtnCreateDb, Me.tbtnOpenDb, Me.tbtnDisableDb, Me.ToolStripSeparator5, Me.tbtnCvrStart, Me.tbtnCvrStop, Me.ToolStripSeparator6, Me.tbtnContents})
        Me.toolMeasurement.Location = New System.Drawing.Point(0, 30)
        Me.toolMeasurement.Name = "toolMeasurement"
        Me.toolMeasurement.Size = New System.Drawing.Size(1615, 31)
        Me.toolMeasurement.TabIndex = 1
        Me.toolMeasurement.Text = "ToolStrip1"
        '
        'tddbComPort
        '
        Me.tddbComPort.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tddbComPort.Image = Global.CVR_10.My.Resources.Resources.Connect
        Me.tddbComPort.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tddbComPort.Name = "tddbComPort"
        Me.tddbComPort.Size = New System.Drawing.Size(34, 28)
        Me.tddbComPort.Text = "Выбор COM-Port к которому подключен ЦВР-10"
        '
        'tddbCoreType
        '
        Me.tddbCoreType.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tddbCoreType.Image = Global.CVR_10.My.Resources.Resources.Reactor
        Me.tddbCoreType.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tddbCoreType.Name = "tddbCoreType"
        Me.tddbCoreType.Size = New System.Drawing.Size(34, 28)
        Me.tddbCoreType.Text = "Номер проекта а.з."
        '
        'tbtnApplySettings
        '
        Me.tbtnApplySettings.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tbtnApplySettings.Image = Global.CVR_10.My.Resources.Resources.gear_ok
        Me.tbtnApplySettings.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbtnApplySettings.Name = "tbtnApplySettings"
        Me.tbtnApplySettings.Size = New System.Drawing.Size(29, 28)
        Me.tbtnApplySettings.Text = "Применить настройки"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 31)
        '
        'tbtnCreateDb
        '
        Me.tbtnCreateDb.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tbtnCreateDb.Enabled = False
        Me.tbtnCreateDb.Image = Global.CVR_10.My.Resources.Resources.data_add
        Me.tbtnCreateDb.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbtnCreateDb.Name = "tbtnCreateDb"
        Me.tbtnCreateDb.Size = New System.Drawing.Size(29, 28)
        Me.tbtnCreateDb.Text = "Создать базу данных"
        '
        'tbtnOpenDb
        '
        Me.tbtnOpenDb.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tbtnOpenDb.Image = Global.CVR_10.My.Resources.Resources.data_view
        Me.tbtnOpenDb.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbtnOpenDb.Name = "tbtnOpenDb"
        Me.tbtnOpenDb.Size = New System.Drawing.Size(29, 28)
        Me.tbtnOpenDb.Text = "Открыть базу данных"
        '
        'tbtnDisableDb
        '
        Me.tbtnDisableDb.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tbtnDisableDb.Enabled = False
        Me.tbtnDisableDb.Image = Global.CVR_10.My.Resources.Resources.data_delete
        Me.tbtnDisableDb.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbtnDisableDb.Name = "tbtnDisableDb"
        Me.tbtnDisableDb.Size = New System.Drawing.Size(29, 28)
        Me.tbtnDisableDb.Text = "Отсоединиться от базы данных"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 31)
        '
        'tbtnCvrStart
        '
        Me.tbtnCvrStart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tbtnCvrStart.Enabled = False
        Me.tbtnCvrStart.Image = Global.CVR_10.My.Resources.Resources.cpu_run
        Me.tbtnCvrStart.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbtnCvrStart.Name = "tbtnCvrStart"
        Me.tbtnCvrStart.Size = New System.Drawing.Size(29, 28)
        Me.tbtnCvrStart.Text = "Начать опрос реактиметра ЦВР-10"
        '
        'tbtnCvrStop
        '
        Me.tbtnCvrStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tbtnCvrStop.Enabled = False
        Me.tbtnCvrStop.Image = Global.CVR_10.My.Resources.Resources.cpu_stop
        Me.tbtnCvrStop.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbtnCvrStop.Name = "tbtnCvrStop"
        Me.tbtnCvrStop.Size = New System.Drawing.Size(29, 28)
        Me.tbtnCvrStop.Text = "Остановить опрос реактиметра ЦВР-10"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 31)
        '
        'tbtnContents
        '
        Me.tbtnContents.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tbtnContents.Image = Global.CVR_10.My.Resources.Resources.help2
        Me.tbtnContents.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbtnContents.Name = "tbtnContents"
        Me.tbtnContents.Size = New System.Drawing.Size(29, 28)
        Me.tbtnContents.Text = "Помощь"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmdSelectOll)
        Me.GroupBox1.Controls.Add(Me.nudKgChange)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.cmdUnSelectOll)
        Me.GroupBox1.Controls.Add(Me.pnlKgPosition)
        Me.GroupBox1.Location = New System.Drawing.Point(4, 5)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(0)
        Me.GroupBox1.Size = New System.Drawing.Size(436, 198)
        Me.GroupBox1.TabIndex = 66
        Me.GroupBox1.TabStop = False
        '
        'cmdSelectOll
        '
        Me.cmdSelectOll.AutoSize = True
        Me.cmdSelectOll.BackgroundImage = Global.CVR_10.My.Resources.Resources.check
        Me.cmdSelectOll.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.cmdSelectOll.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdSelectOll.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdSelectOll.Location = New System.Drawing.Point(372, 59)
        Me.cmdSelectOll.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdSelectOll.Name = "cmdSelectOll"
        Me.cmdSelectOll.Size = New System.Drawing.Size(47, 39)
        Me.cmdSelectOll.TabIndex = 1
        Me.cmdSelectOll.UseVisualStyleBackColor = True
        '
        'nudKgChange
        '
        Me.nudKgChange.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nudKgChange.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.nudKgChange.Location = New System.Drawing.Point(337, 155)
        Me.nudKgChange.Margin = New System.Windows.Forms.Padding(4)
        Me.nudKgChange.Maximum = New Decimal(New Integer() {1500, 0, 0, 0})
        Me.nudKgChange.Name = "nudKgChange"
        Me.nudKgChange.Size = New System.Drawing.Size(95, 34)
        Me.nudKgChange.TabIndex = 7
        Me.nudKgChange.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label4.Location = New System.Drawing.Point(5, 160)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(298, 34)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Изменение положения выделенных КГ" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "            (CG position changing)"
        '
        'cmdUnSelectOll
        '
        Me.cmdUnSelectOll.AutoSize = True
        Me.cmdUnSelectOll.BackgroundImage = Global.CVR_10.My.Resources.Resources.delete
        Me.cmdUnSelectOll.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.cmdUnSelectOll.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdUnSelectOll.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdUnSelectOll.Location = New System.Drawing.Point(372, 106)
        Me.cmdUnSelectOll.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdUnSelectOll.Name = "cmdUnSelectOll"
        Me.cmdUnSelectOll.Size = New System.Drawing.Size(47, 42)
        Me.cmdUnSelectOll.TabIndex = 2
        Me.cmdUnSelectOll.UseVisualStyleBackColor = True
        '
        'pnlKgPosition
        '
        Me.pnlKgPosition.Location = New System.Drawing.Point(4, 14)
        Me.pnlKgPosition.Margin = New System.Windows.Forms.Padding(4)
        Me.pnlKgPosition.Name = "pnlKgPosition"
        Me.pnlKgPosition.Size = New System.Drawing.Size(348, 134)
        Me.pnlKgPosition.TabIndex = 0
        '
        'cmdContinuousValue
        '
        Me.cmdContinuousValue.BackColor = System.Drawing.SystemColors.Control
        Me.cmdContinuousValue.Enabled = False
        Me.cmdContinuousValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.cmdContinuousValue.ForeColor = System.Drawing.Color.DarkRed
        Me.cmdContinuousValue.Location = New System.Drawing.Point(8, 196)
        Me.cmdContinuousValue.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdContinuousValue.Name = "cmdContinuousValue"
        Me.cmdContinuousValue.Size = New System.Drawing.Size(292, 36)
        Me.cmdContinuousValue.TabIndex = 72
        Me.cmdContinuousValue.Text = "Начать непрерывную запись"
        Me.cmdContinuousValue.UseVisualStyleBackColor = False
        '
        'cmdAvarageValue
        '
        Me.cmdAvarageValue.Enabled = False
        Me.cmdAvarageValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.cmdAvarageValue.ForeColor = System.Drawing.Color.DarkRed
        Me.cmdAvarageValue.Location = New System.Drawing.Point(8, 152)
        Me.cmdAvarageValue.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdAvarageValue.Name = "cmdAvarageValue"
        Me.cmdAvarageValue.Size = New System.Drawing.Size(292, 36)
        Me.cmdAvarageValue.TabIndex = 71
        Me.cmdAvarageValue.Text = "Начать усредненную запись"
        Me.cmdAvarageValue.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.nudExperNumb)
        Me.GroupBox4.Controls.Add(Me.GroupBox5)
        Me.GroupBox4.Controls.Add(Me.Label14)
        Me.GroupBox4.Location = New System.Drawing.Point(4, 4)
        Me.GroupBox4.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Padding = New System.Windows.Forms.Padding(0)
        Me.GroupBox4.Size = New System.Drawing.Size(296, 142)
        Me.GroupBox4.TabIndex = 70
        Me.GroupBox4.TabStop = False
        '
        'nudExperNumb
        '
        Me.nudExperNumb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nudExperNumb.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.nudExperNumb.Location = New System.Drawing.Point(215, 15)
        Me.nudExperNumb.Margin = New System.Windows.Forms.Padding(4)
        Me.nudExperNumb.Maximum = New Decimal(New Integer() {99, 0, 0, 0})
        Me.nudExperNumb.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudExperNumb.Name = "nudExperNumb"
        Me.nudExperNumb.Size = New System.Drawing.Size(65, 34)
        Me.nudExperNumb.TabIndex = 6
        Me.nudExperNumb.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.nudExperNumb.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.combo_dRo_dH)
        Me.GroupBox5.Controls.Add(Me.combo_AZ)
        Me.GroupBox5.Controls.Add(Me.rbtActiveGuard)
        Me.GroupBox5.Controls.Add(Me.rbt_dRo_dH)
        Me.GroupBox5.Location = New System.Drawing.Point(8, 54)
        Me.GroupBox5.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox5.Size = New System.Drawing.Size(284, 80)
        Me.GroupBox5.TabIndex = 5
        Me.GroupBox5.TabStop = False
        '
        'combo_dRo_dH
        '
        Me.combo_dRo_dH.FormattingEnabled = True
        Me.combo_dRo_dH.Location = New System.Drawing.Point(159, 12)
        Me.combo_dRo_dH.Margin = New System.Windows.Forms.Padding(4)
        Me.combo_dRo_dH.Name = "combo_dRo_dH"
        Me.combo_dRo_dH.Size = New System.Drawing.Size(117, 24)
        Me.combo_dRo_dH.TabIndex = 5
        '
        'combo_AZ
        '
        Me.combo_AZ.FormattingEnabled = True
        Me.combo_AZ.Location = New System.Drawing.Point(159, 43)
        Me.combo_AZ.Margin = New System.Windows.Forms.Padding(4)
        Me.combo_AZ.Name = "combo_AZ"
        Me.combo_AZ.Size = New System.Drawing.Size(119, 24)
        Me.combo_AZ.TabIndex = 4
        '
        'rbtActiveGuard
        '
        Me.rbtActiveGuard.AutoSize = True
        Me.rbtActiveGuard.Location = New System.Drawing.Point(5, 43)
        Me.rbtActiveGuard.Margin = New System.Windows.Forms.Padding(4)
        Me.rbtActiveGuard.Name = "rbtActiveGuard"
        Me.rbtActiveGuard.Size = New System.Drawing.Size(46, 20)
        Me.rbtActiveGuard.TabIndex = 1
        Me.rbtActiveGuard.Text = "EP"
        Me.rbtActiveGuard.UseVisualStyleBackColor = True
        '
        'rbt_dRo_dH
        '
        Me.rbt_dRo_dH.AutoSize = True
        Me.rbt_dRo_dH.Checked = True
        Me.rbt_dRo_dH.Location = New System.Drawing.Point(5, 17)
        Me.rbt_dRo_dH.Margin = New System.Windows.Forms.Padding(4)
        Me.rbt_dRo_dH.Name = "rbt_dRo_dH"
        Me.rbt_dRo_dH.Size = New System.Drawing.Size(76, 20)
        Me.rbt_dRo_dH.TabIndex = 0
        Me.rbt_dRo_dH.TabStop = True
        Me.rbt_dRo_dH.Text = "dRo/dH"
        Me.rbt_dRo_dH.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label14.Location = New System.Drawing.Point(12, 14)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(203, 37)
        Me.Label14.TabIndex = 0
        Me.Label14.Text = "Номер эксперимента по программе НФИ"
        '
        'tmrContRec
        '
        '
        'tmrGraph
        '
        '
        'tmrCheckCvrConnection
        '
        Me.tmrCheckCvrConnection.Interval = 1000
        '
        'sfdCreateDb
        '
        Me.sfdCreateDb.Filter = "Базы данных Access (*.mdb)|*.mdb"
        Me.sfdCreateDb.Title = "Новая база данных Access"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtReact)
        Me.GroupBox2.Controls.Add(Me.txtPressure)
        Me.GroupBox2.Controls.Add(Me.txtT)
        Me.GroupBox2.Controls.Add(Me.PictureBox1)
        Me.GroupBox2.Controls.Add(Me.txtPowerPwr)
        Me.GroupBox2.Controls.Add(Me.txtPowerMant)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.txtCurPwr)
        Me.GroupBox2.Controls.Add(Me.txtCurMant)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Location = New System.Drawing.Point(4, 211)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Size = New System.Drawing.Size(436, 268)
        Me.GroupBox2.TabIndex = 73
        Me.GroupBox2.TabStop = False
        '
        'txtReact
        '
        Me.txtReact.BackColor = System.Drawing.SystemColors.Control
        Me.txtReact.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtReact.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtReact.Location = New System.Drawing.Point(68, 23)
        Me.txtReact.Margin = New System.Windows.Forms.Padding(4)
        Me.txtReact.Name = "txtReact"
        Me.txtReact.Size = New System.Drawing.Size(134, 37)
        Me.txtReact.TabIndex = 104
        Me.txtReact.Text = "0"
        Me.txtReact.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPressure
        '
        Me.txtPressure.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPressure.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtPressure.Location = New System.Drawing.Point(68, 65)
        Me.txtPressure.Margin = New System.Windows.Forms.Padding(4)
        Me.txtPressure.Name = "txtPressure"
        Me.txtPressure.Size = New System.Drawing.Size(134, 37)
        Me.txtPressure.TabIndex = 103
        Me.txtPressure.Text = "0"
        Me.txtPressure.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtT
        '
        Me.txtT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtT.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtT.Location = New System.Drawing.Point(68, 110)
        Me.txtT.Margin = New System.Windows.Forms.Padding(4)
        Me.txtT.Name = "txtT"
        Me.txtT.Size = New System.Drawing.Size(134, 37)
        Me.txtT.TabIndex = 93
        Me.txtT.Text = "0"
        Me.txtT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = Global.CVR_10.My.Resources.Resources.CVR10_Sova
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox1.Location = New System.Drawing.Point(236, 23)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(165, 135)
        Me.PictureBox1.TabIndex = 102
        Me.PictureBox1.TabStop = False
        '
        'txtPowerPwr
        '
        Me.txtPowerPwr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPowerPwr.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtPowerPwr.Location = New System.Drawing.Point(287, 212)
        Me.txtPowerPwr.Margin = New System.Windows.Forms.Padding(4)
        Me.txtPowerPwr.Name = "txtPowerPwr"
        Me.txtPowerPwr.Size = New System.Drawing.Size(65, 37)
        Me.txtPowerPwr.TabIndex = 95
        Me.txtPowerPwr.Text = "0"
        Me.txtPowerPwr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPowerMant
        '
        Me.txtPowerMant.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPowerMant.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtPowerMant.Location = New System.Drawing.Point(68, 223)
        Me.txtPowerMant.Margin = New System.Windows.Forms.Padding(4)
        Me.txtPowerMant.Name = "txtPowerMant"
        Me.txtPowerMant.Size = New System.Drawing.Size(134, 37)
        Me.txtPowerMant.TabIndex = 92
        Me.txtPowerMant.Text = "0"
        Me.txtPowerMant.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Monotype Corsiva", 20.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label8.Location = New System.Drawing.Point(13, 219)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(43, 41)
        Me.Label8.TabIndex = 91
        Me.Label8.Text = "N"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label9.Location = New System.Drawing.Point(215, 228)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(24, 29)
        Me.Label9.TabIndex = 93
        Me.Label9.Text = "x"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label10.Location = New System.Drawing.Point(227, 219)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(64, 46)
        Me.Label10.TabIndex = 94
        Me.Label10.Text = "10"
        '
        'txtCurPwr
        '
        Me.txtCurPwr.BackColor = System.Drawing.SystemColors.Control
        Me.txtCurPwr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCurPwr.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtCurPwr.Location = New System.Drawing.Point(287, 166)
        Me.txtCurPwr.Margin = New System.Windows.Forms.Padding(4)
        Me.txtCurPwr.Name = "txtCurPwr"
        Me.txtCurPwr.Size = New System.Drawing.Size(65, 37)
        Me.txtCurPwr.TabIndex = 90
        Me.txtCurPwr.Text = "0"
        Me.txtCurPwr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCurMant
        '
        Me.txtCurMant.BackColor = System.Drawing.SystemColors.Control
        Me.txtCurMant.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCurMant.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtCurMant.Location = New System.Drawing.Point(68, 177)
        Me.txtCurMant.Margin = New System.Windows.Forms.Padding(4)
        Me.txtCurMant.Name = "txtCurMant"
        Me.txtCurMant.Size = New System.Drawing.Size(134, 37)
        Me.txtCurMant.TabIndex = 87
        Me.txtCurMant.Text = "0"
        Me.txtCurMant.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Monotype Corsiva", 20.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label7.Location = New System.Drawing.Point(13, 174)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(32, 41)
        Me.Label7.TabIndex = 86
        Me.Label7.Text = "I"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label5.Location = New System.Drawing.Point(215, 182)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(24, 29)
        Me.Label5.TabIndex = 88
        Me.Label5.Text = "x"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label6.Location = New System.Drawing.Point(227, 174)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(64, 46)
        Me.Label6.TabIndex = 89
        Me.Label6.Text = "10"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Symbol", 20.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label12.Location = New System.Drawing.Point(25, 17)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(37, 41)
        Me.Label12.TabIndex = 99
        Me.Label12.Text = "r"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label11.Location = New System.Drawing.Point(20, 60)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(41, 39)
        Me.Label11.TabIndex = 97
        Me.Label11.Text = "P"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label13.Location = New System.Drawing.Point(20, 105)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(39, 39)
        Me.Label13.TabIndex = 101
        Me.Label13.Text = "T"
        '
        'Label2
        '
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label2.Location = New System.Drawing.Point(0, 0)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(591, 17)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "График изменения реактивности (Reactivity)"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(571, 17)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "График изменения тока (Current)"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmdKspCurrentLimitChange
        '
        Me.cmdKspCurrentLimitChange.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdKspCurrentLimitChange.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.cmdKspCurrentLimitChange.Location = New System.Drawing.Point(156, 0)
        Me.cmdKspCurrentLimitChange.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdKspCurrentLimitChange.Name = "cmdKspCurrentLimitChange"
        Me.cmdKspCurrentLimitChange.Size = New System.Drawing.Size(242, 28)
        Me.cmdKspCurrentLimitChange.TabIndex = 9
        Me.cmdKspCurrentLimitChange.Text = "Set"
        Me.cmdKspCurrentLimitChange.UseVisualStyleBackColor = True
        '
        'cmdKspReactLimitChange
        '
        Me.cmdKspReactLimitChange.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdKspReactLimitChange.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.cmdKspReactLimitChange.Location = New System.Drawing.Point(183, 0)
        Me.cmdKspReactLimitChange.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdKspReactLimitChange.Name = "cmdKspReactLimitChange"
        Me.cmdKspReactLimitChange.Size = New System.Drawing.Size(252, 28)
        Me.cmdKspReactLimitChange.TabIndex = 8
        Me.cmdKspReactLimitChange.Text = "Set"
        Me.cmdKspReactLimitChange.UseVisualStyleBackColor = True
        '
        'txtKspReactMaxVal
        '
        Me.txtKspReactMaxVal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtKspReactMaxVal.Dock = System.Windows.Forms.DockStyle.Right
        Me.txtKspReactMaxVal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtKspReactMaxVal.Location = New System.Drawing.Point(532, 0)
        Me.txtKspReactMaxVal.Margin = New System.Windows.Forms.Padding(4)
        Me.txtKspReactMaxVal.Name = "txtKspReactMaxVal"
        Me.txtKspReactMaxVal.Size = New System.Drawing.Size(59, 26)
        Me.txtKspReactMaxVal.TabIndex = 7
        Me.txtKspReactMaxVal.Text = "0.5"
        Me.txtKspReactMaxVal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtKspCurrentMinVal
        '
        Me.txtKspCurrentMinVal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtKspCurrentMinVal.Dock = System.Windows.Forms.DockStyle.Left
        Me.txtKspCurrentMinVal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtKspCurrentMinVal.Location = New System.Drawing.Point(0, 0)
        Me.txtKspCurrentMinVal.Margin = New System.Windows.Forms.Padding(4)
        Me.txtKspCurrentMinVal.Name = "txtKspCurrentMinVal"
        Me.txtKspCurrentMinVal.Size = New System.Drawing.Size(59, 26)
        Me.txtKspCurrentMinVal.TabIndex = 6
        Me.txtKspCurrentMinVal.Text = "-0.1"
        Me.txtKspCurrentMinVal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtKspCurrentMaxVal
        '
        Me.txtKspCurrentMaxVal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtKspCurrentMaxVal.Dock = System.Windows.Forms.DockStyle.Right
        Me.txtKspCurrentMaxVal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtKspCurrentMaxVal.Location = New System.Drawing.Point(516, 0)
        Me.txtKspCurrentMaxVal.Margin = New System.Windows.Forms.Padding(4)
        Me.txtKspCurrentMaxVal.Name = "txtKspCurrentMaxVal"
        Me.txtKspCurrentMaxVal.Size = New System.Drawing.Size(55, 26)
        Me.txtKspCurrentMaxVal.TabIndex = 5
        Me.txtKspCurrentMaxVal.Text = "10"
        Me.txtKspCurrentMaxVal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtKspReactMinVal
        '
        Me.txtKspReactMinVal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtKspReactMinVal.Dock = System.Windows.Forms.DockStyle.Left
        Me.txtKspReactMinVal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtKspReactMinVal.Location = New System.Drawing.Point(0, 0)
        Me.txtKspReactMinVal.Margin = New System.Windows.Forms.Padding(4)
        Me.txtKspReactMinVal.Name = "txtKspReactMinVal"
        Me.txtKspReactMinVal.Size = New System.Drawing.Size(59, 26)
        Me.txtKspReactMinVal.TabIndex = 4
        Me.txtKspReactMinVal.Text = "-0.5"
        Me.txtKspReactMinVal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ofdOpenDb
        '
        Me.ofdOpenDb.Filter = "Базы данных Access (*.mdb)|*.mdb"
        Me.ofdOpenDb.Title = "Открыть базу данных Access"
        '
        'dgvAverageData
        '
        Me.dgvAverageData.AllowUserToAddRows = False
        Me.dgvAverageData.AllowUserToResizeRows = False
        Me.dgvAverageData.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgvAverageData.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ControlLightLight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvAverageData.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvAverageData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvAverageData.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvAverageData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvAverageData.Location = New System.Drawing.Point(0, 0)
        Me.dgvAverageData.Margin = New System.Windows.Forms.Padding(4)
        Me.dgvAverageData.MultiSelect = False
        Me.dgvAverageData.Name = "dgvAverageData"
        Me.dgvAverageData.RowHeadersVisible = False
        Me.dgvAverageData.RowHeadersWidth = 51
        Me.dgvAverageData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvAverageData.Size = New System.Drawing.Size(1089, 243)
        Me.dgvAverageData.TabIndex = 91
        '
        'dgvKgPosition
        '
        Me.dgvKgPosition.AllowUserToAddRows = False
        Me.dgvKgPosition.AllowUserToDeleteRows = False
        Me.dgvKgPosition.AllowUserToResizeRows = False
        Me.dgvKgPosition.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgvKgPosition.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ControlLightLight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvKgPosition.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvKgPosition.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvKgPosition.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgvKgPosition.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvKgPosition.Location = New System.Drawing.Point(0, 0)
        Me.dgvKgPosition.Margin = New System.Windows.Forms.Padding(4)
        Me.dgvKgPosition.MultiSelect = False
        Me.dgvKgPosition.Name = "dgvKgPosition"
        Me.dgvKgPosition.RowHeadersVisible = False
        Me.dgvKgPosition.RowHeadersWidth = 51
        Me.dgvKgPosition.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvKgPosition.Size = New System.Drawing.Size(209, 243)
        Me.dgvKgPosition.TabIndex = 90
        '
        'statMeasure
        '
        Me.statMeasure.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.statMeasure.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.slblAction, Me.slblDetails})
        Me.statMeasure.Location = New System.Drawing.Point(0, 785)
        Me.statMeasure.Name = "statMeasure"
        Me.statMeasure.Padding = New System.Windows.Forms.Padding(1, 0, 19, 0)
        Me.statMeasure.Size = New System.Drawing.Size(1615, 26)
        Me.statMeasure.TabIndex = 92
        Me.statMeasure.Text = "StatusStrip1"
        '
        'slblAction
        '
        Me.slblAction.Name = "slblAction"
        Me.slblAction.Size = New System.Drawing.Size(256, 20)
        Me.slblAction.Text = "Непрерывная запись остановлена "
        '
        'slblDetails
        '
        Me.slblDetails.Name = "slblDetails"
        Me.slblDetails.Size = New System.Drawing.Size(0, 20)
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 61)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.SplitContainer2)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainer3)
        Me.SplitContainer1.Size = New System.Drawing.Size(1615, 724)
        Me.SplitContainer1.SplitterDistance = 477
        Me.SplitContainer1.TabIndex = 93
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.SplitContainer5)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.GroupBox1)
        Me.SplitContainer2.Panel2.Controls.Add(Me.GroupBox2)
        Me.SplitContainer2.Size = New System.Drawing.Size(1615, 477)
        Me.SplitContainer2.SplitterDistance = 1166
        Me.SplitContainer2.TabIndex = 0
        '
        'SplitContainer5
        '
        Me.SplitContainer5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer5.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer5.Name = "SplitContainer5"
        '
        'SplitContainer5.Panel1
        '
        Me.SplitContainer5.Panel1.Controls.Add(Me.SplitContainer6)
        Me.SplitContainer5.Panel1.Controls.Add(Me.Label1)
        '
        'SplitContainer5.Panel2
        '
        Me.SplitContainer5.Panel2.Controls.Add(Me.SplitContainer7)
        Me.SplitContainer5.Panel2.Controls.Add(Me.Label2)
        Me.SplitContainer5.Size = New System.Drawing.Size(1166, 477)
        Me.SplitContainer5.SplitterDistance = 571
        Me.SplitContainer5.TabIndex = 0
        '
        'SplitContainer6
        '
        Me.SplitContainer6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer6.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.SplitContainer6.Location = New System.Drawing.Point(0, 17)
        Me.SplitContainer6.Name = "SplitContainer6"
        Me.SplitContainer6.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer6.Panel1
        '
        Me.SplitContainer6.Panel1.Controls.Add(Me.kspCurrent)
        '
        'SplitContainer6.Panel2
        '
        Me.SplitContainer6.Panel2.Controls.Add(Me.txtKspCurrentMinVal)
        Me.SplitContainer6.Panel2.Controls.Add(Me.cmdKspCurrentLimitChange)
        Me.SplitContainer6.Panel2.Controls.Add(Me.txtKspCurrentMaxVal)
        Me.SplitContainer6.Size = New System.Drawing.Size(571, 460)
        Me.SplitContainer6.SplitterDistance = 429
        Me.SplitContainer6.TabIndex = 18
        '
        'SplitContainer7
        '
        Me.SplitContainer7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer7.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.SplitContainer7.Location = New System.Drawing.Point(0, 17)
        Me.SplitContainer7.Name = "SplitContainer7"
        Me.SplitContainer7.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer7.Panel1
        '
        Me.SplitContainer7.Panel1.Controls.Add(Me.kspReactance)
        '
        'SplitContainer7.Panel2
        '
        Me.SplitContainer7.Panel2.Controls.Add(Me.txtKspReactMinVal)
        Me.SplitContainer7.Panel2.Controls.Add(Me.txtKspReactMaxVal)
        Me.SplitContainer7.Panel2.Controls.Add(Me.cmdKspReactLimitChange)
        Me.SplitContainer7.Size = New System.Drawing.Size(591, 460)
        Me.SplitContainer7.SplitterDistance = 429
        Me.SplitContainer7.TabIndex = 19
        '
        'SplitContainer3
        '
        Me.SplitContainer3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.SplitContainer3.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer3.Name = "SplitContainer3"
        '
        'SplitContainer3.Panel1
        '
        Me.SplitContainer3.Panel1.Controls.Add(Me.SplitContainer4)
        '
        'SplitContainer3.Panel2
        '
        Me.SplitContainer3.Panel2.Controls.Add(Me.GroupBox4)
        Me.SplitContainer3.Panel2.Controls.Add(Me.cmdAvarageValue)
        Me.SplitContainer3.Panel2.Controls.Add(Me.cmdContinuousValue)
        Me.SplitContainer3.Size = New System.Drawing.Size(1615, 243)
        Me.SplitContainer3.SplitterDistance = 1302
        Me.SplitContainer3.TabIndex = 0
        '
        'SplitContainer4
        '
        Me.SplitContainer4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer4.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.SplitContainer4.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer4.Name = "SplitContainer4"
        '
        'SplitContainer4.Panel1
        '
        Me.SplitContainer4.Panel1.Controls.Add(Me.dgvAverageData)
        '
        'SplitContainer4.Panel2
        '
        Me.SplitContainer4.Panel2.Controls.Add(Me.dgvKgPosition)
        Me.SplitContainer4.Size = New System.Drawing.Size(1302, 243)
        Me.SplitContainer4.SplitterDistance = 1089
        Me.SplitContainer4.TabIndex = 0
        '
        'kspCurrent
        '
        Me.kspCurrent.BackColor = System.Drawing.Color.White
        Me.kspCurrent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.kspCurrent.Dock = System.Windows.Forms.DockStyle.Fill
        Me.kspCurrent.InputVal = 0R
        Me.kspCurrent.Location = New System.Drawing.Point(0, 0)
        Me.kspCurrent.Margin = New System.Windows.Forms.Padding(5)
        Me.kspCurrent.MaxVal = 0R
        Me.kspCurrent.MinVal = 0R
        Me.kspCurrent.Name = "kspCurrent"
        Me.kspCurrent.NullLineColor = System.Drawing.Color.Red
        Me.kspCurrent.Size = New System.Drawing.Size(571, 429)
        Me.kspCurrent.TabIndex = 19
        Me.kspCurrent.ValLineColor = System.Drawing.Color.Black
        '
        'kspReactance
        '
        Me.kspReactance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.kspReactance.Dock = System.Windows.Forms.DockStyle.Fill
        Me.kspReactance.InputVal = 0R
        Me.kspReactance.Location = New System.Drawing.Point(0, 0)
        Me.kspReactance.Margin = New System.Windows.Forms.Padding(5)
        Me.kspReactance.MaxVal = 0R
        Me.kspReactance.MinVal = 0R
        Me.kspReactance.Name = "kspReactance"
        Me.kspReactance.NullLineColor = System.Drawing.Color.Red
        Me.kspReactance.Size = New System.Drawing.Size(591, 429)
        Me.kspReactance.TabIndex = 20
        Me.kspReactance.ValLineColor = System.Drawing.Color.Black
        '
        'frmMeasurement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1615, 811)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.statMeasure)
        Me.Controls.Add(Me.toolMeasurement)
        Me.Controls.Add(Me.mnuMeasurement)
        Me.MainMenuStrip = Me.mnuMeasurement
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmMeasurement"
        Me.Text = "ЦВР-10 (Измерения)"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.mnuMeasurement.ResumeLayout(False)
        Me.mnuMeasurement.PerformLayout()
        Me.toolMeasurement.ResumeLayout(False)
        Me.toolMeasurement.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.nudKgChange, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.nudExperNumb, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvAverageData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvKgPosition, System.ComponentModel.ISupportInitialize).EndInit()
        Me.statMeasure.ResumeLayout(False)
        Me.statMeasure.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        Me.SplitContainer2.ResumeLayout(False)
        Me.SplitContainer5.Panel1.ResumeLayout(False)
        Me.SplitContainer5.Panel2.ResumeLayout(False)
        Me.SplitContainer5.ResumeLayout(False)
        Me.SplitContainer6.Panel1.ResumeLayout(False)
        Me.SplitContainer6.Panel2.ResumeLayout(False)
        Me.SplitContainer6.Panel2.PerformLayout()
        Me.SplitContainer6.ResumeLayout(False)
        Me.SplitContainer7.Panel1.ResumeLayout(False)
        Me.SplitContainer7.Panel2.ResumeLayout(False)
        Me.SplitContainer7.Panel2.PerformLayout()
        Me.SplitContainer7.ResumeLayout(False)
        Me.SplitContainer3.Panel1.ResumeLayout(False)
        Me.SplitContainer3.Panel2.ResumeLayout(False)
        Me.SplitContainer3.ResumeLayout(False)
        Me.SplitContainer4.Panel1.ResumeLayout(False)
        Me.SplitContainer4.Panel2.ResumeLayout(False)
        Me.SplitContainer4.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents sptCvr As System.IO.Ports.SerialPort
    Friend WithEvents mnuMeasurement As System.Windows.Forms.MenuStrip
    Friend WithEvents mnuFile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tmnuExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDataBase As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tmnuCreateDb As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tmnuOpenDb As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tmnuDisableDb As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuComPort As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTools As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tmnuCoreType As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuHelp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolMeasurement As System.Windows.Forms.ToolStrip
    Friend WithEvents tmnuContRecInterval As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tmnuGraphSpeed As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tmnuKgStep As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tmnuApplySettings As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tmnuContents As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tmnuAbout As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tddbCoreType As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents tbtnApplySettings As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tbtnCreateDb As System.Windows.Forms.ToolStripButton
    Friend WithEvents tbtnOpenDb As System.Windows.Forms.ToolStripButton
    Friend WithEvents tbtnDisableDb As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tbtnCvrStart As System.Windows.Forms.ToolStripButton
    Friend WithEvents tbtnCvrStop As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tbtnContents As System.Windows.Forms.ToolStripButton
    Friend WithEvents ttxtContRecInterval As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ttxtGraphSpeed As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ttxtKgStep As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents nudKgChange As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmdUnSelectOll As System.Windows.Forms.Button
    Friend WithEvents cmdSelectOll As System.Windows.Forms.Button
    Friend WithEvents pnlKgPosition As System.Windows.Forms.Panel
    Friend WithEvents cmdContinuousValue As System.Windows.Forms.Button
    Friend WithEvents cmdAvarageValue As System.Windows.Forms.Button
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents nudExperNumb As System.Windows.Forms.NumericUpDown
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents combo_dRo_dH As System.Windows.Forms.ComboBox
    Friend WithEvents combo_AZ As System.Windows.Forms.ComboBox
    Friend WithEvents rbtActiveGuard As System.Windows.Forms.RadioButton
    Friend WithEvents rbt_dRo_dH As System.Windows.Forms.RadioButton
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents tddbComPort As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents tmrContRec As System.Windows.Forms.Timer
    Friend WithEvents tmrGraph As System.Windows.Forms.Timer
    Friend WithEvents tmrCheckCvrConnection As System.Windows.Forms.Timer
    Friend WithEvents sfdCreateDb As System.Windows.Forms.SaveFileDialog
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtPowerPwr As System.Windows.Forms.TextBox
    Friend WithEvents txtPowerMant As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtCurPwr As System.Windows.Forms.TextBox
    Friend WithEvents txtCurMant As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdKspCurrentLimitChange As System.Windows.Forms.Button
    Friend WithEvents cmdKspReactLimitChange As System.Windows.Forms.Button
    Friend WithEvents txtKspReactMaxVal As System.Windows.Forms.TextBox
    Friend WithEvents txtKspCurrentMinVal As System.Windows.Forms.TextBox
    Friend WithEvents txtKspCurrentMaxVal As System.Windows.Forms.TextBox
    Friend WithEvents txtKspReactMinVal As System.Windows.Forms.TextBox
    Friend WithEvents kspReactance As CVR_10.KSP
    Friend WithEvents kspCurrent As CVR_10.KSP
    Friend WithEvents ofdOpenDb As System.Windows.Forms.OpenFileDialog
    Friend WithEvents dgvAverageData As System.Windows.Forms.DataGridView
    Friend WithEvents dgvKgPosition As System.Windows.Forms.DataGridView
    Friend WithEvents statMeasure As System.Windows.Forms.StatusStrip
    Friend WithEvents slblAction As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents slblDetails As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents txtReact As System.Windows.Forms.TextBox
    Friend WithEvents txtPressure As System.Windows.Forms.TextBox
    Friend WithEvents txtT As System.Windows.Forms.TextBox
    Friend WithEvents tmnuShowStart As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents SplitContainer2 As SplitContainer
    Friend WithEvents SplitContainer3 As SplitContainer
    Friend WithEvents SplitContainer4 As SplitContainer
    Friend WithEvents SplitContainer5 As SplitContainer
    Friend WithEvents SplitContainer6 As SplitContainer
    Friend WithEvents SplitContainer7 As SplitContainer
End Class
