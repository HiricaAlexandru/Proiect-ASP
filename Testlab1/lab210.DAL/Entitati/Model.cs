using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab210.DAL.Entitati
{
    public class Model
    {
        public int Id { get; set; }
        public string Nume { get; set; }
        public DateTime AnFabricatie { get; set; }
        public decimal Pret { get; set; }
        public virtual Producator Producator{get;set;}//one to many
        public ICollection<ListaMotoare> ListaMotoare { get; set; }//many to many
    }
}
