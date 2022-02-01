using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab210.BLL.Interfaces
{
    public interface IStudentManager
    {
        Task<List<string>> ModifyStudent();
    }
}
