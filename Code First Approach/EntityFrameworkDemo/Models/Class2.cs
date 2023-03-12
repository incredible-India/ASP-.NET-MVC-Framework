using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EntityFrameworkDemo.Models
{
    public class StudentContext : DbContext
    {
        public DbSet<StudentInfo> Stu { get; set; }
    }
}