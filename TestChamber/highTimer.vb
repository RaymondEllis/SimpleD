Public Class highTimer
    Public Enum PerformanceValue
        pvSecond = 1                's
        pvDeciSecond = 10           'ds
        pvCentiSecond = 100         'cs
        pvMilliSecond = 1000        'ms
        pvMicroSecond = 1000000     'µs
        pvNanoSecond = 1000000000   'ns
    End Enum

    Private m_CountsPerSecond As Long
    Private m_Start As Long
    Private m_Stop As Long
    Private m_ApiOverhead As Long

    Private Declare Function QueryPerformanceCounter Lib "kernel32" (ByRef lpPerformanceCount As Long) As Boolean
    Private Declare Function QueryPerformanceFrequency Lib "kernel32" (ByRef lpFrequency As Long) As Boolean
    Private Declare Function GetTickCount Lib "kernel32.dll" () As Long


    Public Sub New()
        'Does the system support a performance counter
        If QueryPerformanceFrequency(m_CountsPerSecond) Then
            Dim i As Long, TotalOverhead As Decimal

            'Find out how long it takes the system to call the API function
            For i = 1 To 1000
                QueryPerformanceCounter(m_Start)
                QueryPerformanceCounter(m_Stop)
                TotalOverhead = TotalOverhead + m_Stop - m_Start
            Next i
            m_ApiOverhead = TotalOverhead / 1000
        Else
            m_CountsPerSecond = 1
        End If
        m_Start = 0
        m_Stop = 0
    End Sub


    ''' <summary>
    ''' Does the system support a performance counter
    ''' </summary>
    Public ReadOnly Property Supported() As Boolean
        Get
            Return QueryPerformanceCounter(0)
        End Get
    End Property

    ''' <summary>
    ''' Get the start time
    ''' </summary>
    Public Sub StartTimer()
        QueryPerformanceCounter(m_Start)
        m_Stop = 0
    End Sub
    ''' <summary>
    ''' Get the end time
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub StopTimer()
        QueryPerformanceCounter(m_Stop)
    End Sub

    ''' <summary>
    ''' Return the time taken
    ''' </summary>
    ''' <param name="ReturnAccuracy"></param>
    Public ReadOnly Property TimeElapsed(ByVal ReturnAccuracy As PerformanceValue) As Double
        Get
            If m_Start And m_Stop Then Return (m_Stop - m_Start - m_ApiOverhead) / m_CountsPerSecond * ReturnAccuracy
            Return 0
        End Get
    End Property
   
End Class
