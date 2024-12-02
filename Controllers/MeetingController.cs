using System.Runtime.CompilerServices;
using System.Text.Json;

class MeetingController
{
    public void NewMeeting(Meeting meeting) //tar inn et nytt møte meeting og legger det til meetings dokumentet(meetings.json)
    {

        List<Meeting> meetings = LoadMeetings(); // finner listen over møter
        meetings.Add(meeting); // legger til det nye møtet
        File.WriteAllText("meetings.json", JsonSerializer.Serialize(meetings)); //skriver det nye møtet inn i json filen meetings.json
    }

    public List<Meeting> LoadMeetings()
    {
        if (!File.Exists("meetings.json"))
        { // hvis meetings.json ikke eksisterer
            return new List<Meeting>(); // lag ny liste med møter
        }

        string json = File.ReadAllText("meetings.json"); // leser all teksten i meetings.json og lagrer det i json variabelen.
        return JsonSerializer.Deserialize<List<Meeting>>(json) ?? new List<Meeting>(); // gjør om teksten til et et List<Meeting> objekt. om det ikke går(), lag en ny List<meeting>.
    }
}