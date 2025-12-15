Module modCalc

    Public strSystemPath1 As String = Directory.GetCurrentDirectory

    Structure Val
        Dim Time As Double
        Dim Ro As Double
        Dim Temper As Double

        Sub New(ByVal dblRo As Double, ByVal dblTime As Double, ByVal dblTemper As Double)
            Me.Ro = dblRo
            Me.Time = dblTime
            Me.Temper = dblTemper
        End Sub
    End Structure

    ' Тип данных для хранения результатов обработки
    ' последнего отсчета
    Structure udtLastSampleAvg
        Dim lngSamples As Long              ' Объем выборки (число отсчетов)
        Dim dblKRo As Double                ' Скорость изменения реактивности
        Dim dblBRo As Double                ' Реактивность в момент остановки съема
        Dim dblRoAvg As Double              ' Средняя за время съема реактивность
        Dim dblKT As Double                 ' Скорость изменения температуры
        Dim dblBT As Double                 ' Температура в момент остановки съема
        Dim dblTAvg As Double               ' Средняя за время съема температура
    End Structure


    ' Хранилище отсчетов реактивностей
    Private rstROs As New System.Collections.ArrayList
    Public lngStartTime As Long         ' Время начала отсчетов


    Public Sub AddSample(ByVal dblRo As Double, ByVal dblT As Double)
        Dim a As New Val
        With a
            .Ro = dblRo
            .Temper = dblT
            .Time = CDbl(Now.Ticks() - lngStartTime) / 10000000.0
        End With
        rstROs.Add(a)
    End Sub

    Public Sub CalcLastSample(ByRef udtSampleResult As udtLastSampleAvg)
        Dim dblNow As Double                      ' Текущее время в секундах
        Dim lngSamples As Long                  ' Число имеющихся отсчетов
        Dim dblSumT As Double                   ' Сумма задержек (в секундах)
        Dim dblSumT2 As Double                  ' Сумма квадратов задержек
        Dim dblSumTemper As Double              ' Сумма температур
        Dim dblSumTTemper As Double             ' Сумма произведений Temp*Time
        Dim dblSumRo As Double                  ' Сумма реактивностей
        Dim dblSumTRo As Double                 ' Сумма произведений Ro*Time
        Dim dblTimeSample As Double             ' Время отсчета
        Dim dblTempSample As Double             ' Температура отсчета
        Dim dblRoSample As Double               ' Реактивность отсчета
        Dim dblD As Double                      ' Детерминант матрицы
        Dim dblDKT As Double                    ' Детерминант для KT
        Dim dblDKRo As Double                   ' Детерминант для KRo
        Dim dblDBT As Double                    ' Детерминант для BT
        Dim dblDBRo As Double                   ' Детерминант для BRo
        Dim dblKT As Double, dblBT As Double
        Dim dblKRo As Double, dblBRo As Double

        dblNow = CDbl(Now.Ticks() - lngStartTime) / 10000000.0


        ' Инициализация переменных для метода наименьших квадратов
        dblSumT = 0
        dblSumT2 = 0
        dblSumTemper = 0
        dblSumTTemper = 0
        dblSumRo = 0
        dblSumTRo = 0

        lngSamples = rstROs.Count

        For Each a As Val In rstROs
            dblTimeSample = (a.Time)
            dblTempSample = a.Temper
            dblRoSample = a.Ro
            dblSumT = dblSumT + dblTimeSample
            dblSumT2 = dblSumT2 + dblTimeSample ^ 2
            dblSumTemper = dblSumTemper + dblTempSample
            dblSumTTemper = dblSumTTemper + dblTimeSample * dblTempSample
            dblSumRo = dblSumRo + dblRoSample
            dblSumTRo = dblSumTRo + dblTimeSample * dblRoSample
        Next

        dblD = dblSumT2 * lngSamples - dblSumT * dblSumT
        dblDKT = dblSumTTemper * lngSamples - dblSumTemper * dblSumT
        dblDKRo = dblSumTRo * lngSamples - dblSumRo * dblSumT
        dblDBT = dblSumT2 * dblSumTemper - dblSumT * dblSumTTemper
        dblDBRo = dblSumT2 * dblSumRo - dblSumT * dblSumTRo

        dblKT = dblDKT / dblD
        dblBT = dblDBT / dblD
        dblKRo = dblDKRo / dblD
        dblBRo = dblDBRo / dblD

        rstROs.Clear()

        With udtSampleResult
            .lngSamples = lngSamples
            .dblTAvg = dblSumTemper / lngSamples
            .dblRoAvg = dblSumRo / lngSamples
            .dblKT = dblKT
            .dblKRo = dblKRo
            .dblBT = dblKT * dblNow + dblBT
            .dblBRo = dblKRo * dblNow + dblBRo
        End With

    End Sub
End Module
