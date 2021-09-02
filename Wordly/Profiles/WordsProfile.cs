using AutoMapper;
using Wordly.Dtos;
using Wordly.Models;

namespace Wordly.Profiles
{
    public class WordsProfile : Profile
    {
        public WordsProfile()
        {
            CreateMap<Word, WordReadDto>();
            CreateMap<WordCreateDto, Word>();
        }
    }
}
