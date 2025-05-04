using Assignment_13.Abstractions;
using Assignment_13.Exceptions;

namespace Assignment_13.Services
{
    public class SpeakerRegistrationService(
        ISpeakerRepository repository,
        ISpeakerValidator validator,
        ISessionApprover sessionApprover,
        IRegistrationFeeCalculator feeCalculator)
    {
        public void Register(Speaker speaker)
        {
            try
            {
                validator.ValidateBasicInfo(speaker);
            }
            catch (Exception)
            {
                throw;
            }

            if (!validator.ValidateSpeaker(speaker))

            if (!sessionApprover.ApproveSessions(speaker.Sessions))
                throw new NoSessionsApprovedException("Can't register speaker with no valid sessions.");

            speaker.RegistrationFee = feeCalculator.CalculateFee(speaker.Exp);

            repository.SaveSpeaker(speaker);
        }
    }
}