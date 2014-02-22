using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business
{
    interface IAppMoney
    {
        #region Transactions

        string CreateTransaction();

         bool UpdateTransaction();

         bool DeleteTransaction();

         void GetTransaction();

         void GetTransactions();
        


        #endregion
    }
}
