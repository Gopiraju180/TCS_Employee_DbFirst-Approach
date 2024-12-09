using System;
using System.Collections.Generic;

namespace TCS_Employee_DbFirst_Approach.DbConnect;

public partial class Employee
{
    public int Empid { get; set; }

    public string Empname { get; set; } = null!;

    public int Empsalary { get; set; }
}
