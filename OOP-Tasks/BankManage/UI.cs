namespace OOP_Tasks.BankManage;

public class UI
{
    public BankUser UserData()
    {
        BankUser user = new BankUser();

        Console.WriteLine("Enter ID: ");
        user.Id = int.Parse(Console.ReadLine());
        
        Console.WriteLine("Enter Fullname: ");
        user.FullName = Console.ReadLine();

        Console.WriteLine("Enter Your Age: ");
        user.UserAge = int.Parse(Console.ReadLine());

        Console.WriteLine("Date of Birth: ");
        user.DateofBirth = DateTime.Parse(Console.ReadLine());

        Console.WriteLine("Amount of Money: ");
        user.Cash = decimal.Parse(Console.ReadLine());

        return user;
    }

    bool a = true;

    UserServise userServise = new UserServise();
    public void Servise()
    {
        while(a)
        {
            Console.WriteLine("Bank servise: ");
            Console.WriteLine("1 => Put Depozit");
            Console.WriteLine("2 => Get Cash");
            Console.WriteLine("3 => Get Balance");
            Console.WriteLine("4 => Back");

            int k = int.Parse(Console.ReadLine());

            Console.Write("Enter your ID: ");

            switch (k)
            {
                case 1:
                    int id = int.Parse(Console.ReadLine());
                    userServise.PutDepozit(id);
                    break;
                case 2:
                    int id1 = int.Parse(Console.ReadLine());
                    userServise.GetCash(id1);
                    break;
                case 3:
                    int id2 = int.Parse(Console.ReadLine());
                    Console.WriteLine(userServise.GetBalance(id2));
                    break;
                case 4: 
                    Print(); 
                    break;
            }
        }
    }
    

    bool b = true;

    public void Print()
    {
        while (b)
        {
            Console.WriteLine("1 => Create");
            Console.WriteLine("2 => GetById"); 
            Console.WriteLine("3 => Update"); 
            Console.WriteLine("4 => Transfer");
            Console.WriteLine("5 => GetAll");
            Console.WriteLine("6 => Delete");
            Console.WriteLine("7 => BankServise");

            int number = int.Parse(Console.ReadLine());

            switch (number)
            {
                case 1:
                    var user = UserData();
                    var data = userServise.Create(user);
                    Console.WriteLine(data);
                    break;
                case 2:
                    Console.WriteLine("Enter ID: ");
                    int m = int.Parse(Console.ReadLine());
                    var pro = userServise.GetById(m);
                    if (pro != null)
                    {
                        Console.WriteLine(pro.Id);
                        Console.WriteLine(pro.FullName);
                        Console.WriteLine(pro.UserAge);
                        Console.WriteLine(pro.DateofBirth);
                    }
                    else { Console.WriteLine("Not Found"); }
                    break;
                case 3:
                    var user1 = UserData();
                    var data1 = userServise.Update(user1);
                    if (user1 != null)
                    {
                        Console.WriteLine("User updated");
                    }
                    else Console.WriteLine("User not updated");
                    break;
                case 4:
                    Console.Write("Enter your ID: ");
                    int id = int.Parse(Console.ReadLine());
                    var prp = userServise.GetById(id);

                    if (prp != null)
                    {
                        Console.WriteLine("Qaysi Id li userga pul yubormoqchisiz?");
                        int iduser = int.Parse(Console.ReadLine());

                        Console.Write("Summa = ");
                        decimal sum = decimal.Parse(Console.ReadLine());

                        BankUser bankuser = new BankUser();

                        if (prp.Cash >= sum)
                        {
                            userServise.Transfers(iduser, sum);
                            prp.Cash -= sum;
                            Console.WriteLine("Done");
                        }
                        else Console.WriteLine("You cannot transfer");
                    }
                    else Console.WriteLine("Not User!");
                    break;
                case 5:
                    List<BankUser> users = userServise.GetAll();
                    foreach (var i in users)
                    {
                        Console.WriteLine(i.Id);
                        Console.WriteLine(i.FullName);
                        Console.WriteLine(i.UserAge);
                        Console.WriteLine(i.DateofBirth);
                        Console.WriteLine($"Cash = {i.Cash}");
                    }
                    break;
                case 6:
                    Console.WriteLine("Enter ID: ");
                    var md = int.Parse(Console.ReadLine());
                    var data2 = userServise.Delete(md);
                    if (data2 != null)
                    {
                        Console.WriteLine("Deleted");
                    }
                    else Console.WriteLine("Not Deleted");
                    break;

                case 7:
                    Servise();
                    break;
            }
        }
    }
 }
