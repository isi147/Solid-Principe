

//--------Single Responsibilty----------

//Incorrect code
//class Cashier
//{
//    public int Id { get; set; }
//    public string Name { get; set; }
//    public string Surname { get; set; }

//    public void CalculateSalary()
//    {
//        Console.WriteLine("Cashier salary calc");
//    }
//}
//class Seller
//{
//    public int Id { get; set; }
//    public string Name { get; set; }
//    public string Surname { get; set; }

//    public void CalculateSalary()
//    {
//        Console.WriteLine("Cashier salary calc");
//    }
//}


//-------Correct Code

//static class CalcSalaryService
//{
//    public static void CalcSalary(Cashier cashier)
//    {
//        //cashier cacl salary
//        Console.WriteLine();
//    }
//    public static void CalcSalary(Seller cashier)
//    {
//        //Seller cacl salary
//        Console.WriteLine();
//    }
//}
//class Cashier
//{
//    public int Id { get; set; }
//    public string Name { get; set; }
//    public string Surname { get; set; }

//}
//class Seller
//{
//    public int Id { get; set; }
//    public string Name { get; set; }
//    public string Surname { get; set; }


//}


//CalcSalaryService.CalcSalary()




//------------ Open Closed -------------


//------Incorrect Code---------
//class Product
//{
//    public Guid Id { get; set; }
//    public string Name { get; set; }
//    public decimal Price { get; set; }
//    public decimal Weight { get; set; }
//}


//class Order
//{
//    private List<Product> items = new();
//    private string shipping = default;

//    public decimal GetTotal() => items.Sum(p => p.Price);
//    public decimal GetTotalWeight() => items.Sum(p => p.Weight);
//    public void SetShippingType(string type) => shipping = type;


//    public decimal GetShippingCost()
//    {
//        if (shipping == "ground")
//        {
//            // Free ground delivery on big orders
//            if (GetTotal() > 100)
//                return 0;

//            // $1.5 per kilogram, but $10 minumum
//            return Math.Max(10, GetTotalWeight() * 1.5M);
//        }

//        if (shipping == "air")
//        {
//            // $3 per kilogram, but $20 minumum
//            return Math.Max(20, GetTotalWeight() * 3);
//        }

//        throw new ArgumentException(nameof(shipping));
//    }


//    public DateTime GetShippingDate()
//    {
//        if (shipping == "ground")
//        {
//            return DateTime.Now.AddDays(7);
//        }

//        if (shipping == "air")
//        {
//            return DateTime.Now.AddDays(7);
//        }

//        throw new ArgumentException(nameof(shipping));
//    }
//}


//------Correct Code-------

//class Product
//{
//    public Guid Id { get; set; }
//    public string Name { get; set; }
//    public decimal Price { get; set; }
//    public decimal Weight { get; set; }
//}


//interface IShipping
//{
//    decimal GetCost(Order order);
//    DateTime GetDate(Order order);
//}


//class Ground : IShipping
//{
//    public decimal GetCost(Order order)
//    {
//        // Free ground delivery on big orders
//        if (order.GetTotal() > 100)
//            return 0;

//        // $1.5 per kilogram, but $10 minumum
//        return Math.Max(10, order.GetTotalWeight() * 1.5M);
//    }

//    public DateTime GetDate(Order order) => DateTime.Now.AddDays(7);
//}



//class Air : IShipping
//{
//    public decimal GetCost(Order order)
//    {
//        // $3 per kilogram, but $20 minumum
//        return Math.Max(20, order.GetTotalWeight() * 3);
//    }

//    public DateTime GetDate(Order order) => DateTime.Now.AddDays(2);
//}
//class Sea : IShipping
//{
//    public decimal GetCost(Order order)
//    {
//        // $3 per kilogram, but $20 minumum
//        return Math.Max(20, order.GetTotalWeight() * 8);
//    }

//    public DateTime GetDate(Order order) => DateTime.Now.AddDays(2);
//}






//class Order
//{
//    private List<Product> items = new();
//    private IShipping shipping;

//    public decimal GetTotal() => items.Sum(p => p.Price);
//    public decimal GetTotalWeight() => items.Sum(p => p.Weight);
//    public void SetShippingType(IShipping type) {
//        shipping = type;
//    }

//    public decimal GetShippingCost() => shipping.GetCost(this);
//    public DateTime GetShippingDate() => shipping.GetDate(this);
//}




//-----------Liskov subsitation---------
//incorrect code

//class Document
//{
//    public string Data { get; set; }
//    public string Filename { get; set; }

//    public virtual void Open()
//    {
//        // Open File
//    }
//    public virtual void Save()
//    {
//        // Save File
//    }
//}



