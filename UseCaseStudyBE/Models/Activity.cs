namespace UseCaseStudyBE.Models;

public class Activity
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string? Title { get; set; }

    public DateTime Date { get; set; } = DateTime.Now;

    public string? Description { get; set; }

    public string? Category { get; set; }

    public string? City { get; set; }

    public string? Venue { get; set; }
}