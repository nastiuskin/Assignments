using Assignment_13;
using Assignment_13.Entities;
using Assignment_13.Enums;
using Assignment_13.Exceptions;
using Assignment_13.Services;

namespace Assignment_17.Tests
{
    public class SpeakerValidatorTests
    {
        private readonly SpeakerValidator _validator;
        public SpeakerValidatorTests()
        {
            _validator = new SpeakerValidator();
        }

        [Fact]
        public void ValidateBasicInfo_ThrowsException_WhenFirstNameIsMissing()
        {
            var speaker = new Speaker
            {
                LastName = "Gaidarli",
                Email = "nasteagaydarly@aol.com",
            };

            var ex = Assert.Throws<FirstNameIsRequiredException>(() => _validator.ValidateBasicInfo(speaker));

            Assert.Equal("First name is required.", ex.Message);
        }

        [Fact]
        public void ValidateBasicInfo_ReturnsTrue_WhenAllInfoIsPresent()
        {
            var speaker = new Speaker
            {
                FirstName = "Anastasia",
                LastName = "Gaidarli",
            };

            var result = _validator.ValidateBasicInfo(speaker);

            Assert.True(result);
        }

        [Fact]
        public void ValidateSpeaker_ReturnsTrue_WhenMeetsPrimaryRequirements()
        {
            var speaker = new Speaker
            {
                Exp = 10,
                HasBlog = true,
                Certifications = new List<string> { "Certification1", "Certification2" },
                Employer = "Google"
            };

            var result = _validator.ValidateSpeaker(speaker);

            Assert.True(result);
        }

        [Fact]
        public void ValidateSpeaker_ReturnsTrue_WhenMeetsSecondaryRequirements()
        {
            var speaker = new Speaker
            {
                Exp = 5,
                HasBlog = false,
                Certifications = new List<string> { "Certification1" },
                Employer = "Other Company",
                Email = "nasteagaydarly@gmail.com",
                Browser = new WebBrowser ("Google Chrome", 90)
            };

            var result = _validator.ValidateSpeaker(speaker);

            Assert.True(result);
        }

        [Fact]
        public void ValidateSpeaker_ReturnsFalse_WhenEmailIsBlacklisted()
        {
            var speaker = new Speaker
            {
                Exp = 5,
                HasBlog = false,
                Certifications = new List<string> { "Certification1" },
                Employer = "Other Company",
                Email = "nasteagaydarly@gmail.com",
                Browser = new WebBrowser("Google Chrome", 90)
            };

            var result = _validator.ValidateSpeaker(speaker);

            Assert.False(result); 
        }

        [Fact]
        public void ValidateSpeaker_ReturnsFalse_WhenUsesOutdatedBrowser()
        {
            var speaker = new Speaker
            {
                Exp = 5,
                HasBlog = false,
                Certifications = new List<string> { "Certification1" },
                Employer = "Other Company",
                Email = "nasteagaydarly@gmail.com",
                Browser = new WebBrowser("Internet Explorer", 2)
            };

            var result = _validator.ValidateSpeaker(speaker);

            Assert.False(result);
        }

    }
}
