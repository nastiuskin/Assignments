namespace Assignment_13.Entities
{
    public class SpeakerExperience
    {
        public int? Fee { get; }
        public int? Years { get; }
        public SpeakerExperience(int? fee, int? years)
        {
            Fee = fee;
            Years = years;
        }

        public static SpeakerExperience Unknown = new SpeakerExperience(null, null);
        public static SpeakerExperience ZeroYears = new SpeakerExperience(1000, 0);
        public static SpeakerExperience OneYear = new SpeakerExperience(500, 1);
        public static SpeakerExperience ThreeYears = new SpeakerExperience(250, 2);
    }
}
