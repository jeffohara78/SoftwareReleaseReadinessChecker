using System;
using System.Collections.Generic;

namespace SoftwareReleaseReadinessChecker
{
    public class ReleaseReadinessManager
    {
        public void StartReleaseAssessment()
        {
            Console.WriteLine("\n======================================");
            Console.WriteLine("     SOFTWARE RELEASE READINESS CHECK");
            Console.WriteLine("======================================");
            Console.WriteLine("This tool helps determine whether a software");
            Console.WriteLine("release appears ready to move forward.");
            Console.WriteLine();
            Console.WriteLine("It checks important release areas such as:");
            Console.WriteLine("- Testing");
            Console.WriteLine("- Security review");
            Console.WriteLine("- Documentation");
            Console.WriteLine("- Rollback planning");
            Console.WriteLine("- Stakeholder approval");
            Console.WriteLine("- Critical known issues");
            Console.WriteLine();
            Console.WriteLine("Enter 0 at any prompt to cancel.");
            Console.WriteLine();

            ReleaseAssessment assessment = new ReleaseAssessment();

            assessment.ApplicationName = GetTextOrCancel("Application name, such as Customer Portal: ");

            if (assessment.ApplicationName == "0")
            {
                Console.WriteLine("Release assessment cancelled.");
                return;
            }

            assessment.ReleaseVersion = GetTextOrCancel("Release version, such as 1.2.0 or June 2026 Release: ");

            if (assessment.ReleaseVersion == "0")
            {
                Console.WriteLine("Release assessment cancelled.");
                return;
            }

            assessment.TestingCompleted = GetYesNoFromUser("\nHas functional testing been completed?");
            assessment.SecurityReviewCompleted = GetYesNoFromUser("\nHas a security review been completed?");
            assessment.DocumentationUpdated = GetYesNoFromUser("\nHas user or technical documentation been updated?");
            assessment.RollbackPlanExists = GetYesNoFromUser("\nIs there a rollback plan if the release fails?");
            assessment.StakeholderApprovalReceived = GetYesNoFromUser("\nHas stakeholder or management approval been received?");
            assessment.KnownCriticalIssues = GetYesNoFromUser("\nAre there any known critical issues still unresolved?");

            ReadinessResult result = CalculateReadiness(assessment);

            DisplayReadinessReport(assessment, result);
        }

        private ReadinessResult CalculateReadiness(ReleaseAssessment assessment)
        {
            ReadinessResult result = new ReadinessResult();

            int score = 0;

            if (assessment.TestingCompleted)
            {
                score += 25;
            }
            else
            {
                result.Recommendations.Add("Complete functional testing before release.");
            }

            if (assessment.SecurityReviewCompleted)
            {
                score += 20;
            }
            else
            {
                result.Recommendations.Add("Complete a security review before deployment.");
            }

            if (assessment.DocumentationUpdated)
            {
                score += 10;
            }
            else
            {
                result.Recommendations.Add("Update documentation so users and support teams understand the release.");
            }

            if (assessment.RollbackPlanExists)
            {
                score += 20;
            }
            else
            {
                result.Recommendations.Add("Create a rollback plan in case the release causes problems.");
            }

            if (assessment.StakeholderApprovalReceived)
            {
                score += 15;
            }
            else
            {
                result.Recommendations.Add("Obtain stakeholder or management approval before proceeding.");
            }

            if (!assessment.KnownCriticalIssues)
            {
                score += 10;
            }
            else
            {
                result.Recommendations.Add("Resolve known critical issues before release.");
            }

            result.ReadinessScore = score;

            if (score >= 90)
            {
                result.ReadinessLevel = "Ready for Release";
            }
            else if (score >= 70)
            {
                result.ReadinessLevel = "Mostly Ready";
            }
            else if (score >= 50)
            {
                result.ReadinessLevel = "Needs Work";
            }
            else
            {
                result.ReadinessLevel = "Not Ready";
            }

            return result;
        }

        private void DisplayReadinessReport(ReleaseAssessment assessment, ReadinessResult result)
        {
            Console.WriteLine("\n======================================");
            Console.WriteLine("        RELEASE READINESS REPORT");
            Console.WriteLine("======================================");
            Console.WriteLine($"Application: {assessment.ApplicationName}");
            Console.WriteLine($"Release Version: {assessment.ReleaseVersion}");
            Console.WriteLine($"Readiness Score: {result.ReadinessScore}%");
            Console.WriteLine($"Readiness Level: {result.ReadinessLevel}");
            Console.WriteLine();

            Console.WriteLine("--- Release Checklist ---");
            Console.WriteLine($"Testing Completed: {(assessment.TestingCompleted ? "Yes" : "No")}");
            Console.WriteLine($"Security Review Completed: {(assessment.SecurityReviewCompleted ? "Yes" : "No")}");
            Console.WriteLine($"Documentation Updated: {(assessment.DocumentationUpdated ? "Yes" : "No")}");
            Console.WriteLine($"Rollback Plan Exists: {(assessment.RollbackPlanExists ? "Yes" : "No")}");
            Console.WriteLine($"Stakeholder Approval Received: {(assessment.StakeholderApprovalReceived ? "Yes" : "No")}");
            Console.WriteLine($"Known Critical Issues: {(assessment.KnownCriticalIssues ? "Yes" : "No")}");
            Console.WriteLine();

            Console.WriteLine("--- Recommendation Summary ---");

            if (result.Recommendations.Count == 0)
            {
                Console.WriteLine("No major blockers were identified. The release appears ready.");
            }
            else
            {
                foreach (string recommendation in result.Recommendations)
                {
                    Console.WriteLine($"- {recommendation}");
                }
            }
        }

        private bool GetYesNoFromUser(string question)
        {
            while (true)
            {
                Console.WriteLine(question);
                Console.WriteLine("1. Yes");
                Console.WriteLine("2. No");
                Console.Write("Choose option 1 or 2: ");

                string choice = Console.ReadLine();

                if (choice == "1") return true;
                if (choice == "2") return false;

                Console.WriteLine("Invalid option. Please choose 1 or 2.");
            }
        }

        private string GetTextOrCancel(string prompt)
        {
            Console.Write(prompt);

            return Console.ReadLine().Trim();
        }
    }
}