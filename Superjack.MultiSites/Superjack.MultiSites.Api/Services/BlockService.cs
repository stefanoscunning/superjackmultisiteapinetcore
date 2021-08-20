using Superjack.MultiSites.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Superjack.MultiSites.Api.Services
{
  public interface IBlockService
  {
    IEnumerable<Block> GetAll();
    Block GetById(long id);
    Block GetByUuid(string uuid);
    Block Create(Block item);
    void Update(Block newitem);
    void Delete(long id);

  }
  public class BlockService : IBlockService
  {
    private AppDbContext _context;

    public BlockService(AppDbContext context)
    {
      _context = context;
    }

    public IEnumerable<Block> GetAll()
    {
      return _context.Blocks.OrderBy(x=>x.Title);
    }


    public Block GetById(long id)
    {
      return _context.Blocks.Find(id);
    }

    public Block GetByUuid(string uuid)
    {
      return _context.Blocks.Where(x => x.Uuid == Guid.Parse(uuid)).FirstOrDefault();
    }

    public Block Create(Block item)
    {

      _context.Blocks.Add(item);
      _context.SaveChanges();

      return item;
    }

    public void Update(Block newitem)
    {
      var item = _context.Blocks.Find(newitem.Id);

      item.BlockType = newitem.BlockType;
      item.CanHaveChildren = newitem.CanHaveChildren;
      item.DateCreated = newitem.DateCreated;
      item.DateModified = newitem.DateModified;
      item.ParentId = newitem.ParentId;
      item.Title = newitem.Title;

      // update Block properties

      _context.Blocks.Update(item);
      _context.SaveChanges();
    }

    public void Delete(long id)
    {
      var item = _context.Blocks.Find(id);
      if (item != null)
      {
        _context.Blocks.Remove(item);
        _context.SaveChanges();
      }
    }

  }
}
