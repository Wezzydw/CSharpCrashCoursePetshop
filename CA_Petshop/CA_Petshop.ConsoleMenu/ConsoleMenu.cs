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
            menuItemsList.Add("Search all pets");
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
                    break;
                default:
                    Print("Choose one of the numbers");
                    MakeSelection(WaitForInt());
                    break;
            }
        }

        private void ShowAllPets()
        {
            DisplayList(_petService.GetPets());
            WaitForContinue();
            ClearConsole();
            ShowMainMenu();
        }

        private void ClearConsole()
        {
            Console.Clear();
        }

        private void WaitForContinue()
        {
            Print("Press enter to return");
            Console.ReadLine();
        }

        private void DisplayList(List<Pet> pets)
        {
            ClearConsole();
            foreach (Pet pet in pets)
            {
                Print($"ID: {pet.ID}, Name:{pet.Name}, Color: {pet.Color}, " +
                      $"Birthdate: {pet.Birthdate}, Price: {pet.Price}, " +
                      $"Sold: {pet.SoldDate}, Prev Owner: {pet.PreviousOwner} ");
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

    }
}
