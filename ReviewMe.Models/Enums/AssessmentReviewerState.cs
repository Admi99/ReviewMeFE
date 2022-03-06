namespace ReviewMe.Models.Enums
{
    public enum AssessmentReviewerState
    {
        Created,
        Declined,
        Drafted,
        Reviewed
    }

    public static class AssessmentReviewerStateExtensions
    {
        public static int GetWeightForOrdering(this AssessmentReviewerState state)
            => state switch
            {
                AssessmentReviewerState.Created => 1,
                AssessmentReviewerState.Declined => 3,
                AssessmentReviewerState.Drafted => 0,
                AssessmentReviewerState.Reviewed => 2,
                _ => 4
            };
    }
}
