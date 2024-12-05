using System.Runtime.CompilerServices;
using System.Text.Json;

class MeetingController
{
    public MeetingView _view;
    public List<Meeting> _meetings;



    public MeetingController()
    {
        _view = new MeetingView();
        _meetings = LoadMeetings(); // LoadMeetings returnerer en List<Meeting> fra meetings.json
    }

    public bool RunMenu()
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
        string[] participants = _view.GetParticipants(); // kjører GetParticipants metoden fra view, ber bruker om hvilke deltagere som skal være med
        DateTime time = _view.GetTime(); // kjører GetTime metoden fra view, ber bruker om en tid for møtet

        Meeting meeting = new Meeting()  // lager et nytt møte med brukerens input
        {
            Participants = participants,
            Time = time
        };

        _meetings.Add(meeting); //legger til møtet i List<Meeting> _meetings
        SaveToJson(); //serialize til json og skriv inn i meetings.json

        _view.DisplayMessage("New meeting has been saved!");

    }

    public JsonSerializerOptions options = new JsonSerializerOptions
    {
        WriteIndented = true
    };

    public void SaveToJson()
    {
        string json = JsonSerializer.Serialize(_meetings, options); // gjør møtet(string[] og DateTime) om til Json format
        File.WriteAllText("meetings.json", json); // skriver inn til meetings.json
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

        string json = File.ReadAllText("meetings.json"); // leser all teksten i meetings.json
        return JsonSerializer.Deserialize<List<Meeting>>(json) ?? new List<Meeting>(); // gjør om teksten til et et List<Meeting> objekt. om den er null, eller ikke klarer å gjøre det om, lag ny liste.
    }
}