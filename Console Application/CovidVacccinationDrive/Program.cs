// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
namespace CovidVacccinationDrive
{
    class Program
    {
        static List<BeneficiaryRegistration> benificiarylist = new List<BeneficiaryRegistration>();
        static List<Vaccine> vaccinelist = new List<Vaccine>();
        static List<Vaccination> vaccinationlist = new List<Vaccination>();
        static BeneficiaryRegistration currentregistration;
        static Vaccination currentvaccination;
        public static void Main(String[] args)
        {
            LoadDefaultData();
            string option = "yes";
            do
            {
                //create Main menu
                Console.WriteLine("Main Menu :");
                Console.WriteLine("1. Beneficiary Registration");
                Console.WriteLine("2. Login");
                Console.WriteLine("3. Get Vaccine Info");
                Console.WriteLine("4. Exit");
                Console.WriteLine("Please select the option for main menu :");
                Console.WriteLine();
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        {
                            Console.WriteLine("you selected beneficiary registration");
                            BeneficiaryRegistration();
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("You selected Login page");
                            Login();
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("you selected GerVaccine info");
                            GetVaccineInfo();
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("Exiting the page");
                            option = "no";
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Invalid choice!");
                            break;
                        }
                }
            } while (option == "yes");
        }

        //Create method for beneficiary registration
        public static void BeneficiaryRegistration()
        {
            //Get the details from the user
            Console.WriteLine("Enter the details");
            Console.WriteLine("Enter the Name :");
            string Name = Console.ReadLine();
            Console.WriteLine("Enter the Age : ");
            int Age = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the Gender : ");
            Gender Gender = Enum.Parse<Gender>(Console.ReadLine(), true);
            Console.WriteLine("Enter the MobileNumber : ");
            long MobileNumber = long.Parse(Console.ReadLine());
            Console.WriteLine("Enter the City");
            string City = Console.ReadLine();

            //create object for beneficiary registration
            BeneficiaryRegistration beneficiary = new BeneficiaryRegistration(Name, Age, Gender, MobileNumber, City);

            //Add user details to the benificiary list
            benificiarylist.Add(beneficiary);

            //Display the registration number
            Console.WriteLine("you have registered successfully. Your RegistrationNumber : " + beneficiary.RegisterNumber);
            Console.WriteLine();
        }

        // create method for Login Page
        public static void Login()
        {
            //ask user to enter the beneficiary register number
            Console.WriteLine("Enter the Beneficiary Register Number :");
            string beneficiaryNumber = Console.ReadLine();
            bool flag = true;
            foreach (BeneficiaryRegistration beneficiary in benificiarylist)
            {
                if (beneficiaryNumber.Equals(beneficiary.RegisterNumber))
                {
                    //show login successful
                    Console.WriteLine("Login successful");
                    Console.WriteLine();
                    flag = false;
                    currentregistration = beneficiary;
                    //create method for show the submenu
                    ShowSubMenu();
                    break;
                }
            }
            if (flag == true)
            {
                Console.WriteLine("Invalid Register Number");
            }
        }

        //method for showing submenu
        public static void ShowSubMenu()
        {
            string choice = "yes";
            do
            {
                Console.WriteLine("Sub Menu");
                Console.WriteLine("1. Show My Details");
                Console.WriteLine("2. Take Vaccination");
                Console.WriteLine("3. My Vaccination History");
                Console.WriteLine("4. Next Due Date");
                Console.WriteLine("5. Exit");
                Console.WriteLine("Enter the choice for selecting sub menu");
                char choose = char.Parse(Console.ReadLine());
                switch (choose)
                {
                    case 'a':
                        {
                            ShowMyDetails();
                            break;
                        }
                    case 'b':
                        {
                            TakeVaccination();
                            break;
                        }
                    case 'c':
                        {
                            MyVaccinationHistory();
                            break;
                        }
                    case 'd':
                        {
                            NextDueDate();
                            break;
                        }
                    case 'e':
                        {
                            choice = "no";
                            Console.WriteLine("Exiting the page");
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Invalid Option!");
                            break;
                        }
                }
            } while (choice == "yes");
        }

        //create method for showmy details
        public static void ShowMyDetails()
        {
            //show the current beneficiary's personal detaills
            Console.WriteLine($"Name : {currentregistration.Name}");
            Console.WriteLine($"Age : {currentregistration.Age}");
            Console.WriteLine($"Gender : {currentregistration.Gender}");
            Console.WriteLine($"Mobille Number : {currentregistration.MobileNumber}");
            Console.WriteLine($"City : {currentregistration.City}");
        }

