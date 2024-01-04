using System;
public class Visit
{
    public int VisitID { get; set; }
    public int PatientID { get; set; }
    public int HospitalID { get; set; }
    public DateTime VisitDate { get; set; }

    // Navigation properties
    public Patient Patient { get; set; } = new Patient();
    public Hospital Hospital { get; set; } = new Hospital();
}

