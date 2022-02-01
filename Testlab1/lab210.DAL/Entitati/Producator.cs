using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab210.DAL.Entitati
{
    public class Producator
    {
        public int Id { get; set; }
        public string Nume { get; set; }
        public decimal premium { get; set; }
        public virtual ICollection<Model> Model { get; set; }//one to many
    
        public virtual Oras Oras { get; set; }//one to one
    
    }

}
