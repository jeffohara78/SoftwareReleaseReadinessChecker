/* Jeff O'Hara
 * 6/14/2026
 * 
 * Evaluates whether a software release is prepared for deployment by assessing key areas such as testing completion, 
 * security reviews, documentation updates, rollback planning, stakeholder approvals, and unresolved critical issues. 
 * Based on the responses, it calculates a readiness score, determines an overall release status, and provides 
 * recommendations to address any gaps before moving forward with the release.
 */


using System;

namespace SoftwareReleaseReadinessChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            ReleaseReadinessManager manager = new ReleaseReadinessManager();

            bool running = true;

            while (running)
            {
                Console.WriteLine("\n==========================================");
                Console.WriteLine("     SOFTWARE RELEASE READINESS CHECKER");
                Console.WriteLine("==========================================");
                Console.WriteLine("Evaluate whether a software release is ready");
                Console.WriteLine("based on testing, security, approval, rollback,");
                Console.WriteLine("documentation, and known issue status.");
                Console.WriteLine();
                Console.WriteLine("1. Start release readiness assessment");
                Console.WriteLine("2. Exit");
                Console.Write("\nChoose an option 1 through 2: ");

                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    manager.StartReleaseAssessment();
                }
                else if (choice == "2")
                {
                    running = false;
                    Console.WriteLine("Exiting Software Release Readiness Checker.");
                }
                else
                {
                    Console.WriteLine("Invalid option. Please choose 1 or 2.");
                }
            }
        }
    }
}