//class ReadOnlyDocument : Document
//{
//    public override void Save()
//    {
//        throw new Exception("Can't save a read-only document");
//    }
//}



//class Project
//{
//    private List<Document> _documents;

//    public void OpenAll()
//    {
//        foreach (var document in _documents)
//            document.Open();
//    }
//    public void SaveAll()
//    {
//        foreach (var document in _documents)
//            if (document is not ReadOnlyDocument)
//                document.Save();
//    }
//}



//Correct code

//class Document
//{
//    public string Data { get; set; }
//    public string Filename { get; set; }


//    public virtual void Open()
//    {
//        // Open File
//    }
//}



//class WritableDocument : Document
//{
//    public void Save()
//    {
//        // Save file
//    }
//}



//class Project
//{
//    private List<Document> _allDocuments;
//    private List<WritableDocument> _writableDocuments;



//    public void OpenAll()
//    {
//        foreach (var document in _allDocuments)
//            document.Open();

//        foreach (var document in _writableDocuments)
//            document.Open();
//    }
//    public void SaveAll()
//    {
//        foreach (var document in _writableDocuments)
//            document.Save();
//    }
//}




//---------------Interface segrgation---------------


//interface ICloudProvide
//{
//    void StoreFile(string name);
//    void GetFile(string name);
//    void CreteServer(string region);
//    void ListServer(string region);
//    void GetCDNAddress();
//}



//class Amazon : ICloudProvide
//{
//    public void StoreFile(string name)
//    {
//        // do smth
//    }

//    public void GetFile(string name)
//    {
//        // do smth
//    }

//    public void CreteServer(string region)
//    {
//        // do smth
//    }

//    public void ListServer(string region)
//    {
//        // do smth
//    }

//    public void GetCDNAddress()
//    {
//        // do smth
//    }
//}




//class Dropbox : ICloudProvide
//{
//    public void StoreFile(string name)
//    {
//        // do smth
//    }

//    public void GetFile(string name)
//    {
//        // do smth
//    }

//    public void CreteServer(string region)
//    {
//        throw new NotImplementedException();
//    }

//    public void ListServer(string region)
//    {
//        throw new NotImplementedException();
//    }

//    public void GetCDNAddress()
//    {
//        throw new NotImplementedException();
//    }
//}
//}



//interface ICloudHostingProvide
//{
//    void CreteServer(string region);
//    void ListServer(string region);
//}

//interface ICDNProvide
//{
//    void GetCDNAddress();
//}

//interface ICloudStorageProvide
//{
//    void StoreFile(string name);
//    void GetFile(string name);
//}





//class Amazon : ICDNProvide, ICloudStorageProvide, ICloudHostingProvide
//{
//    public void StoreFile(string name)
//    {
//        // do smth
//    }

//    public void GetFile(string name)
//    {
//        // do smth
//    }

//    public void CreteServer(string region)
//    {
//        // do smth
//    }

//    public void ListServer(string region)
//    {
//        // do smth
//    }

//    public void GetCDNAddress()
//    {
//        // do smth
//    }
//}


//class Dropbox : ICloudStorageProvide
//{
//    public void StoreFile(string name)
//    {
//        // do smth
//    }
//    public void GetFile(string name)
//    {
//        // do smth
//    }
//}



//-------------Depencency Inversion---------------
//-----Incorrect code--------
//class MySQLDatabase
//{
//    public void Insert()
//    {
//        // do smth...
//    }

//    public void Update()
//    {
//        // do smth...
//    }
//    public void Delete()
//    {
//        // do smth...
//    }
//}




//class BudgetReport
//{
//    public MySQLDatabase database { get; set; }

//    public void Open(DateOnly date)
//    {
//        // do smth...
//    }
//    public void Save()
//    {
//        // do smth...
//    }
//}


//-----------Correct Database---------------
//interface IDatabase
//{
//    void Insert();
//    void Update();
//    void Delete();
//}



//class MySQL : IDatabase
//{
//    public void Insert()
//    {
//        // do smth...
//    }

//    public void Update()
//    {
//        // do smth...
//    }

//    public void Delete()
//    {
//        // do smth...
//    }
//}

//class MongoDB : IDatabase
//{
//    public void Insert()
//    {
//        // do smth...
//    }

//    public void Update()
//    {
//        // do smth...
//    }

//    public void Delete()
//    {
//        // do smth...
//    }
//}




//class BudgetReport
//{
//    private IDatabase database;

//    public void Open(DateOnly date)
//    {
//        // do smth...
//    }

//    public void Save()
//    {
//        // do smth...
//    }
//}
