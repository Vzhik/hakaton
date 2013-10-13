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
            foreach (var error in errorBase.Errors.OrderBy(p=>p.Time))
            {
                var dict = new Dictionary<string, string>();
                if (error.Time >= DateTime.Now.AddDays(-period))
                {
                    dict.Add("Agent", error.Agent);
                    dict.Add("FileUrl", error.FileUrl);
                    dict.Add("PageUrl", error.PageUrl);
                    dict.Add("Line", error.Line.ToString());
                    dict.Add("Time", error.Time.ToLongTimeString() + error.Time.ToLongDateString());
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

        public static ErrorModel GetErrorDetails(Guid errorid)
        {
            var repo = new ErrorsRepository();
            var error = repo.GetErrorById(errorid);
            if (error == null) return null;
            var errorBase = repo.GetBaseErrorById(error.ErrorBaseId);
            var res = new ErrorModel() { Agent = error.Agent, FileUrl = error.FileUrl, Id = error.ErrorId, Line = error.Line, Message = errorBase.Message, PageUrl = error.PageUrl, Stack = error.Stack, Time = error.Time };
            var events = new EventModel[error.Events.Count];
            int i =0;
            foreach (var ev in error.Events.ToList().OrderBy(p => p.TimeAfterStart))
            {
                events[i] = new EventModel() { EventType = (EventTypes)ev.EventType, Target = ev.Target, TimeAfterStart = ev.TimeAfterStart };
                i++;
            }
            res.Events = events;
            return res;
        }
    }
}