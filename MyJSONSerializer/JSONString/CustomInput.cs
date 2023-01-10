using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSONSerializer
{
    public class CustomInput
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public float Height { get; set; }
        public double Salary { get; set; }

        public List<Friend> Friends {get; set;}

        public double[] TGPA { get; set; }
    }

    public class Friend
    {
        public string Name { get; set; }
        public string Gender { get; set; }
    }
}
