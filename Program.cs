using System;
using System.ComponentModel.Design;
using System.Net.Sockets;

class Program
{
    //NONCONFIDENTIAL=0, CONFIDENTIAL=1, SECRET=2, TOP SECRET=3
    static void Main(string[] args)
    {
        //string[] A = { "NONCONFIDENTIAL", "CONFIDENTIAL", "SECRET", "TOP SECRET" };
        List<string> users = new List<string> { "Angelina", "Vitalina", "Arina", "Daria" };
        List<string> objects = new List<string> { "Object 1", "Object 2", "Object 3", "Object 4" };
        string admin = "Angelina";
        int[] users_access_array_base = new int[users.Count];
        int[] users_access_array = new int[users.Count];
        int[] objects_access_array = new int[objects.Count];
        int new_access_user = -1;
        int current_object = 0;

        Random random = new Random();
        for(int i = 0; i < users.Count; i++)
        {
            if (i == users.IndexOf(admin))
            {
                users_access_array_base[i] = 3;
                users_access_array[i] = 3;
            }
            else
            {
                users_access_array[i] = random.Next(0, 3);
                users_access_array_base[i] = users_access_array[i];                
            }
        }
        for (int i = 0; i < objects.Count; i++)
        {
            objects_access_array[i] = random.Next(0, 3);
        }

        Console.WriteLine("OBJECTS:");
        for(int i = 0; i < objects.Count; i++)
        {
            switch(objects_access_array[i])
            {
                case 0:
                    Console.WriteLine(objects[i]+ ": NONCONFIDENTIAL");
                    break;
                case 1:
                    Console.WriteLine(objects[i] + ": CONFIDENTIAL");
                    break;
                case 2:
                    Console.WriteLine(objects[i] + ": SECRET");
                    break;
                case 3:
                    Console.WriteLine(objects[i] + ": TOP_SECRET");
                    break;
            }
        }
        Console.WriteLine("SUBJECTS:");
        for (int i = 0; i < users.Count; i++)
        {
            switch (users_access_array[i])
            {
                case 0:
                    Console.WriteLine(users[i] + ": NONCONFIDENTIAL");
                    break;
                case 1:
                    Console.WriteLine(users[i] + ": CONFIDENTIAL");
                    break;
                case 2:
                    Console.WriteLine(users[i] + ": SECRET");
                    break;
                case 3:
                    Console.WriteLine(users[i] + ": TOP_SECRET");
                    break;
            }
        }

        Console.WriteLine("\nLogin:");
        string current_user = Console.ReadLine();
        int index=users.IndexOf(current_user);
        while (true)
        {
            if (users.Contains(current_user))
            {
                Console.WriteLine("command>");
                string command = Console.ReadLine();                
                switch (command)
                {
                    case "read":
                        Console.WriteLine("At what object?");
                        current_object = int.Parse(Console.ReadLine());
                        if ((users_access_array[index]>= objects_access_array[current_object-1])) {
                            Console.WriteLine("Read success");
                        }
                        else Console.WriteLine("Read denied");
                        break;
                    case "write":
                        Console.WriteLine("At what object?");
                        current_object = int.Parse(Console.ReadLine());
                        if ((users_access_array[index] <= objects_access_array[current_object-1]))
                        {
                            Console.WriteLine("Write success");
                        }
                        else Console.WriteLine("Write denied");
                        break;                        
                    case "change":
                        Console.WriteLine("Enter CLASSIFICATION : ");
                        string new_classification = Console.ReadLine();                        
                        if (new_classification == "NONCONFIDENTIAL") users_access_array[index] = 0;
                        else if (new_classification == "CONFIDENTIAL") users_access_array[index] = 1;
                        else if (new_classification == "SECRET") users_access_array[index] = 2;
                        else if (new_classification == "TOP_SECRET") users_access_array[index] = 3;

                        if(users_access_array[index] <= users_access_array_base[index])
                        {
                            Console.WriteLine(current_user+" is "+ new_classification);
                        }
                        else Console.WriteLine("Change denied");
                        break;
                    case "exit":
                        Console.WriteLine("Login:");
                        current_user = Console.ReadLine();
                        index = users.IndexOf(current_user);
                        break;
                }
            }
            else Console.WriteLine("Извините, такого пользователя не существует!");
        }        
    }
}
