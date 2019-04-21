using DBMOD;
using EntityFrameworkDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
  public class CustomerLogic : EFGenericRepository<Customer>
  {
        protected EFGenericRepository<Customer> _repo;
        public CustomerLogic(EFGenericRepository<Customer> repo)
        {
            _repo = repo;
        }
        public override void Add(Customer[] pocos)
        {
        Verify(pocos);
        base.Add(pocos);
        }
        public override void Update(Customer[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }
        protected void Verify(Customer[] pocos)
        {

        }
  }
}
