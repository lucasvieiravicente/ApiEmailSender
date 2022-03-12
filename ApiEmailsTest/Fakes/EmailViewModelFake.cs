using ApiEmails.Domain;
using Bogus;

namespace ApiEmailsTest.Fakes
{
    public static class EmailViewModelFake
    {
        private static readonly Faker _faker = new();

        public static EmailViewModel Create(bool withSubject = false)
        {
            return new Faker<EmailViewModel>("pt_BR")
                                        .RuleFor(x => x.Email, x => x.Internet.Email())
                                        .RuleFor(x => x.Name, x => x.Name.FullName())
                                        .RuleFor(x => x.PhoneNumber, x => x.Phone.PhoneNumber())
                                        .RuleFor(x => x.Body, x => x.Lorem.Text())
                                        .RuleFor(x => x.Subject, x => withSubject ? _faker.Lorem.Slug() : string.Empty)
                                        .Generate();
        }
    }
}
