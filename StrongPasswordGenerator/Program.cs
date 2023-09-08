using StrongPasswordGenerator.Models;

Console.WriteLine("Bem vindo ao Gerador de Senhas Difíceis :)");
Console.WriteLine("Insira uma palavra chave para a senha ser gerada a partir dela...");

var passwordKey = Console.ReadLine();
var passwordMaker = new PasswordMaker();
var passwordResult = passwordMaker.GeneratePassword(passwordKey);

Console.WriteLine(passwordResult);
