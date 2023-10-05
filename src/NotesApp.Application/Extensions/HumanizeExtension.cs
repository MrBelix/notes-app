namespace NotesApp.Application.Extensions;

public static class HumanizeExtension
{
    public static string Humanize(this TimeSpan timeSpan)
    {
        var years = timeSpan.Days / 365;
        var months = (timeSpan.Days % 365) / 30;
        var days = timeSpan.Days % 30;
        var hours = timeSpan.Hours;
        var minutes = timeSpan.Minutes;

        if (years > 0)
            return $"{years} year{(years > 1 ? "s" : "")} ago";
        if (months > 0)
            return $"{months} month{(months > 1 ? "s" : "")} ago";
        if (days > 0)
            return $"{days} day{(days > 1 ? "s" : "")} ago";
        if (hours > 0)
            return $"{hours} hour{(hours > 1 ? "s" : "")} ago";
        if (minutes > 0)
            return $"{minutes} minute{(minutes > 1 ? "s" : "")} ago";

        return "less than a minute ago";
    }
}