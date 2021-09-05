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
        public ActionResult<IEnumerable<WordReadDto>> GetAllWords()
        {
            string currentUserId;

            try
            {
                ClaimsPrincipal currentUser = this.User;
                currentUserId = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
            }
            catch
            {
                return BadRequest();
            }

            var words = _repository.GetAllWords(currentUserId);
            return Ok(_mapper.Map<IEnumerable<WordReadDto>>(words));
        }

        [HttpGet("{id}", Name = "GetWordById")]
        public ActionResult<WordReadDto> GetWordById(int id)
        {
            string currentUserId;

            try
            {
                ClaimsPrincipal currentUser = this.User;
                currentUserId = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
            }
            catch
            {
                return BadRequest();
            }

            var word = _repository.GetWordById(id, currentUserId);

            if (word != null)
            {
                return Ok(_mapper.Map<WordReadDto>(word));
            }

            return NotFound();
        }

        [HttpPost]
        public ActionResult<WordReadDto> CreateWord(WordCreateDto wordCreateDto)
        {
            ClaimsPrincipal currentUser = this.User;
            string currentUserId = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;

            var wordModel = _mapper.Map<Word>(wordCreateDto);
            wordModel.ApplicationUserId = currentUserId;

            _repository.CreateWord(wordModel);
            _repository.SaveChanges();

            var wordReadDto = _mapper.Map<WordReadDto>(wordModel);

            return CreatedAtRoute(nameof(GetWordById), new { wordModel.Id }, wordReadDto);
        }

        [HttpDelete("{id}")]
        public void DeleteWord(int id)
        {
        }
    }
}
