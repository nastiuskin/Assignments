using Assignment_13.Enums;

namespace Assignment_13.Abstractions
{
    public interface ISpeakerValidator
    {
        bool ValidateBasicInfo(Speaker speaker);
        bool ValidateSpeaker(Speaker speaker);
    }
}
