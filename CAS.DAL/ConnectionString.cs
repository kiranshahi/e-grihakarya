using System;
using System.Collections.Generic;
using System.Text;

namespace CAS.DAL
{
    class ConnectionString
    {
        public static string Con { get; set; } = "Server=.;Database=Classroom;Trusted_Connection=True;MultipleActiveResultSets=True;";
    }
}
