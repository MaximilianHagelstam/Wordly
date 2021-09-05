using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Wordly.Data;
using Wordly.Dtos;
using Wordly.Models;

namespace Wordly.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WordsController : ControllerBase
    {
        private readonly IWordRepo _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<WordsController> _logger;

        public WordsController(IWordRepo repository, IMapper mapper, ILogger<WordsController> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Word>> GetAllWords()
        {
            var words = _repository.GetAllWords();
            return Ok(words);
        }

        [HttpGet("{id}")]
        public ActionResult<Word> GetWordById(int id)
        {
            return Ok(_repository.GetWordById(id));
        }

        [HttpPost]
        public ActionResult<WordReadDto> CreateWord(WordCreateDto wordCreateDto)
        {
            ClaimsPrincipal currentUser = this.User;
            string currentUserId = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;

            var wordModel = _mapper.Map<Word>(wordCreateDto);
            wordModel.UserId = currentUserId;

            _repository.CreateWord(wordModel);
            _repository.SaveChanges();

            var wordReadDto = _mapper.Map<WordReadDto>(wordModel);

            return CreatedAtRoute(nameof(GetWordById), new { wordReadDto.Id }, wordReadDto);
        }

        [HttpPut("{id}")]
        public void UpdateWord(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void DeleteWord(int id)
        {
        }
    }
}
