using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Repositories.Models;
using Repositories.Repositories;
using Repositories.EntityModel;
using hakaton.Models;

namespace hakaton.Services
{
    public static class ErrorService
    {
        public static void SaveError(ErrorModel error)
        {
            var repo = new ErrorsRepository();
            repo.AddError(error);
        }

        public static List<Dictionary<string, string>> GetErrorsBase(Guid userId, int period)
        {
            var repo = new ErrorsRepository();
            var error = repo.GetErrors(userId);
            var res = new List<Dictionary<string, string>>();
            for (int i = 0; i < error.Count; i++)
            {
                var dict = new Dictionary<string, string>();
                dict.Add("message", error[i].Message);
                dict.Add("count", error[i].Errors.Where(p=>p.Time >= DateTime.Now.AddDays(-period)).ToList().Count.ToString());
                dict.Add("id", error[i].ErrorBaseId.ToString());
                res.Add(dict);
            }
            return res;
        }

        public static List<ChartPoints> GetChartPointsBase(Guid userId)
        {
            var repo = new ErrorsRepository();
            var error = repo.GetErrors(userId);
            var res = new List<ChartPoints>();
            for (int i = 0; i < error.Count; i++)
            {
                var points = new ChartPoints();
                points.id = error[i].Message;
                points.mass = new int[31];
                for (int j = 0; j < 31; j++)
                {
                    points.mass[30 - j] = error[i].Errors.Where(p => p.Time >= DateTime.Now.AddDays(-1 - j) && p.Time <= DateTime.Now.AddDays(-j)).ToList().Count;
                }
                res.Add(points);
            }
            return res;
        }

        public static List<Dictionary<string, string>> GetErrorsTable(Guid errorBaseId, int period)
        {
            var res = new List<Dictionary<string, string>>();
            var repo = new ErrorsRepository();
            var errorBase = repo.GetBaseErrorById(errorBaseId);
            foreach (var error in errorBase.Errors)
            {
                var dict = new Dictionary<string, string>();
                if (error.Time >= DateTime.Now.AddDays(-period))
                {
                    dict.Add("Agent", error.Agent);
                    dict.Add("FileUrl", error.FileUrl);
                    dict.Add("PageUrl", error.PageUrl);
                    dict.Add("Line", error.Line.ToString());
                    dict.Add("Time", error.Time.ToLongTimeString());
                    dict.Add("Message", errorBase.Message);
                    dict.Add("Id", error.ErrorId.ToString());
                }
                res.Add(dict);
            }
            return res;

        }

        public static ChartPoints GetChartPoints(Guid userId, Guid errorBaseId)
        {
            var points = GetChartPointsBase(userId);
            var repo = new ErrorsRepository();
            var errorBase = repo.GetBaseErrorById(errorBaseId);
            ChartPoints point = points.SingleOrDefault(p => p.id == errorBase.Message);
            return point;
        }

    }
}