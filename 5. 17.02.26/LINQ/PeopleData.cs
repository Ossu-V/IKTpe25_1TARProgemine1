using LINQ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    public class PeopleData
    {
        public static readonly List<PeopleList> peoples = new List<PeopleList>
        {
            new PeopleList()
            {
                Id = 1,
                Name = "Moona",
                Age = 31,
                GenderId = Guid.Parse("9a314d3b-896e-487f-80ca-9db39ac1e923")
            },
            new PeopleList()
            {
                Id = 2,
                Name = "Poona",
                Age = 21,
                GenderId = Guid.Parse("7d37e4eb-a136-4e02-8c6d-f5f899b80dad")
            },
            new PeopleList()
            {
                Id = 3,
                Name = "Ron",
                Age = 18,
                GenderId = Guid.Parse("7d37e4eb-a136-4e02-8c6d-f5f899b80dad")
            },
            new PeopleList()
            {
                Id = 4,
                Name = "Anna",
                Age = 20,
                GenderId = Guid.Parse("9a314d3b-896e-487f-80ca-9db39ac1e923")
            },
            new PeopleList()
            {
                Id = 5,
                Name = "Mari",
                Age = 19,
                GenderId = Guid.Parse("9a314d3b-896e-487f-80ca-9db39ac1e923")
            },
            new PeopleList()
            {
                Id = 6,
                Name = "Mari",
                Age = 21,
                GenderId = Guid.Parse("9a314d3b-896e-487f-80ca-9db39ac1e923")
            },
            new PeopleList()
            {
                Id = 7,
                Name = "Bill",
                Age = 21,
                GenderId = Guid.Parse("7d37e4eb-a136-4e02-8c6d-f5f899b80dad")
            },
        };
    }
}
