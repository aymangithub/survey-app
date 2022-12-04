using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using SurveyApp.Web.Areas.Identity.Data;
using SurveyApp.Web.Data;
using SurveyApp.Web.Models;
using SurveyApp.Web.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyApp.Web.Services
{
    public class SurveyService
    {
        private readonly ApplicationDbContext _context;

        public SurveyService(ApplicationDbContext context)
        {
            _context = context;
        }
        public void SetLicenseIdEnc()
        {
            string password = "E546C8DF278CD5931069B522E695D4F2";

            var list = _context.Licenses.ToList();
            for (int i = 0; i < list.Count; i++)
            {
                list[i].LicenseIdEncrypted =

                StringCipher.EncryptString(list[i].LicenseId);

                _context.Licenses.Update(list[i]);


            }
            _context.SaveChanges();

        }

        public void TestLicensedKey()
        {
            string password = "E546C8DF278CD5931069B522E695D4F2";

            var list = _context.Licenses.ToList();
            var listIssue = new List<License>();
            for (int i = 0; i < list.Count; i++)
            {
                String licens = StringCipher.DecryptString(list[i].LicenseIdEncrypted);
                if (string.IsNullOrEmpty(licens) || licens != list[i].LicenseId)
                {

                    listIssue.Add(list[i]);

                }
            }

        }
        public async Task<Survey[]> GetAllSurveysAsync(ApplicationUser user)
        {
            return await _context.Surveys
                .Where(s => s.UserId == user.Id)
                .Include(s => s.Questions)
                .Include(s => s.FilledSurveys)
                .ToArrayAsync();
        }
        public async Task<License> GetLicense(String license)
        {
            return await _context.Licenses
                .FirstOrDefaultAsync(x => x.LicenseId == license);
        }
        public async Task<Survey> GetSurveyOfUserByIdAsync(int id, ApplicationUser user)
        {
            return await _context.Surveys
                .Where(s => s.Id == id && s.UserId == user.Id)
                .Include(s => s.Questions)
                    .ThenInclude(q => q.Options)
                .Include(s => s.FilledSurveys)
                    .ThenInclude(f => f.FilledSurveyOptions)
                        .ThenInclude(o => o.Option)
                            .ThenInclude(o => o.Question)
                .FirstOrDefaultAsync();
        }

        public async Task<Survey> GetSurveyByIdAsync(int id)
        {
            return await _context.Surveys
                .Where(s => s.Id == id)
                .Include(s => s.Questions)
                    .ThenInclude(q => q.Options)
                .FirstOrDefaultAsync();
        }

        public async Task<bool> CreateSurveyAsync(SurveyViewModel model, ApplicationUser user)
        {
            var survey = new Survey()
            {
                Title = model.Title,
                Questions = model.Questions,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                UserId = user.Id
            };

            _context.Surveys.Add(survey);
            var saveResult = await _context.SaveChangesAsync();
            return saveResult > 1;
        }

        public async Task<bool> CreateFilledSurveyAsync(FilledSurveyViewModel model)
        {
            var survey = await GetSurveyByIdAsync(model.SurveyId);
            var filledSurvey = new FilledSurvey
            {
                CreatedAt = DateTime.Now,
                Survey = survey,
                Email = model.Email,
                SurveyId = model.SurveyId,
                FilledSurveyOptions = model.FilledSurveyOptions
            };

            _context.FilledSurveys.Add(filledSurvey);
            var saveResult = await _context.SaveChangesAsync();
            return saveResult > 1;
        }
        public async Task<bool> IsLicenseHasSurveyResponse(string license)
        {
            return await _context.LicenseSurveyResponses.AnyAsync(x => x.LicenseId == license);
        }
        public async Task<bool> CreateLicenseResponseAsync(LicenseSurveyViewModel model)
        {
            //check if resposne exist 
            if (_context.LicenseSurveyResponses.Any(x => x.LicenseId == model.LicenseId))
            {
                return false;

            }
            var filledSurvey = new LicenseSurveyResponse
            {
                LicenseId = model.LicenseId,
                Question1ResponseValue = model.Question1ResponseValue,
                Question2ResponseValue = model.Question2ResponseValue,

            };

            _context.LicenseSurveyResponses.Add(filledSurvey);
            //add files 
            var files = model.FilesViewModel.Select(x => x.FileData).ToList();
            if (files.Count > 0)
                _context.SurveyFiles.AddRange(files);


            var saveResult = await _context.SaveChangesAsync();
            return saveResult > 1;
        }

        public async Task<bool> isEmailAnsweredSurvey(string email, int surveyId)
        {
            var result = await _context.FilledSurveys
                .FirstOrDefaultAsync(f => f.Email == email && f.SurveyId == surveyId);

            return !(result == null);
        }

        public async Task<bool> DeleteSurveyAsync(Survey survey, ApplicationUser user)
        {
            _context.Surveys.Remove(survey);
            var saveResult = await _context.SaveChangesAsync();
            return saveResult > 1;
        }
    }
}
