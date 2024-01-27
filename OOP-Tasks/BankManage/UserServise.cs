namespace OOP_Tasks.BankManage;

public class UserServise
{
    List<BankUser> users = new List<BankUser>();
    public void PutDepozit(int id)
    {
        var user = users.FirstOrDefault(u => u.Id == id);
        if (user != null)
        {
            Console.Write("Summa = ");
            int sum = int.Parse(Console.ReadLine());
            user.Cash += sum;
        }
        else Console.WriteLine("Not User");
    }
    public void GetCash(int id)
    {
        var user = users.FirstOrDefault(u => u.Id == id);
        if (user != null)
        {
            Console.Write("Summa = ");
            int sum = int.Parse(Console.ReadLine());
            user.Cash -= sum;
        }
    }
    public decimal GetBalance(int id)
    {
        var user = users.FirstOrDefault(u => u.Id == id);
        if (user != null)
        {
            return user.Cash;
        }
        else Console.WriteLine("Not User");
        return 0;
    }
    public bool Create(BankUser user)
    {
        BankUser existUser = users.FirstOrDefault(u => u.Id == user.Id);
        if (existUser == null)
        {
            users.Add(user);
            return true;
        }
        return false;
    }

    public BankUser GetById(int id)
    {
        var pruduct = users.FirstOrDefault(u => u.Id == id);
        if (pruduct != null)
        {
            return pruduct;
        }
        return null;
    }
    public bool Update(BankUser user)
    {
        BankUser existuser = users.FirstOrDefault(u => u.Id == user.Id);
        if (existuser == null)
        {
            return false;
        }

        existuser.Id = user.Id;
        existuser.FullName = user.FullName;
        existuser.UserAge = user.UserAge;
        existuser.DateofBirth = user.DateofBirth;
        existuser.Cash = user.Cash;

        return true;
    }

    public bool Delete(int id)
    {
        BankUser existUser = users.FirstOrDefault(u => u.Id == id);
        if (existUser != null)
        {
            users.Remove(existUser);
            return true;
        }
        return false;
    }

    public decimal Transfers(int id, decimal summa)
    {
        BankUser existUser = users.FirstOrDefault(u => u.Id == id);
        if(existUser != null)
        {
            existUser.Cash += summa;
        }
        return existUser.Cash;
    }
    public List<BankUser> GetAll()
    {
        return users;
    }

}
