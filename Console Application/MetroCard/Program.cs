using System;
using System.Collections.Generic;
namespace MetroCard;
class Program{
 
    static List<UserDetails> userDetailsList=new List<UserDetails>();
    static List<TravelDetails>travelDetailsLsit=new List<TravelDetails>();
    static List<TicketDetails>ticketDetailsList=new List<TicketDetails>();
    static UserDetails currentUser;
    public static void Main(string[] args)
    {
        LoadData();
        //to prepare a console application for the Metro Card Management System
        Console.WriteLine("                          Welcome to the Chennai Metro Rail Limited                                 ");
        string input="yes";
        do{
            Console.WriteLine("1.New User Registration\n2.Login User\n3.Exit");
            Console.WriteLine("Enter your Choice to Proceed further....");
            int choice= int.Parse(Console.ReadLine());
            switch(choice){
                case 1:{
                    NewUserRegistration();
                    break;
                }
                case 2:{
                    UserLogin();
                    break;
                }
                case 3:{
                    input="no";
                    Console.WriteLine("Exited Successfully.......");
                    break;
                }
                default:{
                    Console.WriteLine("Invalid Input...");
                    break;
                }
            }

        }while(input=="yes");
        
    }
    public static void LoadData(){
        //Default details of User Details class
        UserDetails user1=new UserDetails("Ravi",98488,1000);
        UserDetails user2=new UserDetails("Baskaran",99488,1000);
        //add to the list
        userDetailsList.Add(user1);
        userDetailsList.Add(user2);
        //Default Travel history Details 
        TravelDetails travel1=new TravelDetails("Airport","Egmore",DateTime.ParseExact("10/10/2022","dd/MM/yyyy",null),55);
        TravelDetails travel2=new TravelDetails("Egmore","Koyambedu",DateTime.ParseExact("10/10/2022","dd/MM/yyyy",null),32);
        TravelDetails travel3=new TravelDetails("Alandur","Koyambedu",DateTime.ParseExact("10/11/2022","dd/MM/yyyy",null),25);
        TravelDetails travel4=new TravelDetails("Egmore","Thirumangalam",DateTime.ParseExact("10/11/2022","dd/MM/yyyy",null),25); 
        //add to the list
        travelDetailsLsit.Add(travel1);
        travelDetailsLsit.Add(travel2);
        travelDetailsLsit.Add(travel3);
        travelDetailsLsit.Add(travel4);
        //Default Ticket Fair Details
        TicketDetails ticket1=new TicketDetails("Airport","Egmore",55);
        TicketDetails ticket2=new TicketDetails("Airport","Koyambedu",25);
        TicketDetails ticket3=new TicketDetails("Alandur","Egmore",25);
        TicketDetails ticket4=new TicketDetails("Koyambedu","Egmore",32);
        TicketDetails ticket5=new TicketDetails("Vadapalani","Egmore",45);
        TicketDetails ticket6=new TicketDetails("Arumbakkam","Egmore",25);
        TicketDetails ticket7=new TicketDetails("vadapalani","Koyambedu",25);
        TicketDetails ticket8=new TicketDetails("Arumbakkam","Koyambedu",16);
        //add to the List
        ticketDetailsList.Add(ticket1);
        ticketDetailsList.Add(ticket2);
        ticketDetailsList.Add(ticket3);
        ticketDetailsList.Add(ticket4);
        ticketDetailsList.Add(ticket5);
        ticketDetailsList.Add(ticket6);
        ticketDetailsList.Add(ticket7);
        ticketDetailsList.Add(ticket8);
    }
    public static void NewUserRegistration(){
        Console.WriteLine("           USER REGISTRATION PORTAL          ");
        //to get the below User’s details and add new user to the system
        Console.WriteLine("Enter the UserName: ");
        string name=Console.ReadLine();
        Console.WriteLine("Enter your Phone Number: ");
        long phone=long.Parse(Console.ReadLine());
        Console.WriteLine("Enter your Balance: ");
        double balance=double.Parse(Console.ReadLine());
        UserDetails user3=new UserDetails(name,phone,balance);
        userDetailsList.Add(user3);
        Console.WriteLine($"your card number is {user3.CardNumber}");
    }
    public static void UserLogin(){
        Console.WriteLine("           USER LOGIN PORTAL          ");
        //Get the card number from the user and check whether the card number is exists
        Console.WriteLine("Enter your Card Number: ");
        string cardNumber=Console.ReadLine().ToUpper();
        bool flag=true;
        foreach(UserDetails user in userDetailsList){
            if(cardNumber==user.CardNumber){
                //If exist, display the below sub menu options
                currentUser=user;
                Login();
                flag=false;

            }
        }
        if(flag==true){
            //Else, display “the card number you entered is not a valid one”
            Console.WriteLine("the card number you entered is not a valid one");
        }
    }
    public static void Login(){
        
        string input="yes";
        do{
            Console.WriteLine("1.Balance Check\n2.Recharge\n3.View Travel History\n4.Travel\n5.Exit");
        Console.WriteLine("choose your choice to proceed further....");
        int choice=int.Parse(Console.ReadLine());
            switch(choice){
                case 1:{
                    NewUserRegistration();
                    break;
                }
                case 2:{
                    UserLogin();
                    break;
                }
                case 3:{
                    input="no";
                    Console.WriteLine("Exited Successfully.......");
                    break;
                }
                default:{
                    Console.WriteLine("Invalid Input...");
                    break;
                }
            }

        }while(input=="yes");
        
    }
}

