using System;
using System.Collections.Generic;
using System.Text;

namespace GetACam.Data
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}
