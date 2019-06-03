﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using RozkladNpuBot.Application.Exceptions;
using RozkladNpuBot.Application.Interfaces;
using RozkladNpuBot.Application.Localization;

namespace RozkladNpuBot.Application.Services
{
    public class LocalizationService : ILocalizationService
    {
        private readonly List<RozkladLocalization> _localizations;
        public LocalizationService(
            ILogger<LocalizationService> logger)
        {
            _localizations = LocalizationLoader.LoadAll();

            foreach (var rozkladLocalization in _localizations)
            {
                try
                {
                    RozkladLocalizationValidator.Validate(rozkladLocalization);
                }
                catch (RozkladLocalizationValidationException e)
                {
                    logger.LogWarning(e.Message);
                }
            }
            
        }

        public LocalizationValue this[string language, string text]
        {
            get
            {
                var localization = _localizations.FirstOrDefault(l => l.ShortName == language);
                if (localization == null)
                    throw new Exception($"Localization for {language} is not defined");
                if (!localization.Values.TryGetValue(text, out string value))
                    return new LocalizationValue(text);

                return new LocalizationValue(value);
            }
        }
    }
}