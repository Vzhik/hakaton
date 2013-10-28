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
            try
            {
                Event[] events = new Event[error.Events.Length];
                var baseError = createErrorBase(error.UserId, error.Message);

                var errorDb = new Error() { ErrorId = Guid.NewGuid(), Agent = error.Agent, FileUrl = error.FileUrl, PageUrl = error.PageUrl, Line = error.Line, Stack = error.Stack, ErrorBaseId = baseError.ErrorBaseId, Time = DateTime.Now };

                for (int i = 0; i < error.Events.Length; i++)
                {
                    events[i] = new Event();
                    events[i].EventType = (int)error.Events[i].EventType;
                    events[i].Target = error.Events[i].Target;
                    events[i].TimeAfterStart = error.Events[i].TimeAfterStart;
                    events[i].ErrorId = errorDb.ErrorId;
                    events[i].Id = error.Events[i].Id;
                    _context.Events.AddObject(events[i]);
                }
                _context.Errors.AddObject(errorDb);
                _context.SaveChanges();
            }
            catch (Exception)
            {

            }
        }

        public IEnumerable<ErrorBas> GetErrors(Guid userId)
        {
            var errors = _context.ErrorBases.Where(p => p.UserId == userId);
            //errors = errors.Where(p => p.Errors.Where(c => c.Time >= DateTime.Now.AddDays(-period)).ToList().Count > 0);
            return errors;
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

        public Error GetErrorById(Guid id)
        {
            return _context.Errors.SingleOrDefault(p => p.ErrorId == id);
        }
    }
}
