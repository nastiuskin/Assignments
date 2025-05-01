﻿namespace Assignment_13.Exceptions
{
    public class SpeakerDoesntMeetRequirementsException : Exception
    {
        public SpeakerDoesntMeetRequirementsException(string message)
            : base(message) { }

        public SpeakerDoesntMeetRequirementsException(string format, params object[] args)
            : base(string.Format(format, args)) { }
    }
}
