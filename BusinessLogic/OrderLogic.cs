using DBMOD;
using EntityFrameworkDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class OrderLogic : EFGenericRepository<Order>
    {
        protected EFGenericRepository<Order> _repo;
        public OrderLogic(EFGenericRepository<Order> repo)
        {
            _repo = repo;
        }
        public override void Add(Order[] pocos)
        {
            Verify(pocos);
            base.Add(pocos);
        }
        public override void Update(Order[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }
        protected  void Verify(Order[] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();
            foreach (Order poco in pocos)
            {
                if (string.IsNullOrEmpty(poco.City))
                {
                    exceptions.Add(new ValidationException(100, $"Cannot be empty!"));

                }

                if (string.IsNullOrEmpty(poco.HomeNumber))
                {
                    exceptions.Add(new ValidationException(601, $"Valid Phone cannot be empty and must correspond to a format (e.g. 416-555-1234)"));
                }

                else
                {
                    string p = poco.HomeNumber;
                    int pl = p.Length;
                    int lofd = p.LastIndexOf("-");
                    int fofd = p.IndexOf("-");
                    if (fofd != 3 || lofd != 7)
                    {
                        exceptions.Add(new ValidationException(601, $"Valid Phone cannot be empty and must correspond to a format (e.g. 416-555-1234)"));
                    }
                    else
                    {
                        var k = Convert.ToInt64(9999999999);
                        try
                        {
                            string d = p.Substring(0, 3) + p.Substring(4, 3) + p.Substring(8, pl - 8);
                            k = Convert.ToInt64(d);
                        }
                        catch
                        {
                            exceptions.Add(new ValidationException(601, $"Valid Phone cannot be empty and must correspond to a format (e.g. 416-555-1234)"));
                        }
                        if (9999999999 < k || k < 1000000000)
                        {
                            exceptions.Add(new ValidationException(601, $"Valid Phone cannot be empty and must correspond to a format (e.g. 416-555-1234)"));
                        }
                    }
                }

                //else
                //if (poco.Major.Length < 3)
                //{
                //    exceptions.Add(new ValidationException(107, $"Cannot be empty or less than 3 characters - {poco.Id}"));
                //}
                //if (poco.StartDate > DateTime.Now)
                //{
                //    exceptions.Add(new ValidationException(108, $"Cannot be greater than today - {poco.Id}"));

                //}
                //if (poco.CompletionDate < poco.StartDate)
                //{
                //    exceptions.Add(new ValidationException(109, $"CompletionDate cannot be earlier than StartDate - {poco.Id}"));

                //}

                if (exceptions.Count > 0)
                {
                    throw new AggregateException(exceptions);
                }
            }
        }
    }
}
