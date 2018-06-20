using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.Extensions.Caching.Memory;

namespace Assessment.Web.Models
{
    public interface IBoardRepository
    {
        IQueryable<Board> GetAll();
        Board Find(int id);
        bool Add(Board board);
        bool Delete(int id);
    }

    public class BoardRepository : IBoardRepository
    {
        private List<Board> boards;
        private IMemoryCache _cache; //cache boards
        private static readonly object BoardsLock = new object();

        public BoardRepository(IMemoryCache cache)
        {
            //boards = GetBoardsFromFile();
            _cache = cache;            
        }


        public void InitCache()
        {
            _cache.Set("Boards", GetBoardsFromFile());
        }

        public void SetCache(List<Board> boards)
        {
            _cache.Set("Boards", boards);
        }


        //get from file or cache
        public List<Board> GetBoards()
        {
            object boardsFromCache;
            
            if (!_cache.TryGetValue("Boards", out boardsFromCache))
            {
                lock (BoardsLock)
                {
                    if (!_cache.TryGetValue("Boards", out boardsFromCache))
                    {
                        
                        boards = GetBoardsFromFile();

                        SetCache(boards);
                    }
                    else
                    {
                        
                        boards = (List<Board>)boardsFromCache;
                    }
                }
            }
            else
            {
                
                boards = (List<Board>)boardsFromCache;
            }
            return boards;
        }


        private List<Board> GetBoardsFromFile()
        {
            var filePath = Application.Configuration["DataFile"];
            if (!Path.IsPathRooted(filePath)) filePath = Path.Combine(Directory.GetCurrentDirectory(), filePath);

            var json = System.IO.File.ReadAllText(filePath);

            return JsonConvert.DeserializeObject<List<Board>>(json);
        }

        public IQueryable<Board> GetAll()
        {
            return GetBoards().AsQueryable();
        }

        public Board Find(int id)
        {
            return GetBoards().FirstOrDefault(x => x.Id == id);
        }

        public bool Add(Board board)
        {
            if (Find(board.Id) != null) return false;

            boards = GetBoards();
            boards.Add(board);

            SetCache(boards);

            return true;
        }

        public bool Delete(int id)
        {
            var board = Find(id);
            if (board == null) return false;

            boards = GetBoards();
            boards.Remove(board);

            SetCache(boards);
            return true;
        }
    }
}
