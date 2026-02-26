using CleanArchitecture.Domain.Exceptions;

namespace CleanArchitecture.Domain.ValueObjects
{
    public class TimeInterval
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public TimeInterval(DateTime startTime, DateTime endTime)
        {
            if (startTime > endTime)
            {
                throw new BusinessRuleException("Start time must be before end time.");

            }
            StartTime = startTime;
            EndTime = endTime;

        }

    }
}
