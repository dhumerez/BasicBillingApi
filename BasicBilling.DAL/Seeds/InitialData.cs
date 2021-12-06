namespace BasicBilling.DAL.Seeds
{
    using System;
    using System.Linq;
    using BasicBilling.DAL.Context;
    using Models;

    public static class InitialData
    {
        public static void Seed(this CompanyContext dbContext)
        {
            if (!dbContext.Clients.Any())
            {
                dbContext.Clients.Add(new Client
                {
                    Id = 100,
                    Name = "Joseph Carlton"
                });
                dbContext.Clients.Add(new Client
                {
                    Id = 200,
                    Name = "Maria Juarez"
                });
                dbContext.Clients.Add(new Client
                {
                    Id = 300,
                    Name = "Albert Kenny"
                });
                dbContext.Clients.Add(new Client
                {
                    Id = 400,
                    Name = "Jessica Phillips"
                });
                dbContext.Clients.Add(new Client
                {
                    Id = 500,
                    Name = "Charles Johnson"
                });

                dbContext.SaveChanges();
            }

            if (!dbContext.States.Any())
            {
                dbContext.States.Add(new State
                {
                    Name = "Pending"
                });
                dbContext.States.Add(new State
                {
                    Name = "Paid"
                });

                dbContext.SaveChanges();
            }

            if (!dbContext.BillTypes.Any())
            {
                dbContext.BillTypes.Add(new BillType
                {
                    Name = "Electricity"
                });
                dbContext.BillTypes.Add(new BillType
                {
                    Name = "Water"
                });

                dbContext.SaveChanges();
            }

            if (!dbContext.Bills.Any())
            {
                dbContext.Bills.Add(new Bill
                {
                    BillTypeId = 1,
                    Date = new DateTime(2021, 11, 1),                    
                    StateId = 2,
                    ClientId = 100,
                    Total = 100,
                    RemainingBalance =100
                });
                dbContext.Bills.Add(new Bill
                {
                    BillTypeId = 2,
                    Date = new DateTime(2021, 11, 1),                    
                    StateId = 2,
                    ClientId = 100,
                    Total = 100,
                    RemainingBalance = 100
                });
                dbContext.Bills.Add(new Bill
                {
                    BillTypeId = 1,
                    Date = new DateTime(2021, 11, 1),                    
                    StateId = 2,
                    ClientId = 200,
                    Total = 100,
                    RemainingBalance = 100
                });
                dbContext.Bills.Add(new Bill
                {
                    BillTypeId = 2,
                    Date = new DateTime(2021, 11, 1),
                    
                    StateId = 2,
                    ClientId = 200,
                    Total = 100,
                    RemainingBalance = 100
                });
                dbContext.Bills.Add(new Bill
                {
                    BillTypeId = 1,
                    Date = new DateTime(2021, 11, 1),                    
                    StateId = 2,
                    ClientId = 300,
                    Total = 100,
                    RemainingBalance = 100
                });
                dbContext.Bills.Add(new Bill
                {
                    BillTypeId = 2,
                    Date = new DateTime(2021, 11, 1),                    
                    StateId = 2,
                    ClientId = 300,
                    Total = 100,
                    RemainingBalance = 100
                });
                dbContext.Bills.Add(new Bill
                {
                    BillTypeId = 1,
                    Date = new DateTime(2021, 11, 1),
                    StateId = 2,
                    ClientId = 400,
                    Total = 100,
                    RemainingBalance = 100
                });
                dbContext.Bills.Add(new Bill
                {
                    BillTypeId = 2,
                    Date = new DateTime(2021, 11, 1),                    
                    StateId = 2,
                    ClientId = 400,
                    Total = 100,
                    RemainingBalance = 100
                });
                dbContext.Bills.Add(new Bill
                {
                    BillTypeId = 1,
                    Date = new DateTime(2021, 11, 1),                    
                    StateId = 2,
                    ClientId = 500,
                    Total = 100,
                    RemainingBalance = 100
                });
                dbContext.Bills.Add(new Bill
                {
                    BillTypeId = 2,
                    Date = new DateTime(2021, 11, 1),                    
                    StateId = 2,
                    ClientId = 500,
                    Total = 100,
                    RemainingBalance = 100
                });
                ////
                dbContext.Bills.Add(new Bill
                {
                    BillTypeId = 1,
                    Date = new DateTime(2021, 12, 1),                    
                    StateId = 2,
                    ClientId = 100,
                    Total = 100,
                    RemainingBalance = 100
                });
                dbContext.Bills.Add(new Bill
                {
                    BillTypeId = 2,
                    Date = new DateTime(2021, 12, 1),                    
                    StateId = 2,
                    ClientId = 100,
                    Total = 100,
                    RemainingBalance = 100
                });
                dbContext.Bills.Add(new Bill
                {
                    BillTypeId = 1,
                    Date = new DateTime(2021, 12, 1),                    
                    StateId = 2,
                    ClientId = 200,
                    Total = 100,
                    RemainingBalance = 100
                });
                dbContext.Bills.Add(new Bill
                {
                    BillTypeId = 2,
                    Date = new DateTime(2021, 12, 1),                    
                    StateId = 2,
                    ClientId = 200,
                    Total = 100,
                    RemainingBalance = 100
                });
                dbContext.Bills.Add(new Bill
                {
                    BillTypeId = 1,
                    Date = new DateTime(2021, 12, 1),                    
                    StateId = 2,
                    ClientId = 300,
                    Total = 100,
                    RemainingBalance = 100
                });
                dbContext.Bills.Add(new Bill
                {
                    BillTypeId = 2,
                    Date = new DateTime(2021, 12, 1),                    
                    StateId = 2,
                    ClientId = 300,
                    Total = 100,
                    RemainingBalance = 100
                });
                dbContext.Bills.Add(new Bill
                {
                    BillTypeId = 1,
                    Date = new DateTime(2021, 12, 1),                    
                    StateId = 2,
                    ClientId = 400,
                    Total = 100,
                    RemainingBalance = 100
                });
                dbContext.Bills.Add(new Bill
                {
                    BillTypeId = 2,
                    Date = new DateTime(2021, 12, 1),                    
                    StateId = 2,
                    ClientId = 400,
                    Total = 100,
                    RemainingBalance = 100
                });
                dbContext.Bills.Add(new Bill
                {
                    BillTypeId = 1,
                    Date = new DateTime(2021, 12, 1),                    
                    StateId = 2,
                    ClientId = 500,
                    Total = 100,
                    RemainingBalance = 100
                });
                dbContext.Bills.Add(new Bill
                {
                    BillTypeId = 2,
                    Date = new DateTime(2021, 12, 1),                    
                    StateId = 2,
                    ClientId = 500,
                    Total = 100,
                    RemainingBalance = 100
                });

                dbContext.SaveChanges();
            }
        }
    }
}