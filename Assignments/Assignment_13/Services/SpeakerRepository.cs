using Assignment_13.Abstractions;

namespace Assignment_13.Services
{
    public class SpeakerRepository : ISpeakerRepository
    {
        private readonly List<Speaker> _speakers = [];
        public void SaveSpeaker(Speaker speaker)
        {
            _speakers.Add(speaker);
        }
    }
}
