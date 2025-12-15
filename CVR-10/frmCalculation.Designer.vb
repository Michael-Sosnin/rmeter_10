<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCalculation
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCalculation))
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.statCalc = New System.Windows.Forms.StatusStrip
        Me.lblStatus = New System.Windows.Forms.ToolStripStatusLabel
        Me.tpbrExcelProcessing = New System.Windows.Forms.ToolStripProgressBar
        Me.toolCalc = New System.Windows.Forms.ToolStrip
        Me.tbtnDbConnect = New System.Windows.Forms.ToolStripButton
        Me.tbtnDbDisable = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.tddb_dT = New System.Windows.Forms.ToolStripDropDownButton
        Me.ttxt_dT1 = New System.Windows.Forms.ToolStripTextBox
        Me.tddb_TCold = New System.Windows.Forms.ToolStripDropDownButton
        Me.ttxt_TCold1 = New System.Windows.Forms.ToolStripTextBox
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.tbtnCalculate = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator
        Me.tbtnContent = New System.Windows.Forms.ToolStripButton
        Me.mnuCalc = New System.Windows.Forms.MenuStrip
        Me.mnuFile = New System.Windows.Forms.ToolStripMenuItem
        Me.tmnuClose = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuDataBase = New System.Windows.Forms.ToolStripMenuItem
        Me.tmnuDbConnect = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.tmnuDbDisable = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuTools = New System.Windows.Forms.ToolStripMenuItem
        Me.tmnu_dT = New System.Windows.Forms.ToolStripMenuItem
        Me.ttxt_dT = New System.Windows.Forms.ToolStripTextBox
        Me.tmnu_TCold = New System.Windows.Forms.ToolStripMenuItem
        Me.ttxt_TCold = New System.Windows.Forms.ToolStripTextBox
        Me.tmnuChartTools = New System.Windows.Forms.ToolStripMenuItem
        Me.XMajorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ttxtXMajorUnit = New System.Windows.Forms.ToolStripTextBox
        Me.XMinorUnitСекToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ttxtXMinorUnit = New System.Windows.Forms.ToolStripTextBox
        Me.mnuHelp = New System.Windows.Forms.ToolStripMenuItem
        Me.tmnuContent = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.tmnuAbout = New System.Windows.Forms.ToolStripMenuItem
        Me.cmdCalculate = New System.Windows.Forms.Button
        Me.ofdOpenDb = New System.Windows.Forms.OpenFileDialog
        Me.dgvAverageData = New System.Windows.Forms.DataGridView
        Me.dgvKgPosition = New System.Windows.Forms.DataGridView
        Me.gbxDbInform = New System.Windows.Forms.GroupBox
        Me.lblCvrDataRecCount = New System.Windows.Forms.Label
        Me.lblContDataRecCount = New System.Windows.Forms.Label
        Me.lblCoreType = New System.Windows.Forms.Label
        Me.lblCvrDataTStop = New System.Windows.Forms.Label
        Me.lblContDataTStop = New System.Windows.Forms.Label
        Me.lblCvrDataTStart = New System.Windows.Forms.Label
        Me.lblContDataTStart = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.tmnuShowStart = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator
        Me.statCalc.SuspendLayout()
        Me.toolCalc.SuspendLayout()
        Me.mnuCalc.SuspendLayout()
        CType(Me.dgvAverageData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvKgPosition, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbxDbInform.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'statCalc
        '
        Me.statCalc.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblStatus, Me.tpbrExcelProcessing})
        Me.statCalc.Location = New System.Drawing.Point(0, 483)
        Me.statCalc.Name = "statCalc"
        Me.statCalc.Size = New System.Drawing.Size(806, 22)
        Me.statCalc.TabIndex = 0
        Me.statCalc.Text = "StatusStrip1"
        '
        'lblStatus
        '
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(47, 17)
        Me.lblStatus.Text = "Готово."
        '
        'tpbrExcelProcessing
        '
        Me.tpbrExcelProcessing.Name = "tpbrExcelProcessing"
        Me.tpbrExcelProcessing.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.tpbrExcelProcessing.Size = New System.Drawing.Size(600, 16)
        Me.tpbrExcelProcessing.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.tpbrExcelProcessing.Visible = False
        '
        'toolCalc
        '
        Me.toolCalc.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tbtnDbConnect, Me.tbtnDbDisable, Me.ToolStripSeparator2, Me.tddb_dT, Me.tddb_TCold, Me.ToolStripSeparator3, Me.tbtnCalculate, Me.ToolStripSeparator5, Me.tbtnContent})
        Me.toolCalc.Location = New System.Drawing.Point(0, 24)
        Me.toolCalc.Name = "toolCalc"
        Me.toolCalc.Size = New System.Drawing.Size(806, 25)
        Me.toolCalc.TabIndex = 1
        Me.toolCalc.Text = "ToolStrip1"
        '
        'tbtnDbConnect
        '
        Me.tbtnDbConnect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tbtnDbConnect.Image = Global.CVR_10.My.Resources.Resources.data_view
        Me.tbtnDbConnect.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbtnDbConnect.Name = "tbtnDbConnect"
        Me.tbtnDbConnect.Size = New System.Drawing.Size(23, 22)
        Me.tbtnDbConnect.Text = "Подключиться к базе данных Access"
        '
        'tbtnDbDisable
        '
        Me.tbtnDbDisable.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tbtnDbDisable.Enabled = False
        Me.tbtnDbDisable.Image = Global.CVR_10.My.Resources.Resources.data_delete
        Me.tbtnDbDisable.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbtnDbDisable.Name = "tbtnDbDisable"
        Me.tbtnDbDisable.Size = New System.Drawing.Size(23, 22)
        Me.tbtnDbDisable.Text = "Отключиться от базы данных Access"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'tddb_dT
        '
        Me.tddb_dT.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tddb_dT.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ttxt_dT1})
        Me.tddb_dT.Image = CType(resources.GetObject("tddb_dT.Image"), System.Drawing.Image)
        Me.tddb_dT.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tddb_dT.Name = "tddb_dT"
        Me.tddb_dT.Size = New System.Drawing.Size(32, 22)
        Me.tddb_dT.Text = "dT"
        '
        'ttxt_dT1
        '
        Me.ttxt_dT1.Name = "ttxt_dT1"
        Me.ttxt_dT1.Size = New System.Drawing.Size(100, 21)
        Me.ttxt_dT1.Text = "2"
        '
        'tddb_TCold
        '
        Me.tddb_TCold.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tddb_TCold.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ttxt_TCold1})
        Me.tddb_TCold.Image = CType(resources.GetObject("tddb_TCold.Image"), System.Drawing.Image)
        Me.tddb_TCold.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tddb_TCold.Name = "tddb_TCold"
        Me.tddb_TCold.Size = New System.Drawing.Size(48, 22)
        Me.tddb_TCold.Text = "Tхол."
        '
        'ttxt_TCold1
        '
        Me.ttxt_TCold1.Name = "ttxt_TCold1"
        Me.ttxt_TCold1.Size = New System.Drawing.Size(100, 21)
        Me.ttxt_TCold1.Text = "5"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'tbtnCalculate
        '
        Me.tbtnCalculate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tbtnCalculate.Enabled = False
        Me.tbtnCalculate.Image = Global.CVR_10.My.Resources.Resources.calculator
        Me.tbtnCalculate.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbtnCalculate.Name = "tbtnCalculate"
        Me.tbtnCalculate.Size = New System.Drawing.Size(23, 22)
        Me.tbtnCalculate.Text = "Обработать базу данных"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 25)
        '
        'tbtnContent
        '
        Me.tbtnContent.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tbtnContent.Image = Global.CVR_10.My.Resources.Resources.help2
        Me.tbtnContent.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbtnContent.Name = "tbtnContent"
        Me.tbtnContent.Size = New System.Drawing.Size(23, 22)
        Me.tbtnContent.Text = "Помощь"
        '
        'mnuCalc
        '
        Me.mnuCalc.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuFile, Me.mnuDataBase, Me.mnuTools, Me.mnuHelp})
        Me.mnuCalc.Location = New System.Drawing.Point(0, 0)
        Me.mnuCalc.Name = "mnuCalc"
        Me.mnuCalc.Size = New System.Drawing.Size(806, 24)
        Me.mnuCalc.TabIndex = 2
        Me.mnuCalc.Text = "MenuStrip1"
        '
        'mnuFile
        '
        Me.mnuFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tmnuShowStart, Me.ToolStripSeparator6, Me.tmnuClose})
        Me.mnuFile.Name = "mnuFile"
        Me.mnuFile.Size = New System.Drawing.Size(45, 20)
        Me.mnuFile.Text = "Файл"
        '
        'tmnuClose
        '
        Me.tmnuClose.Image = Global.CVR_10.My.Resources.Resources.delete2
        Me.tmnuClose.Name = "tmnuClose"
        Me.tmnuClose.Size = New System.Drawing.Size(175, 22)
        Me.tmnuClose.Text = "Закрыть"
        '
        'mnuDataBase
        '
        Me.mnuDataBase.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tmnuDbConnect, Me.ToolStripSeparator1, Me.tmnuDbDisable})
        Me.mnuDataBase.Name = "mnuDataBase"
        Me.mnuDataBase.Size = New System.Drawing.Size(87, 20)
        Me.mnuDataBase.Text = "Базы Данных"
        '
        'tmnuDbConnect
        '
        Me.tmnuDbConnect.Image = Global.CVR_10.My.Resources.Resources.data_view
        Me.tmnuDbConnect.Name = "tmnuDbConnect"
        Me.tmnuDbConnect.Size = New System.Drawing.Size(167, 22)
        Me.tmnuDbConnect.Text = "Подключить БД"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(164, 6)
        '
        'tmnuDbDisable
        '
        Me.tmnuDbDisable.Enabled = False
        Me.tmnuDbDisable.Image = Global.CVR_10.My.Resources.Resources.data_delete
        Me.tmnuDbDisable.Name = "tmnuDbDisable"
        Me.tmnuDbDisable.Size = New System.Drawing.Size(167, 22)
        Me.tmnuDbDisable.Text = "Отключить БД"
        '
        'mnuTools
        '
        Me.mnuTools.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tmnu_dT, Me.tmnu_TCold, Me.tmnuChartTools})
        Me.mnuTools.Name = "mnuTools"
        Me.mnuTools.Size = New System.Drawing.Size(73, 20)
        Me.mnuTools.Text = "Настройки"
        '
        'tmnu_dT
        '
        Me.tmnu_dT.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ttxt_dT})
        Me.tmnu_dT.Name = "tmnu_dT"
        Me.tmnu_dT.Size = New System.Drawing.Size(280, 22)
        Me.tmnu_dT.Text = "Погрешность Т, °С."
        '
        'ttxt_dT
        '
        Me.ttxt_dT.Name = "ttxt_dT"
        Me.ttxt_dT.Size = New System.Drawing.Size(100, 21)
        Me.ttxt_dT.Text = "2"
        '
        'tmnu_TCold
        '
        Me.tmnu_TCold.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ttxt_TCold})
        Me.tmnu_TCold.Name = "tmnu_TCold"
        Me.tmnu_TCold.Size = New System.Drawing.Size(280, 22)
        Me.tmnu_TCold.Text = "Температура холодных измерений, °С"
        '
        'ttxt_TCold
        '
        Me.ttxt_TCold.Name = "ttxt_TCold"
        Me.ttxt_TCold.Size = New System.Drawing.Size(100, 21)
        Me.ttxt_TCold.Text = "5"
        '
        'tmnuChartTools
        '
        Me.tmnuChartTools.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.XMajorToolStripMenuItem, Me.XMinorUnitСекToolStripMenuItem})
        Me.tmnuChartTools.Name = "tmnuChartTools"
        Me.tmnuChartTools.Size = New System.Drawing.Size(280, 22)
        Me.tmnuChartTools.Text = "Настройки отображения графиков"
        '
        'XMajorToolStripMenuItem
        '
        Me.XMajorToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ttxtXMajorUnit})
        Me.XMajorToolStripMenuItem.Name = "XMajorToolStripMenuItem"
        Me.XMajorToolStripMenuItem.Size = New System.Drawing.Size(166, 22)
        Me.XMajorToolStripMenuItem.Text = "XMajorUnit, мин."
        '
        'ttxtXMajorUnit
        '
        Me.ttxtXMajorUnit.Name = "ttxtXMajorUnit"
        Me.ttxtXMajorUnit.Size = New System.Drawing.Size(100, 21)
        Me.ttxtXMajorUnit.Text = "1"
        '
        'XMinorUnitСекToolStripMenuItem
        '
        Me.XMinorUnitСекToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ttxtXMinorUnit})
        Me.XMinorUnitСекToolStripMenuItem.Name = "XMinorUnitСекToolStripMenuItem"
        Me.XMinorUnitСекToolStripMenuItem.Size = New System.Drawing.Size(166, 22)
        Me.XMinorUnitСекToolStripMenuItem.Text = "XMinorUnit, сек."
        '
        'ttxtXMinorUnit
        '
        Me.ttxtXMinorUnit.Name = "ttxtXMinorUnit"
        Me.ttxtXMinorUnit.Size = New System.Drawing.Size(100, 21)
        Me.ttxtXMinorUnit.Text = "10"
        '
        'mnuHelp
        '
        Me.mnuHelp.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tmnuContent, Me.ToolStripSeparator4, Me.tmnuAbout})
        Me.mnuHelp.Name = "mnuHelp"
        Me.mnuHelp.Size = New System.Drawing.Size(59, 20)
        Me.mnuHelp.Text = "Помощь"
        '
        'tmnuContent
        '
        Me.tmnuContent.Image = Global.CVR_10.My.Resources.Resources.help2
        Me.tmnuContent.Name = "tmnuContent"
        Me.tmnuContent.Size = New System.Drawing.Size(152, 22)
        Me.tmnuContent.Text = "Описание"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(146, 6)
        '
        'tmnuAbout
        '
        Me.tmnuAbout.Name = "tmnuAbout"
        Me.tmnuAbout.Size = New System.Drawing.Size(152, 22)
        Me.tmnuAbout.Text = "О программе"
        '
        'cmdCalculate
        '
        Me.cmdCalculate.Enabled = False
        Me.cmdCalculate.Location = New System.Drawing.Point(644, 438)
        Me.cmdCalculate.Name = "cmdCalculate"
        Me.cmdCalculate.Size = New System.Drawing.Size(136, 23)
        Me.cmdCalculate.TabIndex = 3
        Me.cmdCalculate.Text = "Обработать БД"
        Me.cmdCalculate.UseVisualStyleBackColor = True
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
        Me.dgvAverageData.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.dgvAverageData.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        DataGridViewCellStyle17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        DataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.ControlLightLight
        DataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvAverageData.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle17
        Me.dgvAverageData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        DataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle18.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvAverageData.DefaultCellStyle = DataGridViewCellStyle18
        Me.dgvAverageData.Location = New System.Drawing.Point(4, 244)
        Me.dgvAverageData.MultiSelect = False
        Me.dgvAverageData.Name = "dgvAverageData"
        Me.dgvAverageData.RowHeadersVisible = False
        Me.dgvAverageData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvAverageData.Size = New System.Drawing.Size(617, 224)
        Me.dgvAverageData.TabIndex = 93
        '
        'dgvKgPosition
        '
        Me.dgvKgPosition.AllowUserToAddRows = False
        Me.dgvKgPosition.AllowUserToDeleteRows = False
        Me.dgvKgPosition.AllowUserToResizeRows = False
        Me.dgvKgPosition.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.dgvKgPosition.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical
        DataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        DataGridViewCellStyle19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        DataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.ControlLightLight
        DataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvKgPosition.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle19
        Me.dgvKgPosition.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle20.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        DataGridViewCellStyle20.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle20.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvKgPosition.DefaultCellStyle = DataGridViewCellStyle20
        Me.dgvKgPosition.Location = New System.Drawing.Point(627, 244)
        Me.dgvKgPosition.MultiSelect = False
        Me.dgvKgPosition.Name = "dgvKgPosition"
        Me.dgvKgPosition.RowHeadersVisible = False
        Me.dgvKgPosition.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvKgPosition.Size = New System.Drawing.Size(167, 183)
        Me.dgvKgPosition.TabIndex = 92
        '
        'gbxDbInform
        '
        Me.gbxDbInform.Controls.Add(Me.lblCvrDataRecCount)
        Me.gbxDbInform.Controls.Add(Me.lblContDataRecCount)
        Me.gbxDbInform.Controls.Add(Me.lblCoreType)
        Me.gbxDbInform.Controls.Add(Me.lblCvrDataTStop)
        Me.gbxDbInform.Controls.Add(Me.lblContDataTStop)
        Me.gbxDbInform.Controls.Add(Me.lblCvrDataTStart)
        Me.gbxDbInform.Controls.Add(Me.lblContDataTStart)
        Me.gbxDbInform.Controls.Add(Me.Label7)
        Me.gbxDbInform.Controls.Add(Me.Label6)
        Me.gbxDbInform.Controls.Add(Me.Label5)
        Me.gbxDbInform.Controls.Add(Me.Label4)
        Me.gbxDbInform.Controls.Add(Me.Label3)
        Me.gbxDbInform.Controls.Add(Me.Label2)
        Me.gbxDbInform.Controls.Add(Me.Label1)
        Me.gbxDbInform.Location = New System.Drawing.Point(4, 52)
        Me.gbxDbInform.Name = "gbxDbInform"
        Me.gbxDbInform.Size = New System.Drawing.Size(617, 186)
        Me.gbxDbInform.TabIndex = 94
        Me.gbxDbInform.TabStop = False
        Me.gbxDbInform.Text = "Информация о БД"
        '
        'lblCvrDataRecCount
        '
        Me.lblCvrDataRecCount.AutoSize = True
        Me.lblCvrDataRecCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lblCvrDataRecCount.Location = New System.Drawing.Point(286, 66)
        Me.lblCvrDataRecCount.Name = "lblCvrDataRecCount"
        Me.lblCvrDataRecCount.Size = New System.Drawing.Size(13, 16)
        Me.lblCvrDataRecCount.TabIndex = 13
        Me.lblCvrDataRecCount.Text = "-"
        '
        'lblContDataRecCount
        '
        Me.lblContDataRecCount.AutoSize = True
        Me.lblContDataRecCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lblContDataRecCount.Location = New System.Drawing.Point(332, 43)
        Me.lblContDataRecCount.Name = "lblContDataRecCount"
        Me.lblContDataRecCount.Size = New System.Drawing.Size(13, 16)
        Me.lblContDataRecCount.TabIndex = 12
        Me.lblContDataRecCount.Text = "-"
        '
        'lblCoreType
        '
        Me.lblCoreType.AutoSize = True
        Me.lblCoreType.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lblCoreType.Location = New System.Drawing.Point(139, 23)
        Me.lblCoreType.Name = "lblCoreType"
        Me.lblCoreType.Size = New System.Drawing.Size(13, 16)
        Me.lblCoreType.TabIndex = 11
        Me.lblCoreType.Text = "-"
        '
        'lblCvrDataTStop
        '
        Me.lblCvrDataTStop.AutoSize = True
        Me.lblCvrDataTStop.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lblCvrDataTStop.Location = New System.Drawing.Point(476, 141)
        Me.lblCvrDataTStop.Name = "lblCvrDataTStop"
        Me.lblCvrDataTStop.Size = New System.Drawing.Size(13, 16)
        Me.lblCvrDataTStop.TabIndex = 10
        Me.lblCvrDataTStop.Text = "-"
        Me.lblCvrDataTStop.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblContDataTStop
        '
        Me.lblContDataTStop.AutoSize = True
        Me.lblContDataTStop.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lblContDataTStop.Location = New System.Drawing.Point(268, 141)
        Me.lblContDataTStop.Name = "lblContDataTStop"
        Me.lblContDataTStop.Size = New System.Drawing.Size(13, 16)
        Me.lblContDataTStop.TabIndex = 9
        Me.lblContDataTStop.Text = "-"
        Me.lblContDataTStop.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCvrDataTStart
        '
        Me.lblCvrDataTStart.AutoSize = True
        Me.lblCvrDataTStart.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lblCvrDataTStart.Location = New System.Drawing.Point(476, 116)
        Me.lblCvrDataTStart.Name = "lblCvrDataTStart"
        Me.lblCvrDataTStart.Size = New System.Drawing.Size(13, 16)
        Me.lblCvrDataTStart.TabIndex = 8
        Me.lblCvrDataTStart.Text = "-"
        Me.lblCvrDataTStart.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblContDataTStart
        '
        Me.lblContDataTStart.AutoSize = True
        Me.lblContDataTStart.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lblContDataTStart.Location = New System.Drawing.Point(268, 116)
        Me.lblContDataTStart.Name = "lblContDataTStart"
        Me.lblContDataTStart.Size = New System.Drawing.Size(13, 16)
        Me.lblContDataTStart.TabIndex = 7
        Me.lblContDataTStart.Text = "-"
        Me.lblContDataTStart.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label7.Location = New System.Drawing.Point(476, 94)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(57, 16)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "CvrData"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label6.Location = New System.Drawing.Point(257, 94)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(103, 16)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "ContinuousData"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label5.Location = New System.Drawing.Point(12, 141)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(176, 16)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Время последней записи:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label4.Location = New System.Drawing.Point(12, 116)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(153, 16)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Время первой записи:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 66)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(268, 16)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Количество записей в таблице CvrData:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(314, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Количество записей в таблице ContinuousData:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(121, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Тип проекта а.з. :"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = Global.CVR_10.My.Resources.Resources.CVR10_Sova
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox1.Location = New System.Drawing.Point(648, 85)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(124, 134)
        Me.PictureBox1.TabIndex = 103
        Me.PictureBox1.TabStop = False
        '
        'tmnuShowStart
        '
        Me.tmnuShowStart.Name = "tmnuShowStart"
        Me.tmnuShowStart.Size = New System.Drawing.Size(175, 22)
        Me.tmnuShowStart.Text = "Стартовая форма"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(172, 6)
        '
        'frmCalculation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(806, 505)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.gbxDbInform)
        Me.Controls.Add(Me.dgvAverageData)
        Me.Controls.Add(Me.dgvKgPosition)
        Me.Controls.Add(Me.cmdCalculate)
        Me.Controls.Add(Me.toolCalc)
        Me.Controls.Add(Me.statCalc)
        Me.Controls.Add(Me.mnuCalc)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MainMenuStrip = Me.mnuCalc
        Me.MaximizeBox = False
        Me.Name = "frmCalculation"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ЦВР-10 (Обработка результатов)"
        Me.statCalc.ResumeLayout(False)
        Me.statCalc.PerformLayout()
        Me.toolCalc.ResumeLayout(False)
        Me.toolCalc.PerformLayout()
        Me.mnuCalc.ResumeLayout(False)
        Me.mnuCalc.PerformLayout()
        CType(Me.dgvAverageData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvKgPosition, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbxDbInform.ResumeLayout(False)
        Me.gbxDbInform.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents statCalc As System.Windows.Forms.StatusStrip
    Friend WithEvents toolCalc As System.Windows.Forms.ToolStrip
    Friend WithEvents mnuCalc As System.Windows.Forms.MenuStrip
    Friend WithEvents mnuFile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tmnuClose As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDataBase As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tmnuDbConnect As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tmnuDbDisable As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTools As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tmnu_dT As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tmnu_TCold As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tbtnDbConnect As System.Windows.Forms.ToolStripButton
    Friend WithEvents tbtnDbDisable As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tddb_dT As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents ttxt_dT1 As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents tddb_TCold As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents ttxt_TCold1 As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuHelp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tmnuContent As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tmnuAbout As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tbtnCalculate As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tbtnContent As System.Windows.Forms.ToolStripButton
    Friend WithEvents ttxt_dT As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ttxt_TCold As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents cmdCalculate As System.Windows.Forms.Button
    Friend WithEvents ofdOpenDb As System.Windows.Forms.OpenFileDialog
    Friend WithEvents dgvAverageData As System.Windows.Forms.DataGridView
    Friend WithEvents dgvKgPosition As System.Windows.Forms.DataGridView
    Friend WithEvents gbxDbInform As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblCvrDataTStart As System.Windows.Forms.Label
    Friend WithEvents lblContDataTStart As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblCvrDataRecCount As System.Windows.Forms.Label
    Friend WithEvents lblContDataRecCount As System.Windows.Forms.Label
    Friend WithEvents lblCoreType As System.Windows.Forms.Label
    Friend WithEvents lblCvrDataTStop As System.Windows.Forms.Label
    Friend WithEvents lblContDataTStop As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents lblStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tpbrExcelProcessing As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents tmnuChartTools As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents XMajorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ttxtXMajorUnit As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents XMinorUnitСекToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ttxtXMinorUnit As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents tmnuShowStart As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
End Class
