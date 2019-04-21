using DBMOD;
using EntityFrameworkDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class ProductLogic : EFGenericRepository<Product>
    {
        protected EFGenericRepository<Product> _repo;
        public ProductLogic(EFGenericRepository<Product> repo)
        {
            _repo = repo;
        }
        public override void Add(Product[] pocos)
        {
            Verify(pocos);
            base.Add(pocos);
        }
        public override void Update(Product[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }
        protected  void Verify(Product[] pocos)
        {

        }
    }
}
