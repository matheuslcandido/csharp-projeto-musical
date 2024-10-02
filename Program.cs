using System.Dynamic;

static void PrintPageTitle(string pageTitle, bool isMainPage = false) {
  Console.Clear();

  if (isMainPage == true) {
    Console.WriteLine(@"
░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░");
    Console.WriteLine("\n" + pageTitle);
  }
  
  if (isMainPage == false) {
    int pageTitleSize = pageTitle.Length;
    string asteriscos = string.Empty.PadRight(pageTitleSize, '*');
    
    Console.WriteLine(asteriscos);
    Console.WriteLine(pageTitle);
    Console.WriteLine($"{asteriscos}\n");
  }
}

void MainMenu() {
  PrintPageTitle("Boas vindas ao ScreenSound", true);

  Console.WriteLine("\nDigite 1 para registrar uma banda");
  Console.WriteLine("Digite 2 para listar todas as bandas");
  Console.WriteLine("Digite 3 para avaliar uma banda");
  Console.WriteLine("Digite 4 para mostrar a avaliação de uma banda");
  Console.WriteLine("Digite 5 para sair");

  Console.Write("\nDigite a sua opção: ");
  
  string selectedOption = Console.ReadLine()!;
  int numericSelectedOption = int.Parse(selectedOption);

  string selectMessage = "Você escolheu a opção ";

  switch (numericSelectedOption)
  {
    case 1: 
      CreateBand();
      break;
    case 2: 
      ListBands();
      break;
    case 3:
      AvaliateBand();
      break;
    case 4:
      ShowAvaliateBand();
      break;
    case 5: 
      Console.WriteLine("Programa finalizado!");
      break;
    default:
      Console.WriteLine("Opção inválida!");
      break;
  }
}

// List<string> bandsList = new List<string>();
Dictionary<string, List<int>> bands = new Dictionary<string, List<int>>();
bands.Add("Pink Floyd", new List<int>());
bands.Add("Beatles", new List<int> {10});
bands.Add("Linkin Park", new List<int> {10, 8, 9});

void CreateBand() {
  PrintPageTitle("Registro de bandas!");
  
  Console.Write("Digite o nome da banda que deseja registrar: ");
  
  string bandName = Console.ReadLine()!;
  bands.Add(bandName, new List<int>());
  
  Console.WriteLine($"A banda {bandName} foi registrada com sucesso");
  
  Thread.Sleep(2000);
  MainMenu();
}

void ListBands() {
  PrintPageTitle("Exibindo todas as bandas do sistema!");

  foreach (string band in bands.Keys) {
    Console.WriteLine($"Banda: {band}");
  }

  Console.WriteLine("\nDigite qualquer tecla para votlar ao menu principal");
  Console.ReadKey();
  MainMenu();
}

void AvaliateBand() {
  PrintPageTitle("Avaliar banda!");

  Console.Write("Digite o nome da banda que deseja avaliar: ");
  
  string bandName = Console.ReadLine()!;

  if (bands.ContainsKey(bandName)) {
    Console.Write($"Qual nota vecÊ deseja dar para a banda {bandName}: ");
    int nota = int.Parse(Console.ReadLine()!);

    bands[bandName].Add(nota);

    Console.WriteLine($"\nA nota {nota} foi registrada com sucesso para a banda {bandName}!");
    Thread.Sleep(4000);
  } else {
    Console.WriteLine($"\nA banda {bandName} não foi encontrada!");
    Console.WriteLine("\nDigite qualquer tecla para voltar ao menu principal");
    Console.ReadKey();
  }

  MainMenu();
}

void ShowAvaliateBand() {
  PrintPageTitle("Mostrar avaliação de uma banda!");

  Console.Write("Digite o nome da banda que deseja ver a avaliação: ");
  
  string bandName = Console.ReadLine()!;

  if(bands.ContainsKey(bandName)) {
    List<int> bandNotes = bands[bandName];
    double avgAvaliate = bandNotes.Average();

    Console.WriteLine($"A média de avaliação da banda {bandName} é {avgAvaliate}");
    Console.WriteLine("\nDigite qualquer tecla para voltar ao menu principal");
    Console.ReadKey();
  } else {
    Console.WriteLine($"\nA banda {bandName} não foi encontrada!");
    Console.WriteLine("\nDigite qualquer tecla para voltar ao menu principal");
    Console.ReadKey();
  }

  MainMenu();
}

MainMenu();