        //create method for Take Vaccination
        public static void TakeVaccination()
        {
            //show the list of vaccine available 
            foreach (Vaccine vaccine in vaccinelist)
            {
                Console.WriteLine($"Vaccine name : {vaccine.VaccineName} \t No of dose available : {vaccine.NoOfDoseAvailable}");
            }

            //ask the user to select a vaccine by vaccine ID
            Console.WriteLine("Enter the vaccineID :");
            string vaccineID = Console.ReadLine();
            bool flag1 = true;
            //find thee vaccineID is valid or not
            foreach (Vaccine vaccine1 in vaccinelist)
            {
                flag1 = false;
                if (vaccineID.Equals(vaccine1.VaccineID))
                {
                    foreach (BeneficiaryRegistration beneficiary in benificiarylist)
                    {
                        //if ID is valid then get the vaccination history of current logged in beneficiary
                        Console.WriteLine($"vaccination ID : {currentvaccination.VaccinationID}");
                        Console.WriteLine($"RegisterNumber : {currentregistration.RegisterNumber}");
                        Console.WriteLine($"Vaccine ID : {currentvaccination.VaccineID}");
                        Console.WriteLine($"Dose Number : {(int)(currentvaccination.DoseNumber)}");
                        Console.WriteLine($"Vaccination Date : {currentvaccination.VaccinatedDate}");

                        //they didn't take any vaccine check age is above 14 
                        if (beneficiary.Age > 14)
                        {

                            Console.WriteLine("You are eligiblle to take vaccine");
                            //update the details in vaccination history
                            Vaccination vaccination = new Vaccination(currentregistration.RegisterNumber, vaccine1.VaccineID, DoseNumber.one, DateTime.Now);
                            //add the details in list
                            vaccinationlist.Add(vaccination);

                            //deduct the count of vaccine available.
                            vaccine1.NoOfDoseAvailable--;
                            currentvaccination.DoseNumber = vaccination.DoseNumber;

                            //if
                            if (currentvaccination.DoseNumber == DoseNumber.three)
                            {
                                Console.WriteLine("All the threee vaccination are completed, you cannot be vaccinated now.");
                                foreach (Vaccination vaccination1 in vaccinationlist)
                                {
                                    if (vaccination1.DoseNumber == DoseNumber.one || vaccination1.DoseNumber == DoseNumber.two)
                                    {
                                        //check they selected the same vaccination type
                                        if (vaccine1.VaccineName == VaccineName.Covishield || vaccine1.VaccineName == VaccineName.Covaccine)
                                        {
                                            //check date of his last vaccination
                                            DateTime date = DateTime.Now;
                                            if (date == vaccination1.VaccinatedDate)
                                            {
                                                TimeSpan span = date - vaccination1.VaccinatedDate;
                                                int totaldays = span.Days;

                                                //check whether 30 days have completed
                                                if (totaldays == 30)
                                                {
                                                    //if it is yes allow him to take vaccination
                                                    Vaccination vaccination2 = new Vaccination(currentregistration.RegisterNumber, vaccine1.VaccineID, DoseNumber.two, DateTime.Now);
                                                    //add details to his vaccination list
                                                    vaccinationlist.Add(vaccination2);

                                                    //deduct the count of vaccine available
                                                    vaccine1.NoOfDoseAvailable--;
                                                }
                                            }

                                        }
                                        else
                                        {
                                            Console.WriteLine("You have selected different vaccine. You can vaccine with Covaccine/covishield (His first / second dose vaccine type)");
                                        }
                                    }
                                }
                                //they took one or twoo vaccination in bis vaccinattion history
                            }

                        }
                    }
                }
            }
            if (flag1 == true)
            {
                Console.WriteLine("Invalid vaccineID!");
            }
        }
        //create method for My Vaccination History
        public static void MyVaccinationHistory()
        {
            foreach(Vaccination vaccination in vaccinationlist)
            {
                if(vaccination.DoseNumber == DoseNumber.three)
                {
                    Console.WriteLine($"vaccination ID : {currentvaccination.VaccinationID}");
                    Console.WriteLine($"RegisterNumber : {currentregistration.RegisterNumber}");
                    Console.WriteLine($"Vaccine ID : {currentvaccination.VaccineID}");
                    Console.WriteLine($"Dose Number : {currentvaccination.DoseNumber}");
                    Console.WriteLine($"Vaccination Date : {currentvaccination.VaccinatedDate}");
                }
            }
        }
        //create method for Next Due Date
        public static void NextDueDate()
        {
            foreach(Vaccination vaccination in vaccinationlist)
            {
                DateTime date = vaccination.VaccinatedDate;
                int totaldays = date.AddDays(30);
            }
        }
        //create method for GetVaccineInfo
        public static void GetVaccineInfo()
        {

        }

        public static void LoadDefaultData()
        {
            //object creation for Beneficiary class
            BeneficiaryRegistration beneficiary1 = new BeneficiaryRegistration("Ravichandran", 21, Gender.Male, 8484484, "Chennai");
            BeneficiaryRegistration beneficiary2 = new BeneficiaryRegistration("Baskaran", 22, Gender.Male, 8484747, "Chennai");

            //Add to list
            benificiarylist.Add(beneficiary1);
            benificiarylist.Add(beneficiary2);

            //object creation for Vaccine class
            Vaccine vaccine1 = new Vaccine(VaccineName.Covishield, 50);
            Vaccine vaccine2 = new Vaccine(VaccineName.Covaccine, 50);

            //Add vaccine details to list
            vaccinelist.Add(vaccine1);
            vaccinelist.Add(vaccine2);

            //object creation for vaccination class
            Vaccination vaccination1 = new Vaccination("BID1001", "CID2001", DoseNumber.one, new DateTime(2021, 11, 11));
            Vaccination vaccination2 = new Vaccination("BID1001", "CID2001", DoseNumber.two, new DateTime(2022, 03, 11));
            Vaccination vaccination3 = new Vaccination("BID1002", "CID2002", DoseNumber.one, new DateTime(2022, 04, 04));

            //Add vaccination details to list
            vaccinationlist.Add(vaccination1);
            vaccinationlist.Add(vaccination2);
            vaccinationlist.Add(vaccination3);
        }
    }
}
