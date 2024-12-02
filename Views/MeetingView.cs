using System.Net.Http.Headers;

class MeetingView
{
    public string MenuChoice()
    {
        Console.WriteLine("Do you wish to ADD a new meeting, LIST current meetings or EXIT?");
        string? input = Console.ReadLine();
        if (string.IsNullOrEmpty(input))
        {
            return string.Empty;
        }

        return input.Trim().ToLower(); // returnerer brukerinput uten whitespace og i lowercase for å stemme med switchen
    }

    public string[] GetParticipants()
    {
        while (true)
        {
            Console.WriteLine("Write the name of the participants seperated by a comma (,)");
            string? input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
            {
                return input.Split(',').Select(participant => participant.Trim()).ToArray(); // splitter arrayet ved (,) , trimmer whitespace og lager string[]
            }
            Console.WriteLine("Please write something. Participants cant be null or empty.");

        }
    }

    public DateTime GetTime()
    {
        while (true)
        {
            Console.WriteLine("What time will they be meeting? use format (yyyy-MM-dd HH:mm)");
            string? input = Console.ReadLine();
            if (DateTime.TryParse(input, out DateTime time))  // hvis den klarer å parse til DateTime, gjør om til DateTime og returner.
            {
                return time;
            }
            Console.WriteLine("Couldnt read as datetime. are you sure you used the correct format? (yyyy-MM-dd HH:mm)");
        }
    }

    public void DisplayMessage(string message)
    {
        Console.WriteLine(message);
    }

    public void DisplayMeetings(List<Meeting> meetings)
    {
        if (meetings.Count == 0)
        {
            Console.WriteLine("No meetings found to display.");
            return;
        }

        foreach (var meeting in meetings)
        {
            Console.WriteLine(meeting.ToString()); //skriver ut meeting med override tostring metode. $"{string.Join(" and ", Participants)} are meeting at {Time}.";
        }
    }
}