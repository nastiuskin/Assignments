namespace Assignment_13.Abstractions
{
    public interface ISpeakerValidator
    {
        void ValidateBasicInfo(Speaker speaker);
        bool ValidateSpeaker(Speaker speaker);
    }
}
