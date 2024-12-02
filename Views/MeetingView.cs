class MeetingView
{
    public string MenuChoice()
    {
        Console.WriteLine("Do you wish to ADD a new meeting, LIST current meetings or EXIT?");
        return Console.ReadLine().Trim().ToLower();
    }

    public string[] GetParticipants()
    {
        while (true)
        {
            Console.WriteLine("Write the name of the participants seperated by a comma (,)");
            string? input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
            {
                return input.Split(',').Select(participant => participant.Trim()).ToArray();
            }
            Console.WriteLine("Please write something. Participants cant be empty.");

        }
    }

    public DateTime GetTime()
    {
        while (true)
        {
            Console.WriteLine("What time will they be meeting? use format (yyyy-MM-dd HH:mm)");
            string? input = Console.ReadLine();
            if (DateTime.TryParse(input, out DateTime time))
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
            Console.WriteLine(meeting.ToString());
        }
    }
}