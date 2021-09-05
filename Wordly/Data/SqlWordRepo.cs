using System;
using System.Collections.Generic;
using System.Linq;
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

            _context.Words.Add(word);
        }

        public void DeleteWord(Word word)
        {
            if (word == null)
            {
                throw new ArgumentNullException(nameof(word));
            }

            _context.Words.Remove(word);
        }

        public IEnumerable<Word> GetAllWords(string userId)
        {
            /* var words = new List<Word>
            {
                new Word { Id = 0, Body = "Make bread", Meaning = "Deez" },
                new Word { Id = 1, Body = "Go to shops", Meaning = "Ligma" },
                new Word { Id = 2, Body = "Eat", Meaning = "Nuts" },
            }; */

            return _context.Words.Where(p => p.ApplicationUserId == userId).ToList();
        }

        public Word GetWordById(int id, string userId)
        {
            return _context.Words.FirstOrDefault(p => p.Id == id && p.ApplicationUserId == userId);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges()) > 0;
        }
    }
}
