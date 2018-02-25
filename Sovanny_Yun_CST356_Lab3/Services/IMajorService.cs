using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sovanny_Yun_CST356_Lab3.Models.View;

namespace Sovanny_Yun_CST356_Lab3.Services
{
    public interface IMajorService
    {
        IEnumerable<MajorViewModel> GetAllMajors();
        bool Create(MajorViewModel majorViewModel);
        MajorViewModel GetMajor(int id);
        bool Edit(MajorViewModel majorViewModel);
        int DeleteMajor(int id);
    }
}
