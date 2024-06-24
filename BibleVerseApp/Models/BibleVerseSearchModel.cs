using System.ComponentModel.DataAnnotations;

namespace BibleVerseApp.Models
{
    /**
     * this class will be for when we search for a verse, this model will be created holding the search term and the testament picked
     */
    public class BibleVerseSearchModel {
        [Required(ErrorMessage = "Please enter a verse to look for")]
        [Display(Name = "Search For A Verse")]
        public string SearchVerse { get; set; }

        [Required(ErrorMessage = "Please Select A Testament")]
        [Display(Name = "Select Testament")]
        public int Testament { get; set; }
    }
}