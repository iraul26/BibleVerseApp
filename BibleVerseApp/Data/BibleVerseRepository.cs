using BibleVerseApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BibleVerseApp.Data {
    /**
     * repository class to handle database queries for our models
     */
    public class BibleVerseRepository {

        //dbcontext to interact with the db
        public readonly ApplicationDbContext context;

        /// <summary>
        /// constructor to initialize the repository with the ApplicationDbContext
        /// </summary>
        /// <param name="context"></param>
        public BibleVerseRepository(ApplicationDbContext context) {
            this.context = context;
        }
        
        /// <summary>
        /// method to search for bible verses based on the search term inputed and testament selected
        /// </summary>
        /// <param name="searchTerm"></param>
        /// <param name="testament"></param>
        /// <returns>list of bible verse models that match with the parameters</returns>
        public async Task<List<BibleVerseModel>> SearchVersesAsync(string searchTerm, int testament) {
            IQueryable<BibleVerseModel> query = context.BibleVerses;

            if(testament == 1) {
                //old testament books 1-39
                query = query.Where(v => v.Book >= 1 && v.Book <= 39);
                
            }
            else if(testament == 2) {
                //new testament books 40-66
                query = query.Where(v => v.Book >= 40 && v.Book <= 66);
            }

            //filter the query with the searchterm
            if(!string.IsNullOrEmpty(searchTerm)) {
                query = query.Where(v => v.Text.Contains(searchTerm));
            }

            //this executes the query and returns the list
            return await query.ToListAsync();
        }

        /// <summary>
        /// method to retreive all bible verses in the new testament
        /// </summary>
        /// <returns>list of bible verse models in the new testament</returns>
        public async Task<List<BibleVerseModel>> GetAllNewTestamentVersesAsync() {
            return await context.BibleVerses.Where(v => v.Book >= 40 && v.Book <= 66).ToListAsync();
        }


        /// <summary>
        /// method to retrieve all bible verses in the old testament
        /// </summary>
        /// <returns>list of bible verse models in the old testament</returns>
        public async Task<List<BibleVerseModel>> GetAllOldTestamentVersesAsync() {
            return await context.BibleVerses.Where(v => v.Book >= 1 && v.Book <= 39).ToListAsync();
        }

    }
}