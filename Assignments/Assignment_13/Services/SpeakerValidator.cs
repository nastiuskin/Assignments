using Assignment_13.Abstractions;
using Assignment_13.Enums;
using Assignment_13.Exceptions;

namespace Assignment_13.Services
{
    public class SpeakerValidator : ISpeakerValidator
    {
        private const int MinRequiredCertifications = 4;
        private const int MinIEVersion = 9;
        private const int MinRequiredExperience = 10;

        private static readonly List<string> PreferredEmployers = new() { "Microsoft", "Google", "Fog Creek Software", "37Signals" };
        private static readonly List<string> BlacklistedEmailDomains = new() { "aol.com", "hotmail.com", "prodigy.com", "CompuServe.com" };

        public bool ValidateBasicInfo(Speaker speaker)
        {
            if (string.IsNullOrWhiteSpace(speaker.FirstName))
                throw new FirstNameIsRequiredException("First name is required.");

            if (string.IsNullOrWhiteSpace(speaker.LastName))
                throw new LastNameIsRequiredException("Last name is required.");

            if (string.IsNullOrWhiteSpace(speaker.Email))
                throw new EmailIsRequiredException("Email is required.");

            return true;
        }

        public bool ValidateSpeaker(Speaker speaker)
        {
            return MeetsPrimaryRequirements(speaker) || MeetsSecondaryRequirements(speaker);
        }

        private bool MeetsPrimaryRequirements(Speaker speaker)
        {
            return speaker.Exp >= MinRequiredExperience
                || speaker.HasBlog
                || speaker.Certifications.Count() >= MinRequiredCertifications
                || PreferredEmployers.Contains(speaker.Employer);
        }
            
        private bool MeetsSecondaryRequirements(Speaker speaker)
        {
            var domain = GetEmailDomain(speaker.Email);
            bool isOutdatedBrowser = speaker.Browser.Name == BrowserName.InternetExplorer
                         && speaker.Browser.MajorVersion < MinIEVersion;

            return !BlacklistedEmailDomains.Contains(domain) && !isOutdatedBrowser;
        }

        private string GetEmailDomain(string email) => email.Split('@').Last();
    }
}
