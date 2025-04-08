using System;
using System.Collections.Generic;

namespace CRUD_Application_DB_First.Models;

public partial class Employee
{
    public int? Id { get; set; }

    public string? EmpName { get; set; }

    public string? City { get; set; }

    public int? Salary { get; set; }
}
