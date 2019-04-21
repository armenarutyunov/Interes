using EntityFrameworkDataAccess;
using DBMOD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class Security_LoginsLogic : EFGenericRepository<Security_Logins>
    {
        protected EFGenericRepository<Security_Logins> _repo;
        public Security_LoginsLogic(EFGenericRepository<Security_Logins> repo)
        {
            _repo = repo;
        }
        public override void Add(Security_Logins[] pocos)
        {
            Verify(pocos);
            base.Add(pocos);
        }
        public override void Update(Security_Logins[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }
        protected void Verify(Security_Logins[] pocos)
        {

        }
    }
}