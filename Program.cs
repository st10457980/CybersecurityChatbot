using System;
using System.Media;
using System.Threading;
using NAudio.Wave;

class CyberSecurityBot
{
    static void Main()
    {
        // Play Voice Greeting
        PlayVoiceGreeting();

        // Display ASCII Logo
        DisplayAsciiArt();

        // Personalized User Interaction
        Console.Write("\nEnter your name: ");
        string userName = Console.ReadLine() ?? "default value";

        while (string.IsNullOrWhiteSpace(userName))
        {
            Console.WriteLine("Name cannot be empty. Please enter your name:");
            userName = Console.ReadLine() ?? "default value";
        }

        Console.WriteLine($"\nHello, {userName}! How can I assist you with cybersecurity today?\n");

        // Start Chat Loop
        while (true)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\nAsk a cybersecurity question (or type 'exit' to quit): ");
            Console.ResetColor();
            string question = Console.ReadLine() ?? "default value".ToLower() ?? "default value";

            if (question == "exit")
            {
                Console.WriteLine("\nGoodbye! Stay safe online!");
                break;
            }

            RespondToUser(question);
        }
    }

    // Function to Play Voice Greeting
    static void PlayVoiceGreeting()
   {
    try
    {
        using (var audioFile = new AudioFileReader("greetings.wav"))
        using (var outputDevice = new WaveOutEvent())
        {
            outputDevice.Init(audioFile);
            outputDevice.Play();
            while (outputDevice.PlaybackState == PlaybackState.Playing)
            {
                Thread.Sleep(500);
            }
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine("Error playing voice greeting: " + ex.Message);
    }
}

    // Function to Display ASCII Art
    static void DisplayAsciiArt()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(@"
        
           
  ██████╗ ███████╗ █████╗ ██████╗ 
  ██╔══██╗██╔════╝██╔══██╗██╔══██╗
  ██████╔╝█████╗  ███████║██████╔╝
  ██╔═══╝ ██╔══╝  ██╔══██║██╔═══╝ 
  ██║     ███████╗██║  ██║██║     
  ╚═╝     ╚══════╝╚═╝  ╚═╝╚═╝     
  CYBERSECURITY AWARENESS BOT
     ");
        Console.ResetColor();
    }

    // Function to Respond to User Queries
    static void RespondToUser(string question)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;

        if (question.Contains("password"))
        {
            Console.WriteLine("Tip: Use strong, unique passwords and enable multi-factor authentication.");
        }
        else if (question.Contains("phishing"))
        {
            Console.WriteLine("Beware of suspicious links and emails. Verify before clicking.");
        }
        else if (question.Contains("safe browsing"))
        {
            Console.WriteLine("Always check website security (HTTPS) and avoid public Wi-Fi for transactions.");
        }
        else
        {
            Console.WriteLine("I didn't quite understand that. Could you rephrase?");
        }

        Console.ResetColor();
    }
}

