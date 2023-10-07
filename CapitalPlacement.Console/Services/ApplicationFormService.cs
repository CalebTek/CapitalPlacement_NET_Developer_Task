using System.Net.Http.Json;
using CapitalPlacement.Domain.Enums;
using CapitalPlacement.Domain.Models;

public class ApplicationFormService
{
    private readonly HttpClient _httpClient;
    private readonly string _baseUrl;

    public ApplicationFormService(HttpClient httpClient, string baseUrl)
    {
        _httpClient = httpClient;
        _baseUrl = baseUrl;
    }

    public async Task RunAsync()
    {
        while (true)
        {
            Console.WriteLine("Select an option:");
            Console.WriteLine("1. Get ApplicationForm by ID");
            Console.WriteLine("2. Update ApplicationForm");
            Console.WriteLine("3. Exit");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    await GetApplicationFormByIdAsync();
                    break;
                case "2":
                    await UpdateApplicationFormAsync();
                    break;
                case "3":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    private async Task GetApplicationFormByIdAsync()
    {
        Console.WriteLine("Enter ApplicationForm ID:");
        var applicationFormId = Console.ReadLine();

        var response = await _httpClient.GetAsync($"{_baseUrl}/api/applicationforms/{applicationFormId}");

        if (response.IsSuccessStatusCode)
        {
            var applicationForm = await response.Content.ReadFromJsonAsync<ApplicationForm>();
            Console.WriteLine($"Cover Image URL: {applicationForm.CoverImageUrl}");

            if (applicationForm.PersonalInformation != null)
            {
                var personalInfo = applicationForm.PersonalInformation;
                Console.WriteLine($"First Name: {personalInfo.FirstName}");
                Console.WriteLine($"Last Name: {personalInfo.LastName}");
                Console.WriteLine($"Email: {personalInfo.Email}");
                Console.WriteLine($"Phone: {personalInfo.Phone}");
                Console.WriteLine($"Nationality: {personalInfo.Nationality}");
                Console.WriteLine($"Current Residence: {personalInfo.CurrentResidence}");
                Console.WriteLine($"Identity Number: {personalInfo.IdentityNumber}");
                Console.WriteLine($"Date of Birth: {personalInfo.DOB}");
                Console.WriteLine($"Gender: {personalInfo.Gender}");
            }

            if (applicationForm.Profile != null)
            {
                var profile = applicationForm.Profile;
                Console.WriteLine($"Profile ID: {profile.ProfileId}");
                Console.WriteLine($"Resume URL: {profile.ResumeUrl}");

      
                if (profile.Educations != null && profile.Educations.Any())
                {
                    Console.WriteLine("Educations:");
                    foreach (var education in profile.Educations)
                    {
                        Console.WriteLine($"  - Education ID: {education.EducationId}");
                        Console.WriteLine($"  - School: {education.School}");
                        Console.WriteLine($"  - Degree: {education.Degree}");
                        Console.WriteLine($"  - Course Name: {education.CourseName}");
                        Console.WriteLine($"  - Location of Study: {education.LocationOfStudy}");
                        Console.WriteLine($"  - Start Date: {education.StartDate}");
                        Console.WriteLine($"  - End Date: {education.EndDate}");
                        Console.WriteLine($"  - Is Active: {education.IsActive}");
                    }
                }
                else
                {
                    Console.WriteLine("No educations found.");
                }

                if (profile.Experiences != null && profile.Experiences.Any())
                {
                    Console.WriteLine("Experiences:");
                    foreach (var experience in profile.Experiences)
                    {
                        Console.WriteLine($"  - Experience ID: {experience.ExperienceId}");
                        Console.WriteLine($"  - Company: {experience.Company}");
                        Console.WriteLine($"  - Title: {experience.Title}");
                        Console.WriteLine($"  - Location: {experience.Location}");
                        Console.WriteLine($"  - Start Date: {experience.StartDate}");
                        Console.WriteLine($"  - End Date: {experience.EndDate}");
                        Console.WriteLine($"  - Is Active: {experience.IsActive}");
                    }
                }
                else
                {
                    Console.WriteLine("No experiences found.");
                }

                if (profile.Questions != null && profile.Questions.Any())
                {
                    Console.WriteLine("Questions:");
                    foreach (var question in profile.Questions)
                    {
                        Console.WriteLine($"  - Question ID: {question.QuestionId}");
                        Console.WriteLine($"  - Question Type: {question.Type}");
                        Console.WriteLine($"  - Question: {question.Question}");
                    }
                }
                else
                {
                    Console.WriteLine("No questions found.");
                }

            }


            if (applicationForm.Questions != null && applicationForm.Questions.Any())
            {
                Console.WriteLine($"Questions:");
                foreach (var question in applicationForm.Questions)
                {
                    Console.WriteLine($"  - Question ID: {question.QuestionId}");
                    Console.WriteLine($"  - Question Type: {question.Type}");
                    Console.WriteLine($"  - Question: {question.Question}");
                }
            }
            else
            {
                Console.WriteLine("No questions found.");
            }
        }
        else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
        {
            Console.WriteLine("ApplicationForm not found.");
        }
        else
        {
            Console.WriteLine("Error getting ApplicationForm.");
        }
    }

    private async Task UpdateApplicationFormAsync()
    {
        Console.WriteLine("Enter ApplicationForm ID:");
        var applicationFormId = Console.ReadLine();

        // Get the existing ApplicationForm data
        var getResponse = await _httpClient.GetAsync($"{_baseUrl}/api/applicationforms/{applicationFormId}");

        if (!getResponse.IsSuccessStatusCode)
        {
            Console.WriteLine("Error getting ApplicationForm. Please check the ID.");
            return;
        }

        var existingApplicationForm = await getResponse.Content.ReadFromJsonAsync<ApplicationForm>();

        Console.WriteLine("Enter new Cover Image URL:");
        existingApplicationForm.CoverImageUrl = Console.ReadLine();

        Console.WriteLine("Enter new First Name:");
        if (!string.IsNullOrWhiteSpace(Console.ReadLine()))
        {
            existingApplicationForm.PersonalInformation.FirstName = Console.ReadLine();
        }

        Console.WriteLine("Enter new Last Name:");
        if (!string.IsNullOrWhiteSpace(Console.ReadLine()))
        {
            existingApplicationForm.PersonalInformation.LastName = Console.ReadLine();
        }

        Console.WriteLine("Enter new Email:");
        if (!string.IsNullOrWhiteSpace(Console.ReadLine()))
        {
            existingApplicationForm.PersonalInformation.Email = Console.ReadLine();
        }

        Console.WriteLine("Enter new Phone:");
        if (!string.IsNullOrWhiteSpace(Console.ReadLine()))
        {
            existingApplicationForm.PersonalInformation.Phone = Console.ReadLine();
        }

        Console.WriteLine("Enter new Nationality:");
        if (!string.IsNullOrWhiteSpace(Console.ReadLine()))
        {
            existingApplicationForm.PersonalInformation.Nationality = Console.ReadLine();
        }

        Console.WriteLine("Enter new Current Residence:");
        if (!string.IsNullOrWhiteSpace(Console.ReadLine()))
        {
            existingApplicationForm.PersonalInformation.CurrentResidence = Console.ReadLine();
        }

        Console.WriteLine("Enter new Identity Number:");
        if (!string.IsNullOrWhiteSpace(Console.ReadLine()))
        {
            existingApplicationForm.PersonalInformation.IdentityNumber = Console.ReadLine();
        }

        Console.WriteLine("Enter new Date of Birth (yyyy-MM-dd):");
        if (DateTime.TryParse(Console.ReadLine(), out DateTime dob))
        {
            existingApplicationForm.PersonalInformation.DOB = dob;
        }

        Console.WriteLine("Enter new Gender (Male/Female):");
        if (Enum.TryParse<Gender>(Console.ReadLine(), out Gender gender))
        {
            existingApplicationForm.PersonalInformation.Gender = gender;
        }


        var updateResponse = await _httpClient.PutAsJsonAsync($"{_baseUrl}/api/applicationforms/{applicationFormId}", existingApplicationForm);

        if (updateResponse.IsSuccessStatusCode)
        {
            Console.WriteLine("ApplicationForm updated successfully.");
        }
        else
        {
            Console.WriteLine("Error updating ApplicationForm.");
        }
    }
}
