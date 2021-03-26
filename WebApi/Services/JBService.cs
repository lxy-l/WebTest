﻿using System.Threading.Tasks;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Services
{
    public class JBService
    {
        private readonly JBContext _context;

        private readonly object obj = new object();

        public JBService(JBContext context)
        {
            _context = context;
        }

        //public async Task<JB>  ReduceStockAsync(int id,int number)
        //{
        //    JB jB = await _context.JBs.FindAsync(id);
        //    if (jB.Num >= number)
        //    {
        //        jB.Num -= number;
        //        _context.JBs.Update(jB);
        //        await _context.SaveChangesAsync().ConfigureAwait(false);
        //        return jB;
        //    }
        //    return null;
        //}

        public JB ReduceStock(int id ,int number)
        {
            lock (obj)
            {
                JB jb = _context.JBs.Find(id);
                if (jb.Num >= number)
                {
                    jb.Num -= number;
                    _context.JBs.Update(jb);
                    _context.SaveChanges();
                    return jb;
                }
                return null;
            }
        }

    }
}
