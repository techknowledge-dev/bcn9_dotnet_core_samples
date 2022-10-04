using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace BlazorSample.Data
{
    public class PersonService
    {
        public Task<Person[]> GetPersonAsync(int limit)
        {
            var list = new List<Person>();
            var ddf = new BtLib.Ddf(@"btrv:///demodata");
            var rec = ddf.GetRecord("Person");
            var rc = rec.Open();
            if (rc != 0)
            {
                return Task.FromResult(list.ToArray());
            }
            rec.IndexNumber = 0;
            var person = new Person();
            rc = rec.Read(BtLib.Operation.GetFirst, person);
            while (rc == 0)
            {
                list.Add(person);
                if(list.Count > limit)
                {
                    break;
                }
                person = new Person();
                rc = rec.Read(BtLib.Operation.GetNext, person);
            }
            rec.Close();
            return Task.FromResult(list.ToArray());

        }
    }
}

