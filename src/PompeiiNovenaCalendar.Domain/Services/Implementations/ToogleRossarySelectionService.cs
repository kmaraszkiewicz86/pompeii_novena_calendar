using FluentResults;
using PompeiiNovenaCalendar.Domain.Database.Repositories;
using PompeiiNovenaCalendar.Domain.Services.Interfaces;
using PompeiiNovenaCalendar.Shared.Models.Handlers.Commands;

namespace PompeiiNovenaCalendar.Domain.Services.Implementations
{
    public class ToogleRossarySelectionService(
        IRosarySelectionRepository rosarySelectionRepository,
        IDayRecordRepository dayRecordRepository,
        IRosarySelectionQuery databaseQuery,
        IUnitOfWork unitOfWork) : IToogleRossarySelectionService
    {
        public async Task<Result> SaveAsync(ToogleRossarySelectionCommand request)
        {
            Result result = await rosarySelectionRepository.ToogleRossarySelectionAsync(request);

            if (result.IsFailed)
            {
                return result;
            }

            result = await unitOfWork.SaveChangesAsync();
            
            if (result.IsFailed)
            {
                return result;
            }

            bool isDayCompleted = await databaseQuery.IsDayCompletedAsync(request.DayId);

            result = await dayRecordRepository.MarkDayAsCompletedAsync(request.DayId, isDayCompleted);

            if (result.IsFailed)
            {
                return result;
            }

            return await unitOfWork.SaveChangesAsync();
        }
    }
}


