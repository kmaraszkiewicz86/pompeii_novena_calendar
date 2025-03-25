using FluentResults;
using PompeiiNovenaCalendar.Domain.Database.Entities;
using PompeiiNovenaCalendar.Domain.Database.Repositories;
using PompeiiNovenaCalendar.Domain.Models;
using PompeiiNovenaCalendar.Domain.Services.Interfaces;
using PompeiiNovenaCalendar.Shared.Models.Handlers.Commands;

namespace PompeiiNovenaCalendar.Domain.Services.Implementations
{
    public class NovennaDaysGenerator(
        IUnitOfWork unitOfWork, 
        IDayRecordRepository repository, 
        IRosaryTypesQuery rosaryTypesQuery,
        LanguageSettings settings
    ) : INovennaDaysGenerator
    {
        public const int NovennaDayLenght = 54;

        public async Task<Result> GenerateInitialDataAsync(GenerateInialDataCommand request)
        {
            RosaryTypeModel[] rosaryTypes = await rosaryTypesQuery.GetAllRosaryTypesAsync(settings.Language);

            List<DayRecord> dayRecords = new();

            for (int i = 0; i < NovennaDayLenght; i++)
            {
                var date = request.fromDate.AddDays(i);
                dayRecords.Add(new()
                {
                    Id = i + 1,
                    Date = date,
                    IsCompleted = false,
                    RosarySelections = [.. rosaryTypes.Select(rt => new RosarySelection
                    {
                        RosaryTypeId = rt.Id,
                        DayRecordId = i + 1
                    })]
                });
            }

            await repository.AddRangeAsync(dayRecords);
            return await unitOfWork.SaveChangesAsync();
        }
    }
}


