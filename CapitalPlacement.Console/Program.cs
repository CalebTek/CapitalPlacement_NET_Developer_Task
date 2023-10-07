
using var httpClient = new HttpClient();
var baseUrl = "https://localhost:7164"; 

var programDetailsConsole = new ProgramDetailsService(httpClient, baseUrl);
await programDetailsConsole.RunAsync();
