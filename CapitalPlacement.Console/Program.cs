
using var httpClient = new HttpClient();
var baseUrl = "https://api-url"; 

var programDetailsConsole = new ProgramDetailsService(httpClient, baseUrl);
await programDetailsConsole.RunAsync();
