using IbmAdmissions2019.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IbmAdmissions2019.Utilities
{
    public class BlockUtility
    {
        private IbmAdmissions2019Entities db;
        private static BlockUtility _instance;

        private BlockUtility()
        {
            db = new IbmAdmissions2019Entities();
        }
        public static BlockUtility getInstance()
        {
            if (_instance == null)
                _instance = new BlockUtility();
            return _instance;
        }

        public List<BlockViewModel> getList()
        {
            var list = db.Blocks.Select(b => new BlockViewModel()
            {
                BlockId=b.BlockId,
                BlockName = b.BlockName,
                Directions = b.Directions,
                Capacity = b.Capacity.Value
            }).ToList();
            return list;
        }

        public bool DeleteBlock(BlockViewModel obj, int id)
        {
            IbmAdmissions2019Entities db = new IbmAdmissions2019Entities();
            foreach(Block b in db.Blocks)
            {
                if(b.BlockId == id)
                {
                    db.Blocks.Remove(b);
                }
            }
            db.SaveChanges();
            return true;
        }
        public bool AddBlock(BlockViewModel block)
        {
            bool isUpdate = true;
            var bt = db.Blocks.Where(a => a.BlockId.Equals(block.BlockId)).FirstOrDefault();
            if (bt == null)
            {
                bt = new Block();
                isUpdate = false;
            }
            bt.BlockName = block.BlockName;
            bt.RollNumberStart = block.RollNumberStart;
            bt.RollNumberEnd = block.RollNumberEnd;
            bt.Capacity = block.Capacity;
            bt.Directions = block.Directions;
            bt.TestId = 1;
            if (!isUpdate)
                db.Blocks.Add(bt);
            else
                db.Entry(bt).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return true;
        }

        public BlockViewModel editBlock(int id)
        {
            IbmAdmissions2019Entities db = new IbmAdmissions2019Entities();
            BlockViewModel blk = new BlockViewModel();
            foreach(Block b in db.Blocks)
            {
                if(b.BlockId == id)
                {
                    blk.BlockName = b.BlockName;
                    blk.Capacity =(int)b.Capacity;
                    blk.Directions = b.Directions;
                    blk.BlockId = b.BlockId;
                    blk.RollNumberStart = (int)b.RollNumberStart;
                    blk.RollNumberEnd = (int)b.RollNumberEnd;
                    break;

                }
            }
            return blk;
        }
    }
}