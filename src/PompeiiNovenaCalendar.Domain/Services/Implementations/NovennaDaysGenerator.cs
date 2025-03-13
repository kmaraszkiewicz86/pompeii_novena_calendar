using FluentResults;
using PompeiiNovenaCalendar.Domain.Database.Entities;
using PompeiiNovenaCalendar.Domain.Database.Repositories;
using PompeiiNovenaCalendar.Domain.Services.Interfaces;
using PompeiiNovenaCalendar.Shared.Models.Handlers.Commands;

namespace PompeiiNovenaCalendar.Domain.Services.Implementations
{
    public class NovennaDaysGenerator(IUnitOfWork unitOfWork, IDayRecordRepository repository) : INovennaDaysGenerator
    {
        public const int NovennaDayLenght = 54;

        public async Task<Result> GenerateInitialDataAsync(GenerateInialDataCommand request)
        {
            List<DayRecord> dayRecords = new();

            for (int i = 0; i < NovennaDayLenght; i++)
            {
                var date = request.fromDate.AddDays(i);
                dayRecords.Add(new()
                {
                    Date = date,
                    IsCompleted = false,
                    RosarySelections = new List<RosarySelection>
                    {
                        new()
                        {
                            RosaryTypeId = 1,
                            IsCompleted = false
                        }
                    }
                });
            }

            await repository.AddRangeAsync(dayRecords);
            return await unitOfWork.SaveChangesAsync();
        }
    }
}
