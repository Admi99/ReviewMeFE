using ReviewMe.Frontend.Services.Data;
using ReviewMe.Models.Employees;
using ReviewMe.Models.Enums;
using ReviewMe.Models.Reviewers;
using ReviewMe.Models.ReviewerTasks;

namespace ReviewMe.Frontend.Mocks.Services
{
    public class MockService : IEmployeesService, IAssessmentService, IReviewersService, IReviewerTaskService, IReviewersFeedbackService
    {
        private static readonly List<Employee> Employees = new()
        {
            new Employee
            {
                Id = 0,
                SurnameFirstName = "Jech, Jan",
                Department = "Web",
                Position = "Developer",
                Location = "Zlín",
                TeamLeaderName = "Jirka Urban",
                PerformanceReviewMonth = DateTimeOffset.Now,
                PerformanceReviewDate = DateTimeOffset.Now,
                AssessmentDueDate = DateTimeOffset.Now,
                HasOpenAssessment = true
            },
            new Employee
            {
                Id = 1,
                SurnameFirstName = "Holzmann, Felix",
                Department = "Hr",
                Position = "Talent hunter",
                Location = "Praha",
                TeamLeaderName = "Jirka Urban",
                PerformanceReviewMonth = DateTimeOffset.Now.AddMonths(1).AddDays(10),
                PerformanceReviewDate = DateTimeOffset.Now.AddMonths(1).AddDays(10),
                HasOpenAssessment = false
            },
            new Employee
            {
                Id = 2,
                SurnameFirstName = "Donutil, Mirek",
                Location = "Zlín",
                TeamLeaderName = "Jirka Urban",
                Position = "Talent hunter",
                PerformanceReviewMonth = DateTimeOffset.Now.AddMonths(1).AddDays(-10),
                PerformanceReviewDate = DateTimeOffset.Now.AddMonths(1).AddDays(-10),
                HasOpenAssessment = false
            },
            new Employee
            {
                Id = 3,
                SurnameFirstName = "Polivka, Bolek",
                Position = "Developer",
                Department = "DotNet",
                Location = "Praha",
                PerformanceReviewMonth = DateTimeOffset.Now.AddDays(-5),
                PerformanceReviewDate = DateTimeOffset.Now.AddDays(-5),
                HasOpenAssessment = false
            },
            new Employee
            {
                Id = 3,
                SurnameFirstName = "Polívka, Bolek",
                Position = "Developer",
                Department = "DotNet",
                Location = "Praha",
                PerformanceReviewMonth = new DateTime(2022, 01, 15),
                HasOpenAssessment = false
            },
            new Employee
            {
                Id = 3,
                SurnameFirstName = "Dáda Patrasová",
                Position = "Developer",
                Department = "DotNet",
                Location = "Praha",
                PerformanceReviewMonth = new DateTime(2022, 01, 15),
                HasOpenAssessment = false
            },
            new Employee
            {
                Id = 4,
                SurnameFirstName = "Pepa z Depa",
                Position = "Developer",
                Department = "DotNet",
                Location = "Praha",
                PerformanceReviewMonth = DateTimeOffset.Now.AddDays(+5),
                PerformanceReviewDate = DateTimeOffset.Now.AddDays(+5),
                HasOpenAssessment = false
            },
            new Employee
            {
                Id = 5,
                SurnameFirstName = "Pepa bez Depa",
                Position = "Hr",
                Department = "Talent hunter",
                Location = "Zlín",
                TeamLeaderName = "Jirka Urban",
                PerformanceReviewMonth = DateTimeOffset.Now.AddMonths(-2),
                PerformanceReviewDate = DateTimeOffset.Now.AddMonths(-2),
                HasOpenAssessment = false
            },
            new Employee
            {
                Id = 6,
                SurnameFirstName = "Wolfeschlegelsteinhausenbergerdorff, Hubert",
                Position = "Hr",
                Department = "Talent hunter",
                Location = "Zlín",
                TeamLeaderName = "Jirka Urban",
                HasOpenAssessment = false
            }
        };

        private static readonly Dictionary<string, List<Reviewer>> Reviewers = new()
        {
            {
                "Internal Projects",
                new List<Reviewer>
                {
                    new()
                    {
                        EmployeeId = 1,
                        Name = "Mock Guy1 Internal",
                        IsSelected = false,
                    },
                    new()
                    {
                        EmployeeId = 2,
                        Name = "Mock Guy2 Internal",
                        IsSelected = false,
                    }
                }
            },
            {
                "Web Planning",
                new List<Reviewer>
                {
                    new()
                    {
                        EmployeeId = 3,
                        Name = "Mock Guy3 Web",
                        IsSelected = true,
                    },
                    new()
                    {
                        EmployeeId = 4,
                        Name = "Mock Guy4 Web",
                        IsSelected = true,
                    },
                    new()
                    {
                        EmployeeId = 5,
                        Name = "Mock Guy5 Web",
                        IsSelected = true,
                    }

                }
            }
        };

