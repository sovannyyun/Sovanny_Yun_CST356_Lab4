using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sovanny_Yun_CST356_Lab3.Models.View;
using Sovanny_Yun_CST356_Lab3.Data.Entities;
using Sovanny_Yun_CST356_Lab3.Repository;

namespace Sovanny_Yun_CST356_Lab3.Services
{
    public class MajorService : IMajorService
    {
        private readonly IMajorRepository _repository;

        public MajorService(IMajorRepository majorRepository)
        {
            _repository = majorRepository;
        }
        public bool Create(MajorViewModel majorViewModel)
        {
            return _repository.Create(MapToMajor(majorViewModel));
        }

        public int DeleteMajor(int id)
        {
            return _repository.DeleteMajor(id);
        }

        public bool Edit(MajorViewModel majorViewModel)
        {
            return _repository.Edit(MapToMajor(majorViewModel));
        }

        public IEnumerable<MajorViewModel> GetAllMajors()
        {

            var allMajors = new List<MajorViewModel>();
            foreach (var major in _repository.GetAllMajors())
            {
                allMajors.Add(MapToMajorViewModel(major));
            }
            return allMajors;
        }

        public MajorViewModel GetMajor(int id)
        {
            return MapToMajorViewModel(_repository.GetMajor(id));
        }

        private Major MapToMajor(MajorViewModel majorViewModel)
        {
            return new Major
            {
                Id = majorViewModel.Id,
                Status = majorViewModel.Status,
                Subject = majorViewModel.Subject,
                UserId = majorViewModel.UserId,
                YearOfGraduate = majorViewModel.YearOfGraduate
            };
        }

        private MajorViewModel MapToMajorViewModel(Major major)
        {
            return new MajorViewModel
            {
                Id = major.Id,
                Status = major.Status,
                Subject = major.Subject,
                UserId = major.UserId,
                YearOfGraduate = major.YearOfGraduate
            };
        }
    }
}