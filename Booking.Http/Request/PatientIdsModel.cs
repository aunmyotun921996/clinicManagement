namespace Booking.Http.Request
{
    public class PatientIdsModel
    {
        public List<int> PatientIds { get;protected set; }

        public PatientIdsModel(List<int> patientIds)
        {
            PatientIds = patientIds;
        }
    }
}
