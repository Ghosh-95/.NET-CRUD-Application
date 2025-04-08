using System;
using System.Collections.Generic;

namespace CRUD_Application_DB_First.Models;

public partial class Student
{
    public int Id { get; set; }

    public string FullName { get; set; } = null!;

    public int Class { get; set; }

    public string Section { get; set; } = null!;
}
