using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

/*
 * A view model represents the data that you want to display on 
 * your view/page, whether it be used for static text or for input
 * values (like textboxes and dropdown lists). It is something 
 * different than your domain model. It is a model for the view. 
 */
namespace Template.NetCore.Application.ViewModels
{
    public class BookViewModel : BaseViewModel
    {
        public BookViewModel() { }

        public BookViewModel(Guid bookId, string author, string title, string description)
        {
            Id = bookId;
            Author = author;
            Title = title;
            Description = description;
        }

        [Required]
        [MaxLength(30)]
        [JsonProperty(PropertyName = "author")]
        public string Author { get; set; } = "";

        [Required]
        [MaxLength(50)]
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; } = "";

        [MaxLength(1000)]
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
    }
}
