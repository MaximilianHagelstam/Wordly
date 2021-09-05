using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wordly.Models;

namespace Wordly.Data
{
    public class MockWordRepo : IWordRepo
    {
        public void CreateWord(Word word)
        {
            throw new NotImplementedException();
        }

        public void DeleteWord(Word word)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Word> GetAllWords()
        {
            var words = new List<Word>
            {
                new Word { Id = 0, Body = "Make bread", Meaning = "Deez" },
                new Word { Id = 1, Body = "Go to shops", Meaning = "Ligma" },
                new Word { Id = 2, Body = "Eat", Meaning = "Nuts" },
            };

            return words;
        }

        public IEnumerable<Word> GetAllWords(string userId)
        {
            throw new NotImplementedException();
        }

        public Word GetWordById(int id)
        {
            return new Word { Id = 0, Body = "Eat", Meaning = "Nuts" };
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void UpdateWord(Word word)
        {
            throw new NotImplementedException();
        }
    }
}
