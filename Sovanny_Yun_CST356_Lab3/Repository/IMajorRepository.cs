using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sovanny_Yun_CST356_Lab3.Data.Entities;
using Sovanny_Yun_CST356_Lab3.Models.View;

namespace Sovanny_Yun_CST356_Lab3.Repository
{
    public interface IMajorRepository
    {
        IEnumerable<Major> GetAllMajors();
        bool Create(Major majorData);
        Major GetMajor(int id);
        bool Edit(Major majorData);
        int DeleteMajor(int id);
    }
}
