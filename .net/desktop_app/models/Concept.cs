using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desktop_app.models
{
    public class Concept
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public bool Active { get; set; }

    }
}
