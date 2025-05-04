using Assignment_13.Enums;

namespace Assignment_13.Abstractions
{
    public interface ISpeakerValidator
    {
        void ValidateBasicInfo(Speaker speaker);
        bool ValidateSpeaker(Speaker speaker);
        bool ValidateBrowser(BrowserName browser);
    }
}
