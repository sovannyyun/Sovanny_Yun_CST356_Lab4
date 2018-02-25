using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sovanny_Yun_CST356_Lab3.Models.View;
using Sovanny_Yun_CST356_Lab3.Repository;
using Sovanny_Yun_CST356_Lab3.Data.Entities;

namespace Sovanny_Yun_CST356_Lab3.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository userRepository)
        {
            _repository = userRepository;
        }


        public IEnumerable<UserViewModel> GetAllUsers()
        {
            List<UserViewModel> userList = new List<UserViewModel>();
            foreach (var user in _repository.GetAllUsers())
            {
                userList.Add(MapToUserViewModel(user));
            }

            return userList;
        }

        public bool Create(UserViewModel userData)
        {
            return _repository.Create(MapToUser(userData));
        }

        public UserViewModel GetUser(int id)
        {
            return MapToUserViewModel(_repository.GetUser(id));
        }

        public bool Edit(UserViewModel userData)
        {
            return _repository.Edit(MapToUser(userData));
        }

        public bool DeleteUser(int id)
        {
            return _repository.DeleteUser(id);
        }

        private User MapToUser(UserViewModel userViewModel)
        {
            return new User
            {
                Id = userViewModel.Id,
                FirstName = userViewModel.FirstName,
                MiddleName = userViewModel.MiddleName,
                LastName = userViewModel.LastName,
                EmailAddress = userViewModel.EmailAddress,
                DateOfBirth = userViewModel.DateOfBirth,
                YearInSchoo = userViewModel.YearInSchool
            };
        }

        private UserViewModel MapToUserViewModel(User user)
        {
            return new UserViewModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                MiddleName = user.MiddleName,
                LastName = user.LastName,
                EmailAddress = user.EmailAddress,
                DateOfBirth = user.DateOfBirth,
                YearInSchool = user.YearInSchoo
            };
        }

        private void CopyToUser(UserViewModel userViewModel, User user)
        {
            user.FirstName = userViewModel.FirstName;
            user.MiddleName = userViewModel.MiddleName;
            user.LastName = userViewModel.LastName;
            user.EmailAddress = userViewModel.EmailAddress;
            user.DateOfBirth = userViewModel.DateOfBirth;
            user.YearInSchoo = userViewModel.YearInSchool;
        }


    }
}