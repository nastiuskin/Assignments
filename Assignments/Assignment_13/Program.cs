using Assignment_13;
using Assignment_13.Entities;
using Assignment_13.Services;

var speaker = new Speaker
{
    FirstName = "Anastasia",
    LastName = "Gaidarli",
    HasBlog = false,
    Employer = "UTM",
    Email = "nasteagaydarly@aol.com",
    Browser = new WebBrowser("Internet Explorer", 4),
    Certifications = new List<string> { "Cert1", "Cert2", "Cert3", "Cert4" },
    Sessions = new List<Session>
    {
        new Session("Modern C#", "An introduction to new features in C#"),
        new Session("Cobol legacy systems", "Cobol Cobol Cobol Cobol")
    }
};

var repository = new SpeakerRepository();
var validator = new SpeakerValidator();
var sessionApprover = new SessionApprover();
var feeCalculator = new RegistrationFeeCalculator();

var registrationService = new SpeakerRegistrationService(
    repository,
    validator,
    sessionApprover,
    feeCalculator
);

try
{
    registrationService.Register(speaker);
    Console.WriteLine($"Speaker {speaker.FirstName} {speaker.LastName} registered successfully");
    Console.WriteLine($"Registration fee: {speaker.RegistrationFee}");
}
catch (Exception ex)
{
    Console.WriteLine($"Registration failed: {ex.Message}");
}