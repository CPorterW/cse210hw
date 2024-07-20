using System.Threading.Tasks;
using System.Diagnostics;
using System.Text;

public class Encounter{

    private static string GetCommandOutput(string command)
    {
        try
        {
            using (Process process = new Process())
            {
                if (Environment.OSVersion.Platform == PlatformID.Win32NT)
                {
                    process.StartInfo.FileName = "cmd.exe";
                    process.StartInfo.Arguments = $"/c {command}";
                }
                else
                {
                    process.StartInfo.FileName = "/bin/bash";
                    process.StartInfo.Arguments = $"-c \"{command}\"";
                }
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;
                process.Start();

                using (StreamReader reader = process.StandardOutput)
                {
                    string result = reader.ReadToEnd().Trim();
                    if (result.Contains(Environment.NewLine))
                    {
                        result = result.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries)[0];
                    }
                    return result;
                }
            }
        }
        catch (Exception err)
        {
            Console.WriteLine(err);
            return null;
        }
    }

    private static string GetPythonInterpreterPath()
    {
        // Try to get the path from environment variables
        string pythonHome = Environment.GetEnvironmentVariable("PYTHON_HOME");
        if (!string.IsNullOrEmpty(pythonHome))
        {
            return Path.Combine(pythonHome, "python.exe");
        }

        // Use 'where' command on Windows
        if (Environment.OSVersion.Platform == PlatformID.Win32NT)
        {
            return GetCommandOutput("where python");
        }

        // Use 'which' command on macOS/Linux
        if (Environment.OSVersion.Platform == PlatformID.Unix || Environment.OSVersion.Platform == PlatformID.MacOSX)
        {
            return GetCommandOutput("which python3") ?? GetCommandOutput("which python");
        }

        return null;
    }

    private static string Input(string prompt)
    {
        Console.Write(prompt);
        return Console.ReadLine();
    }    
    public async Task RunPythonBattle()
    {
        string pythonInterpreterPath = GetPythonInterpreterPath();
        if (string.IsNullOrEmpty(pythonInterpreterPath))
        {
            Console.WriteLine("Python interpreter not found.");
            Console.ReadKey(true);
            return;
        }
        string pythonScriptPath = @"interactive_battle.py";
        Console.WriteLine($"Python interpreter: {pythonInterpreterPath}");
        Console.WriteLine($"Python script: {pythonScriptPath}");

        ProcessStartInfo start = new ProcessStartInfo
        {
            FileName = pythonInterpreterPath,
            Arguments = $"\"{pythonScriptPath}\"",
            UseShellExecute = false,
            RedirectStandardInput = true,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            CreateNoWindow = true,
            WorkingDirectory = @"../../../Pokemon-Game"
        };

        using (Process process = new Process { StartInfo = start })
        {
            try
            {
                process.Start();
                Console.WriteLine("Process started");
                var outputTask = ConsumeOutputAsync(process);
                var errorTask = ConsumeErrorAsync(process.StandardError);
                await process.WaitForExitAsync();
                await Task.WhenAll(outputTask, errorTask);

                Console.WriteLine($"Python script exited with code: {process.ExitCode}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                Console.WriteLine($"Stack trace: {ex.StackTrace}");
            }
        }
    }

    private async Task ConsumeOutputAsync(Process process)
    {
        var reader = process.StandardOutput;
        var writer = process.StandardInput;

        while (!reader.EndOfStream)
        {
            string line = await reader.ReadLineAsync();
            if (line == null) break;

            if (line.StartsWith("INPUT:"))
            {
                string prompt = line.Substring(6);
                Console.Write(prompt);
                string input = Console.ReadLine();
                await writer.WriteLineAsync(input);
                await writer.FlushAsync();
            }
            else
            {
                Console.WriteLine(line);
            }
        }
    }

    private async Task ConsumeErrorAsync(StreamReader reader)
    {
        string errorOutput = await reader.ReadToEndAsync();
        if (!string.IsNullOrEmpty(errorOutput))
        {
            Console.WriteLine($"Error output: {errorOutput}");
        }
    }
}