﻿using FluentResults;
using FluentValidation.Results;
using MediatR;
using PompeiiNovenaCalendar.ApplicationLayer.Validators;
using PompeiiNovenaCalendar.Domain.Database.Repositories;
using PompeiiNovenaCalendar.Shared.Models.Handlers.Commands;

namespace PompeiiNovenaCalendar.ApplicationLayer.Handlers.Commands
{
    public class GenerateInialDataCommandHandler(GenerateInialDataCommandValidator validator, IDayRecordRepository repository, IUnitOfWork unitOfWork) : IRequestHandler<GenerateInialDataCommand, Result>
    {
        public async Task<Result> Handle(GenerateInialDataCommand request, CancellationToken cancellationToken)
        {
            ValidationResult validationResult = validator.Validate(request);

            if (validationResult.IsValid)
            {
                return Result.Fail(validationResult.Errors.Select(e => e.ErrorMessage)?.ToArray() ?? []);
            }

            await repository.GenerateInitialDataAsync(request);

            return await unitOfWork.SaveChangesAsync();
        }
    }
}
