using System;
namespace Debugging
{
    //Enum
    public enum AdmissionStatusEnum{Select,Admitted,Cancelled}
    public class AdmissionDetails:DepartmentDetails
    {
        //Field
        //Static Field for Auto Generation of ID.
        public static int s_admissionID = 3000;

        //Properties
        public string AdmissionID { get; }
        public string StudentID { get; set; }
        public new string DepartmentID { get; set; }
        public new  string DepartmentName { get; set; }
        public DateTime AdmissionDate { get; set; }
        public AdmissionStatusEnum AdmissionStatus { get; set; }

        //Constructor
        public AdmissionDetails(string studentID,string departmentID,string departmentName,DateTime admissionDate,AdmissionStatusEnum admissionStatus,int numberOfSeats) : base(departmentName, numberOfSeats)
        {
            s_admissionID++;
            AdmissionID = "AID" + s_admissionID;
            StudentID=studentID;
            DepartmentID=departmentID;
            DepartmentName=departmentName;
            AdmissionDate = admissionDate;
            AdmissionStatus = admissionStatus;
        }
        
        public AdmissionDetails(string admissionID,string studentID,string departmentID,string departmentName,DateTime admissionDate,AdmissionStatusEnum admissionStatus, int numberOfSeats) : base(departmentName, numberOfSeats)
        {
            AdmissionID=admissionID;
            StudentID = studentID;
            DepartmentID = departmentID;
            DepartmentName=departmentName;
            AdmissionDate = admissionDate;
            AdmissionStatus = admissionStatus;
        }

    }
}