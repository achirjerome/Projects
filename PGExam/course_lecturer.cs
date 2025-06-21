using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DesignTemplate1
{
    public class course_lecturer
    {
        public string departmentName { get; set; }
        public string collegeName { get; set; }

        public static string register(course_lecturer new_lecturer)
        {
            string responsecode = "1";
            return responsecode;
        }
    }
}