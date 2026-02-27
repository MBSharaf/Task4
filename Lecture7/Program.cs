namespace Lecture7
{   
    enum TransactionType
    {
        Dipost,
        withdrwal,
        Transfer
    }
    class Transactions
    {
        public Guid id;
        public string senderName;
        public string receiverName;
        public double amount;
        public DateTime date;
        public bool status;
        public TransactionType Transactionstype;

        public Transactions(Guid id, string senderName, string receiverName, double amount, DateTime date, bool status, TransactionType transactionstype)
        {
            this.id = id;
            this.senderName = senderName;
            this.receiverName = receiverName;
            this.amount = amount;
            this.date = date;
            this.status = status;
            Transactionstype = transactionstype;
        }

        class Account
        {
            int id;
            string name;
            string phone;
            string pass;
            double balance;
            List<Transactions> Transactions = new List<Transactions>();

            public Account(int id, string name, string phone, string pass, double balance)
            {
                this.id = id;
                this.name = name;
                this.phone = phone;
                this.pass = pass;
                this.balance = balance;
            }

            public bool Dipost(double amount)
            {
                if (amount > 0)
                {
                    this.balance += amount;
                    Transactions.Add(new Transactions(Guid.NewGuid(), "mohamed", "sharaf", amount, DateTime.Now, true, TransactionType.Dipost));
                    return true;
                }
                else
                {
                    Transactions.Add(new Transactions(Guid.NewGuid(), "mohamed", "sharaf", amount, DateTime.Now, false, TransactionType.Dipost));

                    return false;
                }
            }
            public bool withdrwal(double amount)
            {
                if (amount > 0 && amount >= balance)
                {
                    this.balance -= amount;
                    Transactions.Add(new Transactions(Guid.NewGuid(), "mohamed", "sharaf", amount, DateTime.Now, true, TransactionType.withdrwal));
                    return true;
                }
                else
                {
                    Transactions.Add(new Transactions(Guid.NewGuid(), "mohamed", "sharaf", amount, DateTime.Now, false, TransactionType.withdrwal));

                    return false;
                }
            }
            public double GetBalanace()
            {
                return balance;
            }

            public bool Transfer(double amount, Account des)
            {
                if (amount > 0 && amount >= balance)
                {
                    this.balance -= amount;
                    des.balance += amount;
                    Transactions.Add(new Transactions(Guid.NewGuid(), this.name, des.name, amount, DateTime.Now, true, TransactionType.Transfer));

                    return true;
                }
                else
                {
                    Transactions.Add(new Transactions(Guid.NewGuid(), this.name, des.name, amount, DateTime.Now, false, TransactionType.Transfer));

                    return false;
                }
            }


            public void ShowTransactions()
            {
                for (int i = 0; i < Transactions.Count; i++)
                {
                    Console.WriteLine(Transactions[i].id);
                    Console.WriteLine(Transactions[i].senderName);
                    Console.WriteLine(Transactions[i].receiverName);
                    Console.WriteLine(Transactions[i].amount);
                    Console.WriteLine(Transactions[i].date);
                    Console.WriteLine(Transactions[i].status);
                    Console.WriteLine(Transactions[i].Transactionstype);
                    Console.WriteLine("=================================");
                }
            }
        }
        internal class Program
        {
            static void Main(string[] args)
            {
                Account Acc1 = new Account(1, "mohamed", "010", "12345678", 1000);
                Account Acc2 = new Account(1, "sharaf", "011", "311713", 500);

                Acc1.Dipost(9000);
                Console.WriteLine(Acc1.GetBalanace());
                Acc2.withdrwal(500);
                Console.WriteLine(Acc2.GetBalanace());

                Acc1.Transfer(900, Acc2);
                Console.WriteLine(Acc1.GetBalanace());
                Console.WriteLine(Acc2.GetBalanace());
                Console.WriteLine("/////////////////////");
                Acc1.ShowTransactions();



            }
        }
    }
}
