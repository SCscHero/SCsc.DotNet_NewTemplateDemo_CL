using System;
using System.Collections.Generic;
using System.Text;

namespace SCsc_DesignPattern.Adapter
{
    public class SqlServerHelper : IHelper
    {
        public void Add<T>()
        {
            throw new NotImplementedException();
        }

        public void Delete<T>()
        {
            throw new NotImplementedException();
        }

        public void Query<T>()
        {
            throw new NotImplementedException();
        }

        public void Update<T>()
        {
            throw new NotImplementedException();
        }
    }
}
