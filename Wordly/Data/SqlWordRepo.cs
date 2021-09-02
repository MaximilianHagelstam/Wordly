using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wordly.Models;

namespace Wordly.Data
{
    public class SqlWordRepo : IWordRepo
    {
        private readonly ApplicationDbContext _context;

        public SqlWordRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public void CreateWord(Word word)
        {
            if (word == null)
            {
                throw new ArgumentNullException(nameof(word));
            }

            throw new NotImplementedException();
        }

        public void DeleteWord(Word word)
        {
            if (word == null)
            {
                throw new ArgumentNullException(nameof(word));
            }

            throw new NotImplementedException();
        }

        public IEnumerable<Word> GetAllWords()
        {
            throw new NotImplementedException();
        }

        public Word GetWordById(int id)
        {
            throw new NotImplementedException();
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges()) > 0;
        }

        public void UpdateWord(Word word)
        {
            // Empty
        }
    }
}
