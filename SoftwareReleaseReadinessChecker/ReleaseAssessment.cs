namespace SoftwareReleaseReadinessChecker
{
    public class ReleaseAssessment
    {
        public string ApplicationName { get; set; }
        public string ReleaseVersion { get; set; }
        public bool TestingCompleted { get; set; }
        public bool SecurityReviewCompleted { get; set; }
        public bool DocumentationUpdated { get; set; }
        public bool RollbackPlanExists { get; set; }
        public bool StakeholderApprovalReceived { get; set; }
        public bool KnownCriticalIssues { get; set; }

        public ReleaseAssessment()
        {
            ApplicationName = "";
            ReleaseVersion = "";
        }
    }
}