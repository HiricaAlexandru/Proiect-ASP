using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab210.DAL.Entitati
{
    public class Oras
    {
        public int Id { get; set; }
        public string Nume { get; set; }
        public virtual Producator Producator { get; set; } //one to one
        public int ProducatorId { get; set; }
    }
}
