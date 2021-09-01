using AutoMapper;
using Wordly.Dtos;
using Wordly.Models;

namespace Wordly.Profiles
{
    public class WordProfile : Profile
    {
        public WordProfile()
        {
            CreateMap<Word, WordReadDto>();
            CreateMap<WordCreateDto, Word>();
        }
    }
}
