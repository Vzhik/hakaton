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
        JSInquisitorEntities _context = new JSInquisitorEntities();

        public void AddError(ErrorModel error)
        {
            Event[] events = new Event[error.Events.Length];
            for (int i = 0; i < error.Events.Length; i++)
            {
                events[i].EventType = (int)error.Events[i].EventType;
                events[i].Target = error.Events[i].Target;
                events[i].TimeAfterStart = error.Events[i].TimeAfterStart;
                events[i].ErrorId = error.Id;
                events[i].Id = error.Events[i].Id;
            }
            var errorBaseId = Guid.NewGuid();
            var errorDb = new Error() { Agent = error.Agent, FileUrl = error.FileUrl, PageUrl = error.PageUrl, Line = error.Line, Stack = error.Stack, ErrorBaseId = errorBaseId, Time = error.Time };
            var baseError = new ErrorBas() { Message = error.Message, ErrorBaseId = errorBaseId, UserId = error.UserId };
            try
            {
                _context.ErrorBases.AddObject(baseError);
                _context.SaveChanges();
            }
            catch (Exception)
            {

            }
        }
    }
}
