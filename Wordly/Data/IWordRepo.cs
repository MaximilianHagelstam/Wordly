using System.Collections.Generic;
using Wordly.Models;

namespace Wordly.Data
{
    public interface IWordRepo
    {
        bool SaveChanges();
        IEnumerable<Word> GetAllWords(string userId);
        Word GetWordById(int id);
        void CreateWord(Word word);
        void UpdateWord(Word word);
        void DeleteWord(Word word);
    }
}
