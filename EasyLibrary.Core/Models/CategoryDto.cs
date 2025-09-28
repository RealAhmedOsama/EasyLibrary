namespace EasyLibrary.Core.Models;

public class CategoryDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime CreatedOn { get; set; }
    public bool IsActive { get; set; }

    // Navigation properties
    public List<BookDto> Books { get; set; }
}