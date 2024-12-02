class MeetingView
{
    public void DisplayMessage(string message)
    {
        Console.WriteLine(message);
    }

    public void DisplayMeetings(List<Meeting> meetings)
    {
        if (meetings.Count == 0)
        {
            Console.WriteLine("No meetings founds to display.");
            return;
        }

        foreach (var meeting in meetings)
        {
            Console.WriteLine(meeting.ToString());
        }
    }
}