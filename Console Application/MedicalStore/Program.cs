using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace MedicalStore;
class Program{
    static List<UserDetails>userDetailsList=new List<UserDetails>();
    static List<MedicineDetails>medicineDetailsList=new List<MedicineDetails>();
    static List<OrderDetails>orderDetailsList=new List<OrderDetails>();
    static UserDetails currentUser;
    public static void Main(string[] args)
    {
        LoadData();
        //to prepare a console application for online medical store
        string input="yes";
        do{
            Console.WriteLine("                WELCOME TO THE ONLINE MEDICAL STORE               ");
            Console.WriteLine("\n1.USER REGISTRATION\n2.USER LOGIN\n3.EXIT");
            Console.WriteLine("Click one to proceed further-------->");
            int choice=int.Parse(Console.ReadLine());
            switch(choice){
                case 1:{
                    Console.WriteLine("                     REGISTRATION PAGE                       ");
                    UserRegistration();
                    break;
                }
                case 2:{
                    Console.WriteLine("                     LOGIN PAGE                       ");
                    UserLogin();
                    break;
                }
                case 3:{
                    input="no";
                    Console.WriteLine("Exited Sucessfullly...........! ");
                    break;
                }
            }

        }while(input=="yes");

    }
    public static void UserRegistration(){
        //to create a new user account get the details from the user....
        Console.WriteLine("ENTER THE USER NAME: ");
        string name=Console.ReadLine();
        Console.WriteLine("ENTER THE AGE: ");
        int age=int.Parse(Console.ReadLine());
        Console.WriteLine("ENTER THE CITY: ");
        string city=Console.ReadLine();
        Console.WriteLine("ENTER THE MOBILE: ");
        long mobile=long.Parse(Console.ReadLine());
        Console.WriteLine("ENTER THE WALLET BALANCE: ");
        double walletBalance=double.Parse(Console.ReadLine());
        UserDetails user=new UserDetails(name,age,city,mobile,walletBalance);
        userDetailsList.Add(user);
        //the new user account is created 
        Console.WriteLine($" YOUR REGISTRATION ID IS {user.UserId}");
    }
    public static void UserLogin(){
        //Get the User Id from the user
        Console.WriteLine("Enter the User Id: ");
        string userId=Console.ReadLine();
        bool flag=true;
        //check the user id  is in the user detail list
        foreach(UserDetails user in userDetailsList){
            if(user.UserId==userId){
                //valid means go to the login method
                flag=false;
                currentUser=user;
                Login();
                break;
            }
        }
        if(flag){
            //invalid means show the message that is not the valid id to proceed further
            Console.WriteLine("INVALID USER ID......");
        }
    }
    public static void Login(){
        //submenu for user Login page
        string input="yes";
        do{
            Console.WriteLine("\n1.Show medicine list\n2.Purchase medicine\n3.Modify purchase\n4.Cancel purchase\n5.Show purchase history\n6.Recharge Wallet\n7.Show Wallet Balance\n8.Exit");
            Console.WriteLine("Click one to proceed further-------->");
            int choice=int.Parse(Console.ReadLine());
            switch(choice){
                case 1:{
                    Console.WriteLine("                     Show medicine list                       ");
                    ShowMedicineList();
                    break;
                }
                case 2:{
                    Console.WriteLine("                      Purchase medicine                      ");
                    PurchaseMedicine();
                    break;
                }
                case 3:{
                    Console.WriteLine("                      Modify purchase                      ");
                    ModifyPurchase();
                    break;
                }
                case 4:{
                    Console.WriteLine("                     Cancel purchase                       ");
                    CancelPurchase();
                    break;
                }
                case 5:{
                    Console.WriteLine("                      Show purchase history                      ");
                    ShowPurchaseHistory();
                    break;
                }
                case 6:{
                    Console.WriteLine("                      Recharge Wallet                      ");
                    RechargeWallet();
                    break;
                }
                case 7:{
                    Console.WriteLine("                      Show Wallet Balance                     ");
                    ShowWalletBalance();
                    break;
                }
                case 8:{
                    input="no";
                    Console.WriteLine("Exited Sucessfullly...........! ");
                    break;
                }
            }

        }while(input=="yes");
    }
    public static void ShowMedicineList(){
        //Show the list of available medicine details in the store....
        string  line="*********************************************************************************************************************************";
        Console.WriteLine(line);
        Console.WriteLine($"{"MedicineID",20}	{"MedicineName",20}	{"Available Count",20}	{"Price",20}  {"DateOfExpiry",20}");
        Console.WriteLine(line);
        foreach(MedicineDetails medicine in medicineDetailsList){
            Console.WriteLine($"{medicine.MedicineID,20}	{medicine.MedicineName,20}	{medicine.AvailableCount,20}	{medicine.Price,20}  {medicine.DateOfExpiry,20}");
            Console.WriteLine(line);
        }
    }
    public static void  PurchaseMedicine(){
        //Show the list of available medicine details in the store....
        string  line="*************************************************************************************************************************************";
        Console.WriteLine(line);
        Console.WriteLine($"{"MedicineID",20}	{"MedicineName",20}	{"Available Count",20}	{"Price",20}  {"DateOfExpiry",20}");
        Console.WriteLine(line);
        foreach(MedicineDetails medicine in medicineDetailsList){
            Console.WriteLine($"{medicine.MedicineID,20}	{medicine.MedicineName,20}	{medicine.AvailableCount,20}	{medicine.Price,20}  {medicine.DateOfExpiry,20}");
            Console.WriteLine(line);
        }
        bool flag=true;
        //to get the user to select the medicine using MedicineID
        Console.WriteLine("Enter the Medical Id : ");
        string medicineId=Console.ReadLine();
        foreach(MedicineDetails medicine1 in medicineDetailsList){
            //Check the Medicine list whether the MedicineID was available
            if(medicine1.MedicineID==medicineId){
                flag=false;
                //Get the number of counts of that medicine...
                Console.WriteLine("Enter the count of medicine that you want: ");
                int count=int.Parse(Console.ReadLine());
                //check the asked count is available//Check the medicine was not expired
                if(count<=medicine1.AvailableCount&&medicine1.DateOfExpiry>DateTime.Today){
                    double total=count*medicine1.Price;
                    //check User has enough balance to purchase that medicine
                    if(currentUser.WalletBalance>=total){
                        //Reduce the number of AvailableCount
                        medicine1.AvailableCount-=count;
                        //Deduct the total amount from user’s balance amount
                        currentUser.DeductBalance(total);
                        //create object for OrderDetails class and add it to the list
                        OrderDetails order=new OrderDetails(currentUser.UserId,medicine1.MedicineID,count,total,DateTime.Now,OrderStatus.Purchased);
                        orderDetailsList.Add(order);
                        //Order details updated sucessfully.....
                        Console.WriteLine($"Medicine was purchased successfully  and your Order Id is {order.OrderId}.");
                        break;

                    }else{
                        Console.WriteLine("Insufficient Balance....");
                    }
                }else{
                    Console.WriteLine("Medicine is not available");
                }

            }
        }
        if(flag){
            Console.WriteLine("Invalid MedicalId....");
        }
    }
    public static void ModifyPurchase(){
        bool flag =true;
        foreach(OrderDetails order in orderDetailsList){
            //Show the order details of current logged in user to pick a order detail by using OrderID and whose status is “Purchased”. Check whether the purchase details is present
            if(order.UserId==currentUser.UserId&&OrderStatus.Purchased==order.Status){
                flag=false;
                string line="*************************************************************************************************************************************************************************************************************";
                Console.WriteLine(line);
                Console.WriteLine($"{"OrderID",20}	{"UserID",20}	{"MedicineID",20}	{"MedicineCount",20}	{"TotalPrice",20}	{"OrderDate",20}	{"OrderStatus",20}");
                Console.WriteLine(line);
                foreach(OrderDetails order1 in orderDetailsList){
                    if(order1.UserId==currentUser.UserId){
                        Console.WriteLine($"{order.OrderId,20}	{order.UserId,20}	{order.MedicineID,20}	{order.MedicineCount,20}	{order.TotalPrice,20}	{order.OrderDate,20}	{order.Status,20}");
                        Console.WriteLine(line);
                    }
                }
                Console.WriteLine("Enter your order Id to modify: ");
                string orderId=Console.ReadLine();
                //Ensure the order ID is available and ask the user to enter the new quantity of the medicine
                if(order.OrderId==orderId){
                    Console.WriteLine("Enter the new count of medicine that you want: ");
                    int quantity=int.Parse(Console.ReadLine());
                    //Calculate the order price and update in the order price
                    foreach(MedicineDetails medicine in medicineDetailsList){
                        if(order.MedicineID==medicine.MedicineID){
                            //To modify the purchase count old one will be added and new count will be deduced...
                            order.MedicineCount+=medicine.AvailableCount;
                            medicine.AvailableCount-=quantity;
                            //Calculate the total price of order and update in purchase details
                            order.TotalPrice+=quantity*medicine.Price;
                            Console.WriteLine("Order Modified Sucessfully.....");
                            break;
                        }
                    }
                    break;

                }else{
                    Console.WriteLine("your order Id is not valid one.......");
                }
            }
        }
        if(flag){
            Console.WriteLine("Invalid Modification.....");
        }
    }
    public static void CancelPurchase(){
        bool flag=true;
        foreach(OrderDetails order in orderDetailsList){
            if(order.UserId==currentUser.UserId&&OrderStatus.Purchased==order.Status){
                flag=false;
                //Show the order details of the currently logged in user whose order status is “Purchased”
                string line="***********************************************************************************************************************************************************";
                Console.WriteLine(line);
                Console.WriteLine($"{"OrderID",20}	{"UserID",20}	{"MedicineID",20}	{"MedicineCount",20}	{"TotalPrice",20}	{"OrderDate",20}	{"OrderStatus",20}");
                Console.WriteLine(line);
                foreach(OrderDetails order1 in orderDetailsList){
                    Console.WriteLine($"{order.OrderId,20}	{order.UserId,20}	{order.MedicineID,20}	{order.MedicineCount,20}	{order.TotalPrice,20}	{order.OrderDate,20}	{order.Status,20}");
                    Console.WriteLine(line);
                }
                Console.WriteLine("Enter your order Id to modify: ");
                string orderId=Console.ReadLine();
                //Get the OrderID information from the user and check the OrderID present in the list and check its OrderStatus is Purchased.
                if(order.OrderId==orderId){
                    foreach(MedicineDetails medicine in medicineDetailsList){
                        if(order.MedicineID==medicine.MedicineID){
                            //If the OrderID matches increase the count of that Medicine in the medicine details
                            medicine.AvailableCount+=order.MedicineCount;
                            //Change the Status of the order to “Cancelled”
                            order.Status=OrderStatus.Cancelled;
                            //Return the amount to the user.
                            currentUser.WalletBalance+=order.TotalPrice;
                            Console.WriteLine($"YOUR ORDER ID {order.OrderId} WAS CANCELLED SUCESSFULLY");
                            break;
                        }
                    }
                    break;
                }else{
                    Console.WriteLine("Your order Id is invalid....");
                }
            }
        }
        if(flag){
            Console.WriteLine("Invalid Id....");
        }
    }
    public static void ShowPurchaseHistory(){
        foreach(OrderDetails order in orderDetailsList){
            if(order.UserId.Equals(currentUser.UserId)){
                string line="***************************************************************************************************************************************************************************";
                Console.WriteLine(line);
                Console.WriteLine($"{"OrderID",20}	{"UserID",20}	{"MedicineID",20}	{"MedicineCount",20}	{"TotalPrice",20}	{"OrderDate",20}	{"OrderStatus",20}");
                Console.WriteLine(line);
                foreach(OrderDetails order1 in orderDetailsList){
                    Console.WriteLine($"{order1.OrderId,20}	{order1.UserId,20}	{order1.MedicineID,20}	{order1.MedicineCount,20}	{order1.TotalPrice,20}	{order1.OrderDate,20}	{order1.Status,20}");
                    Console.WriteLine(line);
                }
                break;
            }
        }
    }
    public static void RechargeWallet(){
        Console.WriteLine("Enter the amount to recharge: ");
        int recharge=int.Parse(Console.ReadLine());
        Console.WriteLine($"Your Wallet is Recharged sucessfully {currentUser.WalletRecharge(recharge)}");
    }
    public static void ShowWalletBalance(){
        Console.WriteLine($"Your Wallet balance is {currentUser.WalletBalance}.");
    }
    public static void LoadData(){
        UserDetails user1=new UserDetails("Ravi",33,"Theni",9877774440,400);
        UserDetails user2=new UserDetails("Baskaran",33,"Chennai",8847757470,500);
        userDetailsList.Add(user1);
        userDetailsList.Add(user2);
        MedicineDetails medicine1=new MedicineDetails("Paracitamol",40,5,DateTime.ParseExact("30/06/2024","dd/MM/yyyy",null));
        MedicineDetails medicine2=new MedicineDetails("Calpol",10,5,DateTime.ParseExact("30/05/2024","dd/MM/yyyy",null));
        MedicineDetails medicine3=new MedicineDetails("Gelucil",3,40,DateTime.ParseExact("30/04/2023","dd/MM/yyyy",null));
        MedicineDetails medicine4=new MedicineDetails("Metrogel",5,50,DateTime.ParseExact("30/12/2024","dd/MM/yyyy",null));
        MedicineDetails medicine5=new MedicineDetails("Povidin Iodin",10,50,DateTime.ParseExact("30/10/2024","dd/MM/yyyy",null));
        medicineDetailsList.Add(medicine1);
        medicineDetailsList.Add(medicine2);
        medicineDetailsList.Add(medicine3);
        medicineDetailsList.Add(medicine4);
        medicineDetailsList.Add(medicine5);
        OrderDetails order1=new OrderDetails("UID1001","MD101",3,15,DateTime.ParseExact("13/11/2022","dd/MM/yyyy",null),OrderStatus.Purchased);
        OrderDetails order2=new OrderDetails("UID1001","MD102",2,10,DateTime.ParseExact("13/11/2022","dd/MM/yyyy",null),OrderStatus.Cancelled);
        OrderDetails order3=new OrderDetails("UID1001","MD104",2,100,DateTime.ParseExact("13/11/2022","dd/MM/yyyy",null),OrderStatus.Purchased);
        OrderDetails order4=new OrderDetails("UID1002","MD103",3,120,DateTime.ParseExact("15/11/2022","dd/MM/yyyy",null),OrderStatus.Cancelled);
        OrderDetails order5=new OrderDetails("UID1002","MD105",5,250,DateTime.ParseExact("15/11/2022","dd/MM/yyyy",null),OrderStatus.Purchased);
        OrderDetails order6=new OrderDetails("UID1002","MD102",3,15,DateTime.ParseExact("15/11/2022","dd/MM/yyyy",null),OrderStatus.Purchased);
        orderDetailsList.Add(order1);
        orderDetailsList.Add(order2);
        orderDetailsList.Add(order3);
        orderDetailsList.Add(order4);
        orderDetailsList.Add(order5);
        orderDetailsList.Add(order6);    
    }
}