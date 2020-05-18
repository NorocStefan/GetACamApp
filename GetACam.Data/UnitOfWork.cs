using System;
using System.Collections.Generic;
using System.Text;

namespace GetACam.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly GetACamContext _getACamContext;
        public UnitOfWork(GetACamContext getACamContext)
        {
            _getACamContext = getACamContext;
        }

        public void Commit()
        {
            _getACamContext.SaveChanges();
        }
    }
}
