namespace BibleVerseApp.Models {
    /**
     * This class is gonna be a model for my bible verse app that will hold all data for one bible verse
     */
    public class BibleVerseModel {
        public int Id { get; set; }
        public int Book { get; set; }
        public int Chapter { get; set; }
        public int Verse { get; set; }
        public string Text { get; set; }
    }
}