using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Assessment.Web.Models;
using Newtonsoft.Json;

namespace Assessment.Web.Controllers
{
    [Route("api/[controller]")]
    public class BoardsController : Controller
    {
        public IBoardRepository boards;
                
        public BoardsController(IBoardRepository boards)
        {
            this.boards = boards;
        }

        [HttpGet]
        public IEnumerable<Board> GetAll()
        {
            return boards.GetAll();
        }

        [HttpGet("{id}")]
        public Board Find(int id)
        {
            if (id <= 0) throw new ArgumentOutOfRangeException(nameof(id), "Board ID must be greater than zero.");

            return boards.Find(id);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id <= 0) throw new ArgumentOutOfRangeException(nameof(id), "Board ID must be greater than zero.");

            if (boards.Delete(id))
            {
                return Ok();
            }

            return BadRequest();
            
        }


        [HttpPost]
        public IActionResult Create([FromBody] Board board)
        {

            if (board == null) return BadRequest();

            boards.Add(board);

            return Ok();
        }
    }
}
