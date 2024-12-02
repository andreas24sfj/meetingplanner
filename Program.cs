MeetingController controller = new MeetingController();
MeetingView view = new MeetingView();

bool isRunning = true;

string[] meetingParticipants;

while (isRunning)
{
    view.DisplayMessage("Do you wish to ADD a new meeting or LIST current meetings?");
    string? initialInput = Console.ReadLine();
    if (initialInput?.Trim().ToLower() == "add")
    {

        view.DisplayMessage("Enter the name of the meeting participants seperated by a comma(,): ");
        string? userInputParticipants = Console.ReadLine();
        if (string.IsNullOrEmpty(userInputParticipants))
        {
            view.DisplayMessage("Please write the name of participants. it cant be empty");
            continue;
        }
        else
        {
            meetingParticipants = userInputParticipants.Split(',').Select(participant => participant.Trim()).ToArray();
        }

        view.DisplayMessage("Enter the time for the meeting in the following format (yyyy-MM-dd HH:mm):");

        string? userInputTime = Console.ReadLine();

        DateTime meetingTime;

        if (!DateTime.TryParse(userInputTime, out meetingTime))
        {
            view.DisplayMessage("Cant parse to DateTime, are you sure you followed this format (yyyy-MM-dd HH:mm):");
            continue;
        }

        Meeting meeting = new Meeting // lager et nytt møte med string[] meetingParticipants og DateTime meetingTime
        {
            Participants = meetingParticipants,
            Time = meetingTime
        };

        controller.NewMeeting(meeting);
        view.DisplayMessage("Your meeting as been saved!");
    }
    else if (initialInput?.Trim().ToLower() == "list")
    {
        List<Meeting> meetings = controller.LoadMeetings();
        view.DisplayMeetings(meetings);
    }
    else
    {
        view.DisplayMessage("Please write either ADD to add new meeting or LIST to list all meetings.");
    }
}