        private static readonly List<ReviewerTask> Tasks = new()
        {
            new ReviewerTask
            {
                AssessmentId = 0,
                SurnameFirstName = "Jech, Jan",
                Department = "Web",
                Location = "Zlín",
                Position = "Developer",
                AssessmentDueDate = DateTimeOffset.Now.AddDays(1),
                ReviewerTaskState = AssessmentReviewerState.Created

            },
            new ReviewerTask
            {
                AssessmentId = 1,
                SurnameFirstName = "Sadilek, Jan",
                Department = "QA",
                Location = "Zlín",
                Position = "Tester",
                AssessmentDueDate = DateTimeOffset.Now.AddDays(1),
                ReviewerTaskState = AssessmentReviewerState.Drafted
            },
            new ReviewerTask
            {
                AssessmentId = 1,
                SurnameFirstName = "Anastasoaie, Emanuel",
                Department = "DotNet",
                Location = "Bucharest",
                Position = "Developer",
                AssessmentDueDate = DateTimeOffset.Now,
                ReviewerTaskState = AssessmentReviewerState.Reviewed
            },
            new ReviewerTask
            {
                AssessmentId = 2,
                SurnameFirstName = "Donutil, Mirek",
                Department = "QA",
                Location = "Zlín",
                Position = "Tester",
                AssessmentDueDate = DateTimeOffset.Now.AddDays(-1),
                ReviewerTaskState = AssessmentReviewerState.Created
            },
            new ReviewerTask
            {
                AssessmentId = 3,
                SurnameFirstName = "Polívka, Bolek",
                Department = "PD",
                Location = "Zlín",
                Position = "Talent Hunter",
                AssessmentDueDate = DateTimeOffset.Now,
                ReviewerTaskState = AssessmentReviewerState.Declined
            }
        };

        public async Task<List<Employee>> Get()
        {
            await Task.Delay(1000);

            return Employees;
        }

        public Task Decline(int assessmentId, string reason)
        {
            return Task.CompletedTask;
        }

        public async Task<Employee> Get(int assessmentId)
        {
            await Task.Delay(1000);

            return Employees.FirstOrDefault(employee => employee.Id == assessmentId) ?? new Employee();
        }

        public async Task<Dictionary<string, List<Reviewer>>> GetReviewers(int id)
        {
            await Task.Delay(1000);

            return Reviewers;
        }

        public async Task OpenAssessment(int employeeId, (DateTimeOffset assessmentDueDate, DateTimeOffset performanceReviewDate, IReadOnlyCollection<int> reviewers) assessmentData)
        {
            var employee = Employees.FirstOrDefault(employee => employee.Id == employeeId);

            if (employee != null)
            {
                employee.HasOpenAssessment = true;
                employee.PerformanceReviewMonth = assessmentData.assessmentDueDate;
                employee.AssessmentDueDate = assessmentData.performanceReviewDate;
            }

            await Task.Delay(1000);
        }

        public async Task UpdateAssessment(int employeeId,
            (DateTimeOffset assessmentDueDate, DateTimeOffset performanceReviewDate, IReadOnlyCollection<int> reviewers) assessmentData)
        {
            var employee = Employees.FirstOrDefault(employee => employee.Id == employeeId);

            if (employee != null)
            {
                employee.HasOpenAssessment = true;
                employee.PerformanceReviewMonth = assessmentData.assessmentDueDate;
                employee.AssessmentDueDate = assessmentData.performanceReviewDate;
            }

            await Task.Delay(1000);
        }

        public async Task CloseAssessment(int employeeId)
        {
            var employeeRecord = Employees.FirstOrDefault(employee => employee.Id == employeeId);

            if (employeeRecord != null)
            {
                employeeRecord.HasOpenAssessment = false;
            }

            await Task.Delay(1000);
        }

        public async Task DeleteAssessment(int employeeId)
        {
            await Task.Delay(1000);
        }

        async Task<List<ReviewerTask>> IReviewerTaskService.Get()
        {
            await Task.Delay(1000);

            return Tasks;
        }

        async Task<ReviewerTask> IReviewerTaskService.Get(int assessmentId)
        {
            await Task.Delay(1000);
            return Tasks.FirstOrDefault(task => task.AssessmentId == assessmentId) ?? new ReviewerTask();
        }

        public Task Draft(int reviewTaskId, string feedback, string areasForImprovements)
        {
            return Task.CompletedTask;
        }
        public Task Submit(int reviewTaskId, string feedback, string areasForImprovements)
        {
            return Task.CompletedTask;
        }

        private static readonly List<ReviewerFeedback> ReviewerFeedbacks = new()
        {
            new ReviewerFeedback
            {
                Feedback = "Dobra komunikce",
                AreasForImprovements = "Nic",
                Name = "Josef Cajka",
                AssessmentReviewerState = AssessmentReviewerState.Reviewed,
            },
            new ReviewerFeedback
            {
                Feedback = "Spatna komunikace fsajfdosaifjisafjosaijfiosajfiosajfioasjfioasjfiosajfoiasj",
                AreasForImprovements = "Nic",
                Name = "Petr Novak",
                AssessmentReviewerState = AssessmentReviewerState.Reviewed,
            },

        };


        public async Task<List<ReviewerFeedback>> GetByEmployeeId(int employeeId)
        {
            await Task.Delay(1000);

            return ReviewerFeedbacks;
        }

        Task IAssessmentService.SaveAdditionalFeedback(int employeeId, string feedback)
        {
            throw new NotImplementedException();
        }
    }
}