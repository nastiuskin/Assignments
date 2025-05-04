using Assignment_16;

Console.Write("Enter a string: ");
string input = Console.ReadLine() ?? "Hello";

var formatter = new TextFormatter(new PlainText(input));
var menu = new Menu(formatter);
menu.Show();