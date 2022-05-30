using economyopedia_server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace economyopedia_server.Data
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BaseController<TEntity> : ControllerBase where TEntity : BaseModel
    {
        private readonly EconomyopediaDbContext _context;
        private DbSet<TEntity> _dbSet { get; set; }

        public BaseController(EconomyopediaDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();

            _context.Database.EnsureCreated();
        }


        [HttpGet]
        public virtual List<TEntity> GetAll()
        {
            return _dbSet.ToList();
        }

        [HttpGet]
        public virtual TEntity GetOne(int id)
        {
            return _dbSet.FirstOrDefault(x => x.Id == id);
        }

        [HttpPost]
        public virtual TEntity CreateOrUpdate(TEntity entity)
        {
            if (entity == null)
                return null;

            _dbSet.Update(entity);
            _context.SaveChanges();

            return entity;

        }

        [HttpDelete]
        public virtual TEntity Delete(int id)
        {
            var entity = _dbSet.FirstOrDefault(x => x.Id == id);

            if (entity == null)
                return null;

            _dbSet.Remove(entity);
            _context.SaveChanges();

            return entity;
        }



    }
}
