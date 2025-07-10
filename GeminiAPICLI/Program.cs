using GenerativeAI;
using System;
using System.Threading.Tasks;
using GenerativeAI.Types;

public class GeminiChat
{
    public static async Task Main(string[] args)
    {
        // Create the generative model
        GoogleAi genAI = new GoogleAi(Environment.GetEnvironmentVariable("GEMINI_API_KEY"));
        GenerativeModel model = genAI.CreateGenerativeModel("models/gemini-2.5-flash");

        // Start the chat session
        ChatSession chat = model.StartChat();

        Console.WriteLine("Gemini Chat CLI");
        Console.WriteLine("Enter '/exit' to end the conversation.");
        Console.WriteLine("------------------------------------");

        while (true)
        {
            Console.Write("You: ");
            string? userInput = Console.ReadLine();

            if (userInput.Equals("/exit", StringComparison.OrdinalIgnoreCase))
            {
                break;
            }

            if (string.IsNullOrWhiteSpace(userInput))
            {
                continue;
            }

            try
            {
                // Send the user's message to the model
                GenerateContentResponse response = await model.GenerateContentAsync(userInput);

                // Print the model's response
                Console.WriteLine($"Gemini: {response.Text()}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}