using System.Net.Http.Json;
using CapitalPlacement.Domain.Enums;
using CapitalPlacement.Domain.Models;

public class ProgramDetailsService
{
    private readonly HttpClient _httpClient;
    private readonly string _baseUrl;

    public ProgramDetailsService(HttpClient httpClient, string baseUrl)
    {
        _httpClient = httpClient;
        _baseUrl = baseUrl;
    }

    public async Task RunAsync()
    {
        while (true)
        {
            Console.WriteLine("Select an option:");
            Console.WriteLine("1. Create ProgramDetail");
            Console.WriteLine("2. Get ProgramDetail by ID");
            Console.WriteLine("3. Update ProgramDetail");
            Console.WriteLine("4. Delete ProgramDetail");
            Console.WriteLine("5. Exit");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    await CreateProgramDetailAsync();
                    break;
                case "2":
                    await GetProgramDetailByIdAsync();
                    break;
                case "3":
                    await UpdateProgramDetailAsync();
                    break;
                case "4":
                    await DeleteProgramDetailAsync();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    private async Task CreateProgramDetailAsync()
    {
        Console.WriteLine("Enter Title:");
        string title = Console.ReadLine();

        Console.WriteLine("Enter Summary:");
        string summary = Console.ReadLine();

        Console.WriteLine("Enter Description:");
        string description = Console.ReadLine();

        Console.WriteLine("Enter KeySkills:");
        string keySkills = Console.ReadLine();

        Console.WriteLine("Enter Benefits:");
        string benefits = Console.ReadLine();

        Console.WriteLine("Enter Criteria:");
        string criteria = Console.ReadLine();

        Console.WriteLine("Enter Program Type (FullTime/PartTime/Contract/Internship):");
        if (Enum.TryParse<ProgramType>(Console.ReadLine(), out ProgramType programType))
        {
            Console.WriteLine($"Selected Program Type: {programType}");
        }
        else
        {
            Console.WriteLine("Invalid Program Type.");
        }


        Console.WriteLine("Enter Start Date (yyyy-MM-dd):");
        if (DateTime.TryParse(Console.ReadLine(), out DateTime start))
        {
            Console.WriteLine($"Selected Start Date: {start:yyyy-MM-dd}");
        }
        else
        {
            Console.WriteLine("Invalid Start Date.");
        }


        Console.WriteLine("Enter Open Date (yyyy-MM-dd):");
        if (DateTime.TryParse(Console.ReadLine(), out DateTime open))
        {
            Console.WriteLine($"Selected Start Date: {open:yyyy-MM-dd}");
        }
        else
        {
            Console.WriteLine("Invalid Open Date.");
        }

        Console.WriteLine("Enter Close Date (yyyy-MM-dd):");
        if (DateTime.TryParse(Console.ReadLine(), out DateTime close))
        {
            Console.WriteLine($"Selected Start Date: {close:yyyy-MM-dd}");
        }
        else
        {
            Console.WriteLine("Invalid Close Date.");
        }

        Console.WriteLine("Enter Duration:");
        string duration = Console.ReadLine();

        Console.WriteLine("Enter Location:");
        string location = Console.ReadLine();

        Console.WriteLine("Enter Minimum Qualification:");
        string minQualification = Console.ReadLine();

        Console.WriteLine("Enter Maximum Application:");
        if (long.TryParse(Console.ReadLine(), out long maxApplication))
        {
            Console.WriteLine($"Selected Maximum Application: {maxApplication}");
        }
        else
        {
            Console.WriteLine("Invalid Maximum Application.");
        }

        var programDetails = new ProgramDetails
        {
            Title = title,
            Summary = summary,
            Description = description,
            KeySkills = keySkills,
            Benefits = benefits,
            Criteria = criteria,
            Type = programType,
            Start = start,
            Open = open,
            Close = close,
            Duration = duration,
            Location = location,
            MinQualification = minQualification,
            MaxApplication = maxApplication
        };


        try
        {
            var createResponse = await _httpClient.PostAsJsonAsync($"{_baseUrl}/api/programdetails", programDetails);

            if (createResponse.IsSuccessStatusCode)
            {
                Console.WriteLine("ProgramDetail created successfully.");
            }
            else
            {
                Console.WriteLine("Error creating ProgramDetail.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

    private async Task GetProgramDetailByIdAsync()
    {
        Console.WriteLine("Enter ProgramDetail ID:");
        var programDetailId = Console.ReadLine();

        try
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}/api/programdetails/{programDetailId}");

            if (response.IsSuccessStatusCode)
            {
                var programDetail = await response.Content.ReadFromJsonAsync<ProgramDetails>();
                Console.WriteLine($"Title: {programDetail.Title}");
                Console.WriteLine($"Summary: {programDetail.Summary}");
                Console.WriteLine($"Description: {programDetail.Description}");
                Console.WriteLine($"Key Skills: {programDetail.KeySkills}");
                Console.WriteLine($"Benefits: {programDetail.Benefits}");
                Console.WriteLine($"Criteria: {programDetail.Criteria}");
                Console.WriteLine($"Program Type: {programDetail.Type}");
                Console.WriteLine($"Start Date: {programDetail.Start}");
                Console.WriteLine($"Open Date: {programDetail.Open}");
                Console.WriteLine($"Close Date: {programDetail.Close}");
                Console.WriteLine($"Duration: {programDetail.Duration}");
                Console.WriteLine($"Location: {programDetail.Location}");
                Console.WriteLine($"Minimum Qualification: {programDetail.MinQualification}");
                Console.WriteLine($"Max Application: {programDetail.MaxApplication}");
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                Console.WriteLine("ProgramDetail not found.");
            }
            else
            {
                Console.WriteLine("Error getting ProgramDetail.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

    private async Task UpdateProgramDetailAsync()
    {
        Console.WriteLine("Enter ProgramDetail ID to update:");
        var programDetailId = Console.ReadLine();

        try
        {
            var getResponse = await _httpClient.GetAsync($"{_baseUrl}/api/programdetails/{programDetailId}");

            if (getResponse.IsSuccessStatusCode)
            {
                var existingProgramDetail = await getResponse.Content.ReadFromJsonAsync<ProgramDetails>();

                Console.WriteLine("Enter updated Title:");
                existingProgramDetail.Title = Console.ReadLine();

                Console.WriteLine("Enter updated Summary:");
                existingProgramDetail.Summary = Console.ReadLine();

                Console.WriteLine("Enter updated Description:");
                existingProgramDetail.Description = Console.ReadLine();

                Console.WriteLine("Enter updated Key Skills:");
                existingProgramDetail.KeySkills = Console.ReadLine();

                Console.WriteLine("Enter updated Benefits:");
                existingProgramDetail.Benefits = Console.ReadLine();

                Console.WriteLine("Enter updated Criteria:");
                existingProgramDetail.Criteria = Console.ReadLine();

                Console.WriteLine("Enter updated Type (FullTime/PartTime/Contract/Internship):");
                if (Enum.TryParse<ProgramType>(Console.ReadLine(), out ProgramType programType))
                {
                    existingProgramDetail.Type = programType;
                }
                else
                {
                    Console.WriteLine("Invalid Program Type.");
                }

                Console.WriteLine("Enter updated Start Date (yyyy-MM-dd):");
                if (DateTime.TryParse(Console.ReadLine(), out DateTime start))
                {
                    existingProgramDetail.Start = start;
                }
                else
                {
                    Console.WriteLine("Invalid Start Date.");
                }

                Console.WriteLine("Enter updated Open Date (yyyy-MM-dd):");
                if (DateTime.TryParse(Console.ReadLine(), out DateTime open))
                {
                    existingProgramDetail.Open = open;
                }
                else
                {
                    Console.WriteLine("Invalid Open Date.");
                }

                Console.WriteLine("Enter updated Close Date (yyyy-MM-dd):");
                if (DateTime.TryParse(Console.ReadLine(), out DateTime close))
                {
                    existingProgramDetail.Close = close;
                }
                else
                {
                    Console.WriteLine("Invalid Close Date.");
                }

                Console.WriteLine("Enter updated Duration:");
                existingProgramDetail.Duration = Console.ReadLine();

                Console.WriteLine("Enter updated Location:");
                existingProgramDetail.Location = Console.ReadLine();

                Console.WriteLine("Enter updated Minimum Qualification:");
                existingProgramDetail.MinQualification = Console.ReadLine();

                Console.WriteLine("Enter updated Maximum Application:");
                if (long.TryParse(Console.ReadLine(), out long maxApplication))
                {
                    existingProgramDetail.MaxApplication = maxApplication;
                }
                else
                {
                    Console.WriteLine("Invalid Maximum Application.");
                }

                var updateResponse = await _httpClient.PutAsJsonAsync($"{_baseUrl}/api/programdetails/{programDetailId}", existingProgramDetail);

                if (updateResponse.IsSuccessStatusCode)
                {
                    Console.WriteLine("ProgramDetail updated successfully.");
                }
                else
                {
                    Console.WriteLine("Error updating ProgramDetail.");
                }
            }
            else if (getResponse.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                Console.WriteLine("ProgramDetail not found.");
            }
            else
            {
                Console.WriteLine("Error getting ProgramDetail.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

    private async Task DeleteProgramDetailAsync()
    {
        Console.WriteLine("Enter ProgramDetail ID to delete:");
        var programDetailId = Console.ReadLine();

        try
        {
            var deleteResponse = await _httpClient.DeleteAsync($"{_baseUrl}/api/programdetails/{programDetailId}");

            if (deleteResponse.IsSuccessStatusCode)
            {
                Console.WriteLine("ProgramDetail deleted successfully.");
            }
            else if (deleteResponse.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                Console.WriteLine("ProgramDetail not found.");
            }
            else
            {
                Console.WriteLine("Error deleting ProgramDetail.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}
