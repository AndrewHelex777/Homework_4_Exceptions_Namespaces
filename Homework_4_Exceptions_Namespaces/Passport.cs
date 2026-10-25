namespace Homework_4_Exceptions_Namespaces
{
    class ForeignPassport
    {
        private string number;
        private string owner;
        private DateTime issueData;
        private DateTime expirationDate;
        private string issuingAuthority;
        public ForeignPassport(string n, string o, DateTime i, DateTime e, string a)
        {
            if (n.Length != 9)
            {
                throw new Exception("Passportn number must have 16 number.");
            }
            foreach (var item in n)
            {
                if (!char.IsDigit(item))
                {
                    throw new Exception("Passport number must have only numbers.");
                }
            }
            number = n;
            if (o.Length == 0)
            {
                throw new Exception("Owner name must be not empty.");
            }
            owner = o;
            if (i.Date > DateTime.Today)
            {
                throw new Exception("Issue date cannot be in the future.");
            }
            issueData = i;
            if (e.Date <= i.Date)
            {
                throw new Exception("Expiration date must be later than issue date.");
            }
            expirationDate = e;
            if (a.Length == 0)
            {
                throw new Exception("Issuing authority must be not empty.");
            }
            issuingAuthority = a;
        }
        public void Print()
        {
            Console.WriteLine($"Passport number: {number}");
            Console.WriteLine($"Owner: {owner}");
            Console.WriteLine($"Issue date: {issueData}");
            Console.WriteLine($"Date of expiration: {expirationDate}");
            Console.WriteLine($"Issuing authority: {issuingAuthority}");
        }
    }
    internal class Passport
    {
        static void Main(string[] args)
        {
            try
            {
                DateTime issue = Convert.ToDateTime("18.10.2024");
                DateTime expiration = Convert.ToDateTime("18.10.2034");
                ForeignPassport p = new ForeignPassport(
                    "123456789",
                    "Ivan Ivanov Ivanovich",
                    issue,
                    expiration,
                    "State Migration Service of Ukraine"
                    );
                p.Print();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error! {ex.Message}");
            }
        }
    }
}
