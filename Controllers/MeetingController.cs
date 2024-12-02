using System.Runtime.CompilerServices;
using System.Text.Json;

class MeetingController
{
    public MeetingView _view;
    public List<Meeting> _meetings;



    public MeetingController()
    {
        _view = new MeetingView();
        _meetings = LoadMeetings();
    }

    public bool HandleMenu()
    {
        string? choice = _view.MenuChoice();

        switch (choice)
        {
            case "add":
                NewMeeting();
                return true;

            case "list":
                ListMeetings();
                return true;

            case "exit":
                _view.DisplayMessage("program is terminating...");
                return false;

            default:
                _view.DisplayMessage("Did not expect your input, are you sure you wrote either ADD, LIST or EXIT?");
                return true;
        }


    }
    public void NewMeeting() //tar inn et nytt møte meeting og legger det til meetings dokumentet(meetings.json)
    {
        string[] participants = _view.GetParticipants();
        DateTime time = _view.GetTime();

        Meeting meeting = new Meeting()
        {
            Participants = participants,
            Time = time
        };

        _meetings.Add(meeting);
        SaveToJson(); //serialize til json og skriv in i meetings.json

        _view.DisplayMessage("New meeting has been saved!");

    }

    public void SaveToJson()
    {
        string json = JsonSerializer.Serialize(_meetings);
        File.WriteAllText("meetings.json", json);
    }

    public void ListMeetings()
    {
        _view.DisplayMeetings(_meetings);
    }

    public List<Meeting> LoadMeetings()
    {
        if (!File.Exists("meetings.json")) // hvis meetings.json ikke eksisterer
        {
            return new List<Meeting>(); // lag ny liste med møter
        }

        string json = File.ReadAllText("meetings.json"); // leser all teksten i meetings.json og lagrer det i json variabelen.
        return JsonSerializer.Deserialize<List<Meeting>>(json) ?? new List<Meeting>(); // gjør om teksten til et et List<Meeting> objekt. om det ikke går(), lag en ny List<meeting>.
    }
}