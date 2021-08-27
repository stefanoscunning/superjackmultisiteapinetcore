using Superjack.MultiSites.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Superjack.MultiSites.Api.Services
{
  public interface IBlockFieldService
  {
    IEnumerable<BlockField> GetAll();
    IEnumerable<BlockField> GetAllByBlockId(long blockId);
    BlockField GetById(long? id);
    BlockField GetByUuid(string uuid);
    BlockField Create(BlockField item);
    void Update(BlockField newitem);
    void Delete(long id);

  }
  public class BlockFieldService : IBlockFieldService
  {
    private AppDbContext _context;

    public BlockFieldService(AppDbContext context)
    {
      _context = context;
    }

    public IEnumerable<BlockField> GetAll()
    {
      return _context.BlockFields.OrderBy(x=>x.BlockId).ThenBy(x=>x.SortOrder).ThenBy(x=>x.Title);
    }

    public IEnumerable<BlockField> GetAllByBlockId(long blockId)
    {
      return _context.BlockFields.Where(x=>x.BlockId==blockId).OrderBy(x=>x.SortOrder).ThenBy(x=>x.Title);
    }


    public BlockField GetById(long? id)
    {
      return _context.BlockFields.Find(id);
    }

    public BlockField GetByUuid(string uuid)
    {
      return _context.BlockFields.Where(x => x.Uuid == Guid.Parse(uuid)).FirstOrDefault();
    }

    public BlockField Create(BlockField item)
    {

      _context.BlockFields.Add(item);
      _context.SaveChanges();

      return item;
    }

    public void Update(BlockField newitem)
    {
      var item = _context.BlockFields.Find(newitem.Id);


      item.BlockId = newitem.BlockId;
      item.Title = newitem.Title;
      item.DataType = newitem.DataType;
      item.SortOrder = newitem.SortOrder;
      item.Value = newitem.Value;

      // update BlockField properties

      _context.BlockFields.Update(item);
      _context.SaveChanges();
    }

    public void Delete(long id)
    {
      var item = _context.BlockFields.Find(id);
      if (item != null)
      {
        _context.BlockFields.Remove(item);
        _context.SaveChanges();
      }
    }

    

  }
}
