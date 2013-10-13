using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Repositories.EntityModel;
using Repositories.Models;

namespace Repositories.Repositories
{
    public class ErrorsRepository
    {
        JSInquisitorEntities1 _context = new JSInquisitorEntities1();

        public void AddError(ErrorModel error)
        {
            Event[] events = new Event[error.Events.Length];
            for (int i = 0; i < error.Events.Length; i++)
            {
                events[i] = new Event();
                events[i].EventType = (int)error.Events[i].EventType;
                events[i].Target = error.Events[i].Target;
                events[i].TimeAfterStart = error.Events[i].TimeAfterStart;
                events[i].ErrorId = error.Id;
                events[i].Id = error.Events[i].Id;
            }
            var baseError = createErrorBase(error.UserId, error.Message);
            var errorDb = new Error() { ErrorId = Guid.NewGuid(), Agent = error.Agent, FileUrl = error.FileUrl, PageUrl = error.PageUrl, Line = error.Line, Stack = error.Stack, ErrorBaseId = baseError.ErrorBaseId, Time = DateTime.Now };
            try
            {
                _context.Errors.AddObject(errorDb);
                _context.SaveChanges();
            }
            catch (Exception)
            {

            }
        }

        public List<ErrorBas> GetErrors(Guid userId)
        {
            var errors = _context.ErrorBases.Where(p => p.UserId == userId);
            //errors = errors.Where(p => p.Errors.Where(c => c.Time >= DateTime.Now.AddDays(-period)).ToList().Count > 0);
            return errors.ToList();
        }

        private ErrorBas createErrorBase(Guid userId, string message)
        {
            var error = _context.ErrorBases.SingleOrDefault(p => p.UserId == userId && p.Message == message);
            if (error == null)
            {
                _context.ErrorBases.AddObject(new ErrorBas() { Message = message, UserId = userId, ErrorBaseId = Guid.NewGuid() });
                _context.SaveChanges();
                error = _context.ErrorBases.Single(p => p.UserId == userId && p.Message == message);
            }
            return error;
        }

        
        public ErrorBas GetBaseErrorById(Guid errorBaseId)
        {
            return _context.ErrorBases.SingleOrDefault(p => p.ErrorBaseId == errorBaseId);
        }
    }
}
