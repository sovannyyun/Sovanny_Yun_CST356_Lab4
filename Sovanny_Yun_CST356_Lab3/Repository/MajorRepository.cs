using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sovanny_Yun_CST356_Lab3.Data;
using Sovanny_Yun_CST356_Lab3.Data.Entities;
using Sovanny_Yun_CST356_Lab3.Models.View;

namespace Sovanny_Yun_CST356_Lab3.Repository
{
    public class MajorRepository : IMajorRepository
    {
        private readonly AppDbContext _dbContex;
        public MajorRepository(AppDbContext dbContext)
        {
            _dbContex = dbContext;
        }
        public bool Create(Major majorData)
        {
            try
            {
                _dbContex.Majors.Add(majorData);
                _dbContex.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public int DeleteMajor(int id)
        {
            try
            {
                var major = _dbContex.Majors.Find(id);
                var userId = major.UserId;
                if (major != null)
                {
                    _dbContex.Majors.Remove(major);
                    _dbContex.SaveChanges();
                }

                return userId;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public bool Edit(Major majorData)
        {
            try
            {
                var major = _dbContex.Majors.Find(majorData.Id);

                major.Status = majorData.Status;
                major.Subject = majorData.Subject;
                major.YearOfGraduate = majorData.YearOfGraduate;
                major.UserId = majorData.UserId;

                _dbContex.SaveChanges();

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public IEnumerable<Major> GetAllMajors()
        {
            return _dbContex.Majors;
        }

        public Major GetMajor(int id)
        {
            var major = _dbContex.Majors.Find(id);

            return major;
        }
    }
}