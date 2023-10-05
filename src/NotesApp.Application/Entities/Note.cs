
using System.ComponentModel.DataAnnotations;
using NotesApp.Application.Extensions;

namespace NotesApp.Application.Entities;

public class Note
{
   [Key]
   public int Id { get; set; }
   
   [Required(ErrorMessage = "Title is required")]
   [MaxLength(128, ErrorMessage = "Title is too long.")]
   public string Title { get; set; }
   
   [Required(ErrorMessage = "Text is required")]
   public string Text { get; set; }
   
   public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
   
   public string HumanizedTimeDifference
   {
      get
      {
         var diff = DateTime.UtcNow.Subtract(CreatedAt);
         return diff.Humanize();
      }
   }
}