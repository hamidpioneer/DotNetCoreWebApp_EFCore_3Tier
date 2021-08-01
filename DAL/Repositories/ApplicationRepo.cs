using DAL.DatabaseContext;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace DAL.Repositories
{
    public class ApplicationRepo : IApplicationRepo
    {
        public ApplicationRepo(AppDbContext context)
        {
            _context = context;
        }

        private readonly AppDbContext _context;

        public async Task<Application> AddApplicationWithApplicantAsync(Applicant applicant, Application application)
        {
            Application data = null;
            try
            {
                using (var transaction = _context.Database.BeginTransaction())
                {
                    try
                    {
                        var savedApplicantTracking = await _context.Applicants.AddAsync(applicant);
                        await _context.SaveChangesAsync();

                        application.Applicant_Id = applicant.Id;
                        var savedApplicationTracking = await _context.Applications.AddAsync(application);
                        await _context.SaveChangesAsync();

                        transaction.Commit();

                        return application;
                    }
                    catch (Exception exception2)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }

            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public async Task<IList<Application>> GetAllApplicationsAsync()
        {
            try
            {
                //var applications = await _context.Applications
                //    .Include(app => app.ApplicationStatus
                //    .Include(app => app.Grade )
                //    .Include(app => app.Applicants)
                //    .ToListAsync();

                var applications = await _context.Applications.ToListAsync();
                foreach(var app in applications)
                {
                    app.Grade = await _context.Grades.Where(i => app.Grade_Id == i.Id).Select( i => new Grade { Id = i.Id, Applications = null, Capacity = i.Capacity, CreationDate = i.CreationDate, ModifiedDate = i.ModifiedDate, Name = i.Name, Number = i.Number}).FirstOrDefaultAsync();
                    //app.Applicant = await _context.Applicants.Where(i => app.Applicant_Id == i.Id).Select(i => new Appl).FirstOrDefaultAsync();
                    //app.ApplicationStatus = await _context.ApplicationStatuses.Where(i => app.ApplicationStatus_Id == i.Id).FirstOrDefaultAsync();

                }

                return applications;


            }
            catch (Exception)
            {

                throw;
            }
            throw new NotImplementedException();
        }

        public Task<Application> GetApplicationByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        //public async Task<Application> AddApplicationWithApplicantAsync(Applicant applicant, Application application)
        //{
        //    try
        //    {
        //        using(var transaction = await _context.Database.BeginTransactionAsync())
        //        {
        //            try
        //            {
        //                var savedApplicantTracking = await _context.Applicants.AddAsync(applicant);
        //                var savedApplicant = savedApplicantTracking.Entity;
        //                await _context.SaveChangesAsync();

        //                var savedApplicationTracking = await _context.Applications.AddAsync(application);
        //                var savedApplication = savedApplicationTracking.Entity;
        //                await _context.SaveChangesAsync();

        //                await transaction.CommitAsync();

        //                savedApplication.Applicant = savedApplicant;

        //                return savedApplication;
        //            }
        //            catch (Exception exception2)
        //            {
        //                await transaction.RollbackAsync();
        //                throw;
        //            }
        //        }
        //    }
        //    catch (Exception execption1)
        //    {
        //        throw;
        //    }
        //}
    }
}
