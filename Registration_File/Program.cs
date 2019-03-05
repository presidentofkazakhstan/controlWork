using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Registration_File
{
    class Program
    {
        static void Main(string[] args)
        {
           

            while(true)
            {
                

                Login login = new Login();
                Registration registration = new Registration();
                int choiceNumber = 0;
                Console.WriteLine("|-----------------|");
                Console.WriteLine("|1. Регистрация   |");
                Console.WriteLine("|-----------------|");
                Console.WriteLine("|2. Вход          |");
                Console.WriteLine("|-----------------|");
                Console.WriteLine("|3. Выход         |");
                Console.WriteLine("|-----------------|");
                Console.WriteLine();
                Console.Write("Выберите цифру: ");


                choiceNumber = int.Parse(Console.ReadLine());

                Console.Clear();

                if (choiceNumber == 1)
                {


                    

                    /*    EMAIL        */
                    Console.Write("Введите e-mail        : ");
                    registration.Email = Console.ReadLine();
                  
                    
                    try
                    {
                        if (!registration.Email.Contains('@') | !registration.Email.Contains('.'))
                        {
                            throw new ArgumentException();
                        }
                    }
                    catch (ArgumentException)
                    {
                        Console.WriteLine("E-mail не соответствует требованиям(@ and .)");
                        Console.ReadKey();
                        break;
                    }

                   
                    
                    /*  Password       */
                    int minimalLengthOfPassword = 6;
                    Console.Write("Введите пароль        : ");
                    registration.Password = ReadPassword();
                    try
                    {
                        if (registration.Password.Length < minimalLengthOfPassword)
                        {
                            throw new ArgumentException("Пароль не соответствует требованиям (не меньше 6 символов)");
                        }
                    }
                    catch (ArgumentException)
                    {
                        Console.WriteLine("Пароль не соответствует требованиям (не меньше 6 символов)");
                        Console.ReadKey();
                        break;
                    }


                    /* FullName        */

                    Console.Write("Введите имя           : ");
                    registration.FullName = Console.ReadLine();

                    /* Age */

                    Console.Write("Введите возраст       : ");
                    registration.Age = int.Parse(Console.ReadLine());

                    /* phoneNumber */

                    Console.Write("Введите номер телефона: ");
                    registration.PhoneNumber = Console.ReadLine();
                    try
                    {
                        if (string.IsNullOrEmpty(registration.PhoneNumber) || registration.PhoneNumber.Length > 12 || registration.PhoneNumber.Contains('-') || registration.PhoneNumber.Contains(' '))
                        {
                            throw new ArgumentException();
                        }
                    }
                    catch (ArgumentException)
                    {
                        throw new ArgumentException("Мобильный телефон неверный");
                    }

                    Console.WriteLine("----------------------");
                    Console.WriteLine( "Логин          : " + registration.Email);
                    Console.WriteLine( "Пароль         : " + registration.Password);
                    Console.WriteLine( "Имя            : " + registration.FullName);
                    Console.WriteLine( "Возраст        : " + registration.Age);
                    Console.WriteLine( "Номер телефона : " + registration.PhoneNumber);

                    
                    Console.WriteLine("----------------------");

                    Console.WriteLine("Регистрация успешно пройдена");
                    Console.ReadKey();
                    Console.Clear();

                }
                else if (choiceNumber == 2)
                {
                    

                    Console.Write("Login   : ");
                    login.Email = Console.ReadLine();

                    Console.Write("Password: ");
                    login.Password = ReadPassword();

                    

                    if (registration.Email == login.Email || registration.Password == login.Password)
                    {
                        Console.WriteLine("Вы успешно вошли в свой аккаунт");
                        Console.ReadKey();
                        Console.Clear();
                    }
                    else
                    {
                        Console.WriteLine("Логин или пароль заданы неправильно");
                        Console.ReadKey();
                        Console.Clear();

                    }
                }
                else if (choiceNumber == 3)
                {
                  
                    break;
                    


                }
               
            }

            

           
           
        }
        public static string ReadPassword()
        {
            string password = "";
            ConsoleKeyInfo info = Console.ReadKey(true);
            while (info.Key != ConsoleKey.Enter)
            {
                if (info.Key != ConsoleKey.Backspace)
                {
                    Console.Write("*");
                    password += info.KeyChar;
                }
                else if (info.Key == ConsoleKey.Backspace)
                {
                    if (!string.IsNullOrEmpty(password))
                    {

                        password = password.Substring(0, password.Length - 1);
                        int pos = Console.CursorLeft;
                        Console.SetCursorPosition(pos - 1, Console.CursorTop);
                        Console.Write(" ");
                        Console.SetCursorPosition(pos - 1, Console.CursorTop);
                    }
                }
                info = Console.ReadKey(true);
            }
            Console.WriteLine();
            return password;
        }

    }
}
