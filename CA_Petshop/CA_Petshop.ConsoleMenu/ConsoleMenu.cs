using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using CA_Petshop.Core.ApplicationServices;
using CA_Petshop.Core.ApplicationServices.Services;
using CA_Petshop.Core.DomainServices;
using CA_Petshop.Core.Entity;
using CA_Petshop.Infrastructure.Data.Repositories;

namespace CA_Petshop.ConsoleMenu
{
    class ConsoleMenu: IConsoleMenu
    {
        private IPetRepository _petRepository;
        private IPetService _petService;
        private List<String> menuItemsList = new List<string>();
        public void Run()
        {
            
            _petRepository = new PetRepository();
            _petService = new PetService(_petRepository);
            MakeMenuItems();
            ShowMainMenu();
        }


        private void MakeMenuItems()
        {
            menuItemsList.Add("Show all pets");
            menuItemsList.Add("Search for pet type");
            menuItemsList.Add("Create new pet");
            menuItemsList.Add("Delete pet");
            menuItemsList.Add("Update pet");
            menuItemsList.Add("Sort pets by price");
            menuItemsList.Add("Get 5 cheapest pets");
        }

        private void MakeSelection(int input)
        {
            switch (input)
            {
                case 1:
                    ShowAllPets();
                    WaitForContinue();
                    break;
                case 2:
                    FindType();
                    break;
                case 3:
                    CreatePet();
                    break;
                case 4:
                    DeletePet();
                    break;
                case 5:
                    UpdatePet();
                    break;
                case 6:
                    ListPetsByPrice();
                    break;
                case 7:
                    List5CheapestPets();
                    break;
                default:
                    Print("Choose one of the numbers");
                    MakeSelection(WaitForInt());
                    break;
            }
        }

        private void List5CheapestPets()
        {
            DisplayList(_petService.Get5CheapestPets());
            WaitForContinue();
        }

        private void ListPetsByPrice()
        {
            DisplayList(_petService.SortPetsByPrice());
            WaitForContinue();
        }

        private void UpdatePet()
        {
            ShowAllPets();
            Print("Select pet ID to edit");
            int id = WaitForInt();

            Print("Type new name");
            string name = WaitForString();
            Print("Type new color");
            string color = WaitForString();
            Print("Type new price");
            double price = WaitForInt();
            Print("Type new Race");
            Pet.Race race = SelectType();
            Print("Type new PrevOwner");
            string prewOwner = WaitForString();
            Print("Type new birthDate in the format : 01-01-2001");
            string birthDate = WaitForString();
            Print("Type new soldDate in the format : 01-01-2001");
            string soldDate = WaitForString();

            Pet newPet = new Pet()
            {
                Name = name,
                Color = color,
                Birthdate = DateTime.Parse(birthDate),
                SoldDate = DateTime.Parse(soldDate),
                PreviousOwner = prewOwner,
                race = race,
                Price = price
            };
            _petService.UpdatePet(id, newPet);

            WaitForContinue();
        }

        private void DeletePet()
        {
            ShowAllPets();
            Print("Select ID to delete");
            _petService.DeletePet(WaitForInt());
            Print("Pet is now deleted");
            WaitForContinue();
        }

        private void CreatePet()
        {
            ClearConsole();
            Print("Type name");
            string name = WaitForString();
            Print("Type color");
            string color = WaitForString();
            Print("Type price");
            double price = WaitForInt();
            Print("Type Race");
            Pet.Race race = SelectType();
            Print("Type PrevOwner");
            string prewOwner = WaitForString();
            Print("Type birthDate in the format : 01-01-2001");
            string birthDate = WaitForString();
            Print("Type soldDate in the format : 01-01-2001");
            string soldDate = WaitForString();
            
            Pet newPet = new Pet()
            {
                Name = name,
                Color = color,
                Birthdate = DateTime.Parse(birthDate),
                SoldDate = DateTime.Parse(soldDate),
                PreviousOwner = prewOwner,
                race = race,
                Price = price
            };

            _petService.CreatePet(newPet);
            WaitForContinue();
        }
        
        private void FindType()
        {

            DisplayList(_petService.SearchPets(SelectType()));
            WaitForContinue();
        }

        private Pet.Race SelectType()
        {
            ClearConsole();
            Print("Select a number");
            int i = 1;
            foreach (Pet.Race race in Enum.GetValues(typeof(Pet.Race)))
            {
                Print($"{i}: {race}");
                i++;
            }

            int number = -1;
            while (number < 0 || number > Enum.GetValues(typeof(Pet.Race)).Length)
            {
                number = WaitForInt();
            }
            Pet.Race selected = (Pet.Race)Enum.GetValues(typeof(Pet.Race)).GetValue(number - 1);
            return selected;
        }

        private void ShowAllPets()
        {
            DisplayList(_petService.GetPets());
            
            
        }

        private void ClearConsole()
        {
            Console.Clear();

        }

        private void WaitForContinue()
        {
            Print("Press enter to return");
            Console.ReadLine();
            ClearConsole();
            ShowMainMenu();
        }

        private void DisplayList(List<Pet> pets)
        {
            ClearConsole();
            foreach (Pet pet in pets)
            {
                Print($"ID: {pet.ID}, Name: {pet.Name}, Color: {pet.Color}, Type: {pet.race}, " +
                      $"Birthdate: {pet.Birthdate:d}, Price: {pet.Price}, " +
                      $"Sold: {pet.SoldDate:d}, Prev Owner: {pet.PreviousOwner} ");
            }
        }


        private void ShowMainMenu()
        {
            Print("Choose what you want to do");
            for (int i = 0; i < menuItemsList.Count; i++)
            {
                Print($"{i+1}: {menuItemsList[i]}");
            }

            MakeSelection(WaitForInt());
        }

        private void Print(string toPrint)
        {
            Console.WriteLine(toPrint);
        }

        private int WaitForInt()
        {
            int userInput;
            if (int.TryParse(Console.ReadLine(), out userInput))
            {
                return userInput;
            }
            else
            {
                return -1;
            }
        }

        private string WaitForString()
        {
            return Console.ReadLine();
        }

    }
}
