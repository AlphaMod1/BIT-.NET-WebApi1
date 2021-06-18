using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiApp.Entities;

namespace WebApiApp.Data
{
    public class DataService
    {
        public List<Todo> Todos { get; set; }

        public DataService()
        {
            Todos = new List<Todo>();
        }
    }
}
