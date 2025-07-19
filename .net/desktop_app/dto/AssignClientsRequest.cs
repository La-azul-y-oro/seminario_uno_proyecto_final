using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desktop_app.dto
{
    public class AssignClientsRequest
    {
        public int FunctionalId { get; set; }
        public List<int> ClientsIds { get; set; } = new List<int>();
    }
}
