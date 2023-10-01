using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.IO;
namespace CSCS1
{
    class SendProgram
    {
        static void Main(string[] args)
        {
            SendMessage();
        }
        private static void SendMessage()
        {
            string remoteAddress = "127.0.0.1";
            int port = 1001;
            Commands commands = new Commands();
            UdpClient sender = new UdpClient(0);
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(remoteAddress),
            port);
            Int16 x0, y0;
            Int16 x1, y1;
            Int16 radius;
            string text;
            string hexcolor;
            try
            {
                Console.WriteLine("Введiть «Допомога» або «?» для списку команд");
                while (true)
                {
                    Console.Write("Введiть комманду > ");
                    string commandText = Console.ReadLine();
                    byte[] commandbyte = new byte[1];
                    byte[] result = new byte[1] { 0 };
                    switch (commandText)
                    {
                        case "1":
                        case "очистити дисплей":
                            commandbyte[0] = 1;
                            hexcolor = ReadHexColor();
                            result = commands.ClearDisplayEncode(commandbyte[0], hexcolor);
                            sender.Send(result, result.Length, endPoint);
                            break;
                        case "2":
                        case "намалювати пiксель":
                            commandbyte[0] = 2;
                            x0 = ReadNumber("x", false);
                            y0 = ReadNumber("y", false);
                            hexcolor = ReadHexColor();
                            result = commands.PixelEncode(commandbyte[0], x0, y0, hexcolor);
                            sender.Send(result, result.Length, endPoint);
                            break;
                        case "3":
                        case "намалювати лiнiю":
                            commandbyte[0] = 3;
                            x0 = ReadNumber("x0", false);
                            y0 = ReadNumber("y0", false);
                            x1 = ReadNumber("x1", false);
                            y1 = ReadNumber("y1", false);
                            hexcolor = ReadHexColor();
                            result = commands.FourNumbersEncode(commandbyte[0], x0, y0, x1, y1, hexcolor);
                            sender.Send(result, result.Length, endPoint);
                            break;
                        case "4":
                        case "намалювати прямокутник":
                            commandbyte[0] = 4;
                            x0 = ReadNumber("x", false);
                            y0 = ReadNumber("y", false);
                            x1 = ReadNumber("ширина", true);
                            y1 = ReadNumber("висота", true);
                            hexcolor = ReadHexColor();
                            result = commands.FourNumbersEncode(commandbyte[0], x0, y0, x1, y1, hexcolor);
                            sender.Send(result, result.Length, endPoint);
                            break;
                        case "5":
                        case "зафарбувати прямокутник":
                            commandbyte[0] = 5;
                            x0 = ReadNumber("x", false);
                            y0 = ReadNumber("y", false);
                            x1 = ReadNumber("ширина", true);
                            y1 = ReadNumber("висота", true);
                            hexcolor = ReadHexColor();
                            result = commands.FourNumbersEncode(commandbyte[0], x0, y0, x1, y1, hexcolor);
                            sender.Send(result, result.Length, endPoint);
                            break;
                        case "6":
                        case "намалювати елiпс":
                            commandbyte[0] = 6;
                            x0 = ReadNumber("x", false);
                            y0 = ReadNumber("y", false);
                            x1 = ReadNumber("радiус x", true);
                            y1 = ReadNumber("радiус y", true);
                            hexcolor = ReadHexColor();
                            result = commands.FourNumbersEncode(commandbyte[0], x0, y0, x1, y1, hexcolor);
                            sender.Send(result, result.Length, endPoint);
                            break;
                        case "7":
                        case "зафарбувати елiпс":
                            commandbyte[0] = 7;
                            x0 = ReadNumber("x", false);
                            y0 = ReadNumber("y", false);
                            x1 = ReadNumber("радiус x", true);
                            y1 = ReadNumber("радiус y", true);
                            hexcolor = ReadHexColor();
                            result = commands.FourNumbersEncode(commandbyte[0], x0, y0, x1, y1, hexcolor);
                            sender.Send(result, result.Length, endPoint);
                            break;
                        case "8":
                        case "намалювати коло":
                            commandbyte[0] = 8;
                            x0 = ReadNumber("x", false);
                            y0 = ReadNumber("y", false);
                            radius = ReadNumber("радiус", true);
                            hexcolor = ReadHexColor();
                            result = commands.CircleEncode(commandbyte[0], x0, y0, radius, hexcolor);
                            sender.Send(result, result.Length, endPoint);
                            break;
                        case "9":
                        case "зафарбувати коло":
                            commandbyte[0] = 9;
                            x0 = ReadNumber("x", false);
                            y0 = ReadNumber("y", false);
                            radius = ReadNumber("радiус", true);
                            hexcolor = ReadHexColor();
                            result = commands.CircleEncode(commandbyte[0], x0, y0, radius, hexcolor);
                            sender.Send(result, result.Length, endPoint);
                            break;
                        case "10":
                        case "намалювати закруглений прямокутник":
                            commandbyte[0] = 10;
                            x0 = ReadNumber("x", false);
                            y0 = ReadNumber("y", false);
                            x1 = ReadNumber("ширина", true);
                            y1 = ReadNumber("висота", true);
                            radius = ReadNumber("радiус", true);
                            hexcolor = ReadHexColor();
                            result = commands.RoundedRectEncode(commandbyte[0], x0, y0, x1, y1, radius, hexcolor);
                            sender.Send(result, result.Length, endPoint);
                            break;
                        case "11":
                        case "зафарбувати закруглений прямокутник":
                            commandbyte[0] = 11;
                            x0 = ReadNumber("x", false);
                            y0 = ReadNumber("y", false);
                            x1 = ReadNumber("ширина", true);
                            y1 = ReadNumber("висота", true);
                            radius = ReadNumber("радiус", true);
                            hexcolor = ReadHexColor();
                            result = commands.RoundedRectEncode(commandbyte[0], x0, y0, x1, y1, radius, hexcolor);
                            sender.Send(result, result.Length, endPoint);
                            break;
                        case "12":
                        case "намалювати текст":
                            commandbyte[0] = 12;
                            x0 = ReadNumber("x", false);
                            y0 = ReadNumber("y", false);
                            hexcolor = ReadHexColor();
                            x1 = ReadNumber("номер шрифту", true);
                            Console.Write("Введiть текст > ");
                            text = Console.ReadLine();
                            y1 = Convert.ToInt16(text.Length);
                            result = commands.TextEncode(commandbyte[0], x0, y0, hexcolor, x1, y1, text);
                            sender.Send(result, result.Length, endPoint);
                            break;
                        case "13":
                        case "намалювати зображення":
                            commandbyte[0] = 13;
                            x0 = ReadNumber("x", false);
                            y0 = ReadNumber("y", false);
                            x1 = ReadNumber("ширина", true);
                            y1 = ReadNumber("висота", true);
                            text = ReadPath();
                            result = commands.ImageEncode(commandbyte[0], x0, y0, x1, y1, text);
                            sender.Send(result, result.Length, endPoint);
                            break;
                        case "14":
                        case "встановити орiєнтацiю":
                            commandbyte[0] = 14;
                            x0 = ReadNumber("кут обертання", false);
                            result = commandbyte.Concat(BitConverter.GetBytes(x0)).ToArray();
                            sender.Send(result, result.Length, endPoint);
                            break;
                        case "15":
                        case "отримати ширину":
                            commandbyte[0] = 15;
                            sender.Send(commandbyte, commandbyte.Length, endPoint);
                            RecieveMessage(sender, endPoint);
                            break;
                        case "16":
                        case "отримати висоту":
                            commandbyte[0] = 16;
                            sender.Send(commandbyte, commandbyte.Length, endPoint);
                            RecieveMessage(sender, endPoint);
                            break;
                        case "17":
                        case "встановити товщину олiвця":
                            commandbyte[0] = 17;
                            x0 = ReadNumber("товщина", true);
                            result = commandbyte.Concat(BitConverter.GetBytes(x0)).ToArray();
                            sender.Send(result, result.Length, endPoint);
                            break;

                        case "Допомога":
                        case "?":
                            Console.WriteLine("\nКоманди:");
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine(" 1. очистити дисплей");
                            Console.WriteLine(" 2. намалювати пiксель");
                            Console.WriteLine(" 3. намалювати лiнiю");
                            Console.WriteLine(" 4. намалювати прямокутник");
                            Console.WriteLine(" 5. зафарбувати прямокутник");
                            Console.WriteLine(" 6. намалювати елiпс");
                            Console.WriteLine(" 7. зафарбувати елiпс");
                            Console.WriteLine(" 8. намалювати коло");
                            Console.WriteLine(" 9. зафарбувати коло");
                            Console.WriteLine(" 10. намалювати закруглений прямокутник");
                            Console.WriteLine(" 11. зафарбувати закруглений прямокутник");
                            Console.WriteLine(" 12. намалювати текст");
                            Console.WriteLine(" 13. намалювати зображення");
                            Console.WriteLine(" 14. встановити орiєнтацiю");
                            Console.WriteLine(" 15. отримати ширину");
                            Console.WriteLine(" 16. отримати висоту");
                            Console.ResetColor();
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Помилка! Невiдома операцiя! Спробуйте ще раз.");
                             Console.ResetColor();
                            break;
                    }
                    Console.WriteLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
            finally
            {
                sender.Close();
            }
        }
        public static bool IsStringInHex(string text)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(text, @"\A\b[0-9afA-F]+\b\Z");
        }
        private static string ReadHexColor()
        {
            string str;
            while (true)
            {
                Console.Write("Введiть колiр RGB565 > ");
                str = Console.ReadLine();
                if (IsStringInHex(str) && str.Length <= 4)
                {
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Помилка! Данi не є шiстнадцятковими! Спробуйте знову.");
                    Console.ResetColor();
                }
            }
            return str;
        }
        private static Int16 ReadNumber(string text, bool onlyPositive = false)
        {
            string str;
            Int16 number;
            while (true)
            {
                Console.Write($"Введiть {text} > ");
                str = Console.ReadLine();
                try
                {
                    number = Int16.Parse(str);
                    if (onlyPositive)
                    {
                        if (number < 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Помилка! Поганi данi! (дiапазон вiд 0 до 32767) Спробуйте ще раз.");Console.ResetColor();
                        }
                        else { break; }
                    }
                    else { break; }
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Помилка! Поганi данi! (дiапазон вiд -32768 до 32767) Спробуйте ще раз.");
                    Console.ResetColor();
                }
            }
            return Convert.ToInt16(str);
        }
        private static string ReadPath()
        {
            string str;
            while (true)
            {
                Console.Write("Введiть шлях > ");
                str = Console.ReadLine();
                if (File.Exists(str) && IsImage(str))
                {
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Помилка! Файл не iснує! Спробуйте знову.");
                    Console.ResetColor();
                }
            }
            return @"" + str;
        }
        public static bool IsImage(string path)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(path,
            @"^.*\.(jpg|JPG|gif|GIF|png|PNG)$");
        }
        public static void RecieveMessage(UdpClient sender, IPEndPoint endPoint)
        {
            byte[] data = sender.Receive(ref endPoint);
            Console.WriteLine($"Recieved value: {BitConverter.ToInt16(data, 0)}");
        }
    }
}