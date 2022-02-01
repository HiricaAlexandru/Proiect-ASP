using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab210.DAL.Entitati
{
    public class ListaMotoare
    {
        public int Id { get; set; }
        public int ModelId { get; set; } //many to many
        public int MotorId { get; set; }

        public virtual Model Model { get; set; }
        public virtual Motor Motor { get; set; }

    }
}
