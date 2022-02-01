using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab210.DAL.Entitati
{
    public class Motor
    {
        public int Id { get; set; }
        public int Putere { get; set; }
        public decimal Pret { get; set; }
        public string Nume { get; set; }

        public ICollection<ListaMotoare> ListaMotoare { get; set; }//many to many
    }
}
