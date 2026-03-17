using System;

public namespace HospitalCommunication
{
    public delegate string ReportGenerator(string patientName);
    public delegate void HospitalAlert(string message);
    public delegate void HospitalNotificationHandler(string message, DateTime time);



}