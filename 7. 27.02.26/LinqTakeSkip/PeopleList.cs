namespace LinqTakeSkip
{
    public class PeopleList
    {
        public static readonly List<People> people = new List<People>
        {
            new People()
            {
                Id = 1,
                Name = "Moona",
                Age = 21,
                GenderId = Guid.Parse("9a314d3b-896e-487f-80ca-9db39ac1e923")
            },
            new People()
            {
                Id = 2,
                Name = "Joonas",
                Age = 20,
                GenderId = Guid.Parse("7d37e4eb-a136-4e02-8c6d-f5f899b80dad")
            },
            new People()
            {
                Id = 3,
                Name = "Ron",
                Age = 17,
                GenderId = Guid.Parse("7d37e4eb-a136-4e02-8c6d-f5f899b80dad")
            },
            new People()
            {
                Id = 4,
                Name = "Anna",
                Age = 22,
                GenderId = Guid.Parse("9a314d3b-896e-487f-80ca-9db39ac1e923")
            },
            new People()
            {
                Id = 5,
                Name = "Mari",
                Age = 19,
                GenderId = Guid.Parse("9a314d3b-896e-487f-80ca-9db39ac1e923")
            },
            new People()
            {
                Id = 6,
                Name = "Bill",
                Age = 15,
                GenderId = Guid.Parse("9a314d3b-896e-487f-80ca-9db39ac1e923")
            },
            new People()
            {
                Id = 7,
                Name = "Jumbo",
                Age = 21,
                GenderId = Guid.Parse("7d37e4eb-a136-4e02-8c6d-f5f899b80dad")
            },
        };
    }
}
