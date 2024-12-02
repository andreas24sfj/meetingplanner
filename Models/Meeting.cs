public class Meeting
{
    public required string[] Participants { get; set; }
    public DateTime Time { get; set; }

    public override string ToString()
    {
        return $"{string.Join(" and ", Participants)} are meeting at {Time}.";
    }

}