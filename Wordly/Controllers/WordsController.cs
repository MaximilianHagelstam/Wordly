using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wordly.Data;
using Wordly.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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

        // GET: api/<WordsController>
        [HttpGet]
        public ActionResult<IEnumerable<Word>> GetAllWords()
        {
            var words = _repository.GetAllWords();
            return Ok(words);
        }

        // GET api/<WordsController>/5
        [HttpGet("{id}")]
        public ActionResult<Word> Get(int id)
        {
            return Ok(_repository.GetWordById(id));
        }

        // POST api/<WordsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<WordsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<WordsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
