using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Cafetaria;
namespace MedicalStore;
class Program{
    //to prepare a console application for Cafeteria management
    static List<UserDetails>userDetailsList=new List<UserDetails>();
    static List<OrderDetails>orderDetailsList=new List<OrderDetails>();
    static List<cartItem>cartItemsList=new List<cartItem>();
    static List<FoodDetails>foodDetailsList=new List<FoodDetails>();
    static UserDetails currentUser;
    public static void Main(string[] args)
    {
        LoadData();
        //to prepare a console application for online medical store
        string input="yes";
        do{
            Console.WriteLine("                           CAFETARIA MANAGEMENT                      ");
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
        Console.WriteLine("ENTER THE FATHER NAME: ");
        string fatherName=Console.ReadLine();
        Console.WriteLine("ENTER THE MOBILE: ");
        long mobile=long.Parse(Console.ReadLine());
        Console.WriteLine("ENTER THE MAIL ID: ");
        string mailID=Console.ReadLine();
        Console.WriteLine("ENTER THE Gender: ");
        Gender gender=Enum.Parse<Gender>(Console.ReadLine(),true);
        Console.WriteLine("ENTER THE BALANCE: ");
        double balance=double.Parse(Console.ReadLine());
        UserDetails user=new UserDetails(name,fatherName,gender,mobile,mailID,balance);
        userDetailsList.Add(user);
        //the new user account is created 
        Console.WriteLine($" YOUR REGISTRATION ID IS {user.UserID}");
        Console.WriteLine($"your Workstation Number is {user.WorkStationNumber}.");
    }
    public static void UserLogin(){
        //Get the User Id from the user
        Console.WriteLine("Enter the User Id: ");
        string userId=Console.ReadLine();
        bool flag=true;
        //check the user id  is in the user detail list
        foreach(UserDetails user in userDetailsList){
            if(user.UserID==userId){
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
        string input="yes";
        do{
            Console.WriteLine("\n1.Show My Profile\n2.Food Order\n3.Modify Order\n4.Cancel Order\n5.Order history\n6.Wallet Recharge\n7.Show Wallet Balance\n8.Exit");
            Console.WriteLine("Click one to proceed further-------->");
            int choice=int.Parse(Console.ReadLine());
            switch(choice){
                case 1:{
                    Console.WriteLine("                     Show My Profile                       ");
                    ShowMyProfile();
                    break;
                }
                case 2:{
                    Console.WriteLine("                      Food Order                      ");
                    FoodOrder();
                    break;
                }
                case 3:{
                    Console.WriteLine("                      Modify Order                      ");
                    ModifyOrder();
                    break;
                }
                case 4:{
                    Console.WriteLine("                     Cancel Order                       ");
                    CancelOrder();
                    break;
                }
                case 5:{
                    Console.WriteLine("                      Order history                      ");
                    OrderHistory();
                    break;
                }
                case 6:{
                    Console.WriteLine("                      Wallet Recharge                     ");
                    WalletRecharge();
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
    public static void ShowMyProfile(){
        string line="****************************************************************************************************************************************************************************";
        Console.WriteLine(line);
        Console.WriteLine($"{"UserID",15}	{"UserName",15}	{"FatherName",15}	{"MobileNumber",15}	{"MailID",15}	{"Gender",18}	{"WorkStationNumber",20}	{"Balance",15}");
        Console.WriteLine(line);
        Console.WriteLine($"{currentUser.UserID,15}	{currentUser.Name,15}	{currentUser.FatherName,15}	{currentUser.Mobile,15}	{currentUser.MailID,18}	{currentUser.Gender,10}	{currentUser.WorkStationNumber,15}	{currentUser.Balance,10}");
        Console.WriteLine(line);
    }
    /*1.	Create a temporary local carItemtList.
2.	Create an Order object with current UserID, Order date as current DateTime, total price as 0, Order status as “Initiated”.
3.	Ask the user to pick a product using FoodID, quantity required and calculate price of food.
4.	If the food and quantity available, reduce the quantity from the food object’s “AvailableQuantity” then create CartItems object using the available data.
5.	Add that object it to local CartItemsList to add it to cart wish list.
6.	Ask the user whether he want to pick another product. 
7.	If “Yes” then repeat from step “3”.
8.	Repeat the process until the user enters “No”.
9.	If He says No then, 
10.	Ask the user whether he confirm the wish list to purchase. If he says “No” then traverse the local CartItemList and get the Items one by one and reverse the quantity to the FoodItem’s objects in the foodList.
11.	If he says “Yes” then, Calculate the total price of the food items selected using the local CartItemList information and check the balance from the user details whether it has sufficient balance to purchase.
12.	If he has enough balance, then deduct the respective amount from the user’s balance. 
13.	Append the local CartItemList to global CartItemList.
14.	Modify Order object created at step 1’s total price as total OrderPrice and OrderStatus as “Ordered”. 
15.	Then add the Order object to the Order list.
16.	Show “Order placed successfully, and OrderID is OID1001”.
17.	If he doesn’t have enough balance show “In sufficient balance to purchase.” Ask him “Are you willing to recharge.”
18.	 If he says “No” then show “Exiting without Order due to insufficient balance”. Then need to return the localCartList items to foodItemsList.
19.	If he says “Yes”. Then ask him to Recharge with the total price of Order. If he recharged with that amount means continue from step 12 to continue purchase. 
*/
    public static void FoodOrder(){
        foreach(FoodDetails food in foodDetailsList){
            Console.Write(food.FoodName);
            Console.Write("             ");
            Console.Write(food.FoodID);
            Console.Write("             ");
            Console.Write(food.AvailableQuantity);
            Console.Write("          ");
            Console.Write(food.FoodPrice);
            Console.WriteLine();
        }
        Console.WriteLine("Enter the Food Id that you want : ");
        string foodId=Console.ReadLine();
        foreach(FoodDetails food in foodDetailsList){
            if(foodId==food.FoodID){
                Console.WriteLine("Enter the count : ");
                int count=int.Parse(Console.ReadLine());
                if(count<food.AvailableQuantity){
                    double price=count*food.FoodPrice;
                    currentUser.WalletBalance-=price;
                    OrderDetails order=new OrderDetails(currentUser.UserID,DateOnly.FromDateTime(DateTime.Now),price,OrderStatus.Ordered);
                    orderDetailsList.Add(order);
                }else{
                    Console.WriteLine("out of stock...");
                }
            }
        }
    }
    public static void ModifyOrder(){
        string line="****************************************************************************************************************************************************************************";
        Console.WriteLine(line);
        Console.WriteLine($"{"OrderID",15}	{"UserID",15}	{"OrderDate",15}	{"TotalPrice",15}	{"OrderStatus",15}");
        foreach(OrderDetails order in orderDetailsList){
            if(order.UserID==currentUser.UserID){
                Console.WriteLine(line);
                Console.WriteLine($"{order.OrderId,15}	{order.UserID,15}	{order.OrderDate,15}	{order.TotalPrice,15}	{order.Status,15}");
            }
        }
        Console.WriteLine("Enter the Order Id That you want to modify: ");
        string orderId=Console.ReadLine();
        foreach(OrderDetails order in orderDetailsList){
            if(order.UserID==currentUser.UserID){
                foreach(cartItem cart in cartItemsList){
                    Console.Write(cart.ItemID);
                    Console.Write("    ");
                    Console.Write(cart.FoodID);
                    Console.WriteLine();
                }
                Console.WriteLine("Enter the item id: ");
                string itemId=Console.ReadLine();
                Console.WriteLine("Enter the new quantity: ");
                int quantity=int.Parse(Console.ReadLine());
                foreach(cartItem cart in cartItemsList){
                    if(itemId==cart.ItemID){
                        foreach(FoodDetails food in foodDetailsList){
                            if(cart.FoodID==food.FoodID&&food.AvailableQuantity>=quantity){
                                double TotalPrice=quantity*food.FoodPrice;
                                food.AvailableQuantity-=quantity;
                                currentUser.WalletBalance-=TotalPrice;
                                OrderDetails order1 =new OrderDetails(currentUser.UserID,DateOnly.FromDateTime(DateTime.Now),TotalPrice,OrderStatus.Ordered);
                                orderDetailsList.Add(order1);
                                Console.WriteLine("Order Modified Sucessfully.....");
                            }
                        }
                    }
                }
                
            }
        }
    }
    public static void CancelOrder(){
        string line="****************************************************************************************************************************************************************************";
        Console.WriteLine(line);
        Console.WriteLine($"{"OrderID",15}	{"UserID",15}	{"OrderDate",15}	{"TotalPrice",15}	{"OrderStatus",15}");
        foreach(OrderDetails order in orderDetailsList){
            if(order.UserID==currentUser.UserID){
                Console.WriteLine(line);
                Console.WriteLine($"{order.OrderId,15}	{order.UserID,15}	{order.OrderDate,15}	{order.TotalPrice,15}	{order.Status,15}");
            }
        }
        Console.WriteLine("Enter the Order Id That you want to modify: ");
        string orderId=Console.ReadLine();
        foreach(OrderDetails order in orderDetailsList){
            if(order.UserID==currentUser.UserID){
                order.Status=OrderStatus.Ordered;
                currentUser.WalletBalance+=order.TotalPrice;
                Console.WriteLine("Order Cancelled sucessfully.....!");
            }
        }

    }
    public static void  OrderHistory(){
        bool flag=true;
        foreach(OrderDetails order in orderDetailsList){
            
            if(currentUser.UserID.Equals(order.UserID)){
                flag=false;
                Console.Write(order.OrderId);
                Console.Write("       ");
                Console.Write(order.UserID);
                Console.Write("       ");
                Console.Write(order.TotalPrice);
                Console.Write("       ");
                Console.Write(order.OrderDate);
                Console.Write("       ");
                Console.Write(order.Status);
                Console.WriteLine();
            }
                
        }
        if(flag){
            Console.WriteLine("Invalid or You didn't have any history...");
        }

    }
    public static void  WalletRecharge(){
         Console.WriteLine("Enter the amount to recharge: ");
        int recharge=int.Parse(Console.ReadLine());
        Console.WriteLine($"Your Wallet is Recharged sucessfully {currentUser.WalletRecharge(recharge)}");
        
    }
    public static void  ShowWalletBalance(){
        Console.WriteLine($"Your Wallet balance is {currentUser.WalletBalance}.");
        
    }



    public static void LoadData(){
        UserDetails user1=new UserDetails("Ravichandran","Ettapparajan",Gender.Male,8857777575,"ravi@gmail.com",400);
        UserDetails user2=new UserDetails("Baskaran","Sethurajan",Gender.Male,9577747744,"baskaran@gmail.com",500);
        userDetailsList.Add(user1);
        userDetailsList.Add(user2);
        OrderDetails order1=new OrderDetails("OID1001","SF1001",DateOnly.ParseExact("15/06/2022","dd/MM/yyyy",null),70,OrderStatus.Ordered);
        OrderDetails order2=new OrderDetails("OID1002","SF1002",DateOnly.ParseExact("15/06/2022","dd/MM/yyyy",null),100,OrderStatus.Ordered);
        orderDetailsList.Add(order1);
        orderDetailsList.Add(order2);
        cartItem cart1=new cartItem("OID1001","FID101",20,1);
        cartItem cart2=new cartItem("OID1001","FID103",10,1);
        cartItem cart3=new cartItem("OID1001","FID105",40,1);
        cartItem cart4=new cartItem("OID1002","FID103",10,1);
        cartItem cart5=new cartItem("OID1002","FID104",50,1);
        cartItem cart6=new cartItem("OID1002","FID105",40,1);
        cartItemsList.Add(cart1);
        cartItemsList.Add(cart2);
        cartItemsList.Add(cart3);
        cartItemsList.Add(cart4);
        cartItemsList.Add(cart5);
        cartItemsList.Add(cart6);
        FoodDetails food1=new FoodDetails("Coffee",20,100);
        FoodDetails food2=new FoodDetails("Tea",15,100);
        FoodDetails food3=new FoodDetails("Biscuit",10,100);
        FoodDetails food4=new FoodDetails("Juice",50,100);
        FoodDetails food5=new FoodDetails("Puff",40,100);
        FoodDetails food6=new FoodDetails("Milk",10,100);
        FoodDetails food7=new FoodDetails("Popcorn",20,20);
        foodDetailsList.Add(food1);
        foodDetailsList.Add(food2);
        foodDetailsList.Add(food3);
        foodDetailsList.Add(food4);
        foodDetailsList.Add(food5);
        foodDetailsList.Add(food6);
        foodDetailsList.Add(food7);
    }
}
