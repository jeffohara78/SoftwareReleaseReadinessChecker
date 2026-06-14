using System.Collections.Generic;

namespace SoftwareReleaseReadinessChecker
{
    public class ReadinessResult
    {
        public int ReadinessScore { get; set; }
        public string ReadinessLevel { get; set; }
        public List<string> Recommendations { get; set; }

        public ReadinessResult()
        {
            ReadinessLevel = "";
            Recommendations = new List<string>();
        }
    